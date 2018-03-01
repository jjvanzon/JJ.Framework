
using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
	/// <inheritdoc />
	public class NotEqualException : ComparativeExceptionWithExpressionBase
	{
		protected override string MessageTemplateWithAAndB => "{0} does not equal {1}.";
		protected override string MessageTemplateWithAValueAndNoBValue => "{0} of {1} does not equal {2}.";
		protected override string MessageTemplateWithNoAValueAndWithBValue => "{0} does not equal {1} of {2}.";
		protected override string MessageTemplateWithTwoValuesAndTwoNames => "{0} of {1} does not equal {2} of {3}.";

		/// <inheritdoc />
		public NotEqualException(Expression<Func<object>> expressionA, object b)
			: base(expressionA, b) { }

		/// <inheritdoc />
		public NotEqualException(object a, object b)
			: base(a, b) { }

		/// <inheritdoc />
		public NotEqualException(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB, bool showValueA = false, bool showValueB = false)
			: base(expressionA, expressionB, showValueA, showValueB) { }

		/// <inheritdoc />
		public NotEqualException(Expression<Func<object>> expressionA, object b, bool showValueA = false)
			: base(expressionA, b, showValueA) { }

		/// <inheritdoc />	
		public NotEqualException(object a, Expression<Func<object>> expressionB, bool showValueB = false)
			: base(a, expressionB, showValueB) { }
	}
}