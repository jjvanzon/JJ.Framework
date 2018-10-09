using System;
using System.Text;
using System.Collections;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5.Basic
{
    /// <summary>
    /// Summary description for ObjectObjectMappingTests
    /// </summary>
    [TestClass]
    public class ObjectObjectMappingTests : CrudTests
    {
        public ObjectObjectMappingTests()
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

        public override IContext GetContext()
        {
            IContext rootContext = base.GetContext();
            IContext leafContext = new Context(rootContext);
            return leafContext;
        }

        #region TestFetchEmployeeById

        /// <summary>
        /// Fetch an employee object by identity
        /// </summary>
        [TestMethod]
        public virtual void TestEarlyOptimisticConcurrency()
        {
            int bossid = EnsureBoss();
            int id = EnsureNancy(bossid);

            using (IContext context = GetContext())
            {
                //we want to fetch the employee with id = 1
                int employeeId = id;

                //Ask the context to fetch the employee
                Employee employee = (Employee)context.GetObjectById(employeeId, typeof(Employee));

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

        /// <summary>
        /// Create a new employee object, then delete it again
        /// </summary>
        [TestMethod]
        public virtual void TestCreateStatus()
        {
            using (IContext context = GetContext())
            {
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

                    Assert.AreEqual(ObjectStatus.UpForCreation, context.GetObjectStatus(employee));

                    employee.FirstName = "Mats";
                    employee.LastName = "Helander";
                    employee.HireDate = DateTime.Now;

                    Assert.AreEqual(ObjectStatus.UpForCreation, context.GetObjectStatus(employee));

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


        /// <summary>
        /// Create a new employee object, then delete it again
        /// </summary>
        [TestMethod]
        public virtual void TestCreateEmployeeAndBoss()
        {
            using (IContext context = GetContext())
            {
                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {
                    //Ask the context to create the new employee
                    Employee employee = (Employee)context.CreateObject(typeof(Employee));

                    //Ask the context to create the new employee
                    Employee boss = (Employee)context.CreateObject(typeof(Employee));

                    //Assert that the context didn't return a null value
                    Assert.IsNotNull(employee);
                    Assert.IsNotNull(boss);

                    //Set the properties of the new employee object
                    employee.FirstName = "Mats";
                    employee.LastName = "Helander";
                    employee.HireDate = DateTime.Now;

                    boss.FirstName = "Roger";
                    boss.LastName = "Alsing";
                    employee.HireDate = DateTime.Now;

                    employee.ReportsTo = boss;

                    //Ask the context to insert our new employee into the database
                    context.Commit();

                    //The employee has an Id mapping to an autoincreasing column.
                    //Make sure the employee object has been updated with its new identity
                    Assert.IsTrue(employee.Id > 0, "Employee was not given identity!");

                    //Make sure that the row was inserted into the database...
                    //To do this we resort to some good old sql...
                    string sql = "Select Count(*) From Employees Where EmployeeId = " + employee.Id.ToString() +
                        " And FirstName = 'Mats'" +
                        " And LastName = 'Helander'";

                    //Execute the sql statement via the context (so that it is in the same transaction...that helps ;-))
                    int result = (int)context.SqlExecutor.ExecuteScalar(sql);

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


    }
}
