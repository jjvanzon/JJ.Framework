//using System;
//using System.Linq.Expressions;

//namespace JJ.Framework.Exceptions
//{
//	/// <inheritdoc />
//	public class NullOrEmptyException : ExceptionWithExpressionBase
//	{
//		private const string MESSAGE_TEMPLATE = "{0} is null or empty.";

//		public NullOrEmptyException(Expression<Func<object>> expression) : base(expression, MESSAGE_TEMPLATE) { }
//		public NullOrEmptyException(string name) : base(name, MESSAGE_TEMPLATE) { }
//	}
//}