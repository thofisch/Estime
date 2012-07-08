using Estime.Web.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;

namespace Estime.Web.Infrastructure.Persistence
{
	public static class SessionFactoryProvider
	{
		public static ISessionFactory BuildSessionFactory()
		{
			var databaseConfig = MsSqlConfiguration
				.MsSql2008
				.FormatSql()
				.ConnectionString(x => x.FromConnectionStringWithKey("Database"));

			return Fluently.Configure()
				.Database(databaseConfig)
				.Mappings(cfg =>
				{
					var mappings = cfg.FluentMappings;
					mappings.AddFromAssemblyOf<Task>();
					mappings.Conventions.Add(PrimaryKey.Name.Is(x => "Id"));
					mappings.Conventions.Add(ForeignKey.EndsWith("Id"));
				})
				.BuildSessionFactory();
		}
	}
}