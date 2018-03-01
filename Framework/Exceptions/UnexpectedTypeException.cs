using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class UnexpectedTypeException : Exception
	{
		public UnexpectedTypeException(Expression<Func<object>> expression)
		{
			string expressionText = ExpressionHelper.GetText(expression);

			object value = ExpressionHelper.GetValue(expression);

			Type concreteType = value?.GetType();

			string concreteTypeName = ExceptionHelper.TryFormatFullTypeName(concreteType);

			Message = $"{expressionText} has an unexpected type: '{concreteTypeName}'";
		}

		public override string Message { get; }
	}
}
