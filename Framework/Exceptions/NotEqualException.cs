using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NotEqualException : Exception
    {
        private const string MESSAGE = "{0} does not equal '{1}'.";

        public NotEqualException(Expression<Func<object>> expression1, object value)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression1), value))
        { }

        public NotEqualException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
        { }
    }
}
