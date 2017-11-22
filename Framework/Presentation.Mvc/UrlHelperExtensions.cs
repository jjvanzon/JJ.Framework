using System.Collections.Generic;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.Mvc
{
	public static class UrlHelperExtensions
	{
		public static string ActionWithCollection<T>(this UrlHelper urlHelper, string actionName, string controllerName, string parameterName, IEnumerable<T> collection)
		{
			return UrlHelpers.ActionWithCollection(actionName, controllerName, parameterName, collection);
		}

		public static string ActionWithParams(this UrlHelper urlHelper, string actionName, string controllerName, params object[] parameterNamesAndValues)
		{
			return UrlHelpers.ActionWithParams(actionName, controllerName, parameterNamesAndValues);
		}

		/// <summary>
		/// The difference with Url.Action is that Url.ReturnAction will produce
		/// a URL that does not fallback to default actions,
		/// nor uses parameters as URL path parts,
		/// but instead returns then as regular URL parameters.
		/// That kind of URL is better interpretable by the Presentation framework,
		/// that needs to convert it to presenter information.
		/// </summary>
		public static string ReturnAction(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues = null)
		{
			return UrlHelpers.ReturnAction(actionName, controllerName, routeValues);
		}

		/// <summary>
		/// Converts presenter action info to an MVC URL.
		/// Stacks up return URL parameters as follows:
		/// Questions/Details?id=1
		/// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
		/// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
		/// Returns null if actionInfo is null.
		/// </summary>
		public static string ReturnAction(this UrlHelper urlHelper, ActionInfo presenterActionInfo, string returnUrlParameterName = "ret")
		{
			return UrlHelpers.ReturnAction(presenterActionInfo, returnUrlParameterName);
		}
	}
}
