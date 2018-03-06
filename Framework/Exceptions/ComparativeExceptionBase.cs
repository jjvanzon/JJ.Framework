using System;
using System.Linq.Expressions;

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions
{
	public abstract class ComparativeExceptionBase : Exception
	{
		protected abstract string MessageTemplate { get; }

		/// <param name="a">Can be both the name or the value of the object.</param>
		/// <param name="b">Can be both the name or the value of the object.</param>
		public ComparativeExceptionBase(object a, object b) =>
			Message = string.Format(MessageTemplate, a, b);

		public ComparativeExceptionBase(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB)
		{
			string textA = ExceptionHelper.GetTextWithValue(expressionA);
			string textB = ExceptionHelper.GetTextWithValue(expressionB);

			Message = string.Format(MessageTemplate, textA, textB);
		}

		/// <param name="b">Can be both the name or the value of the object.</param>
		public ComparativeExceptionBase(Expression<Func<object>> expressionA, object b)
		{
			string textA = ExceptionHelper.GetTextWithValue(expressionA);

			Message = string.Format(MessageTemplate, textA, b);
		}

		/// <param name="a">Can be both the name or the value of the object.</param>
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