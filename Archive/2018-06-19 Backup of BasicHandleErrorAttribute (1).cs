//using System;
//using System.Security.Authentication;
//using System.Web;
//using System.Web.Mvc;
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
//                // Do not add return URL if it is the same as current URL.
//                // Otherwise login failure will get login as a return URL,
//                // and the next failure would add another login return URL.
//                string currentUrl = filterContext.HttpContext.Request.RawUrl;

//                if (!string.Equals(redirectUrl, currentUrl))
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
//    }
//}