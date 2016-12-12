using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotContainsException : Exception
    {
        private const string MESSAGE = "{0} does not contain {1}.";

        public NotContainsException(Expression<Func<object>> expression, object value)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression), value))
        { }

        public NotContainsException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
        { }
    }
}
