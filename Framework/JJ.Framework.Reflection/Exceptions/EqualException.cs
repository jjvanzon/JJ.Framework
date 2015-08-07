using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Exceptions
{
    public class EqualException : Exception
    {
        private const string MESSAGE = "{0} is '{1}'.";

        public EqualException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
        { }
    }
}
