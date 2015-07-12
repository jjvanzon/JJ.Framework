using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public class PropertyNotFoundException : Exception
    {
        private Type _type;
        private string _propertyName;

        public PropertyNotFoundException(Type type, string propertyName)
        {
            if (type == null) throw new ArgumentNullException("type");

            _type = type;
            _propertyName = propertyName;
        }

        public override string Message
        {
            get
            {
                string message = String.Format("Property '{0}' not found on type '{1}'.", _propertyName, _type.Name);
                return message;
            }
        }
    }
}