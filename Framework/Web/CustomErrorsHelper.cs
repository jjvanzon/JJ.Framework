using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using JetBrains.Annotations;

namespace JJ.Framework.Web
{
    [PublicAPI]
    public static class CustomErrorsHelper
    {
        /// <summary>
        /// Note that even for HTTP statuses that indicate success, it will return a default error redirect.
        /// It assumes there was an error.
        /// </summary>
        public static string GetErrorRedirectUrl(int httpStatusCode)
        {
            if (_httpStatusCode_To_RedirectUrl_Dictionary.TryGetValue(httpStatusCode, out string redirectUrl))
            {
                return redirectUrl;
            }

            return _defaultErrorRedirectUrl;
        }

        private static Dictionary<int, string> _httpStatusCode_To_RedirectUrl_Dictionary = Create_HttpStatusCode_To_RedirectUrl_Dictionary();
        private static string _defaultErrorRedirectUrl = GetDefaultErrorRedirectUrl();

        private static Dictionary<int, string> Create_HttpStatusCode_To_RedirectUrl_Dictionary()
        {
            CustomErrorCollection customErrorCollection = GetCustomErrorCollection();
            Dictionary<int, string> dictionary = customErrorCollection.AllKeys
                                                                      .ToArray()
                                                                      .Select(x => customErrorCollection[x])
                                                                      .ToDictionary(x => x.StatusCode, x => x.Redirect);
            return dictionary;
        }

        private static string GetDefaultErrorRedirectUrl()
        {
            CustomErrorsSection customErrorSection = GetCustomErrorsSection();
            string defaultRedirectUrl = customErrorSection.DefaultRedirect;
            return defaultRedirectUrl;
        }

        private static CustomErrorCollection GetCustomErrorCollection()
        {
            CustomErrorsSection customErrorSection = GetCustomErrorsSection();
            CustomErrorCollection customErrorCollection = customErrorSection.Errors;
            return customErrorCollection;
        }

        private static CustomErrorsSection GetCustomErrorsSection()
        {
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
            var customErrorSection = (CustomErrorsSection)configuration.GetSection("system.web/customErrors");
            return customErrorSection;
        }
    }
}
