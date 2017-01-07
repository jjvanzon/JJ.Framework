using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
    public class UnexpectedTypeException : Exception
    {
        private const string MESSAGE = "{0} has an unexpected type: '{1}'";

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
