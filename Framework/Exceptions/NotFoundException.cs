using System;

namespace JJ.Framework.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(Type type, object key)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			Message = $"{type.Name} with key '{key}' not found.";
		}

		public override string Message { get; }
	}
}