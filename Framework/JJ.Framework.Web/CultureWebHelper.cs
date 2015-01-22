using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace JJ.Framework.Web
{
    public static class CultureWebHelper
    {
        private const string CUTURE_NAME_COOKIE_KEY = "cultureName70bba865-c3b8-407e-a405-1a3eb014253d";
        private const string ACCEPT_LANGUAGE_HEADER_KEY = "Accept-Language";

        public static void SetThreadCultureByHttpHeaderOrCookie(HttpContextBase httpContext, string defaultCultureName = "en-US")
        {
            if (httpContext == null) throw new NullException(() => httpContext);

            string cultureName = CookieHelper.GetCookieValue(httpContext.Request, CUTURE_NAME_COOKIE_KEY);
            if (String.IsNullOrEmpty(cultureName))
            {
                string header = httpContext.Request.Headers[ACCEPT_LANGUAGE_HEADER_KEY];
                if (!String.IsNullOrEmpty(header))
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
