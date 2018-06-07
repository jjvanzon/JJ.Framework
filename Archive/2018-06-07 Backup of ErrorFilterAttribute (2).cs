//using System;
//using System.Security.Authentication;
//using System.Web.Mvc;
//using JJ.Framework.Web;

//namespace JJ.Demos.ReturnActions.Mvc.Attributes
//{
//    public class ErrorFilterAttribute : HandleErrorAttribute
//    {
//        public override void OnException(ExceptionContext filterContext)
//        {
//            Exception exception = filterContext.Exception;

//            int? httpErrorStatusCode = null;
//            switch (exception)
//            {
//                case AuthenticationException _:
//                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHENTICATED_401;
//                    break;
                        
//                case UnauthorizedAccessException _:
//                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHORIZED_403;
//                    break;
//            }

//            if (httpErrorStatusCode.HasValue)
//            {
//                //filterContext.Result = new HttpStatusCodeResult(httpErrorStatusCode.Value);
//                //filterContext.Controller.
//                string redirectUrl = CustomErrorsHelper.GetErrorRedirectUrl(httpErrorStatusCode.Value);
//                filterContext.HttpContext.Response.StatusCode = httpErrorStatusCode.Value;
//                filterContext.HttpContext.Response.Redirect(redirectUrl);
//                filterContext.ExceptionHandled = true;
//                // TODO: I thought in earlier solutions I let the ErrorController and all set the HttpStatus.
//                // But if I put this in a framework, this seems assumptious about the implementation?
//                // Not sure.
//                return;
//            }

//            base.OnException(filterContext);
//        }
//    }
//}