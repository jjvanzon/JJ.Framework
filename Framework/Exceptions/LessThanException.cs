using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
	/// <inheritdoc />
	public class LessThanException : ComparativeExceptionWithExpressionBase
	{
		private const string MESSAGE_TEMPLATE = "{0} is less than {1}.";
		private const string MESSAGE_WITH_LIMIT = "{0} is less than {1} of {2}.";

		/// <inheritdoc />
		public LessThanException(Expression<Func<object>> expression, object limit)
			: base(MESSAGE_TEMPLATE, expression, limit)
		{ }

		/// <inheritdoc />
		public LessThanException(string name, object limit)
			: base(MESSAGE_TEMPLATE, name, limit)
		{ }

		/// <inheritdoc />
		public LessThanException(Expression<Func<object>> expression, Expression<Func<object>> limitExpression)
			: base(MESSAGE_WITH_LIMIT, expression, limitExpression)
		{ }
	}
}
