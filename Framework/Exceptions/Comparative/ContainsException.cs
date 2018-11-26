﻿using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.Comparative
{
	/// <inheritdoc />
	public class ContainsException : ComparativeExceptionBase
	{
		protected override string MessageTemplate => "{0} should not contain {1}.";

		/// <inheritdoc />
		public ContainsException(object a, object b)
			: base(a, b) { }

		/// <inheritdoc />
		public ContainsException(Expression<Func<object>> expressionA, object b)
			: base(expressionA, b) { }

		/// <inheritdoc />	
		public ContainsException(object a, Expression<Func<object>> expressionB)
			: base(a, expressionB) { }

		/// <inheritdoc />	
		public ContainsException(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB)
			: base(expressionA, expressionB) { }

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ContainsException(
			Expression<Func<object>> expressionA,
			Expression<Func<object>> expressionB,
			bool showValueA = false,
			bool showValueB = false) : base(expressionA, expressionB, showValueA, showValueB) => throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ContainsException(
			Expression<Func<object>> expressionA,
			object b,
			bool showValueA = false) : base(expressionA, b, showValueA)
			=> throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ContainsException(
			object a,
			Expression<Func<object>> expressionB,
			bool showValueB = false) : base(a, expressionB, showValueB) => throw new NotImplementedException();
	}
}