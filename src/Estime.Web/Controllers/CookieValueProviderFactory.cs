using System;
using System.Globalization;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Estime.Web.Controllers
{
	public class CookieValueProviderFactory : ValueProviderFactory
	{
		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			return new CookieValueProvider(controllerContext.HttpContext.Request.Cookies);
		}

		private class CookieValueProvider : IValueProvider
		{
			private readonly HttpCookieCollection _cookieCollection;

			public CookieValueProvider(HttpCookieCollection cookieCollection)
			{
				_cookieCollection = cookieCollection;
			}

			public bool ContainsPrefix(string prefix)
			{
				return _cookieCollection[prefix]!=null;
			}

			public ValueProviderResult GetValue(string key)
			{
				var cookie = _cookieCollection[key];
				if( cookie!=null )
				{
					return new ValueProviderResult(cookie.Value, cookie.Value, CultureInfo.CurrentUICulture);
				}
				return null;
			}
		}
	}

	public class CurrentUserValueProviderFactory : ValueProviderFactory
	{
		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			return new CurrentUserValueProvider(controllerContext.HttpContext.User.Identity);
		}

		private class CurrentUserValueProvider : IValueProvider
		{
			private readonly IIdentity _identity;

			public CurrentUserValueProvider(IIdentity identity)
			{
				_identity = identity;
			}

			public bool ContainsPrefix(string prefix)
			{
				return prefix.Equals("CurrentUser", StringComparison.OrdinalIgnoreCase);
			}

			public ValueProviderResult GetValue(string key)
			{
				if( !ContainsPrefix(key) )
				{
					return null;
				}

				var user = _identity.Name;

				return new ValueProviderResult(user, user, CultureInfo.CurrentCulture);
			}
		}
	}
}