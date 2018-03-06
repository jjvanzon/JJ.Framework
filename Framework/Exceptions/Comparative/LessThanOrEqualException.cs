using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.Comparative
{
	/// <inheritdoc />
	public class LessThanOrEqualException : ComparativeExceptionBase
	{
		protected override string MessageTemplate => "{0} is less than or equal to {1}.";

		/// <inheritdoc />
		public LessThanOrEqualException(object a, object b)
			: base(a, b) { }

		/// <inheritdoc />
		public LessThanOrEqualException(Expression<Func<object>> expressionA, object b)
			: base(expressionA, b) { }

		/// <inheritdoc />	
		public LessThanOrEqualException(object a, Expression<Func<object>> expressionB)
			: base(a, expressionB) { }

		/// <inheritdoc />	
		public LessThanOrEqualException(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB)
			: base(expressionA, expressionB) { }

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public LessThanOrEqualException(
			Expression<Func<object>> expressionA,
			Expression<Func<object>> expressionB,
			bool showValueA = false,
			bool showValueB = false) : base(expressionA, expressionB, showValueA, showValueB) => throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public LessThanOrEqualException(
			Expression<Func<object>> expressionA,
			object b,
			bool showValueA = false) : base(expressionA, b, showValueA)
			=> throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public LessThanOrEqualException(
			object a,
			Expression<Func<object>> expressionB,
			bool showValueB = false) : base(a, expressionB, showValueB) => throw new NotImplementedException();
	}
}