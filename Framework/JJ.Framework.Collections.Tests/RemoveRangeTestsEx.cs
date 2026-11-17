namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class RemoveRangeTestsEx
{
    [TestMethod]
    public void Test_RemoveRange_ListOfT_WithIndexAndCount()
    {
        List<string> list = [ "Apple", "Orange", "Banana", "Peach", "Pear" ];

        list.RemoveRange(1, 2);

        AreEqual(3, list.Count);
        AreEqual("Apple", list[0]);
        AreEqual("Peach", list[1]);
        AreEqual("Pear",  list[2]);
    }

    [TestMethod]
    public void Test_RemoveRange_WithItemsToRemove()
    {
        List<string> list = [ "Apple", "Orange", "Banana", "Peach", "Pear" ];

        list.RemoveRange("Orange", "Peach");

        AreEqual(3, list.Count);
        AreEqual("Apple",  list[0]);
        AreEqual("Banana", list[1]);
        AreEqual("Pear",   list[2]);
    }

    [TestMethod]
    public void Test_RemoveRange_NullExceptions()
    {
        List<string> notNullList = [ "Apple", "Orange", "Banana", "Peach", "Pear" ];
        List<string>? nullList = null;

        Throws(() => nullList!.RemoveRange("Orange", "Peach"), "dest", "null");
        Throws(() => notNullList.RemoveRange(nullList!), "source", "null");
    }
}