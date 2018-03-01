using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
	/// <inheritdoc />
	public class GreaterThanOrEqualException : ComparativeExceptionWithExpressionBase
	{
		private const string MESSAGE_TEMPLATE = "{0} is greater than or equal to {1}.";
		private const string MESSAGE_FORMAT_WITH_LIMIT = "{0} is greater than or equal to {1} of {2}.";

		/// <inheritdoc />
		public GreaterThanOrEqualException(Expression<Func<object>> expression, object limit)
			: base(MESSAGE_TEMPLATE, expression, limit)
		{ }

		/// <inheritdoc />
		public GreaterThanOrEqualException(string name, object limit)
			: base(MESSAGE_TEMPLATE, name, limit)
		{ }

		/// <inheritdoc />
		public GreaterThanOrEqualException(Expression<Func<object>> expression, Expression<Func<object>> limitExpression)
			: base(MESSAGE_FORMAT_WITH_LIMIT, expression, limitExpression)
		{ }
	}
}
