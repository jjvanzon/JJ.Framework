using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework;
using System.Reflection;
using Puzzle.NPersist.Samples.Northwind.Domain;
using System.Diagnostics;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Linq;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5
{
    /// <summary>
    /// Summary description for SimpleLinq2NPathUnitTest
    /// </summary>
    [TestClass]
    public class SimpleLinq2NPathUnitTest
    {
        public SimpleLinq2NPathUnitTest()
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
        public void CanSelectFromRepository()
        {
            using (IContext context = GetContext())
            {
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ShowExecutingSql);

                var q = from c in context.Repository<Customer>() where c.ContactName != "" select c;

                int i = 0;
                foreach (Customer c in q)
                {
                    Debug.WriteLine(c.ContactName);
                        i++;
                }
                Assert.IsTrue(i > 0);
            }
        }

        [TestMethod]
        public void CanSelectWithLoadSpanFromRepository()
        {
            using (IContext context = GetContext())
            {
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ShowExecutingSql);

                var q = from c in context.Repository(new LoadSpan<Customer>("ContactName")) where c.ContactName != "" select c;

                int i = 0;
                foreach (Customer c in q)
                {
                    Debug.WriteLine(c.ContactName);
                    i++;
                }
                Assert.IsTrue(i > 0);
            }
        }

        [TestMethod]
        public void CanSelectWithLoadSpanListFromRepository()
        {
            using (IContext context = GetContext())
            {
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ShowExecutingSql);

                var q = from c in context.Repository(new LoadSpan<Customer>("ContactName", "Orders.*")) where c.ContactName != "" select c;

                int i = 0;
                foreach (Customer c in q)
                {
                    Debug.WriteLine(c.ContactName);
                    i++;
                }
                Assert.IsTrue(i > 0);
            }
        }

        [TestMethod]
        public void CanSelectWithLoadSpanListUsingNPath()
        {
            using (IContext context = GetContext())
            {
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ShowExecutingSql);

                IList<Customer> customers = context.GetObjectsByNPath<Customer>("Select ContactName, Orders.* From Customer Where ContactName != ''"); 
                int i = 0;
                foreach (Customer c in customers)
                {
                    Debug.WriteLine(c.ContactName);
                    i++;
                }
                Assert.IsTrue(i > 0);
            }
        }

        [TestMethod]
        public void CanSelectWithSubselectFromRepository()
        {
            using (IContext context = GetContext())
            {
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ShowExecutingSql);

                var q = from c in context.Repository<Customer>() where (from o in c.Orders where o.ShipName != "" select o).Count > 0 select c;

                int i = 0;
                foreach (Customer c in q)
                {
                    Debug.WriteLine(c.ContactName);
                    i++;
                }
                Assert.IsTrue(i > 0);
            }
        }

        [TestMethod]
        public void CanSelectWithNestedSubselectFromRepository()
        {
            using (IContext context = GetContext())
            {
                context.ExecutingSql += new ExecutingSqlEventHandler(Context_ShowExecutingSql);

                var q = from c in context.Repository<Customer>() where (from o in c.Orders where (from d in o.OrderDetails where d.Quantity > 0 select d).Count > 0 select o).Count > 0 select c;

                int i = 0;
                foreach (Customer c in q)
                {
                    Debug.WriteLine(c.ContactName);
                    i++;
                }
                Assert.IsTrue(i > 0);
            }
        }



        private IContext GetContext()
        {
            Assembly asm = typeof(Employee).Assembly;
            IContext context = new Context(asm, "Puzzle.NPersist.Samples.Northwind.Domain.Puzzle.NPersist.Samples.Northwind.Domain.npersist");
            context.SetConnectionString("SERVER=(local);DATABASE=Northwind;integrated security=true;");
            return context;
        }

        private void Context_ShowExecutingSql(object sender, SqlExecutorCancelEventArgs e)
        {
            Debug.WriteLine( e.Sql);
        }

    }
}
