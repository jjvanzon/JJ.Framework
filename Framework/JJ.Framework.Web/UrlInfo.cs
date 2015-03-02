using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Web
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class UrlInfo
    {
        public string Protocol { get; set; }

        private IList<string> _pathElements = new List<string>();

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
                var sb = new StringBuilder();

                if (!String.IsNullOrEmpty(Protocol))
                {
                    sb.Append(Protocol);
                    sb.Append("//");
                }

                foreach (string pathElement in PathElements)
                {
                    sb.Append(pathElement);
                    if (pathElement != PathElements.Last())
                    {
                        sb.Append('/');
                    }
                }

                sb.Append('?');

                foreach (UrlParameterInfo parameter in Parameters)
                {
                    sb.Append(parameter.DebuggerDisplay);
                    if (parameter != Parameters.Last())
                    {
                        sb.Append('&');
                    }
                }

                return sb.ToString();
            }
        }
    }
}