using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection
{
    public class NullException : Exception
    {
        public NullException(Expression<Func<object>> expression)
            : base(ExpressionHelper.GetText(expression))
        { }
    }
}
