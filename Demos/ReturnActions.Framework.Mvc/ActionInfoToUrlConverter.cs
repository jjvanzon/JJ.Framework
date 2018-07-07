using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.Comparative;
using JJ.Framework.Web;

namespace JJ.Demos.ReturnActions.Framework.Mvc
{
    internal static class ActionInfoToUrlConverter
    {
        /// <summary>
        /// ActionInfo can contain a property ReturnAction which is again an ActionInfo.
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// Returns null if actionInfo is null.
        /// </summary>
        public static string ConvertActionInfoToUrl(ActionInfo actionInfo, string returnUrlParameterName)
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

            string returnUrl = ConvertActionInfoToUrl_ByList(actionInfos, returnUrlParameterName);
            return returnUrl;
        }

        private static string ConvertActionInfoToUrl_ByList(IList<ActionInfo> actionInfos, string returnUrlParameterName)
        {
            // TODO: Performance of these string operations is not great.
            if (string.IsNullOrWhiteSpace(returnUrlParameterName))
                throw new Exception("returnUrlParameterName cannot be null or white space.");

            ActionInfo actionInfo = actionInfos[0];
            string url = ConvertActionInfoToUrl_NonRecursive(actionInfo);

            for (int i = 1; i < actionInfos.Count; i++)
            {
                ActionInfo actionInfo2 = actionInfos[i];
                string url2 = ConvertActionInfoToUrl_NonRecursive(actionInfo2);

                url = HttpUtility.UrlEncode(url);

                string separator = !url2.Contains('?') ? "?" : "&";

                url = url2 + separator + returnUrlParameterName + "=" + url;
            }

            return url;
        }

        private static string ConvertActionInfoToUrl_NonRecursive(ActionInfo actionInfo)
        {
            if (actionInfo == null) throw new NullException(() => actionInfo);
            if (actionInfo.Parameters == null) throw new NullException(() => actionInfo.Parameters);
            if (string.IsNullOrEmpty(actionInfo.PresenterName)) throw new NullOrEmptyException(() => actionInfo.PresenterName);
            if (string.IsNullOrEmpty(actionInfo.ActionName)) throw new NullOrEmptyException(() => actionInfo.ActionName);

            var urlInfo = new UrlInfo(actionInfo.PresenterName, actionInfo.ActionName)
            {
                Parameters = actionInfo.Parameters.Select(x => new UrlParameterInfo(x.Name, x.Value)).ToArray()
            };

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
        /// NOTE: If a URL contains more than one path element,
        /// the 3rd path element and onward are returned as parameters without names.
        /// </summary>
        public static ActionInfo ConvertUrlToActionInfo(string url, string returnUrlParameterName = "ret")
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            var urlParser = new UrlParser();
            UrlInfo sourceUrlInfo = urlParser.Parse(url);

            if (sourceUrlInfo.PathElements.Count < 2) throw new LessThanException(() => sourceUrlInfo.PathElements.Count, 2);

            var mvcActionInfo = new ActionInfo
            {
                PresenterName = sourceUrlInfo.PathElements[0],
                ActionName = sourceUrlInfo.PathElements[1],
                Parameters = new List<ActionParameterInfo>(sourceUrlInfo.Parameters.Count)
            };

            // If a URL contains more than one path element,
            // the 3rd path element and onward are returned as parameters without names.
            for (int i = 2; i < sourceUrlInfo.PathElements.Count; i++)
            {
                var destActionParameterInfo = new ActionParameterInfo
                {
                    Value = sourceUrlInfo.PathElements[i]
                };
                mvcActionInfo.Parameters.Add(destActionParameterInfo);
            }

            for (int i = 0; i < sourceUrlInfo.Parameters.Count; i++)
            {
                UrlParameterInfo sourceUrlParameterInfo = sourceUrlInfo.Parameters[i];

                bool isReturnUrlParameter = string.Equals(sourceUrlParameterInfo.Name, returnUrlParameterName);
                if (!isReturnUrlParameter)
                {
                    var destActionParameterInfo = new ActionParameterInfo
                    {
                        Name = sourceUrlParameterInfo.Name,
                        Value = sourceUrlParameterInfo.Value
                    };
                    mvcActionInfo.Parameters.Add(destActionParameterInfo);
                }
                else
                {
                    // Recursive call
                    mvcActionInfo.ReturnAction = ConvertUrlToActionInfo(sourceUrlParameterInfo.Value, returnUrlParameterName);
                }
            }

            return mvcActionInfo;
        }
    }
}