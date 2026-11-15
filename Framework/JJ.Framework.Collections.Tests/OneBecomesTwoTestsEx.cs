// ReSharper disable ExpressionIsAlwaysNull
namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class OneBecomesTwoTestsEx
{
    [TestMethod]
    public void Test_OneBecomesTwo()
    {
        {
            int[] oneItem = [1];
            int[] oneBecomesTwo = oneItem.OneBecomesTwo();
           
            NotNull(oneBecomesTwo);
            AreEqual(2, oneBecomesTwo.Length);
            AreEqual(1, oneBecomesTwo[0]);
            AreEqual(1, oneBecomesTwo[1]);
        }
        {
            int[] twoItems = [1, 2];
            int[] twoStaysTwo = twoItems.OneBecomesTwo();

            NotNull(twoStaysTwo);
            AreEqual(2, twoStaysTwo.Length);
            AreEqual(1, twoStaysTwo[0]);
            AreEqual(2, twoStaysTwo[1]);
        }
        {
            int[] threeItems = [ 1, 2, 3 ];
            int[] threeStaysThree = threeItems.OneBecomesTwo();

            NotNull(threeStaysThree);
            AreEqual(3, threeStaysThree.Length);
            AreEqual(1, threeStaysThree[0]);
            AreEqual(2, threeStaysThree[1]);
            AreEqual(3, threeStaysThree[2]);
        }
    }

    [TestMethod]
    public void Test_OneBecomesTwo_NullException()
    {
        int[]? nullColl = null;
        Throws(() => nullColl!.OneBecomesTwo(), "list", "null");
    }
}