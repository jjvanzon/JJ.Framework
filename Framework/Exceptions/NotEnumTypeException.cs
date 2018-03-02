using System;

namespace JJ.Framework.Exceptions
{
	public class NotEnumTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Type {0} is not an enum.";

		public NotEnumTypeException(Type type)
		{
			string typeName =  ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, typeName);
		}

		public override string Message { get; }
	}
}
