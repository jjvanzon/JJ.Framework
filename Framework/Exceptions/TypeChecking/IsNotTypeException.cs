using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions.TypeChecking
{
	/// <summary>
	/// The difference between IsNotTypeException and UnexpectedTypeException
	/// is that UnexpectedTypeException only mentions what type it is not,
	/// not what type is expected.
	/// Example of produced error messages: "Nala is not of type Dog.", 
	/// </summary>
	public class IsNotTypeException : Exception
	{
		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public IsNotTypeException(Expression<Func<object>> expression, Type expectedType)
			: this(expression, ExceptionHelper.TryFormatShortTypeName(expectedType)) { }

		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public IsNotTypeException(Expression<Func<object>> expression, string expectedTypeName)
		{
			string name = ExpressionHelper.GetText(expression);
			object value = ExpressionHelper.GetValue(expression);

			Type concreteType = value?.GetType();
			string concreteTypeName = ExceptionHelper.TryFormatShortTypeName(concreteType);

			Message = $"{concreteTypeName} {name} is not of type {expectedTypeName}.";
		}

		/// <param name="indicator">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public IsNotTypeException(object indicator, Type expectedType)
			: this(indicator, ExceptionHelper.TryFormatShortTypeName(expectedType)) { }

		/// <param name="indicator">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public IsNotTypeException(object indicator, string expectedTypeName) => Message = $"{indicator} is not of type {expectedTypeName}.";

		public override string Message { get; }
	}
}