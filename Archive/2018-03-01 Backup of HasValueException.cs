﻿//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class HasValueException : Exception
//	{
//		private const string MESSAGE_TEMPLATE = "{0} should not have a value.";

//		public HasValueException(Expression<Func<object>> expression)
//			: base(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
//		{ }
//	}
//}
