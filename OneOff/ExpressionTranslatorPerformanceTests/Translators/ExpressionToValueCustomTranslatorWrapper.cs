using JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToValueCustomTranslatorWrapper : IExpressionToValueTranslator
    {
        private ExpressionToValueTranslator _base = new ExpressionToValueTranslator();

        public object Result
        {
            get { return _base.Result; }
        }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            _base.Visit(expression);
        }
    }
}
