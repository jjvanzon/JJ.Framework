﻿using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NotIntegerException : Exception
    {
        private const string MESSAGE = "{0} is not an integer number.";

        public NotIntegerException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}