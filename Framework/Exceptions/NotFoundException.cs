using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
	public class NotFoundException : ExceptionWithNameTypeAndKeyBase
	{
		protected override string MessageWithName => "{0} not found.";
		protected override string MessageWithNameAndKey => "{0} with key {1} not found.";

		public NotFoundException(Expression<Func<object>> expression) : base(expression) { }
		public NotFoundException(Expression<Func<object>> expression, object key) : base(expression, key) { }
		public NotFoundException(Type type) : base(type) { }
		public NotFoundException(Type type, object key) : base(type, key) { }
		public NotFoundException(string name) : base(name) { }
		public NotFoundException(string name, object key) : base(name, key) { }
	}
}