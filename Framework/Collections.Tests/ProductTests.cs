// ReSharper disable ExpressionIsAlwaysNull
namespace JJ.Framework.Collections.Tests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void Test_CollectionExtensions_Product_Doubles()
    {
        double[] nums = [ 1.01, 2, 3, 4 ];
        AreEqual(24.24, nums.Product(), delta: 0.000001);
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Floats()
    {
        float[] nums = [ 1.01f, 2, 3, 4 ];
        AreEqual(24.24, nums.Product(), delta: 0.000001);
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Ints()
    {
        int[] nums = [ 1, 2, 3, 4 ];
        AreEqual(24, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Longs()
    {
        long[] nums = [ 1, 2, 3, 4 ];
        AreEqual(24, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Decimal()
    {
        decimal[] nums = [ 1.01m, 2, 3, 4 ];
        AreEqual(24.24m, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Doubles_EmptyCollection_Is1()
    {
        double[] nums = [  ];
        AreEqual(1, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Floats_EmptyCollection_Is1()
    {
        float[] nums = [  ];
        AreEqual(1, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Ints_EmptyCollection_Is1()
    {
        int[] nums = [  ];
        AreEqual(1, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Longs_EmptyCollection_Is1()
    {
        long[] nums = [  ];
        AreEqual(1, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Decimal_EmptyCollection_Is1()
    {
        decimal[] nums = [  ];
        AreEqual(1, nums.Product());
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Doubles_NullCollection_Exception()
    {
        double[]? nums = null;
        Throws(() => nums!.Product(), "cannot be null", "collection");
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Floats_NullCollection_Exception()
    {
        float[]? nums = null;
        Throws(() => nums!.Product(), "cannot be null", "collection");
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Ints_NullCollection_Exception()
    {
        int[]? nums = null;
        Throws(() => nums!.Product(), "cannot be null", "collection");
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Longs_NullCollection_Exception()
    {
        long[]? nums = null;
        Throws(() => nums!.Product(), "cannot be null", "collection");
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Decimal_NullCollection_Exception()
    {
        decimal[]? nums = null;
        Throws(() => nums!.Product(), "cannot be null", "collection");
    }
}