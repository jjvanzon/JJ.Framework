using System;

namespace JJ.Framework.Exceptions
{
	public class PropertyNotFoundException : Exception
	{
		public PropertyNotFoundException(Type type, string propertyName)
		{
			string typeName = ExceptionHelper.TryFormatFullTypeName(type);

			Message = $"Property '{propertyName}' not found on type '{typeName}'.";
		}

		public override string Message { get; }
	}
}