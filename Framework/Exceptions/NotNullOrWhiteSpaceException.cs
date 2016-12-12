using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NotNullOrWhiteSpaceException : Exception
    {
        private const string MESSAGE = "{0} should be null or white space.";

        public NotNullOrWhiteSpaceException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
