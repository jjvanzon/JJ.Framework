using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Legacy
{
    /// <inheritdoc cref="_nullexception" />
    public class NullException : Exception
    {
        private const string MESSAGE = "{0} cannot be null.";

    /// <inheritdoc cref="_nullexception" />
        public NullException(Expression<Func<object>> expression)
            : base(String.Format(MESSAGE, ExpressionHelper.GetText(expression)))
        { }
    }
}
