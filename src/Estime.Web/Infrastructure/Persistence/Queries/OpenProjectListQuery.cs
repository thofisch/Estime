using System.Collections.Generic;
using Estime.Web.Models;
using Estime.Web.ViewModels;
using NHibernate.Transform;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public class OpenProjectListQuery : Query<IEnumerable<OpenProjectListViewModel>>
	{
		public override IEnumerable<OpenProjectListViewModel> Execute()
		{
			Project project = null;
			Client client = null;
			TaskWare ware = null;
			OpenProjectListViewModel alias = null;

			var tasks = Session.QueryOver<Task>()
				.JoinAlias(x => x.Project, () => project)
				.JoinAlias(x => x.Project.Client, () => client)
				.Left.JoinAlias(x => x.Wares, () => ware)
				.Where(x => x.Status==TaskStatus.Open)
				.AndNot(() => project.StandardProject)
				.SelectList(list => list
					.SelectGroup(() => project.Id).WithAlias(() => alias.ProjectId)
					.SelectGroup(() => project.Name).WithAlias(() => alias.ProjectName)
					.SelectGroup(() => client.Name).WithAlias(() => alias.ClientName)
					.SelectSum(x => x.DurationInMinutes).WithAlias(() => alias.TotalDurationInMinutes)
					.SelectSum(() => ware.Quantity).WithAlias(() => alias.TotalNumberOfWares)
				)
				.TransformUsing(Transformers.AliasToBean<OpenProjectListViewModel>())
				.List<OpenProjectListViewModel>();

			return tasks;
		}
	}
}