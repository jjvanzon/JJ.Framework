using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework;
using NPersistLinqTests.DM;
using Puzzle.NPersist.Framework.Linq;
using Puzzle.NPersist.Framework.BaseClasses;

namespace NPersistLinqTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class LinqToNPathTests
    {

        public LinqToNPathTests()
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


        [TestMethod]
        public void WorldFirstNPathLinqTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository(new LoadSpan<Customer>("Name", "Email"))
                      where cust.Address.StreetName == "abc123"
                      select cust;

            string expected = "select Name, Email from Customer where ((Customer.Address.StreetName = \"abc123\"))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WherePropertyPathTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where cust.Address.StreetName == "abc123"
                      select cust;

            string expected = "select * from Customer where ((Customer.Address.StreetName = \"abc123\"))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoadSpanTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository(new LoadSpan<Customer>("Name", "Email", "Address.StreetName"))
                      select cust;

            string expected = "select Name, Email, Address.StreetName from Customer";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderByTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      orderby cust.Name, cust.Address.StreetName
                      select cust;

            string expected = "select * from Customer order by Customer.Name, Customer.Address.StreetName";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListPropCountTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where cust.Orders.Count == 1
                      select cust;

            string expected = "select * from Customer where ((Customer.Orders.Count() = 1))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01) && order.Total == 3.1
                             select order).Count > 0
                      select cust;

            string expected = "select * from Customer where (((select count(*) from Customer.Orders where ((Order.OrderDate = #2008-01-01#) and (Order.Total = 3.1))) > 0))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQuerySumTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01)
                             select order).Sum(order => order.Total) > 200
                      select cust;

            string expected = "select * from Customer where (((select sum(Order.Total) from Customer.Orders where (Order.OrderDate = #2008-01-01#)) > 200))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryAvgTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01)
                             select order).Average(order => order.Total) > 200
                      select cust;

            string expected = "select * from Customer where (((select avg(Order.Total) from Customer.Orders where (Order.OrderDate = #2008-01-01#)) > 200))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryMinTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01)
                             select order).Min(order => order.Total) > 200
                      select cust;

            string expected = "select * from Customer where (((select min(Order.Total) from Customer.Orders where (Order.OrderDate = #2008-01-01#)) > 200))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryMaxTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01)
                             select order).Max(order => order.Total) > 200
                      select cust;

            string expected = "select * from Customer where (((select max(Order.Total) from Customer.Orders where (Order.OrderDate = #2008-01-01#)) > 200))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryAnyTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01)
                             select order).Any ()
                      select cust;

            string expected = "select * from Customer where ((select count(*) from Customer.Orders where (Order.OrderDate = #2008-01-01#)) > 0)";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryAny2Test()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (cust.Orders.Where (order => order.OrderDate == new DateTime(2008, 01, 01))).Any ()
                      select cust;

            string expected = "select * from Customer where ((select count(*) from Customer.Orders where (Order.OrderDate = #2008-01-01#)) > 0)";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryAnyCondTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01)
                             select order).Any(order => order.Total == 3)
                      select cust;

            string expected = "select * from Customer where ((select count(*) from Customer.Orders where (Order.OrderDate = #2008-01-01#) and (Order.Total = 3)) > 0)";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryAllCondTest()
        {
            Context ctx = null;

            var res = from cust in ctx.Repository<Customer>()
                      where (from order in cust.Orders
                             where order.OrderDate == new DateTime(2008, 01, 01)
                             select order).All(order => order.Total == 3)
                      select cust;

            string expected = "select * from Customer where ((select count(*) from Customer.Orders where not ((Order.OrderDate = #2008-01-01#) and (Order.Total = 3))) > 0)";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubQueryContainsTest()
        {
            Context ctx = null;

            Order myOrder = new Order();
            var res = from cust in ctx.Repository<Customer>()                      
                      where cust.Orders.Contains (myOrder)
                      select cust;

            string expected = "select * from Customer where ((select count(*) from Customer.Orders where Order = ?) > 0)";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void EntityParameterTest()
        {
            Context ctx = null;

            Customer myCustomer = new Customer();
            var res = from cust in ctx.Repository<Customer>()
                      where cust != myCustomer
                      select cust;

            string expected = "select * from Customer where ((Customer != ?))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityTypeTest()
        {
            Context ctx = null;

            
            var res = from cust in ctx.Repository<Customer>()
                      where cust is Customer
                      select cust;

            string expected = "select * from Customer where ((Customer is Customer))";
            string actual = res.Query.ToNPath();

            Assert.AreEqual(expected, actual);
        }
    }    
}

