using System.Collections.Generic;
using Estime.Web.Models;
using Estime.Web.ViewModels;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public class TaskQuery : Query<IEnumerable<TaskListViewModel>>
	{
		private readonly TaskQueryInput _input;

		public TaskQuery(TaskQueryInput input)
		{
			_input = input;
		}

		public override IEnumerable<TaskListViewModel> Execute()
		{
			Consultant consultantAlias = null;
			Project projectAlias = null;
			Client clientAlias = null;
			TaskListViewModel alias = null;

			var query = Session.QueryOver<Task>()
				.JoinAlias(x => x.Consultant, () => consultantAlias)
				.JoinAlias(x => x.Project, () => projectAlias)
				.JoinAlias(x => x.Project.Client, () => clientAlias);

			if( _input.ConsultantId.HasValue )
			{
				query.Where(x => x.Consultant.Id==_input.ConsultantId.Value);
			}
			if( _input.ProjectId.HasValue )
			{
				query.Where(x => x.Project.Id==_input.ProjectId.Value);
			}
			if( _input.Status.HasValue )
			{
				query.Where(x => x.Status==_input.Status.Value);
			}
			if( _input.From.HasValue )
			{
				query.Where(x => x.Timestamp>=_input.From.Value);
			}
			if( _input.Until.HasValue )
			{
				query.Where(x => x.Timestamp<=_input.Until.Value);
			}
			if( !string.IsNullOrWhiteSpace(_input.Text) )
			{
				query.WhereRestrictionOn(x => x.Description).IsInsensitiveLike(_input.Text, MatchMode.Anywhere);
			}

			var tasks = query
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