using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation
{
    public class ValidationMessage
    {
        // TODO: Put back on read-only again after you removed the hack in QuestionValidator, that requires the setter.
        public string PropertyKey { get; set; }
        //public string PropertyKey { get; private set; }
        public string Text { get; private set; }

        public ValidationMessage(string propertyKey, string text)
        {
            if (String.IsNullOrEmpty(propertyKey)) throw new ArgumentNullException("propertyKey");
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException("text");

            PropertyKey = propertyKey;
            Text = text;
        }
    }
}