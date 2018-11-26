﻿using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class IsDateTimeException : Exception
    {
        private const string MESSAGE = "{0} should not be a DateTime.";

        public IsDateTimeException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
