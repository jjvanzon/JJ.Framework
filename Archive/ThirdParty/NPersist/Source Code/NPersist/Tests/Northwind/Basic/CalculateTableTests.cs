using System;
using System.Collections;
using System.Data;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for CalculateTableTests.
	/// </summary>

	[TestFixture()]
	public class CalculateTableTests : TestBase
	{

		#region TestFetchEmployeeById

		/// <summary>
		/// Fetch an employee object by identity
		/// </summary>
		[Test()]
		public virtual void TestFetchEmployeeById()
		{ 
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContextWithPureMap() )
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
			}
		}

		#endregion

		#region TestFetchEmployeesNamedNancyByNPathQuery

		/// <summary>
		/// Fetch an employee object by first name
		/// </summary>
		[Test()]
		public virtual void TestFetchEmployeesNamedNancyByNPathQuery()
		{
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContextWithPureMap() )
			{
				//Create the query string
				string npath = "Select * From Employee Where FirstName = 'Nancy'";

				//Ask the context to fetch all employees with the first name nancy
				IList employees = context.GetObjectsByNPath(npath, typeof(Employee));

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employees);

				//Assert that the context didn't return an empty list
				Assert.IsTrue(employees.Count > 0);

				//Make sure that each employee in the collection
				//has the first name nancy
				foreach (Employee employee in employees)
					Assert.AreEqual("Nancy", employee.FirstName);

			}
		}

		#endregion

		#region TestFetchEmployeesNamedNancyDavolioByNPathQuery

		/// <summary>
		/// Fetch an employee object by last name
		/// </summary>
		[Test()]
		public virtual void TestFetchEmployeesNamedNancyDavolioByNPathQuery()
		{
			using (IContext context = GetContextWithPureMap() )
			{
				//Create the query string
				string npath = "Select * From Employee Where FirstName = ? And LastName = ?";

				//Create query parameters
				QueryParameter param1 = new QueryParameter(DbType.String, "Nancy");
				QueryParameter param2 = new QueryParameter(DbType.String, "Davolio");

				//Create an npath query object
				NPathQuery npathQuery = new NPathQuery(npath, typeof(Employee));

				//add the parameters to the query object
				npathQuery.Parameters.Add(param1);
				npathQuery.Parameters.Add(param2);

				//Ask the context to fetch all employees with the name nancy davolio
				IList employees = context.GetObjectsByQuery(npathQuery);

				//Assert that the context didn't return a null value
				Assert.IsNotNull(employees);

				//Assert that the context didn't return an empty list
				Assert.IsTrue(employees.Count > 0);

				//Make sure that each employee in the collection
				//has the name nancy davolio
				foreach (Employee employee in employees)
				{
					Assert.AreEqual("Nancy", employee.FirstName);					
					Assert.AreEqual("Davolio", employee.LastName);					
				}

			}
		}

		#endregion

		#region TestCreateAndDeleteEmployee

		/// <summary>
		/// Create a new employee object, then delete it again
		/// </summary>
		[Test()]
		public virtual void TestCreateAndDeleteEmployee()
		{
			using (IContext context = GetContextWithPureMap() )
			{
				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
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

					//Assert that the properties have the correct values
					Assert.AreEqual("Mats", employee.FirstName, "FirstName");
					Assert.AreEqual("Helander", employee.LastName, "LastName");			

					//Ask the context to delete our employee
					context.DeleteObject(employee);

					//Ask the context to remove the employee from the database again
					context.Commit();

					//Execute the sql statement again
					result = (int) context.SqlExecutor.ExecuteScalar(sql);

					//Make sure that the query for our new row returns no hits
					Assert.AreEqual(0, result, "Row not deleted!");

					//The whole test went fine! Commit the transaction!
					tx.Commit();
				}
				catch (Exception ex)
				{
					//Something went wrong!
					//Rollback the transaction and retheow the exception
					tx.Rollback();

					throw ex;
				}
			}
		}

		#endregion

		#region TestCreateAndUpdateAndDeleteEmployee

		/// <summary>
		/// Create a new employee object, then update it, then delete it again
		/// </summary>
		[Test()]
		public virtual void TestCreateAndUpdateAndDeleteEmployee()
		{
			using (IContext context = GetContextWithPureMap() )
			{
				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
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
						" And LastName = 'Helander'"; //+

					//Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
					//int result = context.SqlExecutor.ExecuteNonQuery(sql);
					int result = (int) context.SqlExecutor.ExecuteScalar(sql);

					//Make sure that the query for our new row returned exactly one hit
					Assert.AreEqual(1, result, "Row not inserted!");

					//Update the properties
					employee.FirstName = "Roger";
					employee.LastName = "Johansson";

					//Ask the context to update the row in the database
					context.Commit();

					//Make sure that the row was updated the database...
					string sql2 = "Select Count(*) From Employees Where EmployeeId = " + employee.Id.ToString() + 
						" And FirstName = 'Roger'" +
						" And LastName = 'Johansson'";

					//Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
					result = (int) context.SqlExecutor.ExecuteScalar(sql2);

					//Make sure that the query for our updated row returned exactly one hit
					Assert.AreEqual(1, result, "Row not updated!");


					//Ask the context to delete our employee
					context.DeleteObject(employee);

					//Ask the context to remove the employee from the database again
					context.Commit();

					//Execute the sql statement again
					result = (int) context.SqlExecutor.ExecuteScalar(sql2);

					//Make sure that the query for our new row returns no hits
					Assert.AreEqual(0, result, "Row not deleted!");

					//The whole test went fine! Commit the transaction!
					tx.Commit();
				}
				catch (Exception ex)
				{
					//Something went wrong!
					//Rollback the transaction and retheow the exception
					tx.Rollback();

					throw ex;
				}
			}
		}

		#endregion

	
	}

}
