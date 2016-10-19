using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class HasNullsException : Exception
    {
        private const string MESSAGE = "{0} contains nulls.";

        public HasNullsException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
