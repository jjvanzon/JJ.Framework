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

        AreEqual(2, list2.Count);
        AreEqual("Apple added", list2[0]);
        AreEqual("Orange added", list2[1]);
    }

    [TestMethod]
    public void Test_ForEach_WithInterfaces_UsesJJFrameworkVariant()
    {        
        IEnumerable<string> enumerable = new List<string> { "Apple", "Orange" };
        IList<string> list = new List<string>();

        enumerable.ForEach(x => list.Add(x + " added"));

        AreEqual(2, list.Count);
        AreEqual("Apple added", list[0]);
        AreEqual("Orange added", list[1]);
    }

    [TestMethod]
    public void Test_ForEach_WithICollection_UsesJJFrameworkVariant()
    {        
        ICollection<string> enumerable = new List<string> { "Apple", "Orange" };
        IList<string> list = new List<string>();

        enumerable.ForEach(x => list.Add(x + " added"));

        AreEqual(2, list.Count);
        AreEqual("Apple added", list[0]);
        AreEqual("Orange added", list[1]);
    }

    [TestMethod]
    public void Test_ForEach_WithIndexParameter()
    {
        IEnumerable<string> enumerable = new List<string> { "Apple", "Orange" };
        IList<string> list = new List<string>();

        enumerable.ForEach((x, i) => list.Add(x + " added" + " @ [" + i + "]" ));

        AreEqual(2, list.Count);
        AreEqual("Apple added @ [0]", list[0]);
        AreEqual("Orange added @ [1]", list[1]);
    }
}