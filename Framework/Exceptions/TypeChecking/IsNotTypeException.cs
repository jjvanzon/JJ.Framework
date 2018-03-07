using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions.TypeChecking
{
	/// <summary>
	/// The difference between IsNotTypeException and UnexpectedTypeException
	/// is that UnexpectedTypeException only mentions what type it is not,
	/// not what type is expected.
	/// Example of produced error messages: "Nala is not of type Dog.", 
	/// </summary>
	public class IsNotTypeException : Exception
	{
		/// <summary>
		/// These will all have message: "Dog room.MyPet is not of type Cat.":
		/// throw new IsNotTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsNotTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsNotTypeException(() => room.MyPet, "Cat");
		/// These will all have message: "{ number = A } is not of type Int32.":
		/// throw new IsNotTypeException&lt;int&gt;(new { number });
		/// throw new IsNotTypeException(new { number }, typeof(int));
		/// throw new IsNotTypeException(new { number }, "Int32"));
		/// </summary>
		public IsNotTypeException(Expression<Func<object>> expression, Type expectedType)
			: this(expression, ExceptionHelper.TryFormatShortTypeName(expectedType)) { }

		/// <summary>
		/// These will all have message: "Dog room.MyPet is not of type Cat.":
		/// throw new IsNotTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsNotTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsNotTypeException(() => room.MyPet, "Cat");
		/// These will all have message: "{ number = A } is not of type Int32.":
		/// throw new IsNotTypeException&lt;int&gt;(new { number });
		/// throw new IsNotTypeException(new { number }, typeof(int));
		/// throw new IsNotTypeException(new { number }, "Int32"));
		/// </summary>
		public IsNotTypeException(Expression<Func<object>> expression, string expectedTypeName)
		{
			string name = ExceptionHelper.GetTextWithValue(expression);
			object value = ExpressionHelper.GetValue(expression);

			Type concreteType = value?.GetType();
			string concreteTypeName = ExceptionHelper.TryFormatShortTypeName(concreteType);

			Message = $"{concreteTypeName} {name} is not of type {expectedTypeName}.";
		}

		/// <summary>
		/// These will all have message: "Dog room.MyPet is not of type Cat.":
		/// throw new IsNotTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsNotTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsNotTypeException(() => room.MyPet, "Cat");
		/// These will all have message: "{ number = A } is not of type Int32.":
		/// throw new IsNotTypeException&lt;int&gt;(new { number });
		/// throw new IsNotTypeException(new { number }, typeof(int));
		/// throw new IsNotTypeException(new { number }, "Int32"));
		/// </summary>
		public IsNotTypeException(object indicator, Type expectedType)
			: this(indicator, ExceptionHelper.TryFormatShortTypeName(expectedType)) { }

		/// <summary>
		/// These will all have message: "Dog room.MyPet is not of type Cat.":
		/// throw new IsNotTypeException&lt;Cat&gt;(() => room.MyPet);
		/// throw new IsNotTypeException(() => room.MyPet, typeof(Cat));
		/// throw new IsNotTypeException(() => room.MyPet, "Cat");
		/// These will all have message: "{ number = A } is not of type Int32.":
		/// throw new IsNotTypeException&lt;int&gt;(new { number });
		/// throw new IsNotTypeException(new { number }, typeof(int));
		/// throw new IsNotTypeException(new { number }, "Int32"));
		/// </summary>
		public IsNotTypeException(object indicator, string expectedTypeName) => Message = $"{indicator} is not of type {expectedTypeName}.";

		public override string Message { get; }
	}
}