//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class NotDoubleException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} is not a double precision floating point number.";

//		public NotDoubleException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
