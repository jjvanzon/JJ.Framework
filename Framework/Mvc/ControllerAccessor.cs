using System.Reflection;
using System.Web.Mvc;
using JJ.Framework.Exceptions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Mvc
{
	internal class ControllerAccessor
	{
		private static MethodInfo _viewMethodInfo;
		private static MethodInfo _redirectToAction_MethodInfo_With2Parameters;
		private static MethodInfo _redirectToAction_MethodInfo_With3Parameters;

		private Controller _controller;

		static ControllerAccessor()
		{
			_viewMethodInfo = StaticReflectionCache.GetMethod(typeof(Controller), "View", typeof(string), typeof(object));
			_redirectToAction_MethodInfo_With2Parameters = StaticReflectionCache.GetMethod(typeof(Controller), "RedirectToAction", typeof(string), typeof(string));
			_redirectToAction_MethodInfo_With3Parameters = StaticReflectionCache.GetMethod(typeof(Controller), "RedirectToAction", typeof(string), typeof(string), typeof(object));
		}

		public ControllerAccessor(Controller controller)
		{
			if (controller == null) throw new NullException(() => controller);
			_controller = controller;
		}

		public ActionResult View(string viewName, object viewModel)
		{
			return (ActionResult)_viewMethodInfo.Invoke(_controller, new object[] { viewName, viewModel });
		}

		public ActionResult RedirectToAction(string actionName, string controllerName)
		{
			return (ActionResult)_redirectToAction_MethodInfo_With2Parameters.Invoke(_controller, new object[] { actionName, controllerName });
		}

		public ActionResult RedirectToAction(string actionName, string controllerName, object routeValues)
		{
			return (ActionResult)_redirectToAction_MethodInfo_With3Parameters.Invoke(_controller, new object[] { actionName, controllerName, routeValues });
		}
	}
}
