using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringTranslator_Dummy : ExpressionVisitor, IExpressionToStringTranslator
    {
        public string Result { get; set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Result = "Dummy text";
        }
    }
}