using System.Diagnostics;

namespace JJ.Framework.Web
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class UrlParameterInfo
    {
        public UrlParameterInfo()
        { }

        public UrlParameterInfo(string name, string value)
        {
            Name = name;
            Value = value;
        }

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
