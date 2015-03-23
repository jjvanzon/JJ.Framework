using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JJ.Framework.Web
{
    public static class CookieHelper
    {
        private const int DEFAULT_COOKIE_EXPERIATION_YEARS = 20;

        public static string TryGetCookieValue(HttpRequestBase request, string cookieName)
        {
            if (request == null) throw new NullException(() => request);

            HttpCookie cookie = request.Cookies[cookieName];
            if (cookie != null)
            {
                return cookie.Value;
            }
            return null;
        }

        public static void SetCookieValue(HttpResponseBase response, string cookieName, string value)
        {
            if (response == null) throw new NullException(() => response);

            response.Cookies.Remove(cookieName);
            var cookie = new HttpCookie(cookieName, value);
            cookie.Expires = DateTime.Now.AddYears(DEFAULT_COOKIE_EXPERIATION_YEARS);
            response.Cookies.Add(cookie);
        }
    }
}