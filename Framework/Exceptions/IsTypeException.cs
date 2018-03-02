using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class IsTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "{0} cannot be of type {1}.";

		public IsTypeException(Expression<Func<object>> expression, Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression), typeName);
		}

		public IsTypeException(Expression<Func<object>> expression, string typeName)
		{
			Message = string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression), typeName);
		}

		public override string Message { get; }
	}
}