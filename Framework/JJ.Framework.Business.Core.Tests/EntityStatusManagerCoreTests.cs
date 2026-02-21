
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Business.Legacy;
using JJ.Framework.Reflection.Legacy;

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class EntityStatusManagerCoreTests
{
    private class Entity
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public Entity(int id = 1)
        {
            ID = id;
        }
    }

    private class ViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public ViewModel(int id = 1)
        {
            ID = id;
        }
    }

    [TestMethod]
    public void EntityStatusManager_BasicEntityAndPropertyStatusOperations()
    {
        var entity = new Entity(1) { Name = "Original" };
        var manager = new EntityStatusManager();

        // Initially everything is clean
        Assert.IsFalse(manager.IsDirty(entity));
        Assert.IsFalse(manager.IsNew(entity));
        Assert.IsFalse(manager.IsDeleted(entity));

        // Set new
        manager.SetIsNew(entity);
        Assert.IsTrue(manager.IsNew(entity));

        // Set dirty
        manager.SetIsDirty(entity);
        Assert.IsTrue(manager.IsDirty(entity));

        // Set deleted
        manager.SetIsDeleted(entity);
        Assert.IsTrue(manager.IsDeleted(entity));

        // Property-based dirty
        manager.SetIsDirty(() => entity.Name);
        Assert.IsTrue(manager.IsDirty(() => entity.Name));

        // Null expressions throw NullException
        Assert.ThrowsException<NullException>(() => manager.IsDirty<string>(null!));
        Assert.ThrowsException<NullException>(() => manager.SetIsDirty<string>(null!));

        // Insufficient expressions throw
        Assert.ThrowsException<Exception>(() => manager.IsDirty(() => 1));
        Assert.ThrowsException<Exception>(() => manager.SetIsDirty(() => 1));

        // Clear resets everything
        manager.Clear();
        Assert.IsFalse(manager.IsDirty(entity));
        Assert.IsFalse(manager.IsDirty(() => entity.Name));
        Assert.IsFalse(manager.IsNew(entity));
        Assert.IsFalse(manager.IsDeleted(entity));
    }

    [TestMethod]
    public void EntityStatusManagerByID_BasicAndEdgeCases()
    {
        var entity = new Entity(1) { Name = "Original" };
        var manager = new EntityStatusManagerByID();

        // Initially clean
        Assert.IsFalse(manager.IsDirty<Entity>(entity.ID));
        Assert.IsFalse(manager.IsNew<Entity>(entity.ID));
        Assert.IsFalse(manager.IsDeleted<Entity>(entity.ID));

        // Set dirty (generic)
        manager.SetIsDirty<Entity>(entity.ID);
        Assert.IsTrue(manager.IsDirty<Entity>(entity.ID));

        // Property dirty by id
        manager.SetIsDirty(entity.ID, () => entity.Name);
        Assert.IsTrue(manager.IsDirty(entity.ID, () => entity.Name));

        // SetIsNew currently sets Dirty in the legacy implementation.
        manager.SetIsNew<Entity>(entity.ID);
        Assert.IsFalse(manager.IsNew<Entity>(entity.ID));
        Assert.IsTrue(manager.IsDirty<Entity>(entity.ID));

        // Non-generic overloads
        manager.SetIsNew(typeof(Entity), entity.ID);
        Assert.IsFalse(manager.IsNew(typeof(Entity), entity.ID));
        Assert.IsTrue(manager.IsDirty(typeof(Entity), entity.ID));

        // SetIsDeleted currently sets Dirty in the legacy implementation.
        manager.SetIsDeleted<Entity>(entity.ID);
        Assert.IsFalse(manager.IsDeleted<Entity>(entity.ID));
        Assert.IsTrue(manager.IsDirty<Entity>(entity.ID));

        // Null expression checks for property methods
        Assert.ThrowsException<NullException>(() => manager.IsDirty<int>(1, null!));
        Assert.ThrowsException<NullException>(() => manager.SetIsDirty<int>(1, null!));

        // Insufficient expression elements
        Assert.ThrowsException<Exception>(() => manager.IsDirty(1, () => 1));
        Assert.ThrowsException<Exception>(() => manager.SetIsDirty(1, () => 1));
    }
}
