using System.Collections.Generic;
using System.Web.Mvc;

namespace JJ.Framework.Mvc
{
	public static class UrlHelperExtensions
	{
		public static string ActionWithCollection<T>(this UrlHelper urlHelper, string actionName, string controllerName, string parameterName, IEnumerable<T> collection) => UrlHelpers.ActionWithCollection(actionName, controllerName, parameterName, collection);

	    public static string ActionWithParams(this UrlHelper urlHelper, string actionName, string controllerName, params object[] parameterNamesAndValues) => UrlHelpers.ActionWithParams(actionName, controllerName, parameterNamesAndValues);
	}
}
