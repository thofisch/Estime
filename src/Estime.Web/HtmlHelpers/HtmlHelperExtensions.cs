using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Estime.Web.HtmlHelpers
{
	public static class HtmlHelperExtensions
	{
		public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
		{
			var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
			var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
			if( actionName==currentAction && controllerName==currentController )
			{
				return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new {@class = "active"});
			}
			return htmlHelper.ActionLink(linkText, actionName, controllerName);
		}
	}
}