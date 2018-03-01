//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class NotNullOrEmptyException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} should be null or empty.";

//		public NotNullOrEmptyException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
