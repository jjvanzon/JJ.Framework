using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
    public class ExpressionToValueCustomTranslatorWrapper : IExpressionToValueTranslator
    {
        private readonly ExpressionToValueTranslator _base = new ExpressionToValueTranslator();

        public object Result => _base.Result;

        public void Visit<T>(Expression<Func<T>> expression) => _base.Visit(expression);
    }
}