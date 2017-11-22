using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class ContainsException : Exception
	{
		private const string MESSAGE = "{0} should not contain {1}.";

		public ContainsException(Expression<Func<object>> expression, object value)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(expression), value))
		{ }

		public ContainsException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
		{ }
	}
}
