using System;
using System.Collections;
using System.Data;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for ObjectObjectMappingTests.
	/// </summary>
	[TestFixture()]
	public class ObjectObjectMappingTests : CrudTests
	{
		public override IContext GetContext()
		{
			IContext rootContext = base.GetContext ();
			IContext leafContext = new Context(rootContext);
			return leafContext;
		}

		#region TestFetchEmployeeById

		/// <summary>
		/// Fetch an employee object by identity
		/// </summary>
		[Test()]
		public virtual void TestEarlyOptimisticConcurrency()
		{
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				//we want to fetch the employee with id = 1
				int employeeId = id;

				//Ask the context to fetch the employee
				Employee employee = (Employee) context.GetObjectById(employeeId, typeof(Employee));

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);

				//Assert that the object is marked as clean
				Assert.AreEqual(ObjectStatus.Clean, context.ObjectManager.GetObjectStatus(employee));

				Assert.AreEqual(PropertyStatus.Clean, context.ObjectManager.GetPropertyStatus(employee, "Id"));
				Assert.AreEqual(PropertyStatus.Clean, context.ObjectManager.GetPropertyStatus(employee, "FirstName"));
				Assert.AreEqual(PropertyStatus.Clean, context.ObjectManager.GetPropertyStatus(employee, "LastName"));

				//Assert that the employee has the id we asked for
				Assert.AreEqual(employeeId, employee.Id);

				//Assert that the employee has the name Nancy Davolio
				//(She should, in a standard northwind setup)
				Assert.AreEqual("Nancy", employee.FirstName);
				Assert.AreEqual("Davolio", employee.LastName);			

			}
		}

		#endregion
//
//		#region TestFetchAndUpdateEmployee
//
//		/// <summary>
//		/// Fetch an employee object by identity
//		/// </summary>
//		[Test()]
//		public virtual void TestFetchAndUpdateEmployee()
//		{
//			using (IContext context = GetContext() )
//			{
//				//we want to fetch the employee with id = 10
//				int employeeId = 10;
//
//				//Ask the context to fetch the employee
//				Employee employee = (Employee) context.GetObjectById(employeeId, typeof(Employee));
//
//				//Assert that the context didn't return a null value
//				Assert.IsNotNull(employee);
//
//				//Assert that the object is marked as clean
//				Assert.AreEqual(ObjectStatus.Clean, context.ObjectManager.GetObjectStatus(employee));
//
//				Assert.AreEqual(PropertyStatus.Clean, context.ObjectManager.GetPropertyStatus(employee, "Id"));
//				Assert.AreEqual(PropertyStatus.Clean, context.ObjectManager.GetPropertyStatus(employee, "FirstName"));
//				Assert.AreEqual(PropertyStatus.Clean, context.ObjectManager.GetPropertyStatus(employee, "LastName"));
//
//				//Assert that the employee has the id we asked for
//				Assert.AreEqual(employeeId, employee.Id);
//
//				//Assert that the employee has the name Nancy Davolio
//				//(She should, in a standard northwind setup)
//				Assert.AreEqual("Mats", employee.FirstName);
//				Assert.AreEqual("Helander", employee.LastName);			
//
//				employee.FirstName = "Lars";
//				employee.LastName = "Nilsson";
//
//				context.Commit() ;
//			}
//		}
//
//		#endregion

		
	}
}
