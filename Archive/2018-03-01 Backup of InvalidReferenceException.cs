//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class InvalidReferenceException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} not found in list.";

//		public InvalidReferenceException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
