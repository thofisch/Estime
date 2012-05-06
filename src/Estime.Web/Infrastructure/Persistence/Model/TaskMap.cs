using Estime.Web.Models;
using FluentNHibernate.Mapping;

namespace Estime.Web.Infrastructure.Persistence.Model
{
	public sealed class TaskMap : ClassMap<Task>
	{
		public TaskMap()
		{
			Id(x => x.Id).GeneratedBy.GuidComb();
			References(x => x.Project).Not.Nullable();
			References(x => x.Consultant).Not.Nullable();
			Map(x => x.Timestamp).Not.Nullable();
			Map(x => x.DurationInMinutes).Not.Nullable();
			Map(x => x.Description).Not.Nullable().Length(8000);
			Map(x => x.Mileage).Not.Nullable();
			Map(x => x.Status).Not.Nullable().CustomType<TaskStatus>();
			HasMany(x => x.Wares).Component(c =>
			{
				c.References(x => x.Ware).Not.Nullable();
				c.Map(x => x.Quantity).Not.Nullable();
			}).Table("TaskWare");
			Map(x => x.CreatedAt).Not.Nullable().Not.Update();
			Map(x => x.CreatedBy).Not.Nullable().Not.Update();
			Map(x => x.UpdatedAt).Not.Nullable();
			Map(x => x.UpdatedBy).Not.Nullable();
		}
	}
}