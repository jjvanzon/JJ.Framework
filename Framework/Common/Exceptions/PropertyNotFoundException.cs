using System;

namespace JJ.Framework.Common.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public PropertyNotFoundException(Type type, string propertyName)
        {
            if (type == null) throw new ArgumentNullException("type");

            _message = String.Format("Property '{0}' not found on type '{1}'.", propertyName, type.Name);
        }
    }
}