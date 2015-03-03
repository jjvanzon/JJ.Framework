using JJ.Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JJ.Framework.Presentation.Mvc.Tests
{
    [TestClass]
    public class UrlHelpersTests
    {
        [TestMethod]
        public void Test_UrlHelpers_ActionWithCollectionParameter()
        {
            string oldResult = ActionWithCollectionParameter_Old("Action", "Controller", "param", new int[] { 1, 2, 3 });
            string newResult = UrlHelpers.ActionWithCollectionParameter("Action", "Controller", "param", new int[] { 1, 2, 3 });
            Assert.AreEqual(oldResult, newResult);
        }

        private string ActionWithCollectionParameter_Old<T>(string actionName, string controllerName, string parameterName, IEnumerable<T> collection)
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
