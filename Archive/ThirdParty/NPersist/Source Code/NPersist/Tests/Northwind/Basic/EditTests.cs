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
	/// Summary description for EditTests.
	/// </summary>
	[TestFixture()]
	public class EditTests : TestBase
	{

		#region TestFetchEmployeeBeginEditUpdateThenCancel

		/// <summary>
		/// Fetch an employee object by identity
		/// </summary>
		[Test()]
		public virtual void TestFetchEmployeeBeginEditUpdateThenCancel()
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

				//Assert that the employee has the id we asked for
				Assert.AreEqual(employeeId, employee.Id);

				//Assert that the employee has the name Nancy Davolio
				//(She should, in a standard northwind setup)
				Assert.AreEqual("Nancy", employee.FirstName);
				Assert.AreEqual("Davolio", employee.LastName);			

				Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(employee));

				Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "FirstName"));
				Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "LastName"));

				context.BeginEdit() ;

				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				//Assert that the employee has the name Mats Helander
				Assert.AreEqual("Mats", employee.FirstName);
				Assert.AreEqual("Helander", employee.LastName);			
				
				Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

				Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "FirstName"));
				Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "LastName"));

				context.CancelEdit() ;

				//Assert that the employee has the name Nancy Davolio again
				Assert.AreEqual("Nancy", employee.FirstName);
				Assert.AreEqual("Davolio", employee.LastName);			

				Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(employee));
				
				Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "FirstName"));
				Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "LastName"));

			}
		}

		#endregion

	
		#region TestFetchEmployeeBeginEditUpdateThenCancel

		/// <summary>
		/// Fetch an employee object by identity
		/// </summary>
		[Test()]
		public virtual void TestBeginEditCreateEmployeeThenCancel()
		{
			using (IContext context = GetContext() )
			{
				context.BeginEdit() ;

				//Ask the context to create the employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);

				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				//Assert that the employee has the name Mats Helander
				Assert.AreEqual("Mats", employee.FirstName);
				Assert.AreEqual("Helander", employee.LastName);			
				
				Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "FirstName"));
				Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "LastName"));

				Assert.IsTrue(context.IdentityMap.HasObject(employee));

				context.CancelEdit() ;

				Assert.AreEqual(ObjectStatus.NotRegistered, context.GetObjectStatus(employee));

				Assert.IsFalse(context.IdentityMap.HasObject(employee));

			}
		}

		#endregion

	
	}
}
