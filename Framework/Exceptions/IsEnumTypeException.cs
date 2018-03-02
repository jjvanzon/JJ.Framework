using System;

namespace JJ.Framework.Exceptions
{
	public class IsEnumTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Type {0} cannot be an enum.";

		public IsEnumTypeException(Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, typeName);
		}

		public override string Message { get; }
	}
}
