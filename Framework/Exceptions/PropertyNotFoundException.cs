using System;

namespace JJ.Framework.Exceptions
{
	public class PropertyNotFoundException : Exception
	{
		public PropertyNotFoundException(Type type, string propertyName)
		{
			string typeName = type == null ? "<null>" : type.FullName;

			Message = $"Property '{propertyName}' not found on type '{typeName}'.";
		}

		public override string Message { get; }
	}
}