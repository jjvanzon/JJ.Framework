using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class ValidationMessage
    {
        public string PropertyKey { get; private set; }
        public string Text { get; private set; }

        public ValidationMessage(string propertyKey, string text)
        {
            if (String.IsNullOrEmpty(propertyKey)) throw new NullException(() => propertyKey);
            if (String.IsNullOrEmpty(text)) throw new NullException(() => text);

            PropertyKey = propertyKey;
            Text = text;
        }

        private string DebuggerDisplay
        {
            get
            {
                return String.Format("{0}: {1}", PropertyKey, Text);
            }
        }
    }
}
