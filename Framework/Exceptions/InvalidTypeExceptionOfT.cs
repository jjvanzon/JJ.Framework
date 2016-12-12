using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
    public class InvalidTypeException<T> : InvalidTypeException
    {
        public InvalidTypeException(Expression<Func<object>> expression)
            : base(expression, typeof(T))
        { }
    }
}
