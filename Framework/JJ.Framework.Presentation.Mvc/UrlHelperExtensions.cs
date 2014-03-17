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
    }
}
