using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions.TypeChecking
{
	/// <inheritdoc />
	public class IsTypeException<T> : IsTypeException
	{
		/// <inheritdoc />
		public IsTypeException(Expression<Func<object>> expression)
			: base(expression, typeof(T))
		{ }
	}
}
