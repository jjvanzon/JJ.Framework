namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class AddTestsEx
{
    [TestMethod]
    public void Test_Add_WithParams()
    {
        ICollection<string> coll = [ "Apple", "Orange", "Banana" ];
        AreEqual(3, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));
    
        coll.Add("Prune", "Pear");

        AreEqual(5, coll.Count);
        AreEqual("Apple",  coll.ElementAt(0));
        AreEqual("Orange", coll.ElementAt(1));
        AreEqual("Banana", coll.ElementAt(2));
        AreEqual("Prune",  coll.ElementAt(3));
        AreEqual("Pear",   coll.ElementAt(4));
    }

    [TestMethod]
    public void Test_Add_NullExceptions()
    {
        ICollection<string>? nullColl = null;
        ICollection<string> notNullColl = [ "Apple", "Orange", "Banana" ];
        IEnumerable<string>? nullEnumerable = nullColl;

        Throws(() => nullColl!.Add("", ""), "null", "collection");
        Throws(() => notNullColl.Add(nullEnumerable!), "null", "items");
    }

    [TestMethod]
    public void Test_Add_WithIList_CollectionsCore_DoesNotClash_WithCommonLegacy()
    {
        {
            IList<int> list = [ 1, 2, 3 ];
            list.Add(3, 4, 5);
            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            IList<int> list = [ 1, 2, 3 ];
            IListExtensions.Add(list, 3, 4, 5);
            int[] expected = [ 1, 2, 3, 3, 4, 5 ];
            int[] actual = list.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}