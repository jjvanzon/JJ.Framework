using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Exceptions
{
    public class IsEnumException : Exception
    {
        private const string MESSAGE_TEMPLATE = "Type {0} should not be an enum.";

        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public IsEnumException(Type type)
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
