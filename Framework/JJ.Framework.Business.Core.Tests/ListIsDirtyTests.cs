using static JJ.Framework.Business.Legacy.EntityStatusHelper;

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class ListIsDirtyTests
{
    [TestMethod]
    public void GetListIsDirty_SameLists()
    {
        var list1 = new List<Entity> { new() { ID = 1, Name = "A" }, new() { ID = 2, Name = "B" } };
        var list2 = new List<Entity> { new() { ID = 1, Name = "A" }, new() { ID = 2, Name = "B" } };

        bool result = GetListIsDirty(list1, x => x.ID, list2, x => x.ID);

        IsFalse(result);
    }

    [TestMethod]
    public void GetListIsDirty_DifferentCount()
    {
        var list1 = new List<Entity> { new() { ID = 1 } };
        var list2 = new List<Entity> { new() { ID = 1 }, new() { ID = 2 } };

        IsTrue(GetListIsDirty(list1, x => x.ID, list2, x => x.ID));
    }

    [TestMethod]
    public void GetListIsDirty_IgnoreOrderFlagUse()
    {
        var list1 = new List<Entity> { new() { ID = 1 }, new() { ID = 2 } };
        var list2 = new List<Entity> { new() { ID = 2 }, new() { ID = 1 } };

        // Order matters by default -> dirty
        IsTrue(GetListIsDirty(list1, x => x.ID, list2, x => x.ID, ingoreOrder: false));

        // Ignore order -> not dirty
        IsFalse(GetListIsDirty(list1, x => x.ID, list2, x => x.ID, ingoreOrder: true));
    }

    [TestMethod]
    public void GetListIsDirty_ElementChanged()
    {
        var list1 = new List<Entity> { new() { ID = 1 }, new() { ID = 2 } };
        var list2 = new List<Entity> { new() { ID = 1 }, new() { ID = 3 } };

        IsTrue(GetListIsDirty(list1, x => x.ID, list2, x => x.ID));
    }

    [TestMethod]
    public void GetListIsDirty_NullExceptions()
    {
        var list = new List<Entity> { new() { ID = 1 } };
        var listE = new List<Entity> { new() { ID = 1 } };

        // list1 null
        Throws(() => GetListIsDirty<Entity, Entity>(null!, x => x.ID, listE, x => x.ID), "list1", "null");

        // getKey1 null
        Throws(() => GetListIsDirty<Entity, Entity>(list, null!, listE, x => x.ID), "getKey1", "null");

        // list2 null
        Throws(() => GetListIsDirty<Entity, Entity>(list, x => x.ID, null!, x => x.ID), "list2", "null");

        // getKey2 null
        Throws(() => GetListIsDirty<Entity, Entity>(list, x => x.ID, listE, null!), "getKey2", "null");
    }
}
