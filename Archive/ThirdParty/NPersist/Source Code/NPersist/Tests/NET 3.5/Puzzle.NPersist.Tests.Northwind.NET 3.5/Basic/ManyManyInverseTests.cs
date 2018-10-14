using System;
using System.Text;
using System.Collections.Generic;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5.Basic
{
    /// <summary>
    /// Summary description for ManyManyInverseTests
    /// </summary>
    [TestClass]
    public class ManyManyInverseTests : TestBase
    {
        public ManyManyInverseTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

  
        #region TestCreateAndDeleteEmployeeAndTerritoryAddingEmployeeToTerritoryEmployees

        /// <summary>
        /// Create a new employee object, then delete it again
        /// </summary>
        [TestMethod]
        public virtual void TestCreateAndDeleteEmployeeAndTerritoryAddingEmployeeToTerritoryEmployees()
        {
            using (IContext context = GetContext())
            {

                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql);

                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {

                    //Ask the context to create the new employee
                    Employee employee = (Employee)context.CreateObject(typeof(Employee));

                    //Assert that the context didn't return a null value
                    Assert.IsNotNull(employee);

                    //Set the properties of the new employee object
                    employee.FirstName = "Mats";
                    employee.LastName = "Helander";
                    employee.HireDate = DateTime.Now;

                    //Ask the context to create the new territory
                    Territory territory = (Territory)context.CreateObject(typeof(Territory));

                    territory.Id = "Terra";
                    territory.TerritoryDescription = "A cool place";

                    territory.Employees.Add(employee);  // <-------------------- this is the crucial line differing from the next test

                    //Ask the context to insert our new employee and territory into the database
                    context.Commit();

                    //The employee has an Id mapping to an autoincreasing column.
                    //Make sure the employee object has been updated with its new identity
                    Assert.IsTrue(employee.Id > 0, "Employee was not given identity!");

                    //Make sure that the employee row was inserted into the database...
                    //To do this we resort to some good old sql...
                    string sql = "Select Count(*) From Employees Where EmployeeId = " + employee.Id.ToString() +
                        " And FirstName = 'Mats'" +
                        " And LastName = 'Helander'";

                    //Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
                    int result = (int)context.SqlExecutor.ExecuteScalar(sql);

                    //Make sure that the query for our new row returned exactly one hit
                    Assert.AreEqual(1, result, "Employee Row not inserted!");

                    //Make sure that the territory row was inserted into the database...
                    //To do this we resort to some good old sql...
                    sql = "Select Count(*) From Territories Where TerritoryId = '" + territory.Id +
                        "' And TerritoryDescription = 'A cool place'";

                    //Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
                    result = (int)context.SqlExecutor.ExecuteScalar(sql);

                    //Make sure that the query for our new row returned exactly one hit
                    Assert.AreEqual(1, result, "Territory Row not inserted!");


                    //Make sure that the row holding the reference was inserted into the database...
                    //To do this we resort to some good old sql...
                    sql = "Select Count(*) From EmployeeTerritories Where EmployeeId = " + employee.Id.ToString() +
                        " And TerritoryID = '" + territory.Id + "'";

                    //Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
                    result = (int)context.SqlExecutor.ExecuteScalar(sql);

                    //Make sure that the query for our new row returned exactly one hit
                    Assert.AreEqual(1, result, "EmployeeTerritories Row not inserted!");


                    //Assert that the properties have the correct values
                    Assert.AreEqual("Mats", employee.FirstName, "FirstName");
                    Assert.AreEqual("Helander", employee.LastName, "LastName");

                    //Ask the context to delete our employee
                    context.DeleteObject(employee);

                    //Ask the context to delete our territory
                    context.DeleteObject(territory);

                    //Ask the context to remove the employee and territory from the database again
                    context.Commit();

                    //Execute the sql statement again
                    result = (int)context.SqlExecutor.ExecuteScalar(sql);

                    //Make sure that the query for our new row returns no hits
                    Assert.AreEqual(0, result, "Row not deleted!");

                    //The whole test went fine! Commit the transaction!
                    tx.Commit();
                }
                catch (CompositeException cex)
                {
                    //Something went wrong!
                    //Rollback the transaction and retheow the exception
                    tx.Rollback();

                    throw (Exception)cex.InnerExceptions[0];
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



        #region TestCreateAndDeleteEmployeeAndTerritoryAddingEmployeeToTerritoryEmployees

        /// <summary>
        /// Create a new employee object, then delete it again
        /// </summary>
        [TestMethod]
        public virtual void TestCreateAndDeleteEmployeeAndTerritoryAddingTerritoryToEmployeeTerritories()
        {
            using (IContext context = GetContext())
            {

                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql);

                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {
                    //Ask the context to create the new employee
                    Employee employee = (Employee)context.CreateObject(typeof(Employee));

                    //Assert that the context didn't return a null value
                    Assert.IsNotNull(employee);

                    //Set the properties of the new employee object
                    employee.FirstName = "Mats";
                    employee.LastName = "Helander";
                    employee.HireDate = DateTime.Now;

                    //Ask the context to create the new territory
                    Territory territory = (Territory)context.CreateObject(typeof(Territory));

                    territory.Id = "Terra";
                    territory.TerritoryDescription = "A cool place";

                    employee.Territories.Add(territory);	// <-------------------- this is the crucial line differing from the previous test

                    //Ask the context to insert our new employee and territory into the database
                    context.Commit();

                    //The employee has an Id mapping to an autoincreasing column.
                    //Make sure the employee object has been updated with its new identity
                    Assert.IsTrue(employee.Id > 0, "Employee was not given identity!");

                    //Make sure that the employee row was inserted into the database...
                    //To do this we resort to some good old sql...
                    string sql = "Select Count(*) From Employees Where EmployeeId = " + employee.Id.ToString() +
                        " And FirstName = 'Mats'" +
                        " And LastName = 'Helander'";

                    //Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
                    int result = (int)context.SqlExecutor.ExecuteScalar(sql);

                    //Make sure that the query for our new row returned exactly one hit
                    Assert.AreEqual(1, result, "Employee Row not inserted!");

                    //Make sure that the territory row was inserted into the database...
                    //To do this we resort to some good old sql...
                    sql = "Select Count(*) From Territories Where TerritoryId = '" + territory.Id +
                        "' And TerritoryDescription = 'A cool place'";

                    //Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
                    result = (int)context.SqlExecutor.ExecuteScalar(sql);

                    //Make sure that the query for our new row returned exactly one hit
                    Assert.AreEqual(1, result, "Territory Row not inserted!");


                    //Make sure that the row holding the reference was inserted into the database...
                    //To do this we resort to some good old sql...
                    sql = "Select Count(*) From EmployeeTerritories Where EmployeeId = " + employee.Id.ToString() +
                        " And TerritoryID = '" + territory.Id + "'";

                    //Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
                    result = (int)context.SqlExecutor.ExecuteScalar(sql);

                    //Make sure that the query for our new row returned exactly one hit
                    Assert.AreEqual(1, result, "EmployeeTerritories Row not inserted!");


                    //Assert that the properties have the correct values
                    Assert.AreEqual("Mats", employee.FirstName, "FirstName");
                    Assert.AreEqual("Helander", employee.LastName, "LastName");

                    //Ask the context to delete our employee
                    context.DeleteObject(employee);

                    //Ask the context to delete our territory
                    context.DeleteObject(territory);

                    //Ask the context to remove the employee from the database again
                    context.Commit();

                    //Execute the sql statement again
                    result = (int)context.SqlExecutor.ExecuteScalar(sql);

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


        private void Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
        {
            Console.Out.WriteLine(e.Sql);
        }
    }
}
