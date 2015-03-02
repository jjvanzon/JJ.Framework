using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using System.Web;

namespace JJ.Framework.Web
{
    public static class UrlParser
    {
        public static UrlInfo Parse(string url)
        {
            if (String.IsNullOrEmpty(url)) throw new Exception("url cannot be null or empty.");

            var urlInfo = new UrlInfo();

            string[] split = url.Split(':');
            switch (split.Length)
            {
                case 1:
                    ParseUrlWithoutProtocol(urlInfo, url);           
                    return urlInfo;

                case 2:
                    urlInfo.Protocol = split[0];
                    ParseUrlWithoutProtocol(urlInfo, split[1]);
                    return urlInfo;

                default:
                    throw new Exception(String.Format("url cannot contain more than one ':'. url = '{0}'.", url));
            }
        }

        private static void ParseUrlWithoutProtocol(UrlInfo destUrlInfo, string urlWithoutProcol)
        {
            string[] split = urlWithoutProcol.Split('?');

            switch (split.Length)
            {
                case 1:
                    ParseUrlWithoutProtocolWithoutQueryString(destUrlInfo, split[0]);
                    return;

                case 2:
                    ParseUrlWithoutProtocolWithoutQueryString(destUrlInfo, split[0]);
                    ParseQueryString(destUrlInfo, split[1]);
                    return;
                    
                default:
                    throw new Exception(String.Format("urlWithoutProcol cannot contain more than one '?'. urlWithoutProcol = '{0}'.", urlWithoutProcol));
            }
        }

        private static void ParseUrlWithoutProtocolWithoutQueryString(UrlInfo urlInfo, string urlWithoutProtocolWithoutQueryString)
        {
            string[] split = urlWithoutProtocolWithoutQueryString.Split('/', StringSplitOptions.RemoveEmptyEntries);
            urlInfo.PathElements.AddRange(split);
        }

        private static void ParseQueryString(UrlInfo urlInfo, string queryString)
        {
            string[] split = queryString.Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (string parameter in split)
            {
                ParseUrlParameter(urlInfo, parameter);
            }
        }

        private static void ParseUrlParameter(UrlInfo urlInfo, string urlParameter)
        {
            string[] split = urlParameter.Split('=');
            if (split.Length != 2)
            {
                throw new Exception(String.Format("urlParameter '{0}' must contain exactly one '=' character.", urlParameter));
            }

            string name = split[0];
            string value = split[1];

            if (String.IsNullOrWhiteSpace(name)) throw new Exception("name in urlParameter '{0}' cannot be null or white space.");

            var urlParameterInfo = new UrlParameterInfo
            {
                Name = name,
                Value = HttpUtility.UrlDecode(value)
            };

            urlInfo.Parameters.Add(urlParameterInfo);
        }
    }
}
