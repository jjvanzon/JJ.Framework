using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JJ.Framework.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Framework.Mvc.Tests
{
    [TestClass]
    public class UrlHelpersTests
    {
        [TestMethod]
        public void Test_UrlHelpers_ActionWithCollection()
        {
            string oldResult = ActionWithCollectionParameter_Old("Action", "Controller", "param", new[] { 1, 2, 3 });
            string newResult = UrlHelpers.ActionWithCollection("Action", "Controller", "param", new[] { 1, 2, 3 });
            Assert.AreEqual(oldResult, newResult);
        }

        private string ActionWithCollectionParameter_Old<T>(
            string actionName,
            string controllerName,
            string parameterName,
            IEnumerable<T> collection)
        {
            // First URL-encode everything.
            actionName = HttpUtility.UrlEncode(actionName);
            controllerName = HttpUtility.UrlEncode(controllerName);
            parameterName = HttpUtility.UrlEncode(parameterName);

            var values = new List<string>();

            foreach (T x in collection)
            {
                string str = Convert.ToString(x);
                string value = HttpUtility.UrlEncode(str);
                values.Add(value);
            }

            // Build the URL parameter string.
            var parameterString = "";

            if (collection.Count() != 0)
            {
                parameterString = "?" + parameterName + "=" + string.Join("&" + parameterName + "=", values);
            }

            // Build the URL.
            string url2 = "/" + controllerName + "/" + actionName + parameterString;

            return url2;
        }

        [TestMethod]
        public void Test_UrlHelpers_ActionWithParams()
        {
            string oldResult = ActionWithParams_Old("Action", "Controller", "param1", 1, "param2", 2);
            string newResult = UrlHelpers.ActionWithParams("Action", "Controller", "param1", 1, "param2", 2);
            Assert.AreEqual(oldResult, newResult);
        }

        private string ActionWithParams_Old(string actionName, string controllerName, params object[] parameterNamesAndValues)
        {
            // First HTML-encode all elements of the url, for safety.
            actionName = HttpUtility.HtmlEncode(actionName);
            controllerName = HttpUtility.HtmlEncode(controllerName);

            // Build the URL parameter string.
            var parametersString = "";

            IList<KeyValuePair<string, object>>
                parameters = KeyValuePairHelper.ConvertNamesAndValuesListToKeyValuePairs(parameterNamesAndValues);

            if (parameters != null && parameters.Count != 0)
            {
                var list = new List<string>();

                foreach (KeyValuePair<string, object> entry in parameters)
                {
                    string name = HttpUtility.UrlEncode(entry.Key);
                    string value = HttpUtility.UrlEncode(Convert.ToString(entry.Value));
                    string str = name + "=" + value;
                    list.Add(str);
                }

                parametersString = "?" + string.Join("&", list);
            }

            // Build the URL.
            string url = "/" + controllerName + "/" + actionName + parametersString;

            return url;
        }
    }
}