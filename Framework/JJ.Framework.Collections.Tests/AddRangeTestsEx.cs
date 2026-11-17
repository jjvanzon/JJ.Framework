// ReSharper disable AppendToCollectionExpression
namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class AddRangeTestsEx
{
    [TestMethod]
    public void Test_AddRange_WithParams()
    {
        ICollection<string> coll = [ "Apple", "Orange", "Banana" ];
    
        coll.AddRange(["Prune", "Pear"]);

        IsTrue(coll.SequenceEqual(["Apple", "Orange", "Banana", "Prune", "Pear"]));
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

            IsTrue(list.SequenceEqual([ 1, 2, 3, 3, 4, 5 ]));
        }
        {
            IList<int> list  = [ 1, 2, 3 ];
            IList<int> list2 = [ 3, 4, 5 ];

            IListExtensions.AddRange(list, list2);

            IsTrue(list.SequenceEqual([ 1, 2, 3, 3, 4, 5 ]));
        }
    }
}