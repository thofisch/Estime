using System.Collections.Generic;
using Estime.Web.Models;
using Estime.Web.ViewModels;
using NHibernate.Transform;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public class TaskListQuery : Query<IEnumerable<TaskListViewModel>>
	{
		private readonly TaskStatus _taskStatus;
		private readonly bool _standardProject;

		public TaskListQuery(TaskStatus taskStatus, bool standardProject)
		{
			_taskStatus = taskStatus;
			_standardProject = standardProject;
		}

		public override IEnumerable<TaskListViewModel> Execute()
		{
			Consultant consultantAlias = null;
			Project projectAlias = null;
			Client clientAlias = null;
			TaskListViewModel alias = null;

			var tasks = Session.QueryOver<Task>()
				.JoinAlias(x => x.Consultant, () => consultantAlias)
				.JoinAlias(x => x.Project, () => projectAlias)
				.JoinAlias(x => x.Project.Client, () => clientAlias)
				.Where(x => x.Status==_taskStatus)
				.And(() => projectAlias.StandardProject==_standardProject)
				.SelectList(list => list
					.Select(x => x.Id).WithAlias(() => alias.Id)
					.Select(() => consultantAlias.Name).WithAlias(() => alias.ConsultantName)
					.Select(() => projectAlias.Name).WithAlias(() => alias.ProjectName)
					.Select(() => clientAlias.Name).WithAlias(() => alias.ClientName)
					.Select(x => x.Timestamp).WithAlias(() => alias.Timestamp)
					.Select(x => x.DurationInMinutes).WithAlias(() => alias.DurationInMinutes)
					.Select(x => x.Mileage).WithAlias(() => alias.Mileage)
					.Select(x => x.Description).WithAlias(() => alias.Description)
					.Select(() => projectAlias.StandardProject).WithAlias(() => alias.StandardTask)
				)
				.OrderBy(x => x.Timestamp).Desc
				.TransformUsing(Transformers.AliasToBean<TaskListViewModel>())
				.List<TaskListViewModel>();

			return tasks;
		}
	}
}