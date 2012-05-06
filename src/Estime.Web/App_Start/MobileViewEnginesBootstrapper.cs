using System.Web.Mvc;
using Microsoft.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Estime.Web.App_Start.MobileViewEngines), "Start")]

namespace Estime.Web.App_Start
{
	public static class MobileViewEngines
	{
		public static void Start()
		{
			ViewEngines.Engines.Insert(0, new MobileCapableRazorViewEngine());
		}
	}
}