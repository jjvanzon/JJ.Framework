// ReSharper disable RedundantArgumentDefaultValue

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class EntityStatusManagerCoreTests
{
    private class Entity
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        // Unused for now
        //public Entity? RelatedEntity { get; set; }

        public Entity? QuestionType { get; set; }
        public Entity? Source { get; set; }
        public IList<Entity> QuestionCategories { get; set; }
        public IList<Entity> QuestionLinks { get; set; }
        public IList<Entity> QuestionFlags { get; set; }

        public Entity()
        {
            QuestionCategories = new List<Entity>();
            QuestionLinks = new List<Entity>();
            QuestionFlags = new List<Entity>();
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
        var entity = new Entity { ID = 1, Name = "Original" };
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
        var entity = new Entity { ID = 1, Name = "Original" };
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

    // Re-implementation of the legacy helper used in real code.
    private bool MustSetLastModifiedByUser(Entity entity, EntityStatusManager statusManager)
    {
        return statusManager.IsDirty(entity) ||
               statusManager.IsNew(entity) ||
               statusManager.IsDirty(() => entity.QuestionType) ||
               statusManager.IsDirty(() => entity.Source) ||
               statusManager.IsDirty(() => entity.QuestionCategories) ||
               entity.QuestionCategories.Any(x => statusManager.IsDirty(x)) ||
               statusManager.IsDirty(() => entity.QuestionLinks) ||
               entity.QuestionLinks.Any(x => statusManager.IsDirty(x)) ||
               entity.QuestionLinks.Any(x => statusManager.IsNew(x)) ||
               statusManager.IsDirty(() => entity.QuestionFlags) ||
               entity.QuestionFlags.Any(x => statusManager.IsDirty(x)) ||
               entity.QuestionFlags.Any(x => statusManager.IsNew(x));
    }

    [TestMethod]
    public void EntityStatusManager_MustSetLastModifiedByUser_Cases()
    {
        // Clean entity => false
        var entity = new Entity
        {
            ID                 = 1,
            Name               = "Root",
            QuestionType       = new Entity{ ID = 2, Name = "QType" },
            Source             = new Entity{ ID = 3, Name = "Source" },
            QuestionCategories = [ new Entity{ ID = 4, Name = "Cat1" } ],
            QuestionLinks      = [ new Entity{ ID = 5, Name = "Link1" } ],
            QuestionFlags      = [ new Entity{ ID = 6, Name = "Flag1" } ] 
        };

        var manager = new EntityStatusManager();
        IsFalse(MustSetLastModifiedByUser(entity, manager));

        // Entity dirty
        manager.SetIsDirty(entity);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Entity new
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsNew(entity);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Property dirty: QuestionType
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(() => entity.QuestionType);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Property dirty: Source
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(() => entity.Source);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Property dirty: QuestionCategories (collection property)
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(() => entity.QuestionCategories);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Element in QuestionCategories is dirty
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(entity.QuestionCategories[0]);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Property dirty: QuestionLinks
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(() => entity.QuestionLinks);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Element in QuestionLinks is dirty
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(entity.QuestionLinks[0]);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Element in QuestionLinks is new
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsNew(entity.QuestionLinks[0]);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Property dirty: QuestionFlags
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(() => entity.QuestionFlags);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Element in QuestionFlags is dirty
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsDirty(entity.QuestionFlags[0]);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();

        // Element in QuestionFlags is new
        IsFalse(MustSetLastModifiedByUser(entity, manager));
        manager.SetIsNew(entity.QuestionFlags[0]);
        IsTrue(MustSetLastModifiedByUser(entity, manager));
        manager.Clear();
    }


    // ByID variant of the legacy helper.
    private bool MustSetLastModifiedByUserByID(Entity entity, EntityStatusManagerByID statusManager)
    {
        return statusManager.IsDirty<Entity>(entity.ID) ||
               statusManager.IsNew<Entity>(entity.ID) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionType) ||
               statusManager.IsDirty(entity.ID, () => entity.Source) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionCategories) ||
               entity.QuestionCategories.Any(x => statusManager.IsDirty<Entity>(x.ID)) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionLinks) ||
               entity.QuestionLinks.Any(x => statusManager.IsDirty<Entity>(x.ID)) ||
               entity.QuestionLinks.Any(x => statusManager.IsNew<Entity>(x.ID)) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionFlags) ||
               entity.QuestionFlags.Any(x => statusManager.IsDirty<Entity>(x.ID)) ||
               entity.QuestionFlags.Any(x => statusManager.IsNew<Entity>(x.ID));
    }

    [TestMethod]
    public void EntityStatusManagerByID_MustSetLastModifiedByUser_Cases()
    {
        Entity CreateRichEntity()
        {
            var e = new Entity { ID = 1, Name = "Root" };
            e.QuestionType = new Entity { ID = 2, Name = "QType" };
            e.Source = new Entity { ID = 3, Name = "Source" };
            e.QuestionCategories.Add(new Entity { ID = 4, Name = "Cat1" });
            e.QuestionLinks.Add(new Entity { ID = 5, Name = "Link1" });
            e.QuestionFlags.Add(new Entity { ID = 6, Name = "Flag1" });
            return e;
        }

        var entity = CreateRichEntity();
        var manager = new EntityStatusManagerByID();

        // Clean entity => false
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));

        // Entity dirty
        manager.SetIsDirty<Entity>(entity.ID);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Entity new
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsNew<Entity>(entity.ID);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Property dirty: QuestionType
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty(entity.ID, () => entity.QuestionType);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Property dirty: Source
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty(entity.ID, () => entity.Source);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Property dirty: QuestionCategories (collection property)
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty(entity.ID, () => entity.QuestionCategories);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Element in QuestionCategories is dirty
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty<Entity>(entity.QuestionCategories[0].ID);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Property dirty: QuestionLinks
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty(entity.ID, () => entity.QuestionLinks);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Element in QuestionLinks is dirty
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty<Entity>(entity.QuestionLinks[0].ID);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Element in QuestionLinks is new
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsNew<Entity>(entity.QuestionLinks[0].ID);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Property dirty: QuestionFlags
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty(entity.ID, () => entity.QuestionFlags);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Element in QuestionFlags is dirty
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsDirty<Entity>(entity.QuestionFlags[0].ID);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        manager = new EntityStatusManagerByID();

        // Element in QuestionFlags is new
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));
        manager.SetIsNew<Entity>(entity.QuestionFlags[0].ID);
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
    }
}
