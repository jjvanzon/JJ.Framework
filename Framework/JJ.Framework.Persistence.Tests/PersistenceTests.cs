using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Configuration;
using JJ.Framework.Persistence.Tests.Model;

namespace JJ.Framework.Persistence.Tests
{
    [TestClass]
    public class PersistenceTests
    {
        // CreateContext

        [TestMethod]
        public void Test_Persistence_NHibernate_CreateContext()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_CreateContext(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_CreateContext()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_CreateContext(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_CreateContext()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_CreateContext(contextType);
        }

        private void Test_Persistence_CreateContext(string contextType)
        {
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            { }
        }

        // GetEntity

        [TestMethod]
        public void Test_Persistence_NHibernate_GetEntity()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_GetEntity(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_GetEntity()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_GetEntity(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_GetEntity()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_GetEntity(contextType);
        }

        private void Test_Persistence_GetEntity(string contextType)
        {
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                Thing thing = context.GetEntity<Thing>(1).Entity;
                int id = thing.ID;
                string name = thing.Name;
            }
        }

        // GetEntities

        [TestMethod]
        public void Test_Persistence_NHibernate_GetEntities()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_GetEntities(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_GetEntities()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_GetEntities(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_GetEntities()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_GetEntities(contextType);
        }

        private void Test_Persistence_GetEntities(string contextType)
        {
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                foreach (EntityWrapper<Thing> wrapper in context.GetEntities<Thing>())
                {
                    Thing thing = wrapper.Entity;
                    int id = thing.ID;
                    string name = thing.Name;
                }
            }
        }

        // Create

        [TestMethod]
        public void Test_Persistence_NHibernate_CreateEntity()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_CreateEntity(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_CreateEntity()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_CreateEntity(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_CreateEntity()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_CreateEntity(contextType);
        }

        private void Test_Persistence_CreateEntity(string contextType)
        {
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                Thing thing = context.CreateEntity<Thing>().Entity;
                thing.Name = "Thing was created";
                context.Commit();
            }
        }

        // Insert

        [TestMethod]
        public void Test_Persistence_NHibernate_Insert()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_Insert(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_Insert()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_Insert(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_Insert()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_Insert(contextType);
        }

        private void Test_Persistence_Insert(string contextType)
        {
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                Thing thing = new Thing { Name = "Thing was inserted" };
                context.Insert<Thing>(thing);
                context.Commit();
            }
        }

        // Update

        [TestMethod]
        public void Test_Persistence_NHibernate_Update()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_Update(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_Update()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_Update(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_Update()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_Update(contextType);
        }

        private void Test_Persistence_Update(string contextType)
        {
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                Thing thing = context.GetEntity<Thing>(1).Entity;

                thing.Name += "Thing was updated";
                context.Update<Thing>(thing);
            }
        }

        // Delete

        [TestMethod]
        public void Test_Persistence_NHibernate_Delete()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_Delete(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_Delete()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_Delete(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_Delete()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_Delete(contextType);
        }

        private void Test_Persistence_Delete(string contextType)
        {
            int id;
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                Thing thing = context.CreateEntity<Thing>().Entity;
                thing.Name = "Thing was created";
                context.Commit();
                id = thing.ID;
            }

            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                Thing thing = context.GetEntity<Thing>(id).Entity;
                context.Delete(thing);
                context.Commit();
            }
        }

        // Query

        [TestMethod]
        public void Test_Persistence_NHibernate_Query()
        {
            string contextType = GetNHibernateContextType();
            Test_Persistence_Query(contextType);
        }

        [TestMethod]
        public void Test_Persistence_NPersist_Query()
        {
            string contextType = GetNPersistContextType();
            Test_Persistence_Query(contextType);
        }

        [TestMethod]
        public void Test_Persistence_EntityFramework_Query()
        {
            string contextType = GetEntityFrameworkContextType();
            Test_Persistence_Query(contextType);
        }

        private void Test_Persistence_Query(string contextType)
        {
            using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
            {
                foreach (EntityWrapper<Thing> wrapper in context.Query<Thing>())
                {
                    Thing thing = wrapper.Entity;
                    int id = thing.ID;
                    string name = thing.Name;
                }
            }
        }

        // Helpers

        private string GetNHibernateContextType()
        {
            return GetConfiguration().NHibernateContextType;
        }

        private string GetNPersistContextType()
        {
            return GetConfiguration().NPersistContextType;
        }

        private string GetEntityFrameworkContextType()
        {
            return GetConfiguration().EntityFrameworkContextType;
        }

        private ConfigurationSection GetConfiguration()
        {
            return ConfigurationManager.GetSection<ConfigurationSection>();
        }
    }
}
