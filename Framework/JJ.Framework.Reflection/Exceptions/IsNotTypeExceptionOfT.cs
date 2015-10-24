using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Exceptions
{
    public class IsNotTypeException<T> : IsNotTypeException
    {
        public IsNotTypeException(Expression<Func<object>> expression)
            : base(expression, typeof(T))
        { }
    }
}
