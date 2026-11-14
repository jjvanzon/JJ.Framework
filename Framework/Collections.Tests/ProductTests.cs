// ReSharper disable ExpressionIsAlwaysNull
namespace JJ.Framework.Collections.Tests;

[TestClass]
public class ProductTests
{
    private class TestItem
    {
        public double  Double  { get; set; }
        public float   Float   { get; set; }
        public int     Int     { get; set; }
        public long    Long    { get; set; }
        public decimal Decimal { get; set; }
    }

    private const double DELTA = 0.000001;

    private IEnumerable<TestItem> CreateTestItems() =>
    [
       new() { Double  = 1.01, Float = 1.01f, Int = 1, Long = 1, Decimal = 1.01m },
       new() { Double  = 2,    Float = 2,     Int = 2, Long = 2, Decimal = 2 },
       new() { Double  = 3,    Float = 3,     Int = 3, Long = 3, Decimal = 3 },
       new() { Double  = 4,    Float = 4,     Int = 4, Long = 4, Decimal = 4 },
    ];

    // Doubles

    [TestMethod]
    public void Test_CollectionExtensions_Product_Doubles()
    {
        double[] nums = [ 1.01, 2, 3, 4 ];
        AreEqual(24.24, nums.Product(), DELTA);
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Doubles_FromEnumerableItems()
    {
        AreEqual(24.24, CreateTestItems().Product(x => x.Double), DELTA);
    }

    // Floats

    [TestMethod]
    public void Test_CollectionExtensions_Product_Floats()
    {
        float[] nums = [ 1.01f, 2, 3, 4 ];
        AreEqual(24.24f, nums.Product(), DELTA);
    }

    [TestMethod]
    public void Test_CollectionExtensions_Product_Floats_FromEnumerableItems()
    {
        AreEqual(24.24f, CreateTestItems().Product(x => x.Float), DELTA);
    }

    // Ints

    [TestMethod]
    public void Test_CollectionExtensions_Product_Ints()
    {
        int[] nums = [ 1, 2, 3, 4 ];
        AreEqual(24, nums.Product());
    }
    
    [TestMethod]
    public void Test_CollectionExtensions_Product_Ints_FromEnumerableItems()
    {
        AreEqual(24, CreateTestItems().Product(x => x.Int));
    }

    // Longs

    [TestMethod]
    public void Test_CollectionExtensions_Product_Longs()
    {
        long[] nums = [ 1, 2, 3, 4 ];
        AreEqual(24L, nums.Product());
    }
    
    [TestMethod]
    public void Test_CollectionExtensions_Product_Longs_FromEnumerableItems()
    {
        AreEqual(24L, CreateTestItems().Product(x => x.Long));
    }

    // Decimal

    [TestMethod]
    public void Test_CollectionExtensions_Product_Decimal()
    {
        decimal[] nums = [ 1.01m, 2, 3, 4 ];
        AreEqual(24.24m, nums.Product());
    }
        
    [TestMethod]
    public void Test_CollectionExtensions_Product_Decimals_FromEnumerableItems()
    {
        AreEqual(24.24m, CreateTestItems().Product(x => x.Decimal));
    }

    // Empty Collection

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

    // Null Collection

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