using System;
using System.Linq.Expressions;
// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions.Basic
{
	/// <summary>
	/// throw new NullException(() => item.Parent);
	/// will have message: "item.Parent is null."
	/// throw new NotIntegerException(() => height);
	/// will have message: "height of q12 is not an integer number."
	/// throw new NullException(nameof(myParam));
	/// will have message: "myParam is null."
	/// throw new InvalidReferenceException(new { customerNumber, customerType });
	/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not found in list."
	/// throw new NotIntegerException(height);
	/// will have message: "10q is not an integer number".
	/// </summary>
	public abstract class BasicExceptionBase : Exception
	{
		protected abstract string MessageTemplate { get; }

		/// <summary>
		/// throw new NullException(() => item.Parent);
		/// will have message: "item.Parent is null."
		/// throw new NotIntegerException(() => height);
		/// will have message: "height of q12 is not an integer number."
		/// throw new NullException(nameof(myParam));
		/// will have message: "myParam is null."
		/// throw new InvalidReferenceException(new { customerNumber, customerType });
		/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not found in list."
		/// throw new NotIntegerException(height);
		/// will have message: "10q is not an integer number".
		/// </summary>
		public BasicExceptionBase(Expression<Func<object>> expression)
		{
			string text = ExceptionHelper.GetTextWithValue(expression);
			Message = string.Format(MessageTemplate, text);
		}

		/// <summary>
		/// throw new NullException(() => item.Parent);
		/// will have message: "item.Parent is null."
		/// throw new NotIntegerException(() => height);
		/// will produce an exception like: "height of q12 is not an integer number."
		/// throw new NullException(nameof(myParam));
		/// will produce the exception message: "myParam is null."
		/// throw new InvalidReferenceException(new { customerNumber, customerType });
		/// will produce an exception like: "{ customerNumber = 1234, customerType = Subscriber } not found in list."
		/// throw new NotIntegerException(height);
		/// will produce an exception like: "10q is not an integer number".
		/// </summary>
		public BasicExceptionBase(object indicator) => Message = string.Format(MessageTemplate, indicator);

		public override string Message { get; }
	}
}
