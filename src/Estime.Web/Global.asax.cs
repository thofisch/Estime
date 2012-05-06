using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Estime.Web.Controllers;
using Estime.Web.Infrastructure.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;

namespace Estime.Web
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new SessionActionFilterAttribute());
			//filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new {controller = "Task", action = "New", id = UrlParameter.Optional} // Parameter defaults
				);
		}

		protected void Application_Start()
		{
			AutoMapperConfiguration.Configure();

			initializeSessionFactory();

			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			ValueProviderFactories.Factories.Add(new CookieValueProviderFactory());
		}

		public static ISessionFactory SessionFactory { get; private set; }

		private static void initializeSessionFactory()
		{
			var databaseConfig = MsSqlConfiguration.MsSql2008.FormatSql().ConnectionString(x => x.FromConnectionStringWithKey("Database"));
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

			SessionFactory = configuration.BuildSessionFactory();

			HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
		}
	}
}