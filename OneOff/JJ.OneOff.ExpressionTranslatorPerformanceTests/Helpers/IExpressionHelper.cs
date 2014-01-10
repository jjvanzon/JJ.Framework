using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Helpers
{
    public interface IExpressionHelper
    {
        string GetString<T>(Expression<Func<T>> expression);
        T GetValue<T>(Expression<Func<T>> expression);
    }
}
