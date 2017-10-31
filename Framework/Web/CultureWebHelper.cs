using JJ.Framework.Exceptions;
using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace JJ.Framework.Web
{
    public static class CultureWebHelper
    {
        private const string CUTURE_NAME_COOKIE_KEY = "cultureName70bba865c3b8407ea405-1a3eb014253d";
        private const string ACCEPT_LANGUAGE_HEADER_KEY = "Accept-Language";

        public static void SetThreadCultureByHttpHeaderOrCookie(HttpContextBase httpContext, string defaultCultureName = "en-US")
        {
            if (httpContext == null) throw new NullException(() => httpContext);

            string cultureName = CookieHelper.TryGetCookieValue(httpContext.Request, CUTURE_NAME_COOKIE_KEY);
            if (string.IsNullOrEmpty(cultureName))
            {
                string header = httpContext.Request.Headers[ACCEPT_LANGUAGE_HEADER_KEY];
                if (!string.IsNullOrEmpty(header))
                {
                    int pos = header.IndexOf(',');
                    if (pos != -1)
                    {
                        cultureName = header.Substring(0, pos);
                    }
                    else
                    {
                        cultureName = header;
                    }
                }
                else
                {
                    cultureName = defaultCultureName;
                }
            }

            CultureInfo cultureInfo = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public static void SetCultureCookie(HttpContextBase httpContext, string cultureName)
        {
            CookieHelper.SetCookieValue(httpContext.Response, CUTURE_NAME_COOKIE_KEY, cultureName);
        }
    }
}
