using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5.Basic
{
    /// <summary>
    /// Summary description for ListPropertyTests
    /// </summary>
    [TestClass]
    public class ListPropertyTests : TestBase
    {
        public ListPropertyTests()
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

        //Note: This test changes the connection to the ordinary Northwind 
        //database which it assumes has a state where the ALFKI customer has
        //six orders...yes, this is an ugly "special, special" test. Don't ever do
        //anything like this and pretend you didn't see this. Just comment out the test
        //when it doesn't run on your machine rather than giving your poor ALFKI customer
        //six orders...
        [TestMethod]
        public void TestListLoadingBeforeCommit()
        {
            using (IContext context = GetContext())
            {
                context.SetConnectionString(ContextFactory.NormalNWConnectionString);

                Customer customer = (Customer)context.GetObjectById("ALFKI", typeof(Customer));

                Assert.IsNotNull(customer);

                //Make sure that the count has already been loaded
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql);

                int orderCount = customer.Orders.Count;

                Assert.AreEqual(6, orderCount);
            }
        }

        //Note: This test changes the connection to the ordinary Northwind 
        //database which it assumes has a state where the ALFKI customer has
        //six orders...yes, this is an ugly "special, special" test. Don't ever do
        //anything like this and pretend you didn't see this. Just comment out the test
        //when it doesn't run on your machine rather than giving your poor ALFKI customer
        //six orders...
        [TestMethod]
        public void TestListLoadingAfterCommit()
        {
            using (IContext context = GetContext())
            {
                context.SetConnectionString(ContextFactory.NormalNWConnectionString);

                Customer customer = (Customer)context.GetObjectById("ALFKI", typeof(Customer));

                Assert.IsNotNull(customer);

                if (customer.CompanyName.EndsWith("test"))
                    customer.CompanyName = customer.CompanyName.Replace("test", "");
                else
                    customer.CompanyName = customer.CompanyName + "test";

                Console.WriteLine(context.GetPropertyStatus(customer, "Orders"));

                context.Commit();

                Console.WriteLine(context.GetPropertyStatus(customer, "Orders"));

                int orderCount = customer.Orders.Count;

                Assert.AreEqual(6, orderCount);
            }
        }

        [TestMethod]
        public void TestListLoadingBeforeCommitUsingNPath()
        {
            using (IContext context = GetContext())
            {
                context.SetConnectionString(ContextFactory.NormalNWConnectionString);

                Customer customer = (Customer)context.GetObjectByNPath("Select * From Customer Where Id = 'ALFKI'", typeof(Customer));

                Assert.IsNotNull(customer);

                //Make sure that the count has already been loaded
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql);

                int orderCount = customer.Orders.Count;

                Assert.AreEqual(6, orderCount);
            }
        }

        [TestMethod]
        public void TestListLoadingBeforeCommitUsingTwoLevelNPath()
        {
            using (IContext context = GetContext())
            {
                context.SetConnectionString(ContextFactory.NormalNWConnectionString);

                IList orders = context.GetObjectsByNPath("Select *, Customer.* From Order Where Customer.Id = 'ALFKI'", typeof(Order));

                Assert.IsTrue(orders.Count > 0);

                //Make sure that the count has already been loaded
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql);

                string s = "";
                int cnt = 0;
                foreach (Order order in orders)
                {
                    Assert.IsNotNull(order.Customer);
                    Assert.AreEqual(6, order.Customer.Orders.Count);
                    foreach (Order sameOrder in order.Customer.Orders)
                    {
                        s += sameOrder.ShipCity;
                        cnt++;
                    }
                }
                Assert.AreEqual(orders.Count * orders.Count, cnt);

            }
        }

        /// <summary>
        /// Note: This test presupposes that ALFKI has been given two CustomerDemographics...please make sure this
        /// is so in the database before running this test or it will fail...
        /// </summary>
        [TestMethod]
        public void TestManyManyListLoadingBeforeCommit()
        {
            using (IContext context = GetContext())
            {
                context.SetConnectionString(ContextFactory.NormalNWConnectionString);

                Customer customer = (Customer)context.GetObjectById("ALFKI", typeof(Customer));

                Assert.IsNotNull(customer);

                Assert.IsTrue(customer.CustomerDemographics.Count > 0);

                IList<CustomerDemographic> customerDemographics = customer.CustomerDemographics;

                foreach (CustomerDemographic customerDemographic in customerDemographics)
                    break;

                //Make sure that the count has already been loaded
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql);

                foreach (CustomerDemographic customerDemographic in customerDemographics)
                {
                    Assert.IsTrue(customerDemographic.Customers.Count > 0);
                }
            }
        }


        private void Context_ThrowOnExecutingSql(object sender, SqlExecutorCancelEventArgs e)
        {
            throw new Exception("Should not have executed sql: " + e.Sql);
        }

    }
}
