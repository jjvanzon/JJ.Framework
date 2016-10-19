using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class IsIntegerException : Exception
    {
        private const string MESSAGE = "{0} should not be an integer number.";

        public IsIntegerException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
