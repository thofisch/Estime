using System.Web.Mvc;
using Estime.Web.Controllers;

namespace Estime.Web.App_Start
{
	public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new SessionActionFilterAttribute());
			//filters.Add(new HandleErrorAttribute());
		}
	}
}