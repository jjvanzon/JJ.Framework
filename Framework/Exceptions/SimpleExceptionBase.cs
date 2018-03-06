using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	/// <summary> An exception type to which you can pass a lambda expression to identify the object the error applies to, which is then incorporated in the exception message. </summary>
	public abstract class SimpleExceptionBase : Exception
	{
		/// <summary>The passed lambda expression's text is incorporated in the exception message.</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public SimpleExceptionBase(string messageTemplate, Expression<Func<object>> expression)
			: this(messageTemplate, ExpressionHelper.GetText(expression))
		{ }

		/// <param name="name">Pass e.g. nameof(myParam)</param>
		public SimpleExceptionBase(string messageTemplate, string name) => Message = string.Format(messageTemplate, name);

		public override string Message { get; }
	}
}
