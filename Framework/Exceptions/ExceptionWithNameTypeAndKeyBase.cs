using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;
// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions
{
	public abstract class ExceptionWithNameTypeAndKeyBase : Exception
	{
		protected abstract string MessageWithName { get; }
		protected abstract string MessageWithNameAndKey { get; }

		public ExceptionWithNameTypeAndKeyBase(Expression<Func<object>> expression)
		{
			string text = ExpressionHelper.GetText(expression);
			Message = string.Format(MessageWithName, text);
		}

		public ExceptionWithNameTypeAndKeyBase(Expression<Func<object>> expression, object key)
		{
			string text = ExpressionHelper.GetText(expression);
			Message = string.Format(MessageWithNameAndKey, text, key);
		}

		public ExceptionWithNameTypeAndKeyBase(Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			Message = string.Format(MessageWithName, typeName);
		}

		public ExceptionWithNameTypeAndKeyBase(Type type, object key)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			Message = string.Format(MessageWithNameAndKey, typeName, key);
		}

		public ExceptionWithNameTypeAndKeyBase(string name)
		{
			Message = string.Format(MessageWithName, name);
		}

		public ExceptionWithNameTypeAndKeyBase(string name, object key)
		{
			Message = string.Format(MessageWithNameAndKey, name, key);
		}

		public override string Message { get; }
	}
}
