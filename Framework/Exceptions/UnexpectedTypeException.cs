using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	public class UnexpectedTypeException : Exception
	{
		public UnexpectedTypeException(Expression<Func<object>> expression)
		{
			string expressionText = ExpressionHelper.GetText(expression);

			object value = ExpressionHelper.GetValue(expression);
			string typeDescription;
			if (value == null)
			{
				typeDescription = "<null>";
			}
			else
			{
				typeDescription = value.GetType().FullName;
			}

			Message = $"{expressionText} has an unexpected type: '{typeDescription}'";
		}

		public override string Message { get; }
	}
}
