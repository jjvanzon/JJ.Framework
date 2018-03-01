using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
	/// <inheritdoc />
	public class GreaterThanException : ComparativeExceptionWithExpressionBase
	{
		private const string MESSAGE_TEMPLATE = "{0} is greater than {1}.";
		private const string MESSAGE_FORMAT_WITH_LIMIT = "{0} is greater than {1} of {2}.";

		/// <inheritdoc />
		public GreaterThanException(Expression<Func<object>> expression, object limit)
			: base(MESSAGE_TEMPLATE, expression, limit)
		{ }

		/// <inheritdoc />
		public GreaterThanException(string name, object limit)
			: base(MESSAGE_TEMPLATE, name, limit)
		{ }

		/// <inheritdoc />
		public GreaterThanException(Expression<Func<object>> expression, Expression<Func<object>> limitExpression)
			: base(MESSAGE_FORMAT_WITH_LIMIT, expression, limitExpression)
		{ }
	}
}
