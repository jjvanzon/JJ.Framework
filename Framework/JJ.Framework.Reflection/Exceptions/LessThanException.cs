﻿using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class LessThanException : Exception
    {
        private const string MESSAGE = "{0} is less than {1}.";

        public LessThanException(Expression<Func<object>> expression, object limit)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression), limit))
        { }

        public LessThanException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
        { }
    }
}
