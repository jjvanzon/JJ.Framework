using System;
using System.Collections;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for GetDataTableTests.
	/// </summary>
	[TestClass]
	public class GetDataTableTests : TestBase
	{

		#region TestFetchEmployees

		/// <summary>
		/// Fetch an employee object by identity
		/// </summary>
		[TestMethod]
		public virtual void TestFetchEmployeeById()
		{
			using (IContext context = GetContext() )
			{
//				//we want to fetch the top 9 employees
//				string npath = "Select * From Employee";
//
//				//Ask the context to fetch the employee
//				Employee employee = (Employee) context.GetObjectById(employeeId, typeof(Employee));
//
//				//Assert that the context didn't return a null value
//				Assert.IsNotNull(employee);
//
//				//Assert that the employee has the id we asked for
//				Assert.AreEqual(employeeId, employee.Id);
//
//				//Assert that the employee has the name Nancy Davolio
//				//(She should, in a standard northwind setup)
//				Assert.AreEqual("Nancy", employee.FirstName);
//				Assert.AreEqual("Davolio", employee.LastName);			
			}
		}

		#endregion
	}
}
