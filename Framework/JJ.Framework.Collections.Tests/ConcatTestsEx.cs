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

        IsTrue(coll1 .SequenceEqual([ 1, 2, 3 ]));
        IsTrue(coll2 .SequenceEqual([ 3, 4, 5, 6 ]));
        IsTrue(result.SequenceEqual([ 1, 2, 3, 3, 4, 5, 6 ]));  // Deliberate duplicate value 3.
    }

    [TestMethod]
    public void Test_Concat_Item_And_Collection()
    {
        var result = 1.Concat([ 1, 2, 3 ]).ToArray();
        IsTrue(result.SequenceEqual([ 1, 1, 2, 3])); // Deliberate duplicate value 1.
    }

    [TestMethod]
    public void Test_Concat_Collection_And_Item()
    {
        int[] coll = [ 1, 2, 3 ];
        var result = coll.Concat(1).ToArray();

        IsTrue(coll.SequenceEqual([ 1, 2, 3 ]));
        IsTrue(result.SequenceEqual([ 1, 2, 3, 1 ])); // Deliberate duplicate value 1.
    }
}