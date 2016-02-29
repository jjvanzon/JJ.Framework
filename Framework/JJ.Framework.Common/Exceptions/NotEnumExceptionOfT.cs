using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common.Exceptions
{
    public class NotEnumException<T> : NotEnumException
    {
        public NotEnumException()
            : base(typeof(T))
        { }
    }
}
