//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class NaNException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} is NaN.";

//		public NaNException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
