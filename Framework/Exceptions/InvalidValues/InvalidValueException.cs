using System;

namespace JJ.Framework.Exceptions.InvalidValues
{
	public class InvalidValueException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Invalid {0} value: '{1}'.";

		/// <summary>
		/// throw new InvalidValueException(customerType);
		/// will have message: "Invalid CustomerType value: 'Undefined'."
		/// </summary>
		public InvalidValueException(object value)
		{
			Type type = value?.GetType();

			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			string formattedValue = ExceptionHelper.FormatValue(value);

			Message = string.Format(MESSAGE_TEMPLATE, typeName, formattedValue);
		}

		public override string Message { get; }
	}
}
