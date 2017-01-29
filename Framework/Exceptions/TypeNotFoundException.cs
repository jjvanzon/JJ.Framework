using System;

namespace JJ.Framework.Exceptions
{
    public class TypeNotFoundException : Exception
    {
        public TypeNotFoundException(string typeName)
            : base($"Type '{typeName}' not found.")
        { }
    }
}
