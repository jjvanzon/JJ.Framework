using System;

namespace JJ.Framework.Exceptions
{
    public class TypeNotFoundException : Exception
    {
        public TypeNotFoundException(string typeName)
            : base(string.Format("Type '{0}' not found.", typeName))
        { }
    }
}
