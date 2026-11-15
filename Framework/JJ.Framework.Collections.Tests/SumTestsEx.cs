using static System.TimeSpan;
// ReSharper disable ExpressionIsAlwaysNull

namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class SumTestsEx
{
    private class TestItem
    {
        public TimeSpan TimeSpan { get; set; }
    }

    [TestMethod]
    public void Test_Sum_OverTimeSpans()
    {
        TimeSpan[] timeSpans = [ FromMinutes(2), FromMinutes(3), FromMinutes(4) ];
        TimeSpan sum = timeSpans.Sum();
        AreEqual(9, sum.TotalMinutes);
    }

    [TestMethod]
    public void Test_Sum_OverTimeSpans_WithLambda()
    {
        TestItem[] items =
        [
            new() { TimeSpan = FromMinutes(4) },
            new() { TimeSpan = FromMinutes(5) },
            new() { TimeSpan = FromMinutes(6) },
            new() { TimeSpan = FromMinutes(7) }
        ];

        TimeSpan sum = items.Sum(x => x.TimeSpan);
        AreEqual(22, sum.TotalMinutes);
    }

    [TestMethod]
    public void Test_Sum_NullException()
    {
        {
            TimeSpan[]? nullTimeSpans = null;
            Throws(() => nullTimeSpans!.Sum(), "timeSpans", "null");
        }
        {
            TestItem[]? nullItems = null;
            Throws(() => nullItems!.Sum(x => x.TimeSpan), "source", "null");
        }
        {
            Func<TestItem, TimeSpan>? nullSelector = null;
            TestItem[] notNullItems = [ ];
            Throws(() => notNullItems.Sum(nullSelector), "selector", "null");
        }
    }
}