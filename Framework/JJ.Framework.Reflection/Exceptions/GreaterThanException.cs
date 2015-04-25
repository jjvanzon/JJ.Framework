using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Exceptions
{
    public class GreaterThanException : Exception
    {
        private const string MESSAGE = "{0} is greater than {1}.";

        public GreaterThanException(Expression<Func<object>> expression, object limit)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression), limit))
        { }
    }
}
