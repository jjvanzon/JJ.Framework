using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Exceptions;
using JJ.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JJ.Framework.Presentation.Mvc
{
    // TODO: Make internal after making the Accessor class able to access internal classes,
    // so internal classes can be used in unit tests.

    /// <summary>
    /// Plural to not conflict with 'UrlHelper'.
    /// </summary>
    public static class UrlHelpers
    {
        private static ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

        public static string ActionWithCollection<T>(string actionName, string controllerName, string parameterName, IEnumerable<T> collection)
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
        /// Converts presenter action info to an MVC URL.
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// Returns null if actionInfo is null.
        /// </summary>
        public static string ReturnAction(ActionInfo presenterActionInfo, string returnUrlParameterName = "ret")
        {
            if (presenterActionInfo == null)
            {
                return null;
            }

            return ActionDispatcher.GetUrl(presenterActionInfo, returnUrlParameterName);
        }

        /// <summary>
        /// The difference with Url.Action is that Url.ReturnAction will produce
        /// a URL that does not fallback to default actions,
        /// nor uses parameters as URL path parts,
        /// but instead returns then as regular URL parameters.
        /// That kind of URL is better interpretable by the Presentation framework,
        /// that needs to convert it to presenter information.
        /// </summary>
        public static string ReturnAction(string actionName, string controllerName, object routeValues = null)
        {
            var actionInfo = new ActionInfo
            {
                PresenterName = controllerName,
                ActionName = actionName
            };

            if (routeValues == null)
            {
                actionInfo.Parameters = new ActionParameterInfo[0];
            }
            else
            {
                actionInfo.Parameters = _reflectionCache.GetProperties(routeValues.GetType())
                                                        .Select(x => new ActionParameterInfo
                                                        {
                                                            Name = x.Name,
                                                            Value = Convert.ToString(x.GetValue(routeValues, null))
                                                        })
                                                        .ToArray();
            }

            string returnUrl = ActionInfoToUrlConverter.ConvertActionInfoToUrl(actionInfo, returnUrlParameterName: "ret"); // returnUrlParameterName does not matter here.
            return returnUrl;

        }
    }
}