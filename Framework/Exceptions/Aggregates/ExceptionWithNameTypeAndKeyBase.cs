using System;
using System.Linq.Expressions;

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions.Aggregates
{
	public abstract class ExceptionWithNameTypeAndKeyBase : Exception
	{
		protected abstract string MessageWithName { get; }
		protected abstract string MessageWithNameAndKey { get; }

		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public ExceptionWithNameTypeAndKeyBase(Expression<Func<object>> expression)
		{
			string text = ExceptionHelper.GetTextWithValue(expression);
			Message = string.Format(MessageWithName, text);
		}

		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		/// <param name="key">
		/// A name, value or anonymous type, that indicates key.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public ExceptionWithNameTypeAndKeyBase(Expression<Func<object>> expression, object key)
		{
			string text = ExceptionHelper.GetTextWithValue(expression);
			Message = string.Format(MessageWithNameAndKey, text, key);
		}

		public ExceptionWithNameTypeAndKeyBase(Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			Message = string.Format(MessageWithName, typeName);
		}

		/// <param name="key">
		/// A name, value or anonymous type, that indicates key.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public ExceptionWithNameTypeAndKeyBase(Type type, object key)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			Message = string.Format(MessageWithNameAndKey, typeName, key);
		}

		public ExceptionWithNameTypeAndKeyBase(string typeName) => Message = string.Format(MessageWithName, typeName);

		/// <param name="key">
		/// A name, value or anonymous type, that indicates key.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public ExceptionWithNameTypeAndKeyBase(string typeName, object key) => Message = string.Format(MessageWithNameAndKey, typeName, key);

		public override string Message { get; }
	}
}