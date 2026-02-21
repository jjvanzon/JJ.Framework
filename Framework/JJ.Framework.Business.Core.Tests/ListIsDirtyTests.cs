using static JJ.Framework.Business.Legacy.EntityStatusHelper;

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class ListIsDirtyTests
{
    [TestMethod]
    public void GetListIsDirty_SameLists()
    {
        var list1 = new List<ViewModel> { new() { Key = 1, Name = "A" }, new() { Key = 2, Name = "B" } };
        var list2 = new List<Category>  { new() { ID  = 1, Name = "A" }, new() { ID  = 2, Name = "B" } };

        bool result = GetListIsDirty(list1, x => x.Key, list2, x => x.ID);

        IsFalse(result);
    }

    [TestMethod]
    public void GetListIsDirty_DifferentCount()
    {
        var list1 = new List<ViewModel> { new() { Key = 1 } };
        var list2 = new List<Category>  { new() { ID  = 1 }, new() { ID = 2 } };

        IsTrue(GetListIsDirty(list1, x => x.Key, list2, x => x.ID));
    }

    [TestMethod]
    public void GetListIsDirty_IgnoreOrderFlagUse()
    {
        var list1 = new List<ViewModel> { new() { Key = 1 }, new() { Key = 2 } };
        var list2 = new List<Category>  { new() { ID  = 2 }, new() { ID  = 1 } };

        // Order matters by default -> dirty
        IsTrue(GetListIsDirty(list1, x => x.Key, list2, x => x.ID, ingoreOrder: false));

        // Ignore order -> not dirty
        IsFalse(GetListIsDirty(list1, x => x.Key, list2, x => x.ID, ingoreOrder: true));
    }

    [TestMethod]
    public void GetListIsDirty_ElementChanged()
    {
        var list1 = new List<ViewModel> { new() { Key = 1 }, new() { Key = 2 } };
        var list2 = new List<Category>  { new() { ID  = 1 }, new() { ID  = 3 } };

        IsTrue(GetListIsDirty(list1, x => x.Key, list2, x => x.ID));
    }

    [TestMethod]
    public void GetListIsDirty_NullExceptions()
    {
        var list = new List<ViewModel> { new() { Key = 1 } };
        var list2 = new List<Category> { new() { ID  = 1 } };

        // list1 null
        Throws(() => GetListIsDirty<ViewModel, Category>(null!, x => x.Key, list2, x => x.ID), "list1",   "null");

        // getKey1 null
        Throws(() => GetListIsDirty<ViewModel, Category>(list,  null!,      list2, x => x.ID), "getKey1", "null");

        // list2 null
        Throws(() => GetListIsDirty<ViewModel, Category>(list,  x => x.Key, null!, x => x.ID), "list2",   "null");

        // getKey2 null
        Throws(() => GetListIsDirty<ViewModel, Category>(list,  x => x.Key, list2, null!    ), "getKey2", "null");
    }
}
