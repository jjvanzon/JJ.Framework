using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string ActionWithCollectionParameter<T>(this UrlHelper urlHelper, string actionName, string controllerName, string parameterName, IEnumerable<T> collection)
        {
            return UrlHelpers.ActionWithCollectionParameter(actionName, controllerName, parameterName, collection);
        }

        public static string ActionWithParams(this UrlHelper urlHelper, string actionName, string controllerName, params object[] parameterNamesAndValues)
        {
            return UrlHelpers.ActionWithParams(actionName, controllerName, parameterNamesAndValues);
        }

        /// <summary>
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// </summary>
        public static string GetReturnUrl(this UrlHelper urlHelper, string presenterName, string presenterActionName, object parameters = null)
        {
            return UrlHelpers.GetReturnUrl(presenterName, presenterActionName, parameters);
        }

        /// <summary>
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// Returns null if actionInfo is null.
        /// </summary>
        public static string GetReturnUrl(this UrlHelper urlHelper, ActionInfo actionInfo, string returnUrlParameterName = "ret")
        {
            return UrlHelpers.GetReturnUrl(actionInfo, returnUrlParameterName);
        }
    }
}
