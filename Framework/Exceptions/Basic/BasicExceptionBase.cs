using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.Basic
{
	/// <summary>
	/// An exception type to which you can pass a lambda expression to identify the object the error applies to,
	/// which is then incorporated in the exception message as well as the value if applicable.
	/// </summary>
	public abstract class BasicExceptionBase : Exception
	{
		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public BasicExceptionBase(string messageTemplate, Expression<Func<object>> expression)
		{
			string text = ExceptionHelper.GetTextWithValue(expression);
			Message = string.Format(messageTemplate, text);
		}

		/// <param name="indicator">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public BasicExceptionBase(string messageTemplate, object indicator) => Message = string.Format(messageTemplate, indicator);

		public override string Message { get; }
	}
}
