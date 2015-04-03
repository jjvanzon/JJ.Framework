using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Exceptions
{
    public class NullException : Exception
    {
        private const string MESSAGE = "{0} is null.";

        public NullException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
