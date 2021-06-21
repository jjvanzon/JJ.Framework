using System.Reflection;
using System.Web.Mvc;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Reflection;

namespace JJ.Framework.Mvc
{
    [PublicAPI]
    public class ControllerAccessor
    {
        private static readonly ReflectionCache _reflectionCache = new ReflectionCache();
        private static readonly MethodInfo _viewMethodInfo;
        private static readonly MethodInfo _redirectToAction_MethodInfo_With2Parameters;
        private static readonly MethodInfo _redirectToAction_MethodInfo_With3Parameters;

        private readonly Controller _controller;

        static ControllerAccessor()
        {
            _viewMethodInfo = _reflectionCache.GetMethod(typeof(Controller), "View", typeof(string), typeof(object));
            _redirectToAction_MethodInfo_With2Parameters = _reflectionCache.GetMethod(
                typeof(Controller),
                "RedirectToAction",
                typeof(string),
                typeof(string));
            _redirectToAction_MethodInfo_With3Parameters = _reflectionCache.GetMethod(
                typeof(Controller),
                "RedirectToAction",
                typeof(string),
                typeof(string),
                typeof(object));
        }

        public ControllerAccessor(Controller controller) => _controller = controller ?? throw new NullException(() => controller);

        public ActionResult View(string viewName, object viewModel)
            => (ActionResult)_viewMethodInfo.Invoke(_controller, new[] { viewName, viewModel });

        public ActionResult RedirectToAction(string actionName, string controllerName)
            => (ActionResult)_redirectToAction_MethodInfo_With2Parameters.Invoke(_controller, new object[] { actionName, controllerName });

        public ActionResult RedirectToAction(string actionName, string controllerName, object routeValues)
            => (ActionResult)_redirectToAction_MethodInfo_With3Parameters.Invoke(
                _controller,
                new[] { actionName, controllerName, routeValues });
    }
}