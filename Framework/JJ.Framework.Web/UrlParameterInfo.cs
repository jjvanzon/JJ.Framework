using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace JJ.Framework.Web
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class UrlParameterInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }

        internal string DebuggerDisplay
        {
            get
            {
                return String.Format(String.Format("{0}={1}", Name, HttpUtility.UrlEncode(Value)));
            }
        }
    }
}
