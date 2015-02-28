using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.Mvc
{
    internal class ControllerAccessor
    {
        private Accessor _accessor;

        public ControllerAccessor(Controller controller)
        {
            _accessor = new Accessor(controller, typeof(Controller));
        }

        public ActionResult View(string viewName, object viewModel)
        {
            return (ActionResult)_accessor.InvokeMethod("View", viewName, viewModel);
        }

        public ActionResult RedirectToAction(string actionName, string controllerName)
        {
            return (ActionResult)_accessor.InvokeMethod("RedirectToAction", actionName, controllerName);
        }

        public ActionResult RedirectToAction(string actionName, string controllerName, object routeValues)
        {
            return (ActionResult)_accessor.InvokeMethod("RedirectToAction", actionName, controllerName, routeValues);
        }
    }
}
