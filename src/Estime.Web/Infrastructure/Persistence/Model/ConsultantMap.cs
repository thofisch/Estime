using Estime.Web.Models;
using FluentNHibernate.Mapping;

namespace Estime.Web.Infrastructure.Persistence.Model
{
	public sealed class ConsultantMap : ClassMap<Consultant>
	{
		public ConsultantMap()
		{
			Id(x => x.Id).GeneratedBy.GuidComb();
			Map(x => x.Sku).Not.Nullable().Length(50).Unique();
			Map(x => x.Name).Not.Nullable().Length(255);
		}
	}
}