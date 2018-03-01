//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class InfinityException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} is Infinity.";

//		public InfinityException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
