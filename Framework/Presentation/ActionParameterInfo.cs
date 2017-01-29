using System.Diagnostics;

namespace JJ.Framework.Presentation
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public sealed class ActionParameterInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }

        private string DebuggerDisplay
        {
            get
            {
                return string.Format("{0}={1}", Name, Value);
            }
        }
    }
}
