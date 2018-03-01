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

			Type type = value?.GetType();

			string typeName = ExceptionHelper.TryFormatFullTypeName(type);

			Message = $"{expressionText} has an unexpected type: '{typeName}'";
		}

		public override string Message { get; }
	}
}
