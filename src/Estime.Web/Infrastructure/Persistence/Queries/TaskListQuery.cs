using System.Collections.Generic;
using Estime.Web.Models;
using Estime.Web.ViewModels;
using NHibernate.Transform;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public class TaskListQuery : Query<IEnumerable<TaskListViewModel>>
	{
		private readonly TaskStatus _taskStatus;

		public TaskListQuery(TaskStatus taskStatus)
		{
			_taskStatus = taskStatus;
		}

		public override IEnumerable<TaskListViewModel> Execute()
		{
			Consultant consultantAlias = null;
			Client clientAlias = null;
			TaskListViewModel alias = null;

			var tasks = Session.QueryOver<Task>()
				.JoinAlias(x => x.Consultant, () => consultantAlias)
				.JoinAlias(x => x.Client, () => clientAlias)
				.Where(x => x.Status==_taskStatus)
				.SelectList(list => list
					.Select(x => x.Id).WithAlias(() => alias.Id)
					.Select(() => consultantAlias.Name).WithAlias(() => alias.ConsultantName)
					.Select(() => clientAlias.Name).WithAlias(() => alias.ClientName)
					.Select(x => x.Timestamp).WithAlias(() => alias.Timestamp)
					.Select(x => x.DurationInMinutes).WithAlias(() => alias.DurationInMinutes)
					.Select(x => x.Type).WithAlias(() => alias.Type)
					.Select(x => x.Mileage).WithAlias(() => alias.Mileage)
					.Select(x => x.Description).WithAlias(() => alias.Description)
				)
				.OrderBy(x => x.Timestamp).Desc
				.TransformUsing(Transformers.AliasToBean<TaskListViewModel>())
				.List<TaskListViewModel>();

			return tasks;
		}
	}
}