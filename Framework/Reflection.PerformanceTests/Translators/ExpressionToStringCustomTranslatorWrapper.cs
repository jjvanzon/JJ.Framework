using System;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringCustomTranslatorWrapper : IExpressionToStringTranslator
    {
        ExpressionToStringTranslator _base = new ExpressionToStringTranslator();

        public string Result
        {
            get { return _base.Result; }
        }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            _base.Visit(expression);
        }
    }
}
