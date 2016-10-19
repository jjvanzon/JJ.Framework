using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class InvalidReferenceException : Exception
    {
        private const string MESSAGE = "{0} not found in list.";

        public InvalidReferenceException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
