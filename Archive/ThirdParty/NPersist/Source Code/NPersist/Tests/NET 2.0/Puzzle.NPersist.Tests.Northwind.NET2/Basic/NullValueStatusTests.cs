using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for NullValueStatusTests.
	/// </summary>
	[TestClass]
	public class NullValueStatusTests : TestBase
	{
		public NullValueStatusTests()
		{
		}


		#region TestCreateWithNull

		/// <summary>
		/// Create a new employee object, then delete it again
		/// </summary>
		[TestMethod]
		public virtual void TestCreateWithNull()
		{
			int id = 0;

			using (IContext context = GetContext() )
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
					context.SetNullValueStatus(employee, "HireDate", true);

					//Ask the context to insert our new employee into the database
					context.Commit() ;

					//The employee has an Id mapping to an autoincreasing column.
					//Make sure the employee object has been updated with its new identity
					Assert.IsTrue(employee.Id > 0, "Employee was not given identity!");

					id = employee.Id;

					//Make sure that the row was inserted into the database...
					//To do this we resort to some good old sql...
					string sql = "Select Count(*) From Employees Where EmployeeId = " + employee.Id.ToString() + 
						" And FirstName = 'Mats'" +
						" And LastName = 'Helander' And HireDate Is Null";

					//Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
					int result = (int) context.SqlExecutor.ExecuteScalar(sql);

					//Make sure that the query for our new row returned exactly one hit
					Assert.AreEqual(1, result, "Row not correctly inserted!");


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


			using (IContext context = GetContext() )
			{
				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{
					//Ask the context to create the new employee
					Employee employee = (Employee) context.GetObject(id, typeof(Employee));

                    Console.WriteLine(employee.HireDate);

					//Assert that the context didn't return a null value
					Assert.IsNotNull(employee);

					//Set the properties of the new employee object
					Assert.AreEqual("Mats", employee.FirstName);  
					Assert.AreEqual("Helander", employee.LastName);
					Assert.IsTrue(context.GetNullValueStatus(employee, "HireDate"));
					
					//Ask the context to delete our employee
					context.DeleteObject(employee);

					//Ask the context to remove the employee from the database again
					context.Commit();

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


		#region TestCreateWithNull

		/// <summary>
		/// Create a new employee object, then delete it again
		/// </summary>
		[TestMethod]
		public virtual void TestCreateWithNullAndUpdateLeavingNull()
		{
			int id = 0;

			using (IContext context = GetContext() )
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
					context.SetNullValueStatus(employee, "HireDate", true);

					//Ask the context to insert our new employee into the database
					context.Commit() ;

					//The employee has an Id mapping to an autoincreasing column.
					//Make sure the employee object has been updated with its new identity
					Assert.IsTrue(employee.Id > 0, "Employee was not given identity!");

					id = employee.Id;

					//Make sure that the row was inserted into the database...
					//To do this we resort to some good old sql...
					string sql = "Select Count(*) From Employees Where EmployeeId = " + employee.Id.ToString() + 
						" And FirstName = 'Mats'" +
						" And LastName = 'Helander' And HireDate Is Null";

					//Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
					int result = (int) context.SqlExecutor.ExecuteScalar(sql);

					//Make sure that the query for our new row returned exactly one hit
					Assert.AreEqual(1, result, "Row not correctly inserted!");


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


			using (IContext context = GetContext() )
			{
				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{
					//Ask the context to create the new employee
					Employee employee = (Employee) context.GetObject(id, typeof(Employee));

					//Assert that the context didn't return a null value
					Assert.IsNotNull(employee);

					//Set the properties of the new employee object
					Assert.AreEqual("Mats", employee.FirstName);  
					Assert.AreEqual("Helander", employee.LastName);
					Assert.IsTrue(context.GetNullValueStatus(employee, "HireDate"));
					
					//Update the name but leave the nulled HireDate as null
					employee.FirstName = "Roger";

					//Ask the context to remove the employee from the database again
					context.Commit();

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



			using (IContext context = GetContext() )
			{
				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{
					//Ask the context to create the new employee
					Employee employee = (Employee) context.GetObject(id, typeof(Employee));

					//Assert that the context didn't return a null value
					Assert.IsNotNull(employee);

					//Set the properties of the new employee object
					Assert.AreEqual("Roger", employee.FirstName);  
					Assert.AreEqual("Helander", employee.LastName);
					Assert.IsTrue(context.GetNullValueStatus(employee, "HireDate"));
					
					//Ask the context to delete our employee
					context.DeleteObject(employee);

					//Ask the context to remove the employee from the database again
					context.Commit();

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
