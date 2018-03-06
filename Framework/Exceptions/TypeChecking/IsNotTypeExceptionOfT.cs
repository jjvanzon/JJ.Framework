using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.TypeChecking
{
	/// <inheritdoc />
	public class IsNotTypeException<T> : IsNotTypeException
	{
		/// <inheritdoc />
		public IsNotTypeException(Expression<Func<object>> expression) : base(expression, typeof(T)) { }
	}
}