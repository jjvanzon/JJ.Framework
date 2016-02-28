using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common
{
    public class TypeNotFoundException : Exception
    {
        public TypeNotFoundException(string typeName)
            : base(String.Format("Type '{0}' not found.", typeName))
        { }
    }
}
