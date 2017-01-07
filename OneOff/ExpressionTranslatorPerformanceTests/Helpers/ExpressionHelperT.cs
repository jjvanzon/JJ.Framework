using System;
using System.Linq.Expressions;
using JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators;
using JJ.Framework.Exceptions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Helpers
{
    public class ExpressionHelper<TExpressionToStringTranslator, TExpressionToValueTranslator> : IExpressionHelper
        where TExpressionToStringTranslator : IExpressionToStringTranslator, new()
        where TExpressionToValueTranslator : IExpressionToValueTranslator, new()
    {
        public string GetString<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                throw new NullException(() => expression);
            }

            var translator = new TExpressionToStringTranslator();
            translator.Visit(expression);
            return translator.Result;
        }

        public T GetValue<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                throw new NullException(() => expression);
            }

            var translator = new TExpressionToValueTranslator();
            translator.Visit(expression);
            return (T)translator.Result;
        }
    }

    // Generic overloads

    public class ExpressionHelper<TExpressionToValueTranslator>
        : ExpressionHelper<ExpressionToStringTranslator_Dummy, TExpressionToValueTranslator>
        where TExpressionToValueTranslator : IExpressionToValueTranslator, new()
    { }
}
