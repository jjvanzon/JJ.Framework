using System;

namespace JJ.Framework.Exceptions
{
	public class NotEnumException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Type {0} is not an enum.";

		public override string Message { get; }

		public NotEnumException(Type type)
		{
			string typeName;

			if (type == null)
			{
				typeName = "<null>";
			}
			else
			{
				typeName = type.FullName;
			}

			Message = string.Format(MESSAGE_TEMPLATE, typeName);
		}
	}
}
