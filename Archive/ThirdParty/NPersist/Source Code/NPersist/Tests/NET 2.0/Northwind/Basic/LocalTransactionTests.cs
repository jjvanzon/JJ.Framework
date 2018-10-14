using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for TestLocalTransactions.
	/// </summary>
	public class LocalTransactionsTest : TestBase
	{
		public LocalTransactionsTest()
		{
		}

		
		#region TestCreateAndDeleteEmployee

		/// <summary>
		/// Create a new employee object, then delete it again
		/// </summary>
		[Test()]
		public virtual void TestCreateAndDeleteEmployee()
		{
			using (IContext context = GetContext() )
			{
				//Ask the context to create the new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employee);

				//Set the properties of the new employee object
				employee.FirstName = "Mats";
				employee.LastName = "Helander";
				employee.HireDate = DateTime.Now;

				//Ask the context to insert our new employee into the database
				context.Commit() ;

				//The employee has an Id mapping to an autoincreasing column.
				//Make sure the employee object has been updated with its new identity
				Assert.IsTrue(employee.Id > 0, "Employee was not given identity!");

				//Make sure that the row was inserted into the database...
				//To do this we resort to some good old sql...
				string sql = "Select Count(*) From Employees Where EmployeeId = " + employee.Id.ToString() + 
					" And FirstName = 'Mats'" +
					" And LastName = 'Helander'";

				//Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
				int result = (int) context.SqlExecutor.ExecuteScalar(sql);

				//Make sure that the query for our new row returned exactly one hit
				Assert.AreEqual(1, result, "Row not inserted!");

				//Ask the context to delete our employee
				context.DeleteObject(employee);

				//Ask the context to remove the employee from the database again
				context.Commit();

				//Execute the sql statement again
				result = (int) context.SqlExecutor.ExecuteScalar(sql);

				//Make sure that the query for our new row returns no hits
				Assert.AreEqual(0, result, "Row not deleted!");

			}
		}

		#endregion


	}
}
