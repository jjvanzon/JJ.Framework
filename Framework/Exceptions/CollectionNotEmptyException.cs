using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Exceptions
{
    public class CollectionNotEmptyException : Exception
    {
        private const string MESSAGE = "{0} collection should be empty.";

        public CollectionNotEmptyException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
