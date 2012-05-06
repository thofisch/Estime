using Estime.Web.Models;
using FluentNHibernate.Mapping;

namespace Estime.Web.Infrastructure.Persistence.Model
{
	public sealed class ClientMap : ClassMap<Client>
	{
		public ClientMap()
		{
			Id(x => x.Id).GeneratedBy.GuidComb();
			Map(x => x.Name).Not.Nullable().Length(255);
			HasMany(x => x.Projects)
				.Inverse()
				.AsBag();
		}
	}
}