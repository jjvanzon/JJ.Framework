using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class InfinityException : Exception
    {
        private const string MESSAGE = "{0} is Infinity.";

        public InfinityException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
