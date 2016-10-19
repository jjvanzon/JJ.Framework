using JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
