using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class NotNaNException : Exception
    {
        private const string MESSAGE = "{0} should be NaN.";

        public NotNaNException(Expression<Func<object>> expression)
            : base(string.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
