using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class IsNotTypeException : Exception
    {
        private const string MESSAGE = "{0} is not of type {1}.";

        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public IsNotTypeException(Expression<Func<object>> expression, Type type)
        {
            if (type == null) throw new NullException(() => type);

            _message = String.Format(MESSAGE, ExpressionHelper.GetText(expression), type.FullName);
        }

        public IsNotTypeException(Expression<Func<object>> expression, string typeName)
        {
            _message = String.Format(MESSAGE, ExpressionHelper.GetText(expression), typeName);
        }
    }
}