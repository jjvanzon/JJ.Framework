using System;

namespace JJ.Framework.Exceptions
{
    public class TypeNotFoundException : Exception
    {
        public TypeNotFoundException(string typeName)
            : base(String.Format("Type '{0}' not found.", typeName))
        { }
    }
}
