using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.OneOff.ExpressionTranslatorPerformanceTests.Items;
using JJ.OneOff.ExpressionTranslatorPerformanceTests.Helpers;
using JJ.Framework.Exceptions;
using JJ.Framework.Logging;
using JJ.Framework.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests
{
    [TestClass]
    public class ExpressionHelperPerformanceTests
    {
        private int Repeats = 1000;

        // GetString Simple

        [TestMethod]
        public void Test_ExpressionHelper_Performance_GetString_Simple()
        {
            Item item = CreateItem();
            Expression<Func<Item>> expression = () => item;

            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingTranslators_Simple);
            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_Simple);
            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingTranslators);
            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
            //Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
            //Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
            //Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
        }

        // GetValue Simple

        [TestMethod]
        public void Test_ExpressionHelper_Performance_GetValue_Simple()
        {
            Item item = CreateItem();
            Expression<Func<Item>> expression = () => item;

            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingTranslators_Simple);
            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_Simple);
            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingTranslators);
            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingFuncCache);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingFuncCacheAndConstantHashCode);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
        }

        // GetString Composite

        [TestMethod]
        public void Test_ExpressionHelper_Performance_GetString_Composite()
        {
            Item item = CreateItem();
            Expression<Func<string>> expression = () => item.Parent.Name;

            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingTranslators_Simple);
            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_Simple);
            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingTranslators);
            Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
            //Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
            //Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
            //Test_ExpressionHelper_Performance_GetString_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
        }

        // GetValue Composite

        [TestMethod]
        public void Test_ExpressionHelper_Performance_GetValue_Composite()
        {
            Item item = CreateItem();
            Expression<Func<string>> expression = () => item.Parent.Name;

            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingTranslators_Simple);
            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_Simple);
            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingTranslators);
            Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingFuncCache);
            //Test_ExpressionHelper_Performance_GetValue_Base(expression, () => ExpressionHelpers.UsingFuncCacheAndConstantHashCode);
        }

        // NotNull Simple

        [TestMethod]
        public void Test_ExpressionHelper_Performance_NotNull_Simple()
        {
            Item item = CreateItem();
            Expression<Func<Item>> expression = () => item;

            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingTranslators_Simple);
            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_Simple);
            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingTranslators);
            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingFuncCacheAndConstantHashCode);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingFuncCache);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
        }

        // NotNull Composite

        [TestMethod]
        public void Test_ExpressionHelper_Performance_NotNull_Composite()
        {
            Item item = CreateItem();
            Expression<Func<string>> expression = () => item.Parent.Name;

            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingTranslators_Simple);
            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_Simple);
            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingTranslators);
            Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingFuncCacheAndConstantHashCode);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingFuncCache);
            //Test_ExpressionHelper_Performance_NotNull_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
        }

        // Not Postponing String Retrieval Simple

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Simple()
        //{
        //    Item item = CreateItem();
        //    Expression<Func<Item>> expression = () => item;
        //
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingFuncCache);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingFuncCacheAndConstantHashCode);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingExpressionTranslators);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
        //}

        // Not Postponing String Retrieval Composite

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Composite()
        //{
        //    Item item = CreateItem();
        //    Expression<Func<string>> expression = () => item.Parent.Name;
        //
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingPureCompilation);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingFuncCache);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingFuncCacheAndConstantHashCode);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingMemberInfos);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingExpressionTranslators);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingCustomTranslators);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_EntryPointExpensive);
        //    Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base(expression, () => ExpressionHelpers.UsingCustomTranslators_WithLessMethods);
        //}

        // Reusable methods

        private void Test_ExpressionHelper_Performance_GetString_Base<T>(
            Expression<Func<T>> expression,
            Expression<Func<IExpressionHelper>> expressionHelperExpression)
        {
            IExpressionHelper expressionHelper = ExpressionHelper.GetValue(expressionHelperExpression);
            string text = ExpressionHelper.GetText(expressionHelperExpression);

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < Repeats; i++)
            {
                expressionHelper.GetString(expression);
            }
            stopwatch.Stop();
            TraceLogger.LogPerformance(text, stopwatch, Repeats);
        }


        public void Test_ExpressionHelper_Performance_GetValue_Base<T>(
            Expression<Func<T>> expression,
            Expression<Func<IExpressionHelper>> expressionHelperExpression)
        {
            IExpressionHelper expressionHelper = ExpressionHelper.GetValue(expressionHelperExpression);
            string text = ExpressionHelper.GetText(expressionHelperExpression);

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < Repeats; i++)
            {
                expressionHelper.GetValue(expression);
            }
            stopwatch.Stop();
            TraceLogger.LogPerformance(text, stopwatch, Repeats);
        }

        public void Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Base<T>(
            Expression<Func<T>> expression,
            Expression<Func<IExpressionHelper>> expressionHelperExpression)
        {
            IExpressionHelper expressionHelper = ExpressionHelper.GetValue(expressionHelperExpression);
            string text = ExpressionHelper.GetText(expressionHelperExpression);

            Item item = CreateItem();
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < Repeats; i++)
            {
                NotNull_NotPostponingStringRetrieval(expression, expressionHelper);
            }
            stopwatch.Stop();
            TraceLogger.LogPerformance(text, stopwatch, Repeats);
        }

        private void NotNull_NotPostponingStringRetrieval<T>(Expression<Func<T>> expression, IExpressionHelper expressionHelper)
        {
            string text = expressionHelper.GetString(expression);
            if (expressionHelper.GetValue(expression) == null)
            {
                throw new Exception(String.Format("{0} cannot be null.", text));
            }
        }

        public void Test_ExpressionHelper_Performance_NotNull_Base<T>(
            Expression<Func<T>> expression,
            Expression<Func<IExpressionHelper>> expressionHelperExpression)
        {
            IExpressionHelper expressionHelper = ExpressionHelper.GetValue(expressionHelperExpression);
            string text = ExpressionHelper.GetText(expressionHelperExpression);

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < Repeats; i++)
            {
                NotNull_Base(expression, expressionHelper);
            }
            stopwatch.Stop();
            TraceLogger.LogPerformance(text, stopwatch, Repeats);
        }

        private void NotNull_Base<T>(Expression<Func<T>> expression, IExpressionHelper expressionHelper)
        {
            if (expressionHelper.GetValue(expression) == null)
            {
                throw new Exception(String.Format("{0} cannot be null.", expressionHelper.GetString(expression)));
            }
        }

        // Helpers

        private Item CreateItem()
        {
            Item parent = new Item();

            Item item = new Item { Parent = parent };

            parent.Name = "Parent";
            
            return item;
        }

        // Not normalizable

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_GetValue_Simple_UsingFunc()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        ExpressionHelper_UsingFunc.GetValue(() => item);
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_GetValue_Composite_UsingFunc()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        ExpressionHelper_UsingFunc.GetValue(() => item.Parent.Name);
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_Simple_UsingObjectAndString()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_UsingObjectAndString(item, "item");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_Simple_UsingFunc()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_UsingFunc(() => item, "item");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_Composite_UsingObjectAndString()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_UsingObjectAndString(item.Parent.Name, "item.Parent.Name");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_Composite_UsingFunc()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_UsingFunc(() => item.Parent.Name, "item.Parent.Name");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //private void NotNull_UsingObjectAndString(object obj, string text)
        //{
        //    if (obj == null)
        //    {
        //        throw new IsNullException(text);
        //    }
        //}

        //private void NotNull_UsingFunc(Func<object> obj, string text)
        //{
        //    if (obj() == null)
        //    {
        //        throw new IsNullException(text);
        //    }
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Simple_UsingObjectAndString()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_NotPostponingStringRetrieval_UsingObjectAndString(item, "item");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Simple_UsingFunc()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_NotPostponingStringRetrieval_UsingFunc(() => item, "item");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Composite_UsingObjectAndString()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_NotPostponingStringRetrieval_UsingObjectAndString(item.Parent.Name, "item.Parent.Name");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //[TestMethod]
        //public void Test_ExpressionHelper_Performance_NotNull_NotPostponingStringRetrieval_Composite_UsingFunc()
        //{
        //    Item item = CreateItem();
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    for (int i = 0; i < Repeats; i++)
        //    {
        //        NotNull_NotPostponingStringRetrieval_UsingFunc(() => item.Parent.Name, "item.Parent.Name");
        //    }
        //    stopwatch.Stop();
        //    Log.Performance(stopwatch, Repeats);
        //}

        //private void NotNull_NotPostponingStringRetrieval_UsingObjectAndString(object obj, string text)
        //{
        //    if (obj == null)
        //    {
        //        throw new IsNullException(text);
        //    }
        //}

        //private void NotNull_NotPostponingStringRetrieval_UsingFunc(Func<object> obj, string text)
        //{
        //    if (obj() == null)
        //    {
        //        throw new IsNullException(text);
        //    }
        //}
    }
}
