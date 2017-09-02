using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
    public class NullOrEmptyException : ExceptionWithExpressionBase
    {
        protected override string MessageFormat => "{0} is null or empty.";

        public NullOrEmptyException(Expression<Func<object>> expression) : base(expression)
        { }

        public NullOrEmptyException(string name) : base(name)
        { }
    }
}