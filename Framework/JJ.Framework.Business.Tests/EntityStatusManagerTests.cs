using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Business.Tests.Helpers;
using System.Linq;

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
        {
            return statusManager.IsDirty(entity) ||
                   statusManager.IsNew(entity) ||
                   statusManager.IsDirty(() => entity.QuestionType) ||
                   statusManager.IsDirty(() => entity.QuestionSource) ||
                   statusManager.IsDirty(() => entity.QuestionCategories) ||
                   entity.QuestionCategories.Any(x => statusManager.IsDirty(x)) ||
                   statusManager.IsDirty(() => entity.QuestionLinks) ||
                   entity.QuestionLinks.Any(x => statusManager.IsDirty(x)) ||
                   entity.QuestionLinks.Any(x => statusManager.IsNew(x)) ||
                   statusManager.IsDirty(() => entity.QuestionFlags) ||
                   entity.QuestionFlags.Any(x => statusManager.IsDirty(x)) ||
                   entity.QuestionFlags.Any(x => statusManager.IsNew(x));
        }

        // Mocks
        private const int DEFAULT_ID = 1;

        private Entity CreateMockEntity()
        {
            return new Entity { ID = DEFAULT_ID, Name = "OriginalName" };
        }

        private ViewModel CreateMockViewModel()
        {
            return new ViewModel { ID = DEFAULT_ID, Name = "NewName" };
        }
    }
}
