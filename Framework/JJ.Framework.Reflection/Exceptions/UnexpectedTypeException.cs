using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class UnexpectedTypeException : Exception
    {
        private const string MESSAGE = "{0} has an unexpected type: '{0}'";

        public UnexpectedTypeException(Expression<Func<object>> expression)
        {
            string expressionText = ExpressionHelper.GetText(expression);

            object value = ExpressionHelper.GetValue(expression);
            string typeDescription;
            if (value == null)
            {
                typeDescription = "<null>";
            }
            else
            {
                typeDescription = value.GetType().FullName;
            }

            _message = String.Format(MESSAGE, expressionText, typeDescription);
        }

        private string _message;

        public override string Message => _message;
    }
}
