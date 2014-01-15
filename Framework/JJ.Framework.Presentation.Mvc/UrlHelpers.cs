using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ICollection<KeyValuePair<string, object>> parameters = ConvertNamesAndValuesListToKeyValuePairs(parameterNamesAndValues);
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

        private static ICollection<KeyValuePair<string, object>> ConvertNamesAndValuesListToKeyValuePairs(IList<object> namesAndValues)
        {
            // Allow converting null to null.
            if (namesAndValues == null)
            {
                return null;
            }

            if (namesAndValues.Count % 2 != 0) { throw new Exception("namesAndValues.Count must be a multiple of 2."); }

            var keyValuePairs = new List<KeyValuePair<string, object>>();

            for (int i = 0; i < namesAndValues.Count; i += 2)
            {
                object name = namesAndValues[i];
                object value = namesAndValues[i + 1];

                if (name == null) { throw new Exception("Names in namesAndValues cannot contain nulls."); }
                if (name.GetType() != typeof(string)) { throw new Exception("Names in namesAndValues must be strings."); }

                keyValuePairs.Add(new KeyValuePair<string, object>((string)name, value));
            }

            return keyValuePairs;
        }
    }
}