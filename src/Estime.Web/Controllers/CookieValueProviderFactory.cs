using System.Globalization;
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
}