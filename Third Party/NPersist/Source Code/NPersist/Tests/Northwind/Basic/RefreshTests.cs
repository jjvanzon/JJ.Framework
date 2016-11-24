using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for RefreshTests.
	/// </summary>
	[TestFixture()]
	public class RefreshTests : TestBase
	{
		public RefreshTests()
		{
		}

		[Test()]
		public void TestRefreshObjectOverwriteLoaded()
		{
			using (IContext context = GetContext() )
			{
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save in the first context
				employee.FirstName = "John";
				employee.LastName = "Doe";

				context.Commit();

				context2.RefreshObject(employee2, RefreshBehaviorType.OverwriteLoaded);

				Assert.AreEqual("John", employee2.FirstName);
				Assert.AreEqual("Doe", employee2.LastName);
			}
		}


		[Test()]
		public void TestRefreshPropertyOverwriteLoaded()
		{
			using (IContext context = GetContext() )
			{
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some values and save in the first context
				employee.FirstName = "John";
				employee.LastName = "Doe";

				context.Commit();

				context2.RefreshProperty(employee2, "FirstName", RefreshBehaviorType.OverwriteLoaded);

				Assert.AreEqual("John", employee2.FirstName);
			}
		}

		[Test()]
		public void TestRefreshPropertyOverwriteLoadedWillNotOverwriteDirty()
		{
			using (IContext context = GetContext() )
			{
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some new values
				employee2.FirstName = "Roger";

				//we set some values and save in the first context
				employee.FirstName = "John";
				employee.LastName = "Doe";

				context.Commit();

				context2.RefreshProperty(employee2, "FirstName", RefreshBehaviorType.OverwriteLoaded);

				Assert.AreEqual("Roger", employee2.FirstName);
			}
		}


		[Test()]
		public void TestRefreshPropertyOverwriteDirty()
		{
			using (IContext context = GetContext() )
			{
				//first we create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//we set some values and save
				employee.FirstName = "Mats";
				employee.LastName = "Helander";

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				//we set some new values
				employee2.FirstName = "Roger";
				//				employee2.LastName = "Johansson";

				//we set some values and save in the first context
				employee.FirstName = "John";
				employee.LastName = "Doe";

				context.Commit();

				context2.RefreshProperty(employee2, "FirstName", RefreshBehaviorType.OverwriteDirty);

				Assert.AreEqual("John", employee2.FirstName);
			}
		}

		
		[Test()]
		public void TestRefreshListPropertyOverwriteLoaded()
		{
			using (IContext context = GetContext() )
			{
				context.SqlExecutor.ExecuteNonQuery("Delete From [Order Details]");
				context.SqlExecutor.ExecuteNonQuery("Delete From Orders");
				context.SqlExecutor.ExecuteNonQuery("Delete From Customers");

				Customer customer = (Customer) context.CreateObject(typeof(Customer));

				customer.Id = "APEYO";
				customer.CompanyName = "Puzzle";

				Order order1 = CreateOrder(context, customer);
				Order order2 = CreateOrder(context, customer);

				context.Commit();

				IContext context2 = GetContext();

				Customer customer2 = (Customer) context2.TryGetObjectById("APEYO", typeof(Customer));

				int cnt = 0;
				foreach (Order test in customer2.Orders)
				{
					Assert.IsTrue(test.Freight < 1);
					cnt++;
				}

				Assert.AreEqual(2, cnt);

				Order order3 = CreateOrder(context, customer);
				
				context.Commit();

				context2.RefreshProperty(customer2, "Orders", RefreshBehaviorType.OverwriteLoaded);

				cnt = 0;
				foreach (Order test in customer2.Orders)
				{
					Assert.IsTrue(test.Freight < 1);
					cnt++;
				}

				Assert.AreEqual(3, cnt, "List property was not refreshed!");

				context2.Dispose();
			}
		}



		[Test()]
		public void TestRefreshListPropertyOverwriteLoadedSelfRef()
		{
			using (IContext context = GetContext() )
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				//first we create some employees
				Employee employee = CreateEmployee(context, "Mats", "Helander");

				Employee sub1 = CreateEmployee(context, "Mr", "Test");
				Employee sub2 = CreateEmployee(context, "Mr", "Test2");
				Employee sub3 = CreateEmployee(context, "Mr", "Test3");

				sub1.ReportsTo = employee;
				sub2.ReportsTo = employee;

				context.Commit();

				//then we load up the employee in a different context
				IContext context2 = GetContext();

				context2.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				Employee employee2 = (Employee) context2.GetObjectById(employee.Id, typeof(Employee));

				int cnt = 0;
				foreach (Employee sub in employee2.Employees)
				{
					Assert.AreEqual("Mr", sub.FirstName);
					cnt++;
				}

				Assert.AreEqual(2, cnt);

				sub3.ReportsTo = employee;

				context.Commit();

				context2.RefreshProperty(employee2, "Employees", RefreshBehaviorType.OverwriteLoaded);

				cnt = 0;
				foreach (Employee sub in employee2.Employees)
				{
					Assert.AreEqual("Mr", sub.FirstName);
					cnt++;
				}

				Assert.AreEqual(3, cnt, "List property was not refreshed!");
			}
		}

		private Order CreateOrder(IContext context, Customer customer)
		{
			Order order = (Order) context.CreateObject(typeof(Order));

			order.Customer = customer;

			context.Commit();			

			return order;
		}


		private Employee CreateEmployee(IContext context, string FirstName, string lastName)
		{
			//first we create a new employee
			Employee employee = (Employee) context.CreateObject(typeof(Employee));

			//we set some values and save
			employee.FirstName = FirstName;
			employee.LastName = lastName;

			context.Commit();			

			return employee;
		}


		private void Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}

	}
}
