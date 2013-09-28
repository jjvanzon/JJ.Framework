using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation
{
    public class ValidationMessage
    {
        public string PropertyDisplayName { get; private set; }
        public string Message { get; private set; }

        public ValidationMessage(string propertyDisplayName, string message)
        {
            if (String.IsNullOrEmpty(propertyDisplayName))
            {
                throw new ArgumentNullException("propertyDisplayName");
            }
            if (String.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message");
            }

            PropertyDisplayName = propertyDisplayName;
            Message = message;
        }
    }
}
