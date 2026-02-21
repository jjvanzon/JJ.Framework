// ReSharper disable RedundantArgumentDefaultValue

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class EntityStatusManagerCoreTests
{
    [TestMethod]
    public void EntityStatusManager_BasicEntityAndPropertyStatusOperations()
    {
        Question entity = CreateSimpleQuestion();
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
    public void EntityStatusManager_MustSetLastModifiedByUser_Cases()
    {
        // Clean entity => false
        Question entity = CreateRichQuestion();
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

    [TestMethod]
    public void EntityStatusManager_MultiEntityScenario()
    {
        Question entity = CreateRichQuestion();
        var manager = new EntityStatusManager();

        // start clean
        IsFalse(MustSetLastModifiedByUser(entity, manager));

        // mark several things
        manager.SetIsDirty(() => entity.Name);
        manager.SetIsDirty(entity.QuestionLinks[0]);
        manager.SetIsNew(entity.QuestionFlags[0]);
        manager.SetIsDirty(() => entity.QuestionCategories);

        // assertions
        IsTrue(manager.IsDirty(() => entity.Name));
        IsTrue(manager.IsDirty(entity.QuestionLinks[0]));
        IsTrue(manager.IsNew(entity.QuestionFlags[0]));
        IsTrue(manager.IsDirty(() => entity.QuestionCategories));

        // overall composed check
        IsTrue(MustSetLastModifiedByUser(entity, manager));
    }

    [TestMethod]
    public void EntityStatusManager_MixedStatus_LastSetWins()
    {
        Question entity = CreateSimpleQuestion();
        var manager = new EntityStatusManager();

        // Start New
        manager.SetIsNew(entity);
        IsTrue(manager.IsNew(entity));

        // Then Dirty should overwrite New
        manager.SetIsDirty(entity);
        IsTrue(manager.IsDirty(entity));
        IsFalse(manager.IsNew(entity));
        IsFalse(manager.IsDeleted(entity));

        // Then Deleted should overwrite Dirty
        manager.SetIsDeleted(entity);
        IsTrue(manager.IsDeleted(entity));
        IsFalse(manager.IsNew(entity));
        IsFalse(manager.IsDirty(entity));

        // Set New again
        manager.SetIsNew(entity);
        IsTrue(manager.IsNew(entity));
        IsFalse(manager.IsDeleted(entity));
        IsFalse(manager.IsDirty(entity));

        // Property dirty remains independent
        manager.SetIsDirty(() => entity.Name);
        IsTrue(manager.IsDirty(() => entity.Name));

        // Setting entity dirty does not clear property dirty
        manager.SetIsDirty(entity);
        IsTrue(manager.IsDirty(entity));
        IsTrue(manager.IsDirty(() => entity.Name));

        // Clear resets everything
        manager.Clear();
        IsFalse(manager.IsDirty(entity));
        IsFalse(manager.IsDirty(() => entity.Name));
        IsFalse(manager.IsNew(entity));
        IsFalse(manager.IsDeleted(entity));
    }

    [TestMethod]
    public void EntityStatusManager_DuplicateSets_DoNotThrow()
    {
        Question entity = CreateSimpleQuestion();
        var manager = new EntityStatusManager();

        // Setting the same entity status multiple times should not throw and should retain the status.
        manager.SetIsDirty(entity);
        manager.SetIsDirty(entity);
        IsTrue(manager.IsDirty(entity));

        // Property status duplicates
        manager.SetIsDirty(() => entity.Name);
        manager.SetIsDirty(() => entity.Name);
        IsTrue(manager.IsDirty(() => entity.Name));

        // Element in a collection duplicates
        entity.QuestionLinks.Add(new Link { ID = 99, Name = "DupLink" });
        manager.SetIsDirty(entity.QuestionLinks[0]);
        manager.SetIsDirty(entity.QuestionLinks[0]);
        IsTrue(manager.IsDirty(entity.QuestionLinks[0]));
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

    private bool MustSetLastModifiedByUser(Question entity, EntityStatusManager statusManager)
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
}