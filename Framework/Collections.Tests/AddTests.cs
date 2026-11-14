namespace JJ.Framework.Collections.Core.Tests;

[TestClass]
public class AddTests
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
}