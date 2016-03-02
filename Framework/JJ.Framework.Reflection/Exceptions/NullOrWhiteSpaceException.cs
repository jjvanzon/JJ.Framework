using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NullOrEmptyException : Exception
    {
        private const string MESSAGE = "{0} is null or empty.";

        public NullOrEmptyException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
