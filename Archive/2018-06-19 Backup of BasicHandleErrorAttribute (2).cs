//using System;
//using System.Linq;
//using System.Security.Authentication;
//using System.Web;
//using System.Web.Mvc;
//using JJ.Framework.Collections;
//using JJ.Framework.Web;

//namespace JJ.Framework.Mvc
//{
//    /// <summary>
//    /// Upon error this will use some of the things you can specify in the customErrors config element,
//    /// to redirect to the right error page. Some common exceptions are handled to redirect to a specific page
//    /// related to an HTTP status code in the config file.
//    /// (I heard this is supposed to go automatically some how, but I could not get it to work and went for this alternative.)
//    /// </summary>
//    public class BasicHandleErrorAttribute : HandleErrorAttribute
//    {
//        private readonly string _returnParameterName;

//        /// <param name="returnParameterName">
//        /// This URL parameter will be added to the URL redirected to in case of an error.
//        /// If for instance, you redirect to a login page upon an authentication error, you may want to pass the original page URL
//        /// to it.
//        /// For debugging purposes this it is also very handy to have the original URL of the page that went error.
//        /// </param>
//        public BasicHandleErrorAttribute(string returnParameterName = "ret") => _returnParameterName = returnParameterName;

//        public override void OnException(ExceptionContext filterContext)
//        {
//            // Try Get HttpStatusCode
//            int? httpErrorStatusCode = null;

//            switch (filterContext.Exception)
//            {
//                case AuthenticationException _:
//                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHENTICATED_401;
//                    break;

//                case UnauthorizedAccessException _:
//                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHORIZED_403;
//                    break;
//            }

//            if (!httpErrorStatusCode.HasValue)
//            {
//                base.OnException(filterContext);
//                return;
//            }

//            // Try Get RedirectUrl
//            string redirectUrl = CustomErrorsHelper.GetErrorRedirectUrl(httpErrorStatusCode.Value);

//            if (string.IsNullOrWhiteSpace(redirectUrl))
//            {
//                base.OnException(filterContext);
//                return;
//            }

//            // Try Add ReturnParameter
//            if (!string.IsNullOrWhiteSpace(_returnParameterName))
//            {
//                // Check if the first-level return URL is already the current URL.
//                // Then you are just redirected to the same page at the same error over and over again.
//                // This is most common in Login views.
//                // If you do not check, you will just get login URL's stacked on top of eachother
//                // as return URL's.

//                string currentUrl = filterContext.HttpContext.Request.RawUrl;
//                string currentUrlMinusReturnUrl = GetCurrentUrlMinusReturnUrl(filterContext);

//                if (!string.Equals(redirectUrl, currentUrlMinusReturnUrl))
//                {
//                    redirectUrl = UrlBuilder.AddUrlParameter(redirectUrl, _returnParameterName, currentUrl);
//                }
//                else
//                {
//                    int bla = 1;
//                }
//            }

//            // Redirect
//            filterContext.HttpContext.Response.StatusCode = httpErrorStatusCode.Value;
//            filterContext.HttpContext.Response.Redirect(redirectUrl);
//            filterContext.ExceptionHandled = true;
//        }

//        private string GetCurrentUrlMinusReturnUrl(ExceptionContext filterContext)
//        {
//            string currentUrl = filterContext.HttpContext.Request.RawUrl;

//            UrlInfo currentUrlInfo = new UrlParser().Parse(currentUrl);

//            currentUrlInfo.Parameters = currentUrlInfo.Parameters.Except(x => string.Equals(x.Name, _returnParameterName)).ToArray();

//            string currentUrlMinusReturnUrl = UrlBuilder.BuildUrl(currentUrlInfo);
//            return currentUrlMinusReturnUrl;
//        }
//    }
//}