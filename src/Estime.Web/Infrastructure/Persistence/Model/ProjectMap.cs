using Estime.Web.Models;
using FluentNHibernate.Mapping;

namespace Estime.Web.Infrastructure.Persistence.Model
{
	public sealed class ProjectMap : ClassMap<Project>
	{
		public ProjectMap()
		{
			Id(x => x.Id).GeneratedBy.GuidComb();
			Map(x => x.Sku).Not.Nullable().Length(50).Unique();
			References(x => x.Client).Not.Nullable();
			Map(x => x.Name).Not.Nullable().Length(255);
			Map(x => x.StandardProject).Not.Nullable();
			Map(x => x.DefaultTaskStatus).Not.Nullable().CustomType<TaskStatus>();
		}
	}
}