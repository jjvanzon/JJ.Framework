using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.Aggregates
{
	public class NotFoundException : ExceptionWithNameTypeAndKeyBase
	{
		protected override string MessageWithName => "{0} not found.";
		protected override string MessageWithNameAndKey => "{0} with key {1} not found.";

		/// <inheritdoc />
		public NotFoundException(Expression<Func<object>> expression) : base(expression) { }

		/// <inheritdoc />
		public NotFoundException(Expression<Func<object>> expression, object key) : base(expression, key) { }

		/// <inheritdoc />
		public NotFoundException(Type type) : base(type) { }

		/// <inheritdoc />
		public NotFoundException(Type type, object key) : base(type, key) { }

		/// <inheritdoc />
		public NotFoundException(string typeName) : base(typeName) { }

		/// <inheritdoc />
		public NotFoundException(string typeName, object key) : base(typeName, key) { }
	}
}