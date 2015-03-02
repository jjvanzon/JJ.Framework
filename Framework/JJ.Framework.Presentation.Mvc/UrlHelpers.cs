using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.Mvc
{
    /// <summary>
    /// Plural to not conflict with 'UrlHelper'.
    /// </summary>
    public static class UrlHelpers
    {
        private static ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

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

        /// <summary>
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// </summary>
        public static string GetReturnUrl(string presenterName, string presenterActionName, object parameters = null)
        {
            var actionInfo = new ActionInfo
            {
                PresenterName = presenterName,
                ActionName = presenterActionName,
            };

            if (parameters == null)
            {
                actionInfo.Parameters = new ActionParameterInfo[0];
            }
            else
            {
                actionInfo.Parameters = _reflectionCache.GetProperties(parameters.GetType())
                                                        .Select(x => new ActionParameterInfo
                                                        {
                                                            Name = x.Name,
                                                            Value = Convert.ToString(x.GetValue(parameters, null))
                                                        })
                                                        .ToArray();
            }

            string returnUrl = GetReturnUrl_NonRecursive(actionInfo);
            return returnUrl;
        }

        /// <summary>
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// Returns null if actionInfo is null.
        /// </summary>
        public static string GetReturnUrl(ActionInfo actionInfo, string returnUrlParameterName = "ret")
        {
            if (actionInfo == null)
            {
                return null;
            }

            IList<ActionInfo> actionInfos = new List<ActionInfo>();
            actionInfos.Add(actionInfo);

            ActionInfo deeperActionInfo = actionInfo.ReturnAction;
            while (deeperActionInfo != null)
            {
                actionInfos.Add(deeperActionInfo);
                deeperActionInfo = deeperActionInfo.ReturnAction;
            }
            actionInfos = actionInfos.Reverse().ToArray();

            string returnUrl = GetReturnUrl_ByList(actionInfos, returnUrlParameterName);
            return returnUrl;
        }

        private static string GetReturnUrl_ByList(IList<ActionInfo> actionInfos, string returnUrlParameterName)
        {
            // TODO: Performance of these string operations is not great.
            if (String.IsNullOrWhiteSpace(returnUrlParameterName)) throw new Exception("returnUrlParameterName cannot be null or white space.");

            ActionInfo actionInfo = actionInfos[0];
            string url = GetReturnUrl_NonRecursive(actionInfo);

            for (int i = 1; i < actionInfos.Count; i++)
            {
                ActionInfo actionInfo2 = actionInfos[i];
                string url2 = GetReturnUrl_NonRecursive(actionInfo2);

                url = HttpUtility.UrlEncode(url);

                string separator = (!url2.Contains('?') ? "?" : "&");

                url = url2 + separator + returnUrlParameterName + "=" + url;
            }

            return url;
        }

        private static string GetReturnUrl_NonRecursive(ActionInfo actionInfo)
        {
            if (actionInfo == null) throw new NullException(() => actionInfo);
            if (actionInfo.Parameters == null) throw new NullException(() => actionInfo.Parameters);
            if (String.IsNullOrEmpty(actionInfo.PresenterName)) throw new Exception("actionInfo.PresenterName cannot be null or empty.");
            if (String.IsNullOrEmpty(actionInfo.ActionName)) throw new Exception("actionInfo.PresenterName cannot be null or empty.");

            var sb = new StringBuilder();

            sb.Append(actionInfo.PresenterName);
            sb.Append("/");
            sb.Append(actionInfo.ActionName);

            if (actionInfo.Parameters.Count > 0)
            {
                sb.Append("?");

                for (int i = 0; i < actionInfo.Parameters.Count; i++)
                {
                    ActionParameterInfo parameter = actionInfo.Parameters[i];
                    if (String.IsNullOrEmpty(parameter.Name)) throw new Exception(String.Format("{0} cannot be null or empty.", JJ.Framework.Reflection.ExpressionHelper.GetText(() => actionInfo.Parameters[i], true)));

                    sb.Append(parameter.Name);
                    sb.Append("=");
                    sb.Append(HttpUtility.UrlEncode(parameter.Value));

                    if (i != actionInfo.Parameters.Count - 1)
                    {
                        sb.Append("&");
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Accepts return URL's stacked up as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// Converts it to an ActionInfo object with possibly its ReturnAction assigned,
        /// with possibly its ReturnAction assigned, etcetera.
        /// Returns null if returnUrl is null or empty.
        /// </summary>
        public static ActionInfo GetReturnAction(string returnUrl, string returnUrlParameterName = "ret")
        {
            if (String.IsNullOrEmpty(returnUrl))
            {
                return null;
            }

            var urlParser = new UrlParser();
            UrlInfo sourceUrlInfo = urlParser.Parse(returnUrl);
            if (sourceUrlInfo.PathElements.Count != 2)
            {
                throw new Exception(String.Format("returnUrl must have 2 path elements. returnUrl = '{0}'.", returnUrl));
            }

            var destActionInfo = new ActionInfo
            {
                PresenterName = sourceUrlInfo.PathElements[0],
                ActionName = sourceUrlInfo.PathElements[1]
            };

            destActionInfo.Parameters = new List<ActionParameterInfo>(sourceUrlInfo.Parameters.Count);

            for (int i = 0; i < sourceUrlInfo.Parameters.Count; i++)
            {
                UrlParameterInfo sourceUrlParameterInfo = sourceUrlInfo.Parameters[i];

                if (!String.Equals(sourceUrlParameterInfo.Name, returnUrlParameterName))
                {
                    var destActionParameterInfo = new ActionParameterInfo
                    {
                        Name = sourceUrlParameterInfo.Name,
                        Value = sourceUrlParameterInfo.Value
                    };
                    destActionInfo.Parameters.Add(destActionParameterInfo);
                }
                else
                {
                    // Recursive call
                    destActionInfo.ReturnAction = GetReturnAction(sourceUrlParameterInfo.Value, returnUrlParameterName);
                }
            }
            

            return destActionInfo;
        }
    }
}