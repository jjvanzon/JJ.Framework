using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace JJ.Framework.Exceptions.Comparative
{
	/// <inheritdoc />
	[PublicAPI]
	public class GreaterThanException : ComparativeExceptionBase
	{
		protected override string MessageTemplate => "{0} is greater than {1}.";

		/// <inheritdoc />
		public GreaterThanException(object a, object b)
			: base(a, b) { }

		/// <inheritdoc />
		public GreaterThanException(Expression<Func<object>> expressionA, object b)
			: base(expressionA, b) { }

		/// <inheritdoc />	
		public GreaterThanException(object a, Expression<Func<object>> expressionB)
			: base(a, expressionB) { }

		/// <inheritdoc />	
		public GreaterThanException(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB)
			: base(expressionA, expressionB) { }

		[Obsolete("Remove the showValueA or showValueB parameters. They will be determined automatically.", true)]
		public GreaterThanException(
			Expression<Func<object>> expressionA,
			Expression<Func<object>> expressionB,
			bool showValueA = false,
			bool showValueB = false) : base(expressionA, expressionB, showValueA, showValueB) => throw new NotSupportedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be determined automatically.", true)]
		public GreaterThanException(
			Expression<Func<object>> expressionA,
			object b,
			bool showValueA = false) : base(expressionA, b, showValueA)
			=> throw new NotSupportedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be determined automatically.", true)]
		public GreaterThanException(
			object a,
			Expression<Func<object>> expressionB,
			bool showValueB = false) : base(a, expressionB, showValueB) => throw new NotSupportedException();
	}
}