using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation.Legacy
{
    /// <inheritdoc cref="_validationmessage" />
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class ValidationMessage
    {
        /// <inheritdoc cref="_propertykey" />
        public string PropertyKey { get; private set; }
        /// <inheritdoc cref="_messagetext" />
        public string Text { get; private set; }

        /// <inheritdoc cref="_validationmessage" />
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
