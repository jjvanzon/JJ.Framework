using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class GreaterThanException : Exception
    {
        public GreaterThanException(Expression<Func<object>> expression, object limit)
            : base($"{ExpressionHelper.GetText(expression)} is greater than {limit}.")
        { }

        /// <summary>
        /// Only use this overload if you wish to show the text and value of the limitExpression in the exception message.
        /// If you only want to show the limit's value, use the other overload.
        /// </summary>
        public GreaterThanException(Expression<Func<object>> expression, Expression<Func<object>> limitExpression)
            // ReSharper disable once UseStringInterpolation
            : base(string.Format("{0} is greater than {1} of {2}.", ExpressionHelper.GetText(expression), ExpressionHelper.GetText(limitExpression), ExpressionHelper.GetValue(limitExpression)))
        { }
    }
}
