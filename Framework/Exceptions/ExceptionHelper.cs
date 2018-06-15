using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	internal static class ExceptionHelper
	{
		/// <param name="type">nullable</param>
		public static string TryFormatFullTypeName(Type type) => type == null ? "<null>" : type.FullName;

		/// <param name="type">nullable</param>
		public static string TryFormatShortTypeName(Type type) => type == null ? "<null>" : type.Name;

		public static string FormatValue(object value) => value == null ? "<null>" : $"{value}";

		/// <summary>
		/// Will return a string in the format "{something} of {value}", e.g. "height of 0".
		/// Will extract the text and the value from the expression.
		/// If the value is a simple type and not empty, it will be put in the returned text.
		/// </summary>
		public static string GetTextWithValue(Expression<Func<object>> expression)
        {
            string text = ExpressionHelper.GetText(expression);
            object value = ExpressionHelper.GetValue(expression);
            bool mustShowValue = GetMustShowValue(value);
            if (mustShowValue) text += $" of {value}";
            return text;
        }

        private static bool GetMustShowValue(object value)
        {
            if (ReflectionHelper.IsSimpleType(value) && !string.IsNullOrEmpty(Convert.ToString(value)))
            {
                return true;
            }

            bool isType = value?.GetType().IsAssignableTo<Type>() ?? default;

            return isType;
        }
	}
}
