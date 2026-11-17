namespace JJ.Framework.Collections.Legacy.Tests;

using static Console;

[TestClass]
public class ForEachTestsEx
{
    [TestMethod]
    public void Test_ForEach_Example()
    {
        var myColl = new List<string> { "Apple", "Orange" };
        myColl.ForEach((x, i) => WriteLine(x + "[" + i + "]"));
    }

    [TestMethod]
    public void Test_ForEach_WithList_UsesDotNetVariant()
    {        
        var list = new List<string> { "Apple", "Orange" };
        var list2 = new List<string>();

        list.ForEach(x => list2.Add(x + " added"));

        IsTrue(list .SequenceEqual([ "Apple", "Orange" ]));
        IsTrue(list2.SequenceEqual([ "Apple added", "Orange added" ]));
    }

    [TestMethod]
    public void Test_ForEach_WithInterfaces_UsesJJFrameworkVariant()
    {        
        IEnumerable<string> enumerable = new List<string> { "Apple", "Orange" };
        IList<string> list = new List<string>();

        enumerable.ForEach(x => list.Add(x + " added"));
       
        IsTrue(enumerable.SequenceEqual([ "Apple", "Orange" ]));
        IsTrue(list.SequenceEqual([ "Apple added", "Orange added" ]));
    }

    [TestMethod]
    public void Test_ForEach_WithICollection_UsesJJFrameworkVariant()
    {        
        ICollection<string> collection = new List<string> { "Apple", "Orange" };
        IList<string> list = new List<string>();

        collection.ForEach(x => list.Add(x + " added"));
       
        IsTrue(collection.SequenceEqual([ "Apple", "Orange" ]));
        IsTrue(list.SequenceEqual([ "Apple added", "Orange added" ]));
    }

    [TestMethod]
    public void Test_ForEach_WithIndexParameter()
    {
        IEnumerable<string> enumerable = new List<string> { "Apple", "Orange" };
        IList<string> list = new List<string>();

        enumerable.ForEach((x, i) => list.Add(x + " added" + " @ [" + i + "]" ));

        IsTrue(enumerable.SequenceEqual([ "Apple", "Orange" ]));
        IsTrue(list.SequenceEqual([ "Apple added @ [0]", "Orange added @ [1]" ]));
    }
}