using System.Web.Mvc;
using System.Web.Routing;

namespace Estime.Web.App_Start
{
	public static class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new {controller = "Task", action = "New", id = UrlParameter.Optional} // Parameter defaults
				);
		}
	}
}