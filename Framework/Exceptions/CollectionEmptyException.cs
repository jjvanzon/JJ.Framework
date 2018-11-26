﻿using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class CollectionEmptyException : Exception
    {
        private const string MESSAGE = "{0} collection is empty.";

        public CollectionEmptyException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
