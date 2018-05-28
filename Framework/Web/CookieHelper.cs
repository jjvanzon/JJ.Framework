using System;
using System.Web;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Web
{
	public static class CookieHelper
	{
		private const int DEFAULT_COOKIE_EXPERIATION_YEARS = 20;

		public static string TryGetCookieValue(HttpRequestBase request, string cookieName)
		{
			if (request == null) throw new NullException(() => request);

			HttpCookie cookie = request.Cookies[cookieName];

			return cookie?.Value;
		}

		public static void SetCookieValue(HttpResponseBase response, string cookieName, string value)
		{
			if (response == null) throw new NullException(() => response);

			response.Cookies.Remove(cookieName);
			var cookie = new HttpCookie(cookieName, value)
			{
				Expires = DateTime.Now.AddYears(DEFAULT_COOKIE_EXPERIATION_YEARS)
			};
			response.Cookies.Add(cookie);
		}
	}
}