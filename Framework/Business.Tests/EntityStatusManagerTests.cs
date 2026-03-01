using System.Linq;
using JJ.Framework.Business.Tests;
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
            Question entity = CreateMockEntity();
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
            statusManagerByID.SetIsDirty<Question>(entity.ID);
            statusManagerByID.SetIsDirty(entity.ID, () => entity.Name);
            isDirty = statusManagerByID.IsDirty<Question>(entity.ID);
            isDirty = statusManagerByID.IsDirty(entity.ID, () => entity.Name);
        }

        private bool MustSetLastModifiedByUser(Question entity, EntityStatusManager statusManager)
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

        private Question CreateMockEntity() => new Question { ID = DEFAULT_ID, Name = "OriginalName" };
        private ViewModel CreateMockViewModel() => new ViewModel { Key = DEFAULT_ID, Name = "NewName" };
    }
}