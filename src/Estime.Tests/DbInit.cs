using Estime.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Estime.Tests
{
	public class DbInit
	{
		[Test]
		public void InitializeSessionFactory()
		{
			var databaseConfig = MsSqlConfiguration.MsSql2008.FormatSql().ConnectionString(x => x.Is(@"Data Source=.\SQLEXPRESS;Initial Catalog=Exato;User ID=Exato;Password=Abcd_1234"));
			var configuration = Fluently.Configure()
				.Database(databaseConfig)
				.Mappings(cfg =>
				{
					var mappings = cfg.FluentMappings;
					mappings.AddFromAssemblyOf<MvcApplication>();
					mappings.Conventions.Add(PrimaryKey.Name.Is(x => "Id"));
					mappings.Conventions.Add(ForeignKey.EndsWith("Id"));
				})
				.BuildConfiguration();

			new SchemaExport(configuration).Create(true, false);// .Execute(true, true, false);
		}
	}
}