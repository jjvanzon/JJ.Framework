using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class NotContainsException : Exception
	{
		private const string MESSAGE = "{0} does not contain {1}.";

		public NotContainsException(Expression<Func<object>> collectionExpression, object item)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(collectionExpression), item))
		{ }

		public NotContainsException(Expression<Func<object>> collectionexpression, Expression<Func<object>> itemExpression)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(collectionexpression), ExpressionHelper.GetText(itemExpression)))
		{ }
	}
}
