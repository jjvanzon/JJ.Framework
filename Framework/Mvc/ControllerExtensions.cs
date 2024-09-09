using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace JJ.Framework.Mvc
{
    [PublicAPI]
    public static class ControllerExtensions
    {
        public static string GetControllerName(this Controller controller)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            string controllerName = (string)controller.ControllerContext.RouteData.Values["controller"];
            return controllerName;
        }
    }
}