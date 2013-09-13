using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5.Basic
{
    /// <summary>
    /// Summary description for CascadeDeleteTests
    /// </summary>
    [TestClass]
    public class CascadeDeleteTests : TestBase
    {
        public CascadeDeleteTests()
        {
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

        #region TestFetchEmployeeById

        [TestMethod]
        public virtual void TestCascadeDelete()
        {
            using (IContext context = GetContextWithCascadeDelete())
            {
                Employee employee = (Employee)context.CreateObject(typeof(Employee));

                Order order = (Order)context.CreateObject(typeof(Order));

                order.Employee = employee;

                context.DeleteObject(employee);
            }
        }

        #endregion

    }
}
