using System;

namespace JJ.Framework.Exceptions
{
	public class ValueNotSupportedException : Exception
	{
		private const string MESSAGE_TEMPLATE = "{0} value: '{1}' is not supported.";

		public ValueNotSupportedException(object value)
		{
			Type type = value?.GetType();

			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			string formattedValue = ExceptionHelper.FormatValue(value);

			Message = string.Format(MESSAGE_TEMPLATE, typeName, formattedValue);
		}

		public override string Message { get; }
	}
}