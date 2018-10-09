using System;
using JJ.Framework.Configuration;
using JJ.Framework.Data.Tests.Helpers;
using JJ.Framework.Data.Tests.Model;
using JJ.Framework.Testing;
using JJ.Framework.Testing.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedVariable
// ReSharper disable AccessToDisposedClosure
// ReSharper disable JoinDeclarationAndInitializer

namespace JJ.Framework.Data.Tests
{
    [TestClass]
    public class PersistenceTests
    {
        private const int EXISTING_THING_ID = 1;
        private const int NON_EXISTENT_THING_ID = 0;

        // CreateContext

        [TestMethod]
        public void Test_Persistence_NHibernate_CreateContext() => Test_Persistence_CreateContext(GetNHibernateContextType());

        [TestMethod]
        public void Test_Persistence_EntityFramework_CreateContext() => Test_Persistence_CreateContext(GetEntityFrameworkContextType());

        private void Test_Persistence_CreateContext(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType)) { }
                });

        // Get

        [TestMethod]
        public void Test_Persistence_NHibernate_Get() => Test_Persistence_Get(GetNHibernateContextType());

        [TestMethod]
        public void Test_Persistence_EntityFramework_Get() => Test_Persistence_Get(GetEntityFrameworkContextType());

        private void Test_Persistence_Get(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        Thing entity;

                        // Get existing
                        entity = context.Get<Thing>(EXISTING_THING_ID);
                        int id = entity.ID;
                        string name = entity.Name;

                        // Get non-existent
                        AssertHelper.ThrowsException(() => entity = context.Get<Thing>(NON_EXISTENT_THING_ID));
                    }
                });

        // TryGet

        [TestMethod]
        public void Test_Persistence_NHibernate_TryGet() => Test_Persistence_TryGet(GetNHibernateContextType());

        [TestMethod]
        public void Test_Persistence_EntityFramework_TryGet() => Test_Persistence_TryGet(GetEntityFrameworkContextType());

        private void Test_Persistence_TryGet(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        Thing entity;

                        // Try get existing
                        entity = context.TryGet<Thing>(EXISTING_THING_ID);
                        int id = entity.ID;
                        string name = entity.Name;

                        // Try get non-existent
                        entity = context.TryGet<Thing>(NON_EXISTENT_THING_ID);
                        Assert.IsNull(entity);
                    }
                });

        // Create

        [TestMethod]
        public void Test_Persistence_NHibernate_Create() => Test_Persistence_Create(GetNHibernateContextType());

        [TestMethod]
        public void Test_Persistence_EntityFramework_Create() => Test_Persistence_Create(GetEntityFrameworkContextType());

        private void Test_Persistence_Create(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        var entity = context.Create<Thing>();
                        entity.Name = "Thing was created";
                        context.Commit();
                    }
                });

        // Insert

        [TestMethod]
        public void Test_Persistence_NHibernate_Insert() => Test_Persistence_Insert(GetNHibernateContextType());

        [TestMethod]
        public void Test_Persistence_EntityFramework_Insert() => Test_Persistence_Insert(GetEntityFrameworkContextType());

        private void Test_Persistence_Insert(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        var entity = new Thing { Name = "Thing was inserted" };
                        context.Insert(entity);
                        context.Commit();
                    }
                });

        // Update

        [TestMethod]
        public void Test_Persistence_NHibernate_Update() => Test_Persistence_Update(GetNHibernateContextType());

        [TestMethod]
        public void Test_Persistence_EntityFramework_Update() => Test_Persistence_Update(GetEntityFrameworkContextType());

        private void Test_Persistence_Update(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        var entity = context.Get<Thing>(1);
                        entity.Name += "Thing was updated";
                        context.Update(entity);
                    }
                });

        // Delete

        [TestMethod]
        public void Test_Persistence_NHibernate_Delete() => Test_Persistence_Delete(GetNHibernateContextType());

        [TestMethod]
        public void Test_Persistence_EntityFramework_Delete() => Test_Persistence_Delete(GetEntityFrameworkContextType());

        private void Test_Persistence_Delete(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    int id;

                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        var entity = context.Create<Thing>();
                        entity.Name = "Thing was created";
                        context.Commit();
                        id = entity.ID;
                    }

                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        var entity = context.Get<Thing>(id);
                        context.Delete(entity);
                        context.Commit();
                    }
                });

        // Query

        //[TestMethod]
        //public void Test_Persistence_NHibernate_Query()
        //    => TestHelper.WithConnectionInconclusiveAssertion(
        //        () => AssertHelper.ThrowsException(
        //            () => Test_Persistence_Query_WithoutConnectionInconclusiveAssertion(GetNHibernateContextType()),
        //            "Use ISession.QueryOver<TEntity> instead."));

        [TestMethod]
        public void Test_Persistence_NHibernate_Query()
        {
            // AssertHelper.ThrowsException cannot help you here,
            // beause if test is inconclusive due to database connection problems,
            // there is an inconclusive exception, not the exception expected here.

            try
            {
                Test_Persistence_Query(GetNHibernateContextType());
            }
            catch (AssertInconclusiveException)
            {
                // Ignore inconclusive exception.
                return;
            }
            catch (Exception ex)
            {
                AssertHelper.AreEqual("Use ISession.QueryOver<TEntity> instead.", () => ex.Message);
                return;
            }

            throw new Exception("An exception should have occurred.");
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_Query() => Test_Persistence_Query(GetEntityFrameworkContextType());

        private void Test_Persistence_Query(string contextType)
            => AssertInconclusiveHelper.WithConnectionInconclusiveAssertion(
                () =>
                {
                    using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
                    {
                        foreach (Thing entity in context.Query<Thing>())
                        {
                            int id = entity.ID;
                            string name = entity.Name;
                        }
                    }
                });

        // Helpers

        private string GetNHibernateContextType() => GetConfiguration().NHibernateContextType;
        private string GetEntityFrameworkContextType() => GetConfiguration().EntityFrameworkContextType;
        private ConfigurationSection GetConfiguration() => CustomConfigurationManager.GetSection<ConfigurationSection>();
    }
}