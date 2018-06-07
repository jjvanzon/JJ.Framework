using System;
using System.Security.Authentication;
using System.Web.Mvc;
using JJ.Framework.Web;

namespace JJ.Framework.Mvc
{
    public class BasicHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;

            int? httpErrorStatusCode = null;
            switch (exception)
            {
                case AuthenticationException _:
                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHENTICATED_401;
                    break;
                        
                case UnauthorizedAccessException _:
                    httpErrorStatusCode = HttpStatusCodes.NOT_AUTHORIZED_403;
                    break;
            }

            if (httpErrorStatusCode.HasValue)
            {
                string redirectUrl = CustomErrorsHelper.GetErrorRedirectUrl(httpErrorStatusCode.Value);
                filterContext.HttpContext.Response.StatusCode = httpErrorStatusCode.Value;
                filterContext.HttpContext.Response.Redirect(redirectUrl);
                filterContext.ExceptionHandled = true;
                return;
            }

            base.OnException(filterContext);
        }
    }
}