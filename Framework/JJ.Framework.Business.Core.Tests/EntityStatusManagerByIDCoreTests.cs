namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class EntityStatusManagerByIDCoreTests
{
    [TestMethod]
    public void EntityStatusManagerByID_BasicCases()
    {
        Question entity = CreateSimpleQuestion();
        var manager = new EntityStatusManagerByID();

        // Initially clean
        IsFalse(manager.IsDirty<Question>(entity.ID));
        IsFalse(manager.IsNew<Question>(entity.ID));
        IsFalse(manager.IsDeleted<Question>(entity.ID));

        // Set dirty (generic)
        manager.SetIsDirty<Question>(entity.ID);
        IsTrue(manager.IsDirty<Question>(entity.ID));

        // Property dirty by id
        manager.SetIsDirty(entity.ID, () => entity.Name);
        IsTrue(manager.IsDirty(entity.ID, () => entity.Name));

        // Fixed bug that SetIsNew erroneously set Dirty.
        manager.SetIsNew<Question>(entity.ID);
        IsTrue(manager.IsNew<Question>(entity.ID));
        IsFalse(manager.IsDirty<Question>(entity.ID));

        // Non-generic overloads
        manager.SetIsNew(typeof(Question), entity.ID);
        IsTrue(manager.IsNew(typeof(Question), entity.ID));
        IsFalse(manager.IsDirty(typeof(Question), entity.ID));

        // Fixed bug that SetIsDeleted erroneously set Dirty.
        manager.SetIsDeleted<Question>(entity.ID);
        IsTrue(manager.IsDeleted<Question>(entity.ID));
        IsFalse(manager.IsDirty<Question>(entity.ID));
    }

    [TestMethod]
    public void EntityStatusManagerByID_DuplicateSets_DoNotThrow()
    {
        Question entity = CreateSimpleQuestion();
        var manager = new EntityStatusManagerByID();

        // Setting the same entity status multiple times should not throw and should retain the status.
        manager.SetIsDirty<Question>(entity.ID);
        manager.SetIsDirty<Question>(entity.ID);
        IsTrue(manager.IsDirty<Question>(entity.ID));

        // Property status duplicates
        manager.SetIsDirty(entity.ID, () => entity.Name);
        manager.SetIsDirty(entity.ID, () => entity.Name);
        IsTrue(manager.IsDirty(entity.ID, () => entity.Name));

        // Element in a collection duplicates
        entity.QuestionLinks.Add(new Link { ID = 99, Name = "DupLink" });
        manager.SetIsDirty<Link>(entity.QuestionLinks[0].ID);
        manager.SetIsDirty<Link>(entity.QuestionLinks[0].ID);
        IsTrue(manager.IsDirty<Link>(entity.QuestionLinks[0].ID));
    }

    [TestMethod]
    public void EntityStatusManagerByID_MustSetLastModifiedByUser_Cases()
    {
        Question entity = CreateRichQuestion();
        {
            var manager = new EntityStatusManagerByID();

            // Clean entity => false
            IsFalse(MustSetLastModifiedByUserByID(entity, manager));

            // Entity dirty
            manager.SetIsDirty<Question>(entity.ID);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Entity new
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsNew<Question>(entity.ID);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Property dirty: QuestionType
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty(entity.ID, () => entity.QuestionType);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Property dirty: Source
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty(entity.ID, () => entity.Source);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Property dirty: QuestionCategories (collection property)
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty(entity.ID, () => entity.QuestionCategories);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Element in QuestionCategories is dirty
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty<Category>(entity.QuestionCategories[0].ID);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Property dirty: QuestionLinks
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty(entity.ID, () => entity.QuestionLinks);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Element in QuestionLinks is dirty
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty<Link>(entity.QuestionLinks[0].ID);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Element in QuestionLinks is new
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsNew<Link>(entity.QuestionLinks[0].ID);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Property dirty: QuestionFlags
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty(entity.ID, () => entity.QuestionFlags);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Element in QuestionFlags is dirty
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsDirty<Flag>(entity.QuestionFlags[0].ID);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
        // Element in QuestionFlags is new
        {
            var manager = new EntityStatusManagerByID();
            manager.SetIsNew<Flag>(entity.QuestionFlags[0].ID);
            IsTrue(MustSetLastModifiedByUserByID(entity, manager));
        }
    }

    private bool MustSetLastModifiedByUserByID(Question entity, EntityStatusManagerByID statusManager)
    {
        return statusManager.IsDirty<Question>(entity.ID) ||
               statusManager.IsNew<Question>(entity.ID) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionType) ||
               statusManager.IsDirty(entity.ID, () => entity.Source) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionCategories) ||
               entity.QuestionCategories.Any(x => statusManager.IsDirty<Category>(x.ID)) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionLinks) ||
               entity.QuestionLinks.Any(x => statusManager.IsDirty<Link>(x.ID)) ||
               entity.QuestionLinks.Any(x => statusManager.IsNew<Link>(x.ID)) ||
               statusManager.IsDirty(entity.ID, () => entity.QuestionFlags) ||
               entity.QuestionFlags.Any(x => statusManager.IsDirty<Flag>(x.ID)) ||
               entity.QuestionFlags.Any(x => statusManager.IsNew<Flag>(x.ID));
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

    [TestMethod]
    public void EntityStatusManagerByID_MultiEntityScenario()
    {
        Question entity = CreateRichQuestion();

        var manager = new EntityStatusManagerByID();

        // start clean
        IsFalse(MustSetLastModifiedByUserByID(entity, manager));

        // mark several things by id
        manager.SetIsDirty(entity.ID, () => entity.Name);
        manager.SetIsDirty<Link>(entity.QuestionLinks[0].ID);
        manager.SetIsNew<Flag>(entity.QuestionFlags[0].ID);
        manager.SetIsDirty(entity.ID, () => entity.QuestionCategories);

        // assertions
        IsTrue(manager.IsDirty(entity.ID, () => entity.Name));
        IsTrue(manager.IsDirty<Link>(entity.QuestionLinks[0].ID));
        IsTrue(manager.IsNew<Flag>(entity.QuestionFlags[0].ID));
        IsTrue(manager.IsDirty(entity.ID, () => entity.QuestionCategories));

        // overall composed check
        IsTrue(MustSetLastModifiedByUserByID(entity, manager));
    }
}