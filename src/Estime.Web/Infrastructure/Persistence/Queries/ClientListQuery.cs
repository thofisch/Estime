using System.Collections.Generic;
using Estime.Web.Models;
using Estime.Web.ViewModels;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Estime.Web.Infrastructure.Persistence.Queries
{
	public class ClientListQuery : Query<IEnumerable<ClientListViewModel>>
	{
		public override IEnumerable<ClientListViewModel> Execute()
		{
			ClientListViewModel alias = null;
			Client client = null;

			var projectCountSubQuery = QueryOver.Of<Project>()
				.Where(x => x.Client.Id==client.Id)
				.ToRowCountQuery();

			var skuSubQuery = QueryOver.Of<Project>()
				.Where(x => x.Client.Id==client.Id)
				.And(x => x.StandardProject)
				.Select(x => x.Sku);

			var clients = Session.QueryOver(() => client)
				.SelectList(list => list
					.Select(x => x.Id).WithAlias(() => alias.Id)
					.Select(x => x.Name).WithAlias(() => alias.Name)
					.SelectSubQuery(skuSubQuery).WithAlias(() => alias.Sku)
					.SelectSubQuery(projectCountSubQuery).WithAlias(() => alias.NumberOfProjects)
				)
				.OrderBy(x => x.Name).Asc
				.TransformUsing(Transformers.AliasToBean<ClientListViewModel>())
				.List<ClientListViewModel>();

			return clients;
		}
	}
}