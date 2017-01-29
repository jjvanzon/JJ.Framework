using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NotContainsException : Exception
    {
        private const string MESSAGE = "{0} does not contain {1}.";

        public NotContainsException(Expression<Func<object>> expression, object value)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression), value))
        { }

        public NotContainsException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
        { }
    }
}
