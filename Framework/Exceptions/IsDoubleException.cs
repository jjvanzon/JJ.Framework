﻿using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class IsDoubleException : Exception
    {
        private const string MESSAGE = "{0} should not be a double precision floating point number.";

        public IsDoubleException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
