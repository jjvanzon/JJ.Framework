using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
    public class ExpressionToStringCustomTranslatorWrapper : IExpressionToStringTranslator
    {
        private readonly ExpressionToStringTranslator _base = new ExpressionToStringTranslator();

        public string Result => _base.Result;

        public void Visit<T>(Expression<Func<T>> expression) => _base.Visit(expression);
    }
}