using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Exceptions
{
    public class LessThanException : Exception
    {
        private const string MESSAGE = "{0} is less than {1}.";

        public LessThanException(Expression<Func<object>> expression, object limit)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression), limit))
        { }
    }
}
