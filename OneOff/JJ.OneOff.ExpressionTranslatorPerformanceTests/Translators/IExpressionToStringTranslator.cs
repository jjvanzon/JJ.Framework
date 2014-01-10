using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public interface IExpressionToStringTranslator
    {
        string Result { get; }
        void Visit<T>(Expression<Func<T>> expression);
    }
}
