namespace JJ.Framework.Collections.Core.Tests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void Test_CollectionExtensionsCore_Product_Doubles()
    {
        double[] nums = [ 1, 2, 3, 4 ];
        AreEqual(24, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensionsCore_Product_Doubles_EmptyCollection_Is1()
    {
        double[] nums = [  ];
        AreEqual(1, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensionsCore_Product_Doubles_NullColl_Exception()
    {
        double[]? nums = null;
        Throws(() => nums!.Product(), "cannot be null", "collection");
    }
}