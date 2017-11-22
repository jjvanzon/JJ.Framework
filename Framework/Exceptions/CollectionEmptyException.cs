using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class CollectionEmptyException : Exception
	{
		private const string MESSAGE = "{0} collection is empty.";

		public CollectionEmptyException(Expression<Func<object>> expression)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(expression)))
		{ }
	}
}
