using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class NotUniqueException : Exception
	{
		private const string MESSAGE_TEMPLATE = "{0} not unique.";

		public NotUniqueException(Expression<Func<object>> expression)
			: this(string.Format(MESSAGE_TEMPLATE, ExpressionHelper.GetText(expression)))
		{ }

		public NotUniqueException(string message)
			: base(message)
		{ }
	}
}
