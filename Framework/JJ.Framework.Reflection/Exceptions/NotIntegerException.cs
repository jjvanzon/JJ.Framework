using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NotIntegerException : Exception
    {
        private const string MESSAGE = "{0} is not an integer number.";

        public NotIntegerException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
