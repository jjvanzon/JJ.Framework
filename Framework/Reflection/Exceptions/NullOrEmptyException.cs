using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NullOrWhiteSpaceException : Exception
    {
        private const string MESSAGE = "{0} is null or white space.";

        public NullOrWhiteSpaceException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
