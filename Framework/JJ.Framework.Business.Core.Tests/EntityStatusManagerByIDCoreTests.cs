namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class EntityStatusManagerByIDCoreTests
{
    [TestMethod]
    public void EntityStatusManagerByID_BasicCases()
    {
        Entity entity = CreateSimpleEntity();
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
    public void EntityStatusManagerByID_MustSetLastModifiedByUser_Cases()
    {
        Entity entity = CreateRichEntity();
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