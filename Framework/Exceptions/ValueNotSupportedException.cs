using System;

namespace JJ.Framework.Exceptions
{
	public class ValueNotSupportedException : Exception
	{
		private const string MESSAGE = "{0} value: '{1}' is not supported.";

		public override string Message { get; }

		public ValueNotSupportedException(object value)
		{
			if (value == null)
			{
				Message = string.Format(MESSAGE, "<null>", "<null>");
			}
			else
			{
				Message = string.Format(MESSAGE, value.GetType(), value);
			}
		}
	}
}
