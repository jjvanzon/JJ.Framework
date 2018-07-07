using System;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using JJ.Framework.Collections;
using JJ.Framework.Exceptions.Aggregates;
using JJ.Framework.Web;

namespace JJ.Framework.Mvc
{
    /// <summary>
    /// Upon exceptions this will use some of the things you can specify in the customErrors config element,
    /// to redirect to the right error page. Some common exceptions are handled to redirect to a specific page
    /// related to an HTTP status code in the config file.
    /// (I heard this is supposed to go automatically somehow, but I could not get it to work and went for this alternative.)
    /// </summary>
    public class BasicHandleErrorAttribute : HandleErrorAttribute
    {
        private readonly string _returnParameterName;

        /// <param name="returnParameterName">
        /// This URL parameter will be added to the URL redirected to in case of an error.
        /// If for instance, you redirect to a login page upon an authentication error, you may want to pass the original page URL
        /// to it.
        /// For debugging purposes this it is also very handy to have the original URL of the page that went error.
        /// </param>
        public BasicHandleErrorAttribute(string returnParameterName = "ret") => _returnParameterName = returnParameterName;

        public override void OnException(ExceptionContext filterContext)
        {
            // Try Get HttpStatusCode
            int? httpErrorStatusCode = null;

            switch (filterContext.Exception)
            {
                case AuthenticationException _:
                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHENTICATED_401;
                    break;

                case UnauthorizedAccessException _:
                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHORIZED_403;
                    break;

                case NotFoundException _:
                    httpErrorStatusCode = HttpStatusCodes.NOT_FOUND_404;
                    break;

                case HttpException httpException:
                    httpErrorStatusCode = httpException.GetHttpCode();
                    break;
            }

            if (!httpErrorStatusCode.HasValue)
            {
                base.OnException(filterContext);
                return;
            }

            // Try Get RedirectUrl
            string redirectUrl = CustomErrorsHelper.GetErrorRedirectUrl(httpErrorStatusCode.Value);

            if (string.IsNullOrWhiteSpace(redirectUrl))
            {
                base.OnException(filterContext);
                return;
            }

            // Try Add ReturnParameter
            if (!string.IsNullOrWhiteSpace(_returnParameterName))
            {
                // Check if the current URL (minus the return URL) is already the redirect URL.
                // Then you are just redirecting to the same page again and again.
                // This is most common in Login views.
                // If you do not check, you will just get ret upon ret upon ret just login URL's stacked on top of eachother.

                string currentUrl = filterContext.HttpContext.Request.RawUrl;
                string currentUrlMinusReturnUrl = RemoveReturnUrl(currentUrl);

                if (string.Equals(redirectUrl, currentUrlMinusReturnUrl))
                {
                    redirectUrl = currentUrl;
                }
                else
                {
                    redirectUrl = UrlBuilder.AddUrlParameter(redirectUrl, _returnParameterName, currentUrl);
                }
            }

            // Redirect
            filterContext.HttpContext.Response.StatusCode = httpErrorStatusCode.Value;
            filterContext.HttpContext.Response.Redirect(redirectUrl);
            filterContext.ExceptionHandled = true;
        }

        private string RemoveReturnUrl(string url)
        {
            UrlInfo urlInfo = new UrlParser().Parse(url);

            urlInfo.Parameters = urlInfo.Parameters.Except(x => string.Equals(x.Name, _returnParameterName)).ToArray();

            string urlMinusReturnUrl = UrlBuilder.BuildUrl(urlInfo);

            // HACK: UrlBuilder has this minor bug.
            if (!urlMinusReturnUrl.StartsWith("/"))
            {
                return '/' + urlMinusReturnUrl;
            }

            return urlMinusReturnUrl;
        }
    }
}