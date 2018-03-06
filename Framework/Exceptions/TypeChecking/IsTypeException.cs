using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions.TypeChecking
{
	public class IsTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "{0} cannot be of type {1}.";

		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public IsTypeException(Expression<Func<object>> expression, Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression), typeName);
		}

		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public IsTypeException(Expression<Func<object>> expression, string typeName)
		{
			Message = string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression), typeName);
		}

		/// <param name="indicator">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public IsTypeException(object indicator, Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, indicator, typeName);
		}

		/// <param name="indicator">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public IsTypeException(object indicator, string typeName)
		{
			Message = string.Format(MESSAGE_TEMPLATE, indicator, typeName);
		}

		public override string Message { get; }
	}
}