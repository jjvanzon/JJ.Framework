using System;

namespace JJ.Framework.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Type entityType, object key)
        {
            if (entityType == null) throw new ArgumentNullException(nameof(entityType));

            Message = $"{entityType.Name} with key '{key}' not found.";
        }

        public override string Message { get; }
    }
}