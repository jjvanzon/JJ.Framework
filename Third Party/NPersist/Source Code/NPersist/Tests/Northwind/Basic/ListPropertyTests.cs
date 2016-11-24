//Thanks to Harm Neervens for these tests!

using System;
using System.Collections;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Samples.Northwind.Domain;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for ListPropertyTests.
	/// </summary>
	[TestFixture()]
	public class ListPropertyTests : TestBase
	{
		public ListPropertyTests()
		{
		}

		//Note: This test changes the connection to the ordinary Northwind 
		//database which it assumes has a state where the ALFKI customer has
		//six orders...yes, this is an ugly "special, special" test. Don't ever do
		//anything like this and pretend you didn't see this. Just comment out the test
		//when it doesn't run on your machine rather than giving your poor ALFKI customer
		//six orders...
		[Test()]
		public void TestListLoadingBeforeCommit()
		{
			using (IContext context = GetContext() )
			{
				context.SetConnectionString(ContextFactory.NormalNWConnectionString);

				Customer customer = (Customer) context.GetObjectById("ALFKI", typeof(Customer));

				Assert.IsNotNull(customer);

				//Make sure that the count has already been loaded
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql) ;

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
		[Test()]
		public void TestListLoadingAfterCommit()
		{
			using (IContext context = GetContext() )
			{
				context.SetConnectionString(ContextFactory.NormalNWConnectionString);

				Customer customer = (Customer) context.GetObjectById("ALFKI", typeof(Customer));

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

		[Test()]
		public void TestListLoadingBeforeCommitUsingNPath()
		{
			using (IContext context = GetContext() )
			{
				context.SetConnectionString(ContextFactory.NormalNWConnectionString);

				Customer customer = (Customer) context.GetObjectByNPath("Select * From Customer Where Id = 'ALFKI'", typeof(Customer));

				Assert.IsNotNull(customer);

				//Make sure that the count has already been loaded
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql) ;

				int orderCount = customer.Orders.Count;
			
				Assert.AreEqual(6, orderCount);
			}
		}

		[Test()]
		public void TestListLoadingBeforeCommitUsingTwoLevelNPath()
		{
			using (IContext context = GetContext() )
			{
				context.SetConnectionString(ContextFactory.NormalNWConnectionString);

				IList orders = context.GetObjectsByNPath("Select *, Customer.* From Order Where Customer.Id = 'ALFKI'", typeof(Order));

				Assert.IsTrue(orders.Count > 0);

				//Make sure that the count has already been loaded
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql) ;

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
		[Test()]
		public void TestManyManyListLoadingBeforeCommit()
		{
			using (IContext context = GetContext() )
			{
				context.SetConnectionString(ContextFactory.NormalNWConnectionString);

				Customer customer = (Customer) context.GetObjectById("ALFKI", typeof(Customer));

				Assert.IsNotNull(customer);

				Assert.IsTrue(customer.CustomerDemographics.Count > 0);

				IList customerDemographics = customer.CustomerDemographics;

				foreach (CustomerDemographic customerDemographic in customerDemographics)
					break;

				//Make sure that the count has already been loaded
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ThrowOnExecutingSql) ;

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
