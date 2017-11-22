using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class LessThanException : Exception
	{
		private const string MESSAGE = "{0} is less than {1}.";

		public LessThanException(Expression<Func<object>> expression, object limit)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(expression), limit))
		{ }

		public LessThanException(Expression<Func<object>> expression1, Expression<Func<object>> expression2)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(expression1), ExpressionHelper.GetText(expression2)))
		{ }
	}
}
