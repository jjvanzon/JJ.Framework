using System;

namespace JJ.Framework.Exceptions
{
	public class PropertyNotFoundException : Exception
	{
		public override string Message { get; }

		public PropertyNotFoundException(Type type, string propertyName)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			Message = $"Property '{propertyName}' not found on type '{type.Name}'.";
		}
	}
}