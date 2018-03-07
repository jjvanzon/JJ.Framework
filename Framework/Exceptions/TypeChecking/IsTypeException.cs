using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.TypeChecking
{
	public class IsTypeException : Exception
	{
		private const string MESSAGE_TEMPLATE = "{0} cannot be of type {1}.";

		/// <summary>
		/// These will all have message: "room.MyPet cannot be of type Cat.""
		/// throw new IsTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsTypeException(() => room.MyPet, "Cat");
		/// These will all have message: "{ number = 10 } cannot be of type Int32.":
		/// throw new IsTypeException&lt;int&gt;(new { number });
		/// throw new IsTypeException(new { number }, typeof(int));
		/// throw new IsTypeException(new { number }, "Int32"));
		/// </summary>
		public IsTypeException(Expression<Func<object>> expression, Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, ExceptionHelper.GetTextWithValue(expression), typeName);
		}

		/// <summary>
		/// These will all have message: "room.MyPet cannot be of type Cat.""
		/// throw new IsTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsTypeException(() => room.MyPet, "Cat");
		/// These will all have message: "{ number = 10 } cannot be of type Int32.":
		/// throw new IsTypeException&lt;int&gt;(new { number });
		/// throw new IsTypeException(new { number }, typeof(int));
		/// throw new IsTypeException(new { number }, "Int32"));
		/// </summary>
		public IsTypeException(Expression<Func<object>> expression, string typeName)
		{
			Message = string.Format(MESSAGE_TEMPLATE, ExceptionHelper.GetTextWithValue(expression), typeName);
		}

		/// <summary>
		/// throw new IsTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsTypeException(() => room.MyPet, "Cat");
		/// will all have message: "room.MyPet cannot be of type Cat."
		/// throw new IsTypeException&lt;int&gt;(new { number });
		/// throw new IsTypeException(new { number }, typeof(int));
		/// throw new IsTypeException(new { number }, "Int32"));
		/// will all have message: "{ number = 10 } cannot be of type Int32."
		/// </summary>
		public IsTypeException(object indicator, Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);

			Message = string.Format(MESSAGE_TEMPLATE, indicator, typeName);
		}

		/// <summary>
		/// throw new IsTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsTypeException(() => room.MyPet, "Cat");
		/// will all have message: "room.MyPet cannot be of type Cat."
		/// throw new IsTypeException&lt;int&gt;(new { number });
		/// throw new IsTypeException(new { number }, typeof(int));
		/// throw new IsTypeException(new { number }, "Int32"));
		/// will all have message: "{ number = 10 } cannot be of type Int32."
		/// </summary>
		public IsTypeException(object indicator, string typeName)
		{
			Message = string.Format(MESSAGE_TEMPLATE, indicator, typeName);
		}

		public override string Message { get; }
	}
}