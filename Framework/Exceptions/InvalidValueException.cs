using System;

namespace JJ.Framework.Exceptions
{
	public class InvalidValueException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Invalid {0} value: '{1}'.";

		public InvalidValueException(object value)
		{
			Type type = value?.GetType();

			string formattedValue = ExceptionHelper.FormatValue(value);
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, typeName, formattedValue);
		}

		public override string Message { get; }
	}
}
