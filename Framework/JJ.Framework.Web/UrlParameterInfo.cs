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

        private string DebuggerDisplay
        {
            get
            {
                return UrlBuilder.BuildParameter(this);
            }
        }
    }
}
