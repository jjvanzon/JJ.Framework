using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Exceptions
{
    public class GreaterThanException : Exception
    {
        public GreaterThanException(Expression<Func<object>> expression, object limit)
            : base(String.Format("{0} is greater than {1}.", ExpressionHelper.GetText(expression), limit))
        { }

        /// <summary>
        /// Only use this overload if you wish to show the text of the limitExpression in the exception message.
        /// If you only want to show the limit's value, use the other overload.
        /// </summary>
        public GreaterThanException(Expression<Func<object>> expression, Expression<Func<object>> limitExpression)
            : base(String.Format("{0} is greater than {1} of {2}.", ExpressionHelper.GetText(expression), ExpressionHelper.GetText(limitExpression), ExpressionHelper.GetValue(limitExpression)))
        { }
    }
}
