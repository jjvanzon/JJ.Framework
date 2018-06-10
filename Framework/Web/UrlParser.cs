using System;
using System.Collections.Generic;
using System.Web;
using JJ.Framework.Text;

// ReSharper disable ForCanBeConvertedToForeach

namespace JJ.Framework.Web
{
	public class UrlParser
	{
		/// <summary>
		/// Used in exception messages throughout the parser.
		/// </summary>
		private string _fullUrl;

		public UrlInfo Parse(string url)
		{
			if (string.IsNullOrEmpty(url)) throw new Exception("url cannot be null or empty.");

			_fullUrl = url;

			string[] split = url.Split(':');
			switch (split.Length)
			{
				case 1:
				{
					UrlInfo urlInfo = ParseUrlWithoutProtocol(url);
					return urlInfo;
				}

				case 2:
				{
					UrlInfo urlInfo = ParseUrlWithoutProtocol(split[1]);
					urlInfo.Protocol = HttpUtility.UrlDecode(split[0]);
					return urlInfo;
				}

				default:
					throw new Exception($"url cannot contain more than one ':'. url = '{url}'.");
			}
		}

		private UrlInfo ParseUrlWithoutProtocol(string urlWithoutProcol)
		{
			string[] split = urlWithoutProcol.Split('?');

			switch (split.Length)
			{
				case 1:
				{
					UrlInfo urlInfo = ParseUrlWithoutProtocolWithoutParmeters(split[0]);
					return urlInfo;
				}

				case 2:
				{
					UrlInfo urlInfo = ParseUrlWithoutProtocolWithoutParmeters(split[0]);
					urlInfo.Parameters = ParseQueryString(split[1]);
					return urlInfo;
				}

				default:
					throw new Exception(
						$"urlWithoutProcol cannot contain more than one '?'. urlWithoutProcol = '{urlWithoutProcol}'. fullUrl = '{_fullUrl}'.");
			}
		}

		private UrlInfo ParseUrlWithoutProtocolWithoutParmeters(string urlWithoutProtocolWithoutParameters)
		{
			string[] split = urlWithoutProtocolWithoutParameters.Split('/', StringSplitOptions.RemoveEmptyEntries);

			var urlInfo = new UrlInfo
			{
				PathElements = new List<string>(split.Length)
			};

			for (int i = 0; i < split.Length; i++)
			{
				string pathElement = HttpUtility.UrlDecode(split[i]);
				urlInfo.PathElements.Add(pathElement);
			}

			return urlInfo;
		}

		public IList<UrlParameterInfo> ParseQueryString(string queryString)
		{
			var list = new List<UrlParameterInfo>();

			string[] split = queryString.Split('&', StringSplitOptions.RemoveEmptyEntries);
			foreach (string parameter in split)
			{
				UrlParameterInfo urlParameterInfo = ParseUrlParameter(parameter);
				list.Add(urlParameterInfo);
			}

			return list;
		}

		private UrlParameterInfo ParseUrlParameter(string urlParameter)
		{
			string[] split = urlParameter.Split('=');
			if (split.Length != 2)
			{
				throw new ArgumentException($"urlParameter '{urlParameter}' must contain exactly one '=' character. fullUrl = '{_fullUrl}'.");
			}

			string name = split[0];
			string value = split[1];

			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException($"name in urlParameter '{urlParameter}' cannot be null or white space. fullUrl = '{_fullUrl}'.");
			}

			var urlParameterInfo = new UrlParameterInfo
			{
				Name = HttpUtility.UrlDecode(name),
				Value = HttpUtility.UrlDecode(value)
			};

			return urlParameterInfo;
		}
	}
}