using JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators;
using JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Helpers
{
    public static class ExpressionHelpers
    {
        public static readonly IExpressionHelper UsingMemberInfos =
            new ExpressionHelper<ExpressionToStringTranslator_UsingMemberInfos, ExpressionToValueTranslator_UsingMemberInfos>();

        public static readonly IExpressionHelper UsingTranslators_Simple =
            new ExpressionHelper<ExpressionToStringTranslator_Simple, ExpressionToValueTranslator_Simple>();

        public static readonly IExpressionHelper UsingTranslators =
            new ExpressionHelper<ExpressionToStringTranslator, ExpressionToValueTranslator>();

        public static readonly IExpressionHelper UsingCustomTranslators_Simple =
            new ExpressionHelper<ExpressionToStringCustomTranslator_Simple, ExpressionToValueCustomTranslator_Simple>();

        public static readonly IExpressionHelper UsingCustomTranslators =
            new ExpressionHelper<ExpressionToStringCustomTranslatorWrapper, ExpressionToValueCustomTranslatorWrapper>();

        public static readonly IExpressionHelper UsingCustomTranslators_EntryPointExpensive =
            new ExpressionHelper<ExpressionToStringCustomTranslator_EntryPointExpensive, ExpressionToValueCustomTranslator_EntryPointExpensive>();

        public static readonly IExpressionHelper UsingPureCompilation =
            new ExpressionHelper<ExpressionToValueTranslator_UsingPureCompilation>();

        public static readonly IExpressionHelper UsingCustomTranslators_WithLessMethods =
            new ExpressionHelper<ExpressionToStringCustomTranslator_WithLessMethods, ExpressionToValueCustomTranslator_WithLessMethods>();

        public static readonly IExpressionHelper UsingFuncCache =
            new ExpressionHelper<ExpressionToValueTranslator_UsingFuncCache>();

        public static readonly IExpressionHelper UsingFuncCacheAndConstantHashCode =
            new ExpressionHelper<ExpressionToValueTranslator_UsingFuncCacheAndConstantHashCode>();
    }
}
