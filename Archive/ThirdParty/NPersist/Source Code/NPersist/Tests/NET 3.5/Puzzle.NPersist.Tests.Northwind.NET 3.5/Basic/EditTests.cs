using System;
using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5.Basic
{
    /// <summary>
    /// Summary description for EditTests
    /// </summary>
    [TestClass]
    public class EditTests : TestBase
    {
        public EditTests()
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

        #region TestFetchEmployeeBeginEditUpdateThenCancel

        /// <summary>
        /// Fetch an employee object by identity
        /// </summary>
        [TestMethod]
        public virtual void TestFetchEmployeeBeginEditUpdateThenCancel()
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

                //Assert that the employee has the id we asked for
                Assert.AreEqual(employeeId, employee.Id);

                //Assert that the employee has the name Nancy Davolio
                //(She should, in a standard northwind setup)
                Assert.AreEqual("Nancy", employee.FirstName);
                Assert.AreEqual("Davolio", employee.LastName);

                Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(employee));

                Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "FirstName"));
                Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(employee, "LastName"));

                context.BeginEdit();

                employee.FirstName = "Mats";
                employee.LastName = "Helander";

                //Assert that the employee has the name Mats Helander
                Assert.AreEqual("Mats", employee.FirstName);
                Assert.AreEqual("Helander", employee.LastName);

                Assert.AreEqual(ObjectStatus.Dirty, context.GetObjectStatus(employee));

                Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "FirstName"));
                Assert.AreEqual(PropertyStatus.Dirty, context.GetPropertyStatus(employee, "LastName"));

                context.CancelEdit();

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
        [TestMethod]
        public virtual void TestBeginEditCreateEmployeeThenCancel()
        {
            using (IContext context = GetContext())
            {
                context.BeginEdit();

                //Ask the context to create the employee
                Employee employee = (Employee)context.CreateObject(typeof(Employee));

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

                context.CancelEdit();

                Assert.AreEqual(ObjectStatus.NotRegistered, context.GetObjectStatus(employee));

                Assert.IsFalse(context.IdentityMap.HasObject(employee));

            }
        }

        #endregion
    }
}
