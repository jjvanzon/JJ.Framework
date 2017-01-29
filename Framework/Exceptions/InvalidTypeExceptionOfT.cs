using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
    public class InvalidTypeException<TExpectedType> : InvalidTypeException
    {
        public InvalidTypeException(Expression<Func<object>> expression)
            : base(expression, typeof(TExpectedType))
        { }
    }
}
