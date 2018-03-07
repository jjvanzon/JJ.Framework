using System;

namespace JJ.Framework.Exceptions.TypeChecking
{
	public class NotEnumTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Type {0} is not an enum.";

		/// <summary>
		/// throw new NotEnumTypeException(typeof(Customer));
		/// will have message: "Type Customer is not an enum."
		/// </summary>
		public NotEnumTypeException(Type type)
		{
			string typeName =  ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, typeName);
		}

		public override string Message { get; }
	}
}
