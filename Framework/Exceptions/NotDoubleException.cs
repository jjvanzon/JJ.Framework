using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotDoubleException : Exception
    {
        private const string MESSAGE = "{0} is not a double precision floating point number.";

        public NotDoubleException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
