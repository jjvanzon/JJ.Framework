using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.Aggregates
{
	public class NotUniqueException : ExceptionWithNameTypeAndKeyBase
	{
		protected override string MessageWithName => "{0} not unique.";
		protected override string MessageWithNameAndKey => "{0} with key {1} not unique.";

		public NotUniqueException(Expression<Func<object>> expression) : base(expression) { }
		public NotUniqueException(Expression<Func<object>> expression, object key) : base(expression, key) { }
		public NotUniqueException(Type type) : base(type) { }
		public NotUniqueException(Type type, object key) : base(type, key) { }
		public NotUniqueException(string name) : base(name) { }
		public NotUniqueException(string name, object key) : base(name, key) { }
	}
}