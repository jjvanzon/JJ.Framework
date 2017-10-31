using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace JJ.Framework.Web
{
    public static class UrlBuilder
    {
        public static string BuildUrl(UrlInfo urlInfo)
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(urlInfo.Protocol))
            {
                sb.Append(HttpUtility.UrlEncode(urlInfo.Protocol));
                sb.Append("://");
            }

            if (urlInfo.PathElements.Count != 0)
            {
                int i;
                for (i = 0; i < urlInfo.PathElements.Count - 1; i++)
                {
                    sb.Append(HttpUtility.UrlEncode(urlInfo.PathElements[i]));
                    sb.Append('/');
                }
                sb.Append(HttpUtility.UrlEncode(urlInfo.PathElements[i]));
            }

            if (urlInfo.Parameters.Count != 0)
            {
                sb.Append('?');
            }

            BuildQueryString(sb, urlInfo.Parameters);

            return sb.ToString();
        }

        public static string BuildQueryString(IList<UrlParameterInfo> parameters)
        {
            if (parameters == null) throw new NullException(() => parameters);

            var sb = new StringBuilder();
            BuildQueryString(sb, parameters);
            return sb.ToString();
        }

        private static void BuildQueryString(StringBuilder sb, IList<UrlParameterInfo> parameters)
        {
            if (parameters.Count == 0)
            {
                return;
            }

            int i;
            for (i = 0; i < parameters.Count - 1; i++)
            {
                // Inlined for performance
                UrlParameterInfo parameter = parameters[i];
                sb.Append(HttpUtility.UrlEncode(parameter.Name));
                sb.Append('=');
                sb.Append(HttpUtility.UrlEncode(parameter.Value));

                sb.Append('&');
            }

            // Inlined for performance
            UrlParameterInfo lastParameter = parameters[i];
            sb.Append(HttpUtility.UrlEncode(lastParameter.Name));
            sb.Append('=');
            sb.Append(HttpUtility.UrlEncode(lastParameter.Value));
        }

        public static string BuildParameter(UrlParameterInfo parameter)
        {
            return string.Format(string.Format("{0}={1}", HttpUtility.UrlEncode(parameter.Name), HttpUtility.UrlEncode(parameter.Value)));
        }
    }
}
