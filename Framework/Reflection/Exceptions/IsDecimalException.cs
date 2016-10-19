using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class IsDecimalException : Exception
    {
        private const string MESSAGE = "{0} should not be a Decimal.";

        public IsDecimalException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
