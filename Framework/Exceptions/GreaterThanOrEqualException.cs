using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class GreaterThanOrEqualException : Exception
    {
        public GreaterThanOrEqualException(Expression<Func<object>> expression, object limit)
            : base(String.Format("{0} is greater than or equal to {1}.", ExpressionHelper.GetText(expression), limit))
        { }

        /// <summary>
        /// Only use this overload if you wish to show the text and value of the limitExpression in the exception message.
        /// If you only want to show the limit's value, use the other overload.
        /// </summary>
        public GreaterThanOrEqualException(Expression<Func<object>> expression, Expression<Func<object>> limitExpression)
            : base(String.Format("{0} is greater than or equal to {1} of {2}.", ExpressionHelper.GetText(expression), ExpressionHelper.GetText(limitExpression), ExpressionHelper.GetValue(limitExpression)))
        { }
    }
}
