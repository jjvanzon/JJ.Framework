namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class AddTestsEx
{
    [TestMethod]
    public void Test_Add_WithParams()
    {
        ICollection<string> coll = [ "Apple", "Orange", "Banana" ];
    
        coll.Add("Prune", "Pear");

        IsTrue(coll.SequenceEqual([ "Apple", "Orange", "Banana", "Prune", "Pear" ]));
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
            IsTrue(list.SequenceEqual([ 1, 2, 3, 3, 4, 5 ]));
        }
        {
            IList<int> list = [ 1, 2, 3 ];
            IListExtensions.Add(list, 3, 4, 5);
            IsTrue(list.SequenceEqual([ 1, 2, 3, 3, 4, 5 ]));
        }
    }
}