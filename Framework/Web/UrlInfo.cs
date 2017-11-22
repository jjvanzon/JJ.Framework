using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace JJ.Framework.Web
{
	[DebuggerDisplay("{DebuggerDisplay}")]
	public class UrlInfo
	{
		public UrlInfo()
		{
			_pathElements = new List<string>();
		}

		public UrlInfo(params string[] pathElements)
		{
			if (pathElements == null) throw new NullException(() => pathElements);
			_pathElements = pathElements;
		}

		public string Protocol { get; set; }

		private IList<string> _pathElements;

		/// <summary>
		/// auto-instantiated, not nullable
		/// </summary>
		public IList<string> PathElements
		{
			get
			{
				return _pathElements;
			}
			set
			{
				if (value == null) throw new Exception("value cannot be null.");
				_pathElements = value;
			}
		}

		private IList<UrlParameterInfo> _parameters = new List<UrlParameterInfo>();

		/// <summary>
		/// auto-instantiated, not nullable
		/// </summary>
		public IList<UrlParameterInfo> Parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				if (value == null) throw new Exception("value cannot be null.");
				_parameters = value;
			}
		}

		private string DebuggerDisplay
		{
			get
			{
				return UrlBuilder.BuildUrl(this);
			}
		}
	}
}