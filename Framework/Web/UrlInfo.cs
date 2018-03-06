using System;
using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Web
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class UrlInfo
	{
		public UrlInfo() => _pathElements = new List<string>();
		public UrlInfo(params string[] pathElements) => _pathElements = pathElements ?? throw new NullException(() => pathElements);

		public string Protocol { get; set; }

		private IList<string> _pathElements;

		/// <summary> auto-instantiated, not nullable </summary>
		public IList<string> PathElements
		{
			get => _pathElements;
			set => _pathElements = value ?? throw new Exception("value cannot be null.");
		}

		private IList<UrlParameterInfo> _parameters = new List<UrlParameterInfo>();

		/// <summary> auto-instantiated, not nullable </summary>
		public IList<UrlParameterInfo> Parameters
		{
			get => _parameters;
			set => _parameters = value ?? throw new Exception("value cannot be null.");
		}

		private string DebuggerDisplay => UrlBuilder.BuildUrl(this);
	}
}