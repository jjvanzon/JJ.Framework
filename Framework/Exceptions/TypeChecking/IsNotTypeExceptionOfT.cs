using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.TypeChecking
{
	/// <inheritdoc />
	public class IsNotTypeException<T> : IsNotTypeException
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
		public IsNotTypeException(Expression<Func<object>> expression) : base(expression, typeof(T)) { }

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
		public IsNotTypeException(object indicator) : base(indicator, typeof(T)) { }
	}
}