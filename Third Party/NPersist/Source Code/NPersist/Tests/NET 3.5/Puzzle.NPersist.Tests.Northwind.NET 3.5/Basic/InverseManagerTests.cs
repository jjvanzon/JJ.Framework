using System;
using System.Text;
using System.Collections;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Delegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Puzzle.NPersist.Tests.Northwind.NET_3._5.Basic
{
    /// <summary>
    /// Summary description for InverseManagerTests
    /// </summary>
    [TestClass]
    public class InverseManagerTests : TestBase
    {
        public InverseManagerTests()
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

        #region TestInverseManagerOnReferenceProperty

        /// <summary>
        /// Make sure that traversing reference properties will cause
        /// the proper lazy loading behavior
        /// </summary>
        [TestMethod]
        public virtual void TestInverseManagerOnReferenceProperty()
        {
            using (IContext context = GetContext())
            {
                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {

                    //Ask the context to create a new employee object
                    Employee employee = (Employee)context.CreateObject(typeof(Employee));

                    //Ask the context to create a new employee object
                    Employee boss = (Employee)context.CreateObject(typeof(Employee));
                    Employee boss2 = (Employee)context.CreateObject(typeof(Employee));

                    //Assert that the context didn't return null values
                    Assert.IsNotNull(employee);
                    Assert.IsNotNull(boss);

                    //set up the relationship using the ReportsTo reference property 
                    employee.ReportsTo = boss;

                    //Make sure that the inverse manager has added the employee
                    //to the Employees property of the boss object
                    Assert.IsTrue(boss.Employees.Contains(employee));

                    //Change the relationship to another boss
                    employee.ReportsTo = boss2;

                    //Make sure that the inverse manager has removed the employee
                    //from the Employees property of the old boss object
                    Assert.IsFalse(boss.Employees.Contains(employee));

                    //Make sure that the inverse manager has added the employee
                    //to the Employees property of the new boss object
                    Assert.IsTrue(boss2.Employees.Contains(employee));

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
        [TestMethod]
        public virtual void TestInverseManagerOnReferenceListProperty()
        {
            using (IContext context = GetContext())
            {
                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {

                    //Ask the context to create a new employee object
                    Employee employee = (Employee)context.CreateObject(typeof(Employee));

                    //Ask the context to create a new employee object
                    Employee boss = (Employee)context.CreateObject(typeof(Employee));
                    Employee boss2 = (Employee)context.CreateObject(typeof(Employee));

                    //Assert that the context didn't return null values
                    Assert.IsNotNull(employee);
                    Assert.IsNotNull(boss);

                    //set up the relationship using the Employees reference list property 
                    boss.Employees.Add(employee);

                    //Make sure that the inverse manager has wrtten the boss
                    //to the ReportsTo property of the employee object
                    Assert.IsTrue(employee.ReportsTo == boss);

                    //Change the relationship to another boss
                    boss2.Employees.Add(employee);

                    //Make sure that the inverse manager has removed the employee
                    //from the Employees property of the old boss object
                    Assert.IsFalse(boss.Employees.Contains(employee));

                    //Make sure that the inverse manager has wrtten the new boss
                    //to the ReportsTo property of the employee object
                    Assert.IsTrue(employee.ReportsTo == boss2);

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

        #region TestInverseManagerOnDeleteOnReferenceListProperty

        [TestMethod]
        public virtual void TestInverseManagerOnDeleteOnReferenceListProperty()
        {
            int employeeId = 0;
            int employee2Id = 0;
            int bossId = 0;

            using (IContext context = GetContext())
            {
                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {

                    //Ask the context to create a new employee object
                    Employee employee = (Employee)context.CreateObject(typeof(Employee));
                    Employee employee2 = (Employee)context.CreateObject(typeof(Employee));

                    //Ask the context to create a new employee object
                    Employee boss = (Employee)context.CreateObject(typeof(Employee));

                    //Assert that the context didn't return null values
                    Assert.IsNotNull(employee);
                    Assert.IsNotNull(employee2);
                    Assert.IsNotNull(boss);

                    //set up the relationship using the Employees reference list property 
                    boss.Employees.Add(employee);
                    boss.Employees.Add(employee2);

                    SetupEmployee(boss);
                    SetupEmployee(employee);
                    SetupEmployee(employee2);

                    context.Commit();

                    bossId = boss.Id;
                    employeeId = employee.Id;
                    employee2Id = employee2.Id;

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

            using (IContext context = GetContext())
            {
                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {
                    //Ask the context to fetch the boss
                    Employee boss = (Employee)context.GetObjectById(bossId, typeof(Employee));

                    //Assert that the context didn't return null values
                    Assert.IsNotNull(boss);

                    Assert.IsTrue(ContainsId((IList) boss.Employees, employeeId));
                    Assert.IsTrue(ContainsId((IList)boss.Employees, employee2Id));

                    Assert.AreEqual(2, boss.Employees.Count);

                    Employee employee = null;
                    foreach (Employee emp in boss.Employees)
                        if (emp.Id == employeeId)
                            employee = emp;

                    //delete the first employee
                    context.DeleteObject(employee);

                    Assert.AreEqual(1, boss.Employees.Count);
                    Assert.IsFalse(ContainsId((IList)boss.Employees, employeeId));
                    Assert.IsTrue(ContainsId((IList)boss.Employees, employee2Id));

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

        #region TestInverseManagerLazySynchOnDeleteOnReferenceListProperty

        [TestMethod]
        public virtual void TestInverseManagerLazySynchOnDeleteOnReferenceListProperty()
        {
            int employeeId = 0;
            int employee2Id = 0;
            int bossId = 0;

            using (IContext context = GetContext())
            {
                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {

                    //Ask the context to create a new employee object
                    Employee employee = (Employee)context.CreateObject(typeof(Employee));
                    Employee employee2 = (Employee)context.CreateObject(typeof(Employee));

                    //Ask the context to create a new employee object
                    Employee boss = (Employee)context.CreateObject(typeof(Employee));

                    //Assert that the context didn't return null values
                    Assert.IsNotNull(employee);
                    Assert.IsNotNull(employee2);
                    Assert.IsNotNull(boss);

                    //set up the relationship using the Employees reference list property 
                    boss.Employees.Add(employee);
                    boss.Employees.Add(employee2);

                    SetupEmployee(boss);
                    SetupEmployee(employee);
                    SetupEmployee(employee2);

                    context.Commit();

                    bossId = boss.Id;
                    employeeId = employee.Id;
                    employee2Id = employee2.Id;

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

            using (IContext context = GetContext())
            {
                //context.PersistenceManager.ListCountLoadBehavior = LoadBehavior.Lazy;

                //Encapsulate our whole test in a transaction,
                //so that any changes to the database are rolled back in case
                //of a test failure
                ITransaction tx = context.BeginTransaction();

                try
                {
                    //Ask the context to create a new employee object
                    Employee employee = (Employee)context.GetObjectById(employeeId, typeof(Employee));

                    //Assert that the context didn't return null values
                    Assert.IsNotNull(employee);

                    //delete the employee
                    context.DeleteObject(employee);

                    Employee boss = (Employee)context.GetObjectById(bossId, typeof(Employee));

                    Assert.IsNotNull(boss);

                    //Assert.AreEqual(ObjectStatus.NotLoaded, context.GetObjectStatus(employee));
                    Assert.AreEqual(PropertyStatus.NotLoaded, context.GetPropertyStatus(boss, "Employees"));

                    Assert.AreEqual(1, boss.Employees.Count);
                    Assert.IsFalse(ContainsId((IList)boss.Employees, employeeId));
                    Assert.IsTrue(ContainsId((IList)boss.Employees, employee2Id));

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


        public bool ContainsId(IList list, int id)
        {
            foreach (Employee employee in list)
                if (employee.Id == id)
                    return true;
            return false;
        }

        private void SetupEmployee(Employee employee)
        {
            employee.FirstName = "Test";
            employee.LastName = "Test";
        }



        [TestMethod]
        public void TestManyOneResolveOnLoad()
        {
            using (IContext context = GetContext())
            {
                context.SetConnectionString(ContextFactory.NormalNWConnectionString);

                Customer customer = (Customer)context.GetObjectById("ALFKI", typeof(Customer));

                Assert.IsNotNull(customer);

                IList<Order> orders = customer.Orders;

                //make sure orders are loaded...
                foreach (Order order in orders)
                    break;

                context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ThrowOnExecutingSql);

                foreach (Order order in orders)
                {
                    Assert.AreEqual(customer, order.Customer);
                }
            }
        }


        private void m_Context_ThrowOnExecutingSql(object sender, SqlExecutorCancelEventArgs e)
        {
            Console.Out.WriteLine(e.Sql);
            throw new Exception("Should not have executed sql!");
        }
    }
}
