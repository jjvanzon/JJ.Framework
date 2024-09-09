using JJ.Framework.Exceptions.Basic;
using Microsoft.AspNetCore.Http;

namespace JJ.Framework.Web
{
    public static class CookieHelper
    {
        private const int DEFAULT_COOKIE_EXPIRATION_YEARS = 20;

        public static string TryGetCookieValue(HttpRequest request, string cookieName)
        {
            if (request == null) throw new NullException(() => request);

            string cookie = request.Cookies[cookieName];

            return cookie;
        }

        public static void SetCookieValue(HttpResponse response, string cookieName, string value)
        {
            if (response == null) throw new NullException(() => response);

            response.Cookies.Delete(cookieName);

            response.Cookies.Append(
                cookieName, value, 
                new CookieOptions { Expires = DateTime.Now.AddYears(DEFAULT_COOKIE_EXPIRATION_YEARS) });
        }
    }
}