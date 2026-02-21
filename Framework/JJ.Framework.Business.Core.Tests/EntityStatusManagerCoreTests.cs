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

    // Unused for now
    /*
    private class ViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public ViewModel(int id = 1)
        {
            ID = id;
        }
    }
    */

    [TestMethod]
    public void EntityStatusManager_BasicEntityAndPropertyStatusOperations()
    {
        var entity = new Entity(1) { Name = "Original" };
        var manager = new EntityStatusManager();

        // Initially everything is clean
        IsFalse(manager.IsDirty(entity));
        IsFalse(manager.IsNew(entity));
        IsFalse(manager.IsDeleted(entity));

        // Set new
        manager.SetIsNew(entity);
        IsTrue(manager.IsNew(entity));

        // Set dirty
        manager.SetIsDirty(entity);
        IsTrue(manager.IsDirty(entity));

        // Set deleted
        manager.SetIsDeleted(entity);
        IsTrue(manager.IsDeleted(entity));

        // Property-based dirty
        manager.SetIsDirty(() => entity.Name);
        IsTrue(manager.IsDirty(() => entity.Name));

        // Clear resets everything
        manager.Clear();
        IsFalse(manager.IsDirty(entity));
        IsFalse(manager.IsDirty(() => entity.Name));
        IsFalse(manager.IsNew(entity));
        IsFalse(manager.IsDeleted(entity));
    }

    [TestMethod]
    public void EntityStatusManager_EdgeCases()
    {
        var manager = new EntityStatusManager();

        // Null expressions throw NullException
        Throws(() => manager.IsDirty<string>(null!), "expression", "null");
        Throws(() => manager.SetIsDirty<string>(null!), "expression", "null");

        // Insufficient expression elements (needs both entity and property, e.g. `entity.Name`.
        Throws(() => manager.IsDirty(() => 1), "expression", "2 elements");
        Throws(() => manager.SetIsDirty(() => 1), "expression", "2 elements");
    }

    [TestMethod]
    public void EntityStatusManagerByID_BasicCases()
    {
        var entity = new Entity(1) { Name = "Original" };
        var manager = new EntityStatusManagerByID();

        // Initially clean
        IsFalse(manager.IsDirty<Entity>(entity.ID));
        IsFalse(manager.IsNew<Entity>(entity.ID));
        IsFalse(manager.IsDeleted<Entity>(entity.ID));

        // Set dirty (generic)
        manager.SetIsDirty<Entity>(entity.ID);
        IsTrue(manager.IsDirty<Entity>(entity.ID));

        // Property dirty by id
        manager.SetIsDirty(entity.ID, () => entity.Name);
        IsTrue(manager.IsDirty(entity.ID, () => entity.Name));

        // SetIsNew currently sets Dirty in the legacy implementation.
        manager.SetIsNew<Entity>(entity.ID);
        IsFalse(manager.IsNew<Entity>(entity.ID));
        IsTrue(manager.IsDirty<Entity>(entity.ID));

        // Non-generic overloads
        manager.SetIsNew(typeof(Entity), entity.ID);
        IsFalse(manager.IsNew(typeof(Entity), entity.ID));
        IsTrue(manager.IsDirty(typeof(Entity), entity.ID));

        // SetIsDeleted currently sets Dirty in the legacy implementation.
        manager.SetIsDeleted<Entity>(entity.ID);
        IsFalse(manager.IsDeleted<Entity>(entity.ID));
        IsTrue(manager.IsDirty<Entity>(entity.ID));
    }

    [TestMethod]
    public void EntityStatusManagerByID_EdgeCases()
    {
        var manager = new EntityStatusManagerByID();
        
        // Null expression checks for property-releated methods
        Throws(() => manager.IsDirty<int>(1, null!), "expression", "null");
        Throws(() => manager.SetIsDirty<int>(1, null!), "expression", "null");

        // Insufficient expression elements (needs both entity and property, e.g. `entity.Name`.
        Throws(() => manager.IsDirty(1, () => 1), "expression", "2 elements");
        Throws(() => manager.SetIsDirty(1, () => 1), "expression", "2 elements");
    }
}
