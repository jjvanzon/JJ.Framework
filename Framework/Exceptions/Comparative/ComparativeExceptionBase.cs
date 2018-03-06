using System;
using System.Linq.Expressions;

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions.Comparative
{
	public abstract class ComparativeExceptionBase : Exception
	{
		protected abstract string MessageTemplate { get; }

		/// <param name="a">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		/// <param name="b">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public ComparativeExceptionBase(object a, object b) =>
			Message = string.Format(MessageTemplate, a, b);

		public ComparativeExceptionBase(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB)
		{
			string textA = ExceptionHelper.GetTextWithValue(expressionA);
			string textB = ExceptionHelper.GetTextWithValue(expressionB);

			Message = string.Format(MessageTemplate, textA, textB);
		}

		/// <param name="b">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public ComparativeExceptionBase(Expression<Func<object>> expressionA, object b)
		{
			string textA = ExceptionHelper.GetTextWithValue(expressionA);

			Message = string.Format(MessageTemplate, textA, b);
		}

		/// <param name="a">
		/// A name, value or anonymous type, that indicates the object it is about.
		/// Examples: "nameof(myParam)", "new { customerNumber, customerType }", "10".
		/// The anonymous types translate to e.g. "{ customerNumber = 1234, customerType = Subscriber }" in the message.
		/// </param>
		public ComparativeExceptionBase(object a, Expression<Func<object>> expressionB)
		{
			string textB = ExceptionHelper.GetTextWithValue(expressionB);

			Message = string.Format(MessageTemplate, a, textB);
		}

		public override string Message { get; }

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ComparativeExceptionBase(
			Expression<Func<object>> expressionA,
			Expression<Func<object>> expressionB,
			bool showValueA = false,
			bool showValueB = false) => throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ComparativeExceptionBase(
			Expression<Func<object>> expressionA,
			object b,
			bool showValueA = false) => throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ComparativeExceptionBase(
			object a,
			Expression<Func<object>> expressionB,
			bool showValueB = false) => throw new NotImplementedException();
	}
}