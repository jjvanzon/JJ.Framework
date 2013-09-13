using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for ReferenceTests.
	/// </summary>
	[TestFixture()]
	public class ReferenceTests : TestBase
	{
		public ReferenceTests()
		{
		}

		#region TestFetchEmployeeById

		/// <summary>
		/// Fetch an employee object by identity
		/// </summary>
		[Test()]
		public virtual void TestFetchEmployeeById()
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

				Assert.AreEqual("Mr boss", employee.ReportsTo.FirstName);
				Assert.AreEqual("boss", employee.ReportsTo.LastName);			

				Assert.IsNull(employee.ReportsTo.ReportsTo);			
			}
		}

		#endregion

	}
}
