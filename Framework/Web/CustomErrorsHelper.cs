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

        private static readonly Dictionary<int, string> _httpStatusCode_To_RedirectUrl_Dictionary = Create_HttpStatusCode_To_RedirectUrl_Dictionary();
        private static readonly string _defaultErrorRedirectUrl = GetDefaultErrorRedirectUrl();

        private static Dictionary<int, string> Create_HttpStatusCode_To_RedirectUrl_Dictionary()
        {
            CustomErrorsSection customErrorSection = GetCustomErrorsSection();

            Dictionary<int, string> dictionary = customErrorSection.Errors
                                                                   .Cast<CustomError>()
                                                                   .ToDictionary(x => x.StatusCode, x => x.Redirect);
            return dictionary;
        }

        private static string GetDefaultErrorRedirectUrl()
        {
            CustomErrorsSection customErrorSection = GetCustomErrorsSection();
            return customErrorSection.DefaultRedirect;
        }

        private static CustomErrorsSection GetCustomErrorsSection()
        {
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
            var customErrorSection = (CustomErrorsSection)configuration.GetSection("system.web/customErrors");
            return customErrorSection;
        }
    }
}
