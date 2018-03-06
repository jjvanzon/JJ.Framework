using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	/// <summary>
	/// An exception type to which you can pass a lambda expression to identify the object the error applies to,
	/// which is then incorporated in the exception message.
	/// </summary>
	public abstract class ExceptionWithNameAndValueBase : Exception
	{
		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable..</summary>
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public ExceptionWithNameAndValueBase(
			string messageFormatWithName,
			string messageTemplateWithNameAndValue,
			Expression<Func<object>> expression)
		{
			string text = ExpressionHelper.GetText(expression);
			object value = ExpressionHelper.GetValue(expression);
			bool mustShowValue = value != null && ReflectionHelper.IsSimpleType(value);

			if (mustShowValue)
			{
				Message = string.Format(messageTemplateWithNameAndValue, text, value);
			}
			else
			{
				Message = string.Format(messageFormatWithName, text);
			}
		}

		/// <param name="name">Pass e.g. nameof(myParam)</param>
		public ExceptionWithNameAndValueBase(string messageFormatWithName, string name)
		{
			Message = string.Format(messageFormatWithName, name);
		}

		public override string Message { get; }
	}
}