using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{

	[TestFixture()]
	public class InverseManagerTests : TestBase
	{

		#region TestInverseManagerOnReferenceProperty

		/// <summary>
		/// Make sure that traversing reference properties will cause
		/// the proper lazy loading behavior
		/// </summary>
		[Test()]
		public virtual void TestInverseManagerOnReferenceProperty()
		{
			using (IContext context = GetContext() )
			{
				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{

					//Ask the context to create a new employee object
					Employee employee = (Employee) context.CreateObject(typeof(Employee));

					//Ask the context to create a new employee object
					Employee boss = (Employee) context.CreateObject(typeof(Employee));
					Employee boss2 = (Employee) context.CreateObject(typeof(Employee));

					//Assert that the context didn't return null values
					Assert.IsNotNull(employee);
					Assert.IsNotNull(boss);

					//set up the relationship using the ReportsTo reference property 
					employee.ReportsTo = boss;

					//Make sure that the inverse manager has added the employee
					//to the Employees property of the boss object
					Assert.IsTrue(boss.Employees.Contains(employee)) ;

					//Change the relationship to another boss
					employee.ReportsTo = boss2;

					//Make sure that the inverse manager has removed the employee
					//from the Employees property of the old boss object
					Assert.IsFalse(boss.Employees.Contains(employee)) ;
					
					//Make sure that the inverse manager has added the employee
					//to the Employees property of the new boss object
					Assert.IsTrue(boss2.Employees.Contains(employee)) ;
					
					//Nevermind saving the new employees to the database in this test...

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

		#region TestInverseManagerOnReferenceListProperty

		/// <summary>
		/// Make sure that traversing reference list properties will cause
		/// the proper lazy loading behavior
		/// </summary>
		[Test()]
		public virtual void TestInverseManagerOnReferenceListProperty()
		{
			using (IContext context = GetContext() )
			{
				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{

					//Ask the context to create a new employee object
					Employee employee = (Employee) context.CreateObject(typeof(Employee));

					//Ask the context to create a new employee object
					Employee boss = (Employee) context.CreateObject(typeof(Employee));
					Employee boss2 = (Employee) context.CreateObject(typeof(Employee));

					//Assert that the context didn't return null values
					Assert.IsNotNull(employee);
					Assert.IsNotNull(boss);

					//set up the relationship using the Employees reference list property 
					boss.Employees.Add(employee);

					//Make sure that the inverse manager has wrtten the boss
					//to the ReportsTo property of the employee object
					Assert.IsTrue(employee.ReportsTo == boss) ;

					//Change the relationship to another boss
					boss2.Employees.Add(employee);

					//Make sure that the inverse manager has removed the employee
					//from the Employees property of the old boss object
					Assert.IsFalse(boss.Employees.Contains(employee)) ;
					
					//Make sure that the inverse manager has wrtten the new boss
					//to the ReportsTo property of the employee object
					Assert.IsTrue(employee.ReportsTo == boss2) ;
					
					//Nevermind saving the new employees to the database in this test...

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
