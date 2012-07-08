using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Estime.Web.App_Start;
using Estime.Web.Controllers;
using Estime.Web.Infrastructure.Mapping;
using Estime.Web.Infrastructure.Persistence;
using NHibernate;

namespace Estime.Web
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			ValueProviderFactories.Factories.Add(new CookieValueProviderFactory());

			initializeSessionFactory();

			AutoMapperConfiguration.Configure();
		}

		public static ISessionFactory SessionFactory { get; private set; }

		private static void initializeSessionFactory()
		{
			SessionFactory = SessionFactoryProvider.BuildSessionFactory();

			//HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
		}
	}
}