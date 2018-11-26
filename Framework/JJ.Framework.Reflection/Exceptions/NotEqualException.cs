﻿using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotEqualException : Exception
    {
        private const string MESSAGE = "{0} does not equal '{1}'.";

        public NotEqualException(Expression<Func<object>> expression1, object value)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression1), value))
        { }

        public NotEqualException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
        { }
    }
}
