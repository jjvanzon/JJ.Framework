using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JJ.Framework.Presentation.Mvc
{
    public static class ReturnUrlHelper
    {
        public static string ConvertActionInfoToReturnUrl(ActionInfo actionInfo)
        {
            if (actionInfo == null) throw new NullException(() => actionInfo);
            if (actionInfo.Parameters == null) throw new NullException(() => actionInfo.Parameters);

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
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index?ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// </summary>
        public static string ConvertActionInfosToReturnUrl(string returnUrlParameterName, params ActionInfo[] actionInfos)
        {
            return ConvertActionInfosToReturnUrl(returnUrlParameterName, (IList<ActionInfo>)actionInfos);
        }

        /// <summary>
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index?ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// </summary>
        public static string ConvertActionInfosToReturnUrl(string returnUrlParameterName, IList<ActionInfo> actionInfos)
        {
            // TODO: Performance of these string operations is not great.

            if (actionInfos == null) throw new NullException(() => actionInfos);
            if (actionInfos.Count == 0) throw new Exception("actionInfos.Count cannot be 0.");

            ActionInfo actionInfo = actionInfos[0];
            string url = ConvertActionInfoToReturnUrl(actionInfo);

            for (int i = 1; i < actionInfos.Count; i++)
            {
                ActionInfo actionInfo2 = actionInfos[i];
                string url2 = ConvertActionInfoToReturnUrl(actionInfo2);

                url = HttpUtility.UrlEncode(url);

                string separator = (!url2.Contains('?') ? "?" : "&");

                url = url2 + separator + returnUrlParameterName + "=" + url;
            }

            return url;
        }
    }
}
