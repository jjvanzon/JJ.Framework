using System;
using System.Linq.Expressions;

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
