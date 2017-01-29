using JJ.Framework.Exceptions;
using System;
using System.Diagnostics;
using JJ.Framework.PlatformCompatibility;

namespace JJ.Framework.Validation
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class ValidationMessage
    {
        public string PropertyKey { get; private set; }
        public string Text { get; private set; }

        public ValidationMessage(string propertyKey, string text)
        {
            if (String_PlatformSupport.IsNullOrWhiteSpace(propertyKey)) throw new NullOrWhiteSpaceException(() => propertyKey);
            if (string.IsNullOrEmpty(text)) throw new NullException(() => text);

            PropertyKey = propertyKey;
            Text = text;
        }

        private string DebuggerDisplay
        {
            get
            {
                return string.Format("{0}: {1}", PropertyKey, Text);
            }
        }
    }
}
