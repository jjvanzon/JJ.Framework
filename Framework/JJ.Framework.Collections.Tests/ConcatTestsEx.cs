namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class ConcatTestsEx
{
    [TestMethod]
    public void Test_Concat_TwoCollections()
    {
        int[] coll1 = [ 1, 2, 3 ];
        IList<int> coll2 = [ 3, 4, 5, 6 ];

        var result = coll1.Concat(coll2).ToArray();

        IsNotNull(coll1);
        AreEqual(3, coll1.Length);
        AreEqual(1, coll1[0]);
        AreEqual(2, coll1[1]);
        AreEqual(3, coll1[2]);

        IsNotNull(coll2);
        AreEqual(4, coll2.Count);
        AreEqual(3, coll2[0]);
        AreEqual(4, coll2[1]);
        AreEqual(5, coll2[2]);
        AreEqual(6, coll2[3]);

        IsNotNull(result);
        AreEqual(7, result.Length);
        AreEqual(1, result[0]);
        AreEqual(2, result[1]);
        AreEqual(3, result[2]);
        AreEqual(3, result[3]); // Deliberate duplicate value 3.
        AreEqual(4, result[4]);
        AreEqual(5, result[5]);
        AreEqual(6, result[6]);
    }

    [TestMethod]
    public void Test_Concat_Item_And_Collection()
    {
        var result = 1.Concat([1, 2, 3]).ToArray();

        IsNotNull(result);
        AreEqual(4, result.Length);
        AreEqual(1, result[0]);
        AreEqual(1, result[1]);
        AreEqual(2, result[2]);
        AreEqual(3, result[3]);
    }

    [TestMethod]
    public void Test_Concat_Collection_And_Item()
    {
        int[] coll = [ 1, 2, 3 ];

        var result = coll.Concat(1).ToArray();

        AreEqual(3, coll.Length);
        AreEqual(1, coll[0]);
        AreEqual(2, coll[1]);
        AreEqual(3, coll[2]);

        IsNotNull(result);
        AreEqual(4, result.Length);
        AreEqual(1, result[0]);
        AreEqual(2, result[1]);
        AreEqual(3, result[2]);
        AreEqual(1, result[3]);
    }
}