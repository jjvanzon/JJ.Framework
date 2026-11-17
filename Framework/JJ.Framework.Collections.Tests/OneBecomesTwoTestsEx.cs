// ReSharper disable ExpressionIsAlwaysNull
namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class OneBecomesTwoTestsEx
{
    [TestMethod]
    public void Test_OneBecomesTwo()
    {
        {
            int[] oneItem = [ 1 ];
            int[] oneBecomesTwo = oneItem.OneBecomesTwo();
            IsTrue(oneBecomesTwo.SequenceEqual([ 1, 1 ]));
        }
        {
            int[] twoItems = [ 1, 2 ];
            int[] twoStaysTwo = twoItems.OneBecomesTwo();
            IsTrue(twoStaysTwo.SequenceEqual([ 1, 2 ]));
        }
        {
            int[] threeItems = [ 1, 2, 3 ];
            int[] threeStaysThree = threeItems.OneBecomesTwo();
            IsTrue(threeStaysThree.SequenceEqual([ 1, 2, 3 ]));
        }
    }

    [TestMethod]
    public void Test_OneBecomesTwo_NullException()
    {
        int[]? nullColl = null;
        Throws(() => nullColl!.OneBecomesTwo(), "list", "null");
    }
}