using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class IsNotTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "{0} is not of type {1}.";

		public IsNotTypeException(Expression<Func<object>> expression, Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression), typeName);
		}

		public IsNotTypeException(Expression<Func<object>> expression, string typeName)
		{
			Message = string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression), typeName);
		}

		public override string Message { get; }
	}
}