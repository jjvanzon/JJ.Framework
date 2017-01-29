using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class InvalidReferenceException : Exception
    {
        private const string MESSAGE = "{0} not found in list.";

        public InvalidReferenceException(Expression<Func<object>> expression)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
