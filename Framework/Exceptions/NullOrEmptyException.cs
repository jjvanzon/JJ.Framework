using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NullOrWhiteSpaceException : Exception
    {
        private const string MESSAGE = "{0} is null or white space.";

        public NullOrWhiteSpaceException(Expression<Func<object>> expression)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
