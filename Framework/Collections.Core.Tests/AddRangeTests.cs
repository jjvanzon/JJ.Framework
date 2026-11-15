namespace JJ.Framework.Collections.Core.Tests;

[TestClass]
public class AddRangeTests
{
    [TestMethod]
    public void Test_AddRange_WithParams()
    {
        ICollection<string> coll = [ "Apple", "Orange", "Banana" ];
        AreEqual(3, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));
    
        coll.AddRange(["Prune", "Pear"]);

        AreEqual(5, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));
        AreEqual("Prune",  coll.ElementAt(3));
        AreEqual("Pear",   coll.ElementAt(4));
    }

    [TestMethod]
    public void Test_AddRange_NullExceptions()
    {
        ICollection<string>? nullColl = null;
        ICollection<string> notNullColl = [ "Apple", "Orange", "Banana" ];
        IEnumerable<string>? nullEnumerable = nullColl;
        IEnumerable<string> notNullEnumerable = [ "", "" ];

        Throws(() => nullColl!.AddRange(notNullEnumerable), "null", "collection");
        Throws(() => notNullColl.AddRange(nullEnumerable!), "null", "items");
    }
    
    [TestMethod]
    public void Test_AddRange_WithIList_CollectionsCore_DoesNotClash_WithCommonLegacy()
    {
        {
            IList<int> list  = [ 1, 2, 3 ];
            IList<int> list2 = [ 3, 4, 5 ];

            list.AddRange(list2);

            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            IList<int> list  = [ 1, 2, 3 ];
            IList<int> list2 = [ 3, 4, 5 ];

            IListExtensions.AddRange(list, list2);

            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}