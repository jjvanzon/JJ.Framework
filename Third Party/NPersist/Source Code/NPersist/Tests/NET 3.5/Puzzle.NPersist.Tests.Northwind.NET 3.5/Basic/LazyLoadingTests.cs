using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5.Basic
{
    /// <summary>
    /// Summary description for LazyLoadingTests
    /// </summary>
    [TestClass]
    public class LazyLoadingTests : TestBase 
    {
        public LazyLoadingTests()
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

        #region TestIdentityMapOnReferenceProperty

        /// <summary>
        /// Make sure that traversing reference properties will cause
        /// the proper lazy loading behavior
        /// </summary>
        [TestMethod]
        public virtual void TestLazyLoadingOnReferenceProperty()
        {
            int bossid = EnsureBoss();
            int id = EnsureNancy(bossid);

            using (IContext context = GetContext())
            {
                //Ask the context to fetch the employee with id = @id
                Employee employee = (Employee)context.GetObjectById(id, typeof(Employee));

                //Assert that the context didn't return a null value
                Assert.IsNotNull(employee);

                //Assert that the employee has the id we asked for
                Assert.AreEqual(id, employee.Id);

                //Assert that the employee object has been fully loaded
                Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(employee));

                //Read what is hopefully the same instance of the boss via the
                //ReportsTo reference property
                Employee boss = employee.ReportsTo;

                //Assert that the context didn't return a null value
                Assert.IsNotNull(boss);

                //Assert that the boss has the id we asked for
                Assert.AreEqual(bossid, boss.Id);

                //Assert that the boss object has only been lazy loaded
                //(it has an id but none of its other properties are
                //loaded with values from the database yes)
                Assert.AreEqual(ObjectStatus.NotLoaded, context.GetObjectStatus(boss));

                //Read a property of the lazy loaded boss object, causing the object
                //to be loaded with values from the database
                Assert.IsTrue(boss.FirstName.Length > 0);

                //Assert that the boss object has now been fully loaded
                Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(boss));

            }
        }

        #endregion

        #region TestLazyLoadingOnReferenceListProperty

        /// <summary>
        /// Make sure that traversing reference list properties will cause
        /// the proper lazy loading behavior
        /// </summary>
        [TestMethod]
        public virtual void TestLazyLoadingOnReferenceListProperty()
        {
            int bossid = EnsureBoss();
            int id = EnsureNancy(bossid);

            using (IContext context = GetContext())
            {
                //Ask the context to fetch the employee with id = 2
                Employee boss = (Employee)context.GetObjectById(bossid, typeof(Employee));

                //Assert that the context didn't return a null value
                Assert.IsNotNull(boss);

                //Assert that the employee has the id we asked for
                Assert.AreEqual(bossid, boss.Id);

                //Assert that the employee object has been fully loaded
                Assert.AreEqual(ObjectStatus.Clean, context.GetObjectStatus(boss));

                //Assert that the Employees property of the employee object has not been loaded yet
                Assert.AreEqual(PropertyStatus.NotLoaded, context.GetPropertyStatus(boss, "Employees"));

                //Read the Employees property, causing the property
                //to be loaded with values from the database
                foreach (Employee e in boss.Employees)
                    break;

                //Assert that the Employees property of the employee object has not been loaded yet
                Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(boss, "Employees"));
            }
        }

        #endregion
    }
}
