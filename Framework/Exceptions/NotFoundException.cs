using System;

namespace JJ.Framework.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Type entityType, object key)
        {
            if (entityType == null) throw new ArgumentNullException(nameof(entityType));

            Message = String.Format("{0} with key '{1}' not found.", entityType.Name, key);
        }

        public override string Message { get; }
    }
}