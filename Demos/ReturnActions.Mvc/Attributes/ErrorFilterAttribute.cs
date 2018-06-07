using System;
using System.Security.Authentication;
using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.Mvc.Attributes
{
    public class ErrorFilterAttribute : HandleErrorAttribute
    {
        //public override void OnException(ExceptionContext filterContext)
        //{
        //    Exception exception = filterContext.Exception;

        //    switch (exception)
        //    {
        //        case AuthenticationException authenticationException:
        //            // TODO: Redirect to a URL registered under the HTTP status code 40X including a ret parameter.
        //            throw exception;

        //        case UnauthorizedAccessException unauthorizedAccessException:
        //            // TODO: Redirect to a URL registered under the HTTP status code 40X including a ret parameter.
        //            throw exception;
        //    }

        //    base.OnException(filterContext);
        //}
    }
}