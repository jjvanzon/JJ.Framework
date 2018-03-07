using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.TypeChecking
{
	/// <inheritdoc />
	public class IsTypeException<T> : IsTypeException
	{
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
		public IsTypeException(Expression<Func<object>> expression) : base(expression, typeof(T)) { }

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
		public IsTypeException(object indicator) : base(indicator, typeof(T)) { }
	}
}