using System;

namespace JJ.Framework.Exceptions
{
	internal static class ExceptionHelper
	{
		/// <param name="type">nullable</param>
		public static string TryFormatFullTypeName(Type type) => type == null ? "<null>" : type.FullName;

		/// <param name="type">nullable</param>
		public static string TryFormatShortTypeName(Type type) => type == null ? "<null>" : type.Name;

		public static string FormatValue(object value) => value == null ? "<null>" : $"{value}";
	}
}
