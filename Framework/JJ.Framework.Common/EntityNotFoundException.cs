using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common
{
    public class EntityNotFoundException : Exception
    {
        private readonly string _message;

        public EntityNotFoundException(Type entityType, object id)
        {
            if (entityType == null) throw new ArgumentNullException("entityType");

            _message = String.Format("{0} with ID '{1}' not found.", entityType.Name, id);
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}