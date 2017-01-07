using System;
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
