using System;

namespace JJ.Framework.Exceptions
{
	public class NotEnumException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Type {0} is not an enum.";

		public NotEnumException(Type type)
		{
			string typeName =  ExceptionHelper.TryFormatFullTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, typeName);
		}

		public override string Message { get; }
	}
}
