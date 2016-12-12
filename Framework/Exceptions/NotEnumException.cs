using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common.Exceptions
{
    public class NotEnumException : Exception
    {
        private const string MESSAGE_TEMPLATE = "Type {0} is not an enum.";

        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public NotEnumException(Type type)
        {
            string typeName;

            if (type == null)
            {
                typeName = "<null>";
            }
            else
            {
                typeName = type.FullName;
            }

            _message = String.Format(MESSAGE_TEMPLATE, typeName);
        }
    }
}
