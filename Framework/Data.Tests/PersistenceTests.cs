using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Configuration;
using JJ.Framework.Data.Tests.Model;
using JJ.Framework.Testing;
using JJ.Framework.Logging;
using JJ.Framework.Data.Tests.Helpers;
using System.Data.SqlClient;

namespace JJ.Framework.Data.Tests
{
	[TestClass]
	public class PersistenceTests
	{
		private const int EXISTING_THING_ID = 1;
		private const int NON_EXISTENT_THING_ID = 0;

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
		public void Test_Persistence_EntityFramework5_CreateContext()
		{
			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_CreateContext(contextType);
		}

		private void Test_Persistence_CreateContext(string contextType)
		{
			using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
			{ }
		}

		// Get

		[TestMethod]
		public void Test_Persistence_NHibernate_Get()
		{
			string contextType = GetNHibernateContextType();
			Test_Persistence_Get(contextType);
		}

		[TestMethod]
		public void Test_Persistence_NPersist_Get()
		{
			string contextType = GetNPersistContextType();

			TestHelper.WithNPersistInconclusiveAssertion(() =>
			{
				Test_Persistence_Get(contextType);
			});
		}

		[TestMethod]
		public void Test_Persistence_EntityFramework5_Get()
		{
			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_Get(contextType);
		}

		private void Test_Persistence_Get(string contextType)
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
		}

		// TryGet

		[TestMethod]
		public void Test_Persistence_NHibernate_TryGet()
		{
			string contextType = GetNHibernateContextType();
			Test_Persistence_TryGet(contextType);
		}

		[TestMethod]
		public void Test_Persistence_NPersist_TryGet()
		{
			string contextType = GetNPersistContextType();

			TestHelper.WithNPersistInconclusiveAssertion(() =>
			{
				Test_Persistence_TryGet(contextType);
			});
		}

		[TestMethod]
		public void Test_Persistence_EntityFramework5_TryGet()
		{
			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_TryGet(contextType);
		}

		private void Test_Persistence_TryGet(string contextType)
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
		}

		// Create

		[TestMethod]
		public void Test_Persistence_NHibernate_Create()
		{
			string contextType = GetNHibernateContextType();
			Test_Persistence_Create(contextType);
		}

		[TestMethod]
		public void Test_Persistence_NPersist_Create()
		{
			string contextType = GetNPersistContextType();

			TestHelper.WithNPersistInconclusiveAssertion(() =>
			{
				Test_Persistence_Create(contextType);
			});
		}

		[TestMethod]
		public void Test_Persistence_EntityFramework5_Create()
		{
			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_Create(contextType);
		}

		private void Test_Persistence_Create(string contextType)
		{
			using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
			{
				Thing entity = context.Create<Thing>();
				entity.Name = "Thing was created";
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

			TestHelper.WithNPersistInconclusiveAssertion(() =>
			{
				Test_Persistence_Insert(contextType);
			});
		}

		[TestMethod]
		public void Test_Persistence_EntityFramework5_Insert()
		{
			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_Insert(contextType);
		}

		private void Test_Persistence_Insert(string contextType)
		{
			using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
			{
				Thing entity = new Thing { Name = "Thing was inserted" };
				context.Insert(entity);
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

			TestHelper.WithNPersistInconclusiveAssertion(() =>
			{
				Test_Persistence_Update(contextType);
			});
		}

		[TestMethod]
		public void Test_Persistence_EntityFramework5_Update()
		{
			Assert.Inconclusive("I think my EntityFramework5 stuff stopped working since some Visual Studio update?");

			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_Update(contextType);
		}

		private void Test_Persistence_Update(string contextType)
		{
			using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
			{
				Thing entity = context.Get<Thing>(1);
				entity.Name += "Thing was updated";
				context.Update(entity);
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

			TestHelper.WithNPersistInconclusiveAssertion(() =>
			{
				Test_Persistence_Delete(contextType);
			});
		}

		[TestMethod]
		public void Test_Persistence_EntityFramework5_Delete()
		{
			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_Delete(contextType);
		}

		private void Test_Persistence_Delete(string contextType)
		{
			int id;
			using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
			{
				Thing entity = context.Create<Thing>();
				entity.Name = "Thing was created";
				context.Commit();
				id = entity.ID;
			}

			using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
			{
				Thing entity = context.Get<Thing>(id);
				context.Delete(entity);
				context.Commit();
			}
		}

		// Query

		[TestMethod]
		public void Test_Persistence_NHibernate_Query()
		{
			string contextType = GetNHibernateContextType();

			try
			{
				Test_Persistence_Query(contextType);
			}
			catch (Exception ex)
			{
				// This is the expected exception message.
				if (string.Equals(ex.Message, "Use ISession.QueryOver<TEntity> instead."))
				{
					return;
				}

				// This handles the case where the database is not available.
				Exception innerMostException = ExceptionHelper.GetInnermostException(ex);
				if (innerMostException is SqlException)
				{
					string message = ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace: false);
					Assert.Inconclusive(message);
				}

				// Any other exception is a genuine error.
				throw;
			}
		}

		[TestMethod]
		public void Test_Persistence_NPersist_Query()
		{
			string contextType = GetNPersistContextType();

			TestHelper.WithNPersistInconclusiveAssertion(() =>
			{
				Test_Persistence_Query(contextType);
			});
		}

		[TestMethod]
		public void Test_Persistence_EntityFramework5_Query()
		{
			string contextType = GetEntityFramework5ContextType();
			Test_Persistence_Query(contextType);
		}

		private void Test_Persistence_Query(string contextType)
		{
			using (IContext context = PersistenceHelper.CreatePersistenceContext(contextType))
			{
				foreach (Thing entity in context.Query<Thing>())
				{
					int id = entity.ID;
					string name = entity.Name;
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

		private string GetEntityFramework5ContextType()
		{
			return GetConfiguration().EntityFramework5ContextType;
		}

		private ConfigurationSection GetConfiguration()
		{
			return CustomConfigurationManager.GetSection<ConfigurationSection>();
		}
	}
}
