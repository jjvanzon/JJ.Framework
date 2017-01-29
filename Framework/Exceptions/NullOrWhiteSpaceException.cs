using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NullOrEmptyException : Exception
    {
        private const string MESSAGE = "{0} is null or empty.";

        public NullOrEmptyException(Expression<Func<object>> expression)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
