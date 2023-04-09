using System;
using System.Collections.Generic;
using JJ.Framework.Collections;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Web;

namespace JJ.Framework.Mvc
{
    // TODO: Make internal after making the Accessor class able to access internal classes,
    // so internal classes can be used in unit tests.

    /// <summary>
    /// Plural to not conflict with 'UrlHelper'.
    /// </summary>
    public static class UrlHelpers
    {
        public static string ActionWithCollection<T>(
            string actionName,
            string controllerName,
            string parameterName,
            IEnumerable<T> collection)
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

            // ReSharper disable once SuggestVarOrType_Elsewhere
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
    }
}