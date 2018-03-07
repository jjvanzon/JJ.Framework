using System;

namespace JJ.Framework.Exceptions.TypeChecking
{
	public class IsEnumTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Type {0} cannot be an enum.";

		/// <summary>
		/// throw new IsEnumTypeException(myType)
		/// will have message: "Type Customer cannot be an enum."
		/// </summary>
		public IsEnumTypeException(Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, typeName);
		}

		public override string Message { get; }
	}
}
