using System;

namespace JJ.Framework.Exceptions
{
	public class IsEnumException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Type {0} should not be an enum.";

		public IsEnumException(Type type)
		{
			string typeName = ExceptionHelper.TryFormatFullTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, typeName);
		}

		public override string Message { get; }
	}
}
