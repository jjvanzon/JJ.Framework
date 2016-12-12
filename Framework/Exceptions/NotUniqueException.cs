using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NotUniqueException : Exception
    {
        private const string MESSAGE = "{0} not unique.";

        public NotUniqueException(Expression<Func<object>> expression)
            : this(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }

        public NotUniqueException(string message)
            : base(message)
        { }
    }
}
