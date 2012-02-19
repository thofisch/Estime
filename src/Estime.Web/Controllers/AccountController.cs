using System.Web.Mvc;
using System.Web.Security;
using Estime.Web.Models;

namespace Estime.Web.Controllers
{
	public class AccountController : SessionController
	{
		public ActionResult LogOn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LogOn(LogOnModel model, string returnUrl)
		{
			if( ModelState.IsValid )
			{
				if( Membership.ValidateUser(model.UserName, model.Password) )
				{
					FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
					if( Url.IsLocalUrl(returnUrl) && returnUrl.Length>1 && returnUrl.StartsWith("/")
						&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\") )
					{
						return Redirect(returnUrl);
					}
					return RedirectToAction("Index", "Task");
				}
				ModelState.AddModelError("", "The user name or password provided is incorrect.");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();

			return RedirectToAction("Index", "Task");
		}
	}
}