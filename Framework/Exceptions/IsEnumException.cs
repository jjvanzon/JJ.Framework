using System;

namespace JJ.Framework.Exceptions
{
    public class IsEnumException : Exception
    {
        private const string MESSAGE_TEMPLATE = "Type {0} should not be an enum.";

        public override string Message { get; }

        public IsEnumException(Type type)
        {
            string typeName;

            typeName = type == null ? "<null>" : type.FullName;

            Message = string.Format(MESSAGE_TEMPLATE, typeName);
        }
    }
}
