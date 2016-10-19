using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotInfinityException : Exception
    {
        private const string MESSAGE = "{0} should be Infinity.";

        public NotInfinityException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
