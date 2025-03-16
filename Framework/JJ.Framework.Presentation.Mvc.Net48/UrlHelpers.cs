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
            if (collection == null) throw new NullException(() => collection);

            var urlInfo = new UrlInfo(controllerName, actionName);

            foreach (T value in collection)
            {
                var parameter = new UrlParameterInfo
                {
                    Name = parameterName, 
                    Value = Convert.ToString(value)
                };
                urlInfo.Parameters.Add(parameter);
            }

            string url = '/' + UrlBuilder.BuildUrl(urlInfo);
            return url;
        }

        public static string ActionWithParams(string actionName, string controllerName, params object[] parameterNamesAndValues)
        {
            if (parameterNamesAndValues == null) throw new NullException(() => parameterNamesAndValues);

            var urlInfo = new UrlInfo(controllerName, actionName);

            IList<KeyValuePair<string, object>> keyValuePairs = KeyValuePairHelper.ConvertNamesAndValuesListToKeyValuePairs(parameterNamesAndValues);
            foreach (var entry in keyValuePairs)
            {
                var parameter = new UrlParameterInfo
                {
                    Name = entry.Key,
                    Value = Convert.ToString(entry.Value)
                };
                urlInfo.Parameters.Add(parameter);
            }

            string url = UrlBuilder.BuildUrl(urlInfo);
            return '/' + url;
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
                ActionName = presenterActionName
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

            var urlInfo = new UrlInfo(actionInfo.PresenterName, actionInfo.ActionName);
            urlInfo.Parameters = actionInfo.Parameters.Select(x => new UrlParameterInfo(x.Name, x.Value)).ToArray();

            string url = UrlBuilder.BuildUrl(urlInfo);
            return url;
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