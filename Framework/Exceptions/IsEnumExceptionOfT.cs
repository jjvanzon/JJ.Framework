using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Exceptions
{
    public class IsEnumExceptionOfT<T> : IsEnumException
    {
        public IsEnumExceptionOfT()
            : base(typeof(T))
        { }
    }
}
