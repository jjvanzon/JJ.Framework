using System;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace JJ.Framework.Mvc
{
    [PublicAPI]
    public static class ControllerExtensions
    {
        public static string GetControllerName(this Controller controller)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            string controllerName = (string)controller.ControllerContext.RequestContext.RouteData.Values["controller"];
            return controllerName;
        }
    }
}