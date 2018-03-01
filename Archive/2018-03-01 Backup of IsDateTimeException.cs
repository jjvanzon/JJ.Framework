//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class IsDateTimeException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} should not be a DateTime.";

//		public IsDateTimeException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
