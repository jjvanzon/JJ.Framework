//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class NotInfinityException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} should be Infinity.";

//		public NotInfinityException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
