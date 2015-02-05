using JJ.Framework.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.Mvc
{
    public static class UrlHelpers // Plural not to conflict with the name 'UrlHelper'.
    {
        public static string ActionWithCollectionParameter<T>(string actionName, string controllerName, string parameterName, IEnumerable<T> collection)
        {
            // First URL-encode everything.
            actionName = HttpUtility.UrlEncode(actionName);
            controllerName = HttpUtility.UrlEncode(controllerName);
            parameterName = HttpUtility.UrlEncode(parameterName);

            var values = new List<string>();
            foreach (var x in collection)
            {
                string str = Convert.ToString(x);
                string value = HttpUtility.UrlEncode(str);
                values.Add(value);
            }

            // Build the URL parameter string.
            string parameterString = "";
            if (collection.Count() != 0)
            {
                parameterString = "?" + parameterName + "=" + String.Join("&" + parameterName + "=", values);
            }

            // Build the URL.
            string url = "/" + controllerName + "/" + actionName + parameterString;

            return url;
        }

        public static string ActionWithParams(string actionName, string controllerName, params object[] parameterNamesAndValues)
        {
            // First HTML-encode all elements of the url, for safety.
            actionName = HttpUtility.HtmlEncode(actionName);
            controllerName = HttpUtility.HtmlEncode(controllerName);

            // Build the URL parameter string.
            string parametersString = "";
            IList<KeyValuePair<string, object>> parameters = KeyValuePairHelper.ConvertNamesAndValuesListToKeyValuePairs(parameterNamesAndValues);
            if (parameters != null && parameters.Count != 0)
            {
                var list = new List<string>();
                foreach (var entry in parameters)
                {
                    string name = HttpUtility.UrlEncode(entry.Key);
                    string value = HttpUtility.UrlEncode(Convert.ToString(entry.Value));
                    string str = name + "=" + value;
                    list.Add(str);
                }

                parametersString = "?" + String.Join("&", list);
            }

            // Build the URL.
            string url = "/" + controllerName + "/" + actionName + parametersString;

            return url;
        }
    }
}