using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
	public class IsNotTypeException<T> : IsNotTypeException
	{
		public IsNotTypeException(Expression<Func<object>> expression) : base(expression, typeof(T)) { }
	}
}