//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Security.Authentication;
//using System.Web.Configuration;
//using System.Web.Mvc;

//namespace JJ.Demos.ReturnActions.Mvc.Attributes
//{
//    public class ErrorFilterAttribute : HandleErrorAttribute
//    {
//        public override void OnException(ExceptionContext filterContext)
//        {
//            Exception exception = filterContext.Exception;

//            switch (exception)
//            {
//                case AuthenticationException authenticationException:
//                    // TODO: Redirect to a URL registered under the HTTP status code 40X including a ret parameter.
//                    //filterContext.Result = new HttpStatusCodeResult(403);
//                    filterContext.Result = new HttpStatusCodeResult(401);
//                    filterContext.ExceptionHandled = true;
//                    return;

//                case UnauthorizedAccessException unauthorizedAccessException:
//                    // TODO: Redirect to a URL registered under the HTTP status code 40X including a ret parameter.
//                    filterContext.Result = new HttpStatusCodeResult(403);
//                    filterContext.ExceptionHandled = true;
//                    return;
//            }

//            base.OnException(filterContext);
//        }
//    }
//}