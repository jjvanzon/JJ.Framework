﻿using System;
using System.Linq.Expressions;

namespace JJ.Framework.Exceptions
{
	public class IsTypeException<T> : IsTypeException
	{
		public IsTypeException(Expression<Func<object>> expression)
			: base(expression, typeof(T))
		{ }
	}
}
