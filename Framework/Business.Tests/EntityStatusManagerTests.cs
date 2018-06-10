using System.Linq;
using JJ.Framework.Business.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable NotAccessedVariable
// ReSharper disable UnusedVariable
// ReSharper disable JoinDeclarationAndInitializer
// ReSharper disable RedundantAssignment
// ReSharper disable UnusedMember.Local

namespace JJ.Framework.Business.Tests
{
    [TestClass]
    public class EntityStatusManagerTests
    {
        [TestMethod]
        public void Test_EntityStatusManager()
        {
            Entity entity = CreateMockEntity();
            ViewModel viewModel = CreateMockViewModel();

            //EntityStatusEnum status;
            bool isDirty;

            // With instance integrity
            var statusManager = new EntityStatusManager();
            statusManager.SetIsDirty(entity);
            statusManager.SetIsDirty(() => entity.Name);
            isDirty = statusManager.IsDirty(entity);
            isDirty = statusManager.IsDirty(() => entity.Name);

            // Without instance integrity
            var statusManagerByID = new EntityStatusManagerByID();
            statusManagerByID.SetIsDirty<Entity>(entity.ID);
            statusManagerByID.SetIsDirty(entity.ID, () => entity.Name);
            isDirty = statusManagerByID.IsDirty<Entity>(entity.ID);
            isDirty = statusManagerByID.IsDirty(entity.ID, () => entity.Name);
        }

        private bool MustSetLastModifiedByUser(Entity entity, EntityStatusManager statusManager)
            => statusManager.IsDirty(entity) ||
               statusManager.IsNew(entity) ||
               statusManager.IsDirty(() => entity.QuestionType) ||
               statusManager.IsDirty(() => entity.Source) ||
               statusManager.IsDirty(() => entity.QuestionCategories) ||
               entity.QuestionCategories.Any(statusManager.IsDirty) ||
               statusManager.IsDirty(() => entity.QuestionLinks) ||
               entity.QuestionLinks.Any(statusManager.IsDirty) ||
               entity.QuestionLinks.Any(statusManager.IsNew) ||
               statusManager.IsDirty(() => entity.QuestionFlags) ||
               entity.QuestionFlags.Any(statusManager.IsDirty) ||
               entity.QuestionFlags.Any(statusManager.IsNew);

        // Mocks

        private const int DEFAULT_ID = 1;

        private Entity CreateMockEntity() => new Entity { ID = DEFAULT_ID, Name = "OriginalName" };
        private ViewModel CreateMockViewModel() => new ViewModel { ID = DEFAULT_ID, Name = "NewName" };
    }
}