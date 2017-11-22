using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class ZeroException : Exception
	{
		private const string MESSAGE = "{0} is 0.";

		public ZeroException(Expression<Func<object>> expression)
			: base(string.Format(MESSAGE, ExpressionHelper.GetText(expression)))
		{ }
	}
}
