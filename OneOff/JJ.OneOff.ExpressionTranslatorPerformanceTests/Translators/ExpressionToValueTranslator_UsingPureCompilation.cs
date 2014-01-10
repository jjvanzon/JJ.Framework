using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToValueTranslator_UsingPureCompilation : IExpressionToValueTranslator
    {
        public object Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Func<T> function = expression.Compile();
            Result = function();
        }
    }
}
