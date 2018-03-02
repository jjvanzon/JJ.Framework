//using System;
//using System.Linq.Expressions;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Exceptions
//{
//	public class NotUniqueException : Exception
//	{
//		public NotUniqueException(Expression<Func<object>> expression)
//		{
//			string name = ExpressionHelper.GetText(expression);
//			Message = $"{name} not unique.";
//		}

//		public NotUniqueException(Expression<Func<object>> expression, object key)
//		{
//			string name = ExpressionHelper.GetText(expression);
//			Message = $"{name} with key '{key}' not unique.";
//		}

//		public NotUniqueException(Type type)
//		{
//			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
//			Message = $"{typeName} not unique.";
//		}

//		public NotUniqueException(Type type, object key)
//		{
//			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
//			Message = $"{typeName} with key '{key}' not unique.";
//		}

//		public NotUniqueException(string name)
//		{
//			Message = $"{name} not unique.";
//		}

//		public NotUniqueException(string name, object key)
//		{
//			Message = $"{name} not unique.";
//		}

//		protected NotUniqueException() { }

//		public override string Message { get; }
//	}
//}
