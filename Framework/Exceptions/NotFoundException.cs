using System;

namespace JJ.Framework.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(Type type, object key)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = $"{typeName} with key '{key}' not found.";
		}

		public override string Message { get; }
	}
}