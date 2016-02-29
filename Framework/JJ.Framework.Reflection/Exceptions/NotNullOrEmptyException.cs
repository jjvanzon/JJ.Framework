using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotNullOrEmptyException : Exception
    {
        private const string MESSAGE = "{0} should be null or empty.";

        public NotNullOrEmptyException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
