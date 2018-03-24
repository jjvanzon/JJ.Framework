using System;
using System.Linq.Expressions;
// ReSharper disable UnusedParameter.Local

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions.Comparative
{
	public abstract class ComparativeExceptionBase : Exception
	{
		protected abstract string MessageTemplate { get; }

		/// <summary>
		/// throw new LessThanException(() => item.Height, 10);
		/// will have message: "item.Height of 2 is less than 10."
		/// throw new NotContainsException(() => TheList, new { customerNumber, customerType });
		/// will have message: "TheList does not contain { customerNumber = 1234, customerType = Subscriber }."
		/// throw new NotEqualException(() => item1.Height, () => item2.Height);
		/// will have message: "item1.Height of 2 does not equal item2.Height of 10."
		/// </summary>
		public ComparativeExceptionBase(object a, object b) =>
			Message = string.Format(MessageTemplate, a, b);

		/// <summary>
		/// throw new LessThanException(() => item.Height, 10);
		/// will have message: "item.Height of 2 is less than 10."
		/// throw new NotContainsException(() => TheList, new { customerNumber, customerType });
		/// will have message: "TheList does not contain { customerNumber = 1234, customerType = Subscriber }."
		/// throw new NotEqualException(() => item1.Height, () => item2.Height);
		/// will have message: "item1.Height of 2 does not equal item2.Height of 10."
		/// </summary>
		public ComparativeExceptionBase(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB)
		{
			string textA = ExceptionHelper.GetTextWithValue(expressionA);
			string textB = ExceptionHelper.GetTextWithValue(expressionB);

			Message = string.Format(MessageTemplate, textA, textB);
		}

		/// <summary>
		/// throw new LessThanException(() => item.Height, 10);
		/// will have message: "item.Height of 2 is less than 10."
		/// throw new NotContainsException(() => TheList, new { customerNumber, customerType });
		/// will have message: "TheList does not contain { customerNumber = 1234, customerType = Subscriber }."
		/// throw new NotEqualException(() => item1.Height, () => item2.Height);
		/// will have message: "item1.Height of 2 does not equal item2.Height of 10."
		/// </summary>
		public ComparativeExceptionBase(Expression<Func<object>> expressionA, object b)
		{
			string textA = ExceptionHelper.GetTextWithValue(expressionA);

			Message = string.Format(MessageTemplate, textA, b);
		}

		/// <summary>
		/// throw new LessThanException(() => item.Height, 10);
		/// will have message: "item.Height of 2 is less than 10."
		/// throw new NotContainsException(() => TheList, new { customerNumber, customerType });
		/// will have message: "TheList does not contain { customerNumber = 1234, customerType = Subscriber }."
		/// throw new NotEqualException(() => item1.Height, () => item2.Height);
		/// will have message: "item1.Height of 2 does not equal item2.Height of 10."
		/// </summary>
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