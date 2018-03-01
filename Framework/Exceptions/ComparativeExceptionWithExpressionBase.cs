using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public abstract class ComparativeExceptionWithExpressionBase : Exception
	{
		public ComparativeExceptionWithExpressionBase(string messageFormat, Expression<Func<object>> expression, object limit)
			: this(messageFormat, ExpressionHelper.GetText(expression), limit) { }

		public ComparativeExceptionWithExpressionBase(string messageFormat, string name, object limit)
			: base(string.Format(messageFormat, name, limit)) { }

		/// <summary>
		/// Only use this overload if you wish to show the text and value of the limitExpression in the exception message.
		/// If you only want to show the limit's value, use the other overload.
		/// </summary>
		public ComparativeExceptionWithExpressionBase(
			string messageFormatWithLimit,
			Expression<Func<object>> expression,
			Expression<Func<object>> limitExpression)
			: base(
				string.Format(
					messageFormatWithLimit,
					ExpressionHelper.GetText(expression),
					ExpressionHelper.GetText(limitExpression),
					ExpressionHelper.GetValue(limitExpression))) { }
	}
}