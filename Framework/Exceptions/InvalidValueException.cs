using System;

namespace JJ.Framework.Exceptions
{
	public class InvalidValueException : Exception
	{
		private const string MESSAGE = "Invalid {0} value: '{1}'.";

		public override string Message { get; }

		public InvalidValueException(object value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));

			Message = string.Format(MESSAGE, value.GetType().Name, value);
		}
	}
}
