using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions ;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for TestOptimisticConcurrency.
	/// </summary>
	[TestClass]
	public class OptimisticConcurrencyTests : TestBase
	{
		
		#region TestOptimisticConcurrencyBasic

		/// <summary>
		/// </summary>
		[TestMethod, ExpectedException(typeof(OptimisticConcurrencyException))]
		public virtual void TestOptimisticConcurrencyBasic()
		{
			using (IContext context = GetContext() )
			{
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save via the second context
				employee2.FirstName = "Roger";
				employee2.LastName = "Johansson";

				context2.Commit();

				context2.Dispose();

				//we set some values and save in the first context
				//this should cause an optimistic concurrency exception
				employee.FirstName = "John";
				employee.LastName = "Doe";

				context.Commit();

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);
			}
		}

		#endregion

		#region TestOptimisticConcurrencyIncludeWhenDirty

		/// <summary>
		/// </summary>
		[TestMethod]
		public virtual void TestOptimisticConcurrencyIncludeWhenDirty()
		{
			using (IContext context = GetContext() )
			{
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save via the second context
				employee2.LastName = "Johansson";

				context2.Commit();

				context2.Dispose();

				//we set some values and save in the first context
				//this should not cause an optimistic concurrency exception
				//because we have not changed the same field as context2
				employee.FirstName = "John";

				context.Commit();

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);
			}
		}

		#endregion

		#region TestOptimisticConcurrencyIncludeWhenLoaded

		/// <summary>
		/// </summary>
		[TestMethod, ExpectedException(typeof(OptimisticConcurrencyException))]
		public virtual void TestOptimisticConcurrencyIncludeWhenLoaded()
		{
			using (IContext context = GetContext() )
			{
				//Set the context to include all loaded properties
				//in the optimistic concurrency check (default is to only
				//check for dirty properties)
				context.PersistenceManager.UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenLoaded ;
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save via the second context
				employee2.LastName = "Johansson";

				context2.Commit();

				context2.Dispose();

				//we set some values and save in the first context
				//this cause an optimistic concurrency exception
				employee.FirstName = "John";

				context.Commit();

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);
			}
		}

		#endregion

		#region TestOptimisticConcurrencyThenResolveWithRefresh

		/// <summary>
		/// </summary>
		[TestMethod]
		public virtual void TestOptimisticConcurrencyThenResolveWithRefresh()
		{
			using (IContext context = GetContext() )
			{
				//Set the context to include all loaded properties
				//in the optimistic concurrency check (default is to only
				//check for dirty properties)
				context.PersistenceManager.UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenLoaded ;
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save via the second context
				employee2.LastName = "Johansson";

				context2.Commit();

				context2.Dispose();

				//we set some values and save in the first context
				//this cause an optimistic concurrency exception
				employee.FirstName = "John";

				int catches = 0;

				try
				{
					context.Commit();					
				}
				catch (OptimisticConcurrencyException ex)
				{
					catches++;
					context.RefreshObject(employee, RefreshBehaviorType.OverwriteLoaded);

					Assert.AreEqual("John", employee.FirstName );
					Assert.AreEqual("Johansson", employee.LastName );

					context.Commit();					
				}

				Assert.AreEqual(1, catches );
			}
		}

		#endregion

		#region TestOptimisticConcurrencyThenResolveWithRefreshThenOverwriteDirty

		/// <summary>
		/// </summary>
		[TestMethod]
		public virtual void TestOptimisticConcurrencyThenResolveWithRefreshThenOverwriteDirty()
		{
			using (IContext context = GetContext() )
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(this.HandleExecutingSql) ;

				//Set the context to include all loaded properties
				//in the optimistic concurrency check (default is to only
				//check for dirty properties)
				context.PersistenceManager.UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenLoaded ;
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				Assert.AreEqual(ObjectStatus.UpForCreation, context.GetObjectStatus(employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(employee));

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save via the second context
				employee2.FirstName = "Roger";
				employee2.LastName = "Johansson";

				context2.Commit();

				context2.Dispose();

				//we set some values and save in the first context
				//this cause an optimistic concurrency exception
				employee.FirstName = "John";

				int catches = 0;

				Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

				try
				{
					context.Commit();					
				}
				catch (OptimisticConcurrencyException ex)
				{
					catches++;
					Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

					context.RefreshObject(employee, RefreshBehaviorType.OverwriteLoaded);

					Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

					Assert.AreEqual("John", employee.FirstName );
					Assert.AreEqual("Johansson", employee.LastName );

					Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "FirstName"));
					Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "LastName"));

					Assert.AreEqual("Mats", context.ObjectManager.GetOriginalPropertyValue(employee, "FirstName"));

					try
					{
						context.Commit();					
					}
					catch (OptimisticConcurrencyException ex2)
					{
						catches++;
						context.RefreshObject(employee, RefreshBehaviorType.OverwriteDirty);

						Assert.AreEqual("Roger", employee.FirstName );

						employee.FirstName = "John";

						context.Commit();					
					}
				}

				Assert.AreEqual(2, catches );
				
				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);
			}
		}

		#endregion

		#region TestOptimisticConcurrencyThenResolveWithRefreshThenRefreshProperty

		/// <summary>
		/// </summary>
		[TestMethod]
		public virtual void TestOptimisticConcurrencyThenResolveWithRefreshThenRefreshProperty()
		{
			using (IContext context = GetContext() )
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(this.HandleExecutingSql) ;

				//Set the context to include all loaded properties
				//in the optimistic concurrency check (default is to only
				//check for dirty properties)
				context.PersistenceManager.UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenLoaded ;
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				Assert.AreEqual(ObjectStatus.UpForCreation, context.GetObjectStatus(employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(employee));

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save via the second context
				employee2.FirstName = "Roger";
				employee2.LastName = "Johansson";

				context2.Commit();

				context2.Dispose();

				//we set some values and save in the first context
				//this cause an optimistic concurrency exception
				employee.FirstName = "John";

				int catches = 0;

				Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

				try
				{
					context.Commit();					
				}
				catch (OptimisticConcurrencyException ex)
				{
					catches++;
					Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

					context.RefreshObject(employee, RefreshBehaviorType.OverwriteLoaded);

					Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

					Assert.AreEqual("John", employee.FirstName );
					Assert.AreEqual("Johansson", employee.LastName );

					Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "FirstName"));
					Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "LastName"));

					Assert.AreEqual("Mats", context.ObjectManager.GetOriginalPropertyValue(employee, "FirstName"));

					try
					{
						context.Commit();					
					}
					catch (OptimisticConcurrencyException ex2)
					{
						catches++;
						context.RefreshProperty(employee, "FirstName", RefreshBehaviorType.OverwriteDirty);

						Assert.AreEqual("Roger", employee.FirstName );

						employee.FirstName = "John";

						context.Commit();					
					}
				}

				Assert.AreEqual(2, catches );
				
				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);
			}
		}

		#endregion

		private void HandleExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}
	}
}
