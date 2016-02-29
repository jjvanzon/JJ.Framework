using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotDecimalException : Exception
    {
        private const string MESSAGE = "{0} is not a Decimal.";

        public NotDecimalException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
