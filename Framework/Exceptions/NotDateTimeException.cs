using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotDateTimeException : Exception
    {
        private const string MESSAGE = "{0} is not a DateTime.";

        public NotDateTimeException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
