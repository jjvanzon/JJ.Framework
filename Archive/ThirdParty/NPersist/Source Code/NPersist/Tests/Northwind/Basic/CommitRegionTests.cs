using System;
using System.Collections;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for CommitRegionTests.
	/// </summary>
	[TestFixture()]
	public class CommitRegionTests : TestBase
	{
		public CommitRegionTests()
		{
		}

		[Test()]
		public void TestNPathSelectSiblings()
		{
			int order1Id = 0;
			using (IContext context = GetContext() )
			{
				context.SqlExecutor.ExecuteNonQuery("Delete From [Order Details]");
				context.SqlExecutor.ExecuteNonQuery("Delete From Orders");
				context.SqlExecutor.ExecuteNonQuery("Delete From Customers");

//				Customer deleteCustomer = (Customer) context.TryGetObjectById("APEHI", typeof(Customer));
//				if (deleteCustomer != null)
//				{
//					foreach (Order order in deleteCustomer.Orders)
//						context.DeleteObject(order);
//					context.DeleteObject(deleteCustomer);
//					context.Commit();
//				}

				Customer customer = (Customer) context.CreateObject(typeof(Customer));

				customer.Id = "APEYO";
				customer.CompanyName = "Puzzle";

				Order order1 = CreateOrder(context, customer);
				Order order2 = CreateOrder(context, customer);
				Order order3 = CreateOrder(context, customer);

				context.Commit();

				order1Id = order1.Id;
			}			

			using (IContext context = GetContext())
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				Order order1 = (Order) context.GetObjectByNPath("Select *, Customer.*, Customer.Orders.* From Order Where Id = " + order1Id, typeof(Order));

				Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(order1, "Customer") );

				Customer customer = order1.Customer;

				Assert.AreEqual(PropertyStatus.Clean, context.GetPropertyStatus(customer, "Orders") );

				Assert.AreEqual(3, customer.Orders.Count);
			}
		}


		[Test(), ExpectedException(typeof(OrderMaxTotalExceededException))]
		public void TestValidationRuleDirectly()
		{
			string detail1Id = "";
			string detail3Id = "";
			using (IContext context = GetContext() )
			{
				Product product1 = CreateProduct(context, "Banana", 100);
				Product product2 = CreateProduct(context, "Apple", 150);
				Product product3 = CreateProduct(context, "Orange", 200);

				Order order = (Order) context.CreateObject(typeof(Order));				

				OrderDetail detail1 = CreateOrderDetail(context, order, product1, 1);
				OrderDetail detail2 = CreateOrderDetail(context, order, product2, 2);
				OrderDetail detail3 = CreateOrderDetail(context, order, product3, 3);

				try
				{
					context.Commit();										
				}
				catch (NPersistValidationException ex)
				{
					throw ex.InnerException ;
				}
			}			
		}


//		[Test(), Ignore("This doesn't work yet!")]
//		public void TestNPathSelectListWithCompositeKey()
//		{
//			int orderId = 0;
//			using (IContext context = GetContext() )
//			{
//				Product product1 = CreateProduct(context, "Banana", 10);
//				Product product2 = CreateProduct(context, "Apple", 15);
//				Product product3 = CreateProduct(context, "Orange", 20);
//
//				Order order = (Order) context.CreateObject(typeof(Order));				
//
//				OrderDetail detail1 = CreateOrderDetail(context, order, product1, 1);
//				OrderDetail detail2 = CreateOrderDetail(context, order, product2, 2);
//				OrderDetail detail3 = CreateOrderDetail(context, order, product3, 3);
//
//				context.Commit();										
//
//				orderId = order.Id;
//			}			
//
//			using (IContext context = GetContext() )
//			{
//				Order order = (Order) context.GetObjectsByNPath("Select Id, OrderDetails.* From Order Where Id = " + orderId.ToString() , typeof(Order));
//			}
//		}

//		[Test()]
//		public void TestCommitRegions()
//		{
//			string detail1Id = "";
//			string detail3Id = "";
//			using (IContext context = GetContext() )
//			{
//				Product product1 = CreateProduct(context, "Banana", 10);
//				Product product2 = CreateProduct(context, "Apple", 15);
//				Product product3 = CreateProduct(context, "Orange", 20);
//
//				Order order = (Order) context.CreateObject(typeof(Order));				
//
//				OrderDetail detail1 = CreateOrderDetail(context, order, product1, 1);
//				OrderDetail detail2 = CreateOrderDetail(context, order, product2, 2);
//				OrderDetail detail3 = CreateOrderDetail(context, order, product3, 3);
//
//				context.Commit();
//
//				detail1Id = context.ObjectManager.GetObjectIdentity(detail1);
//				detail3Id = context.ObjectManager.GetObjectIdentity(detail3);
//			}			
//
//			using (IContext context = GetContext())
//			{
//				OrderDetail detail1 = (OrderDetail) context.GetObjectById(detail1Id, typeof(OrderDetail));
//				Assert.IsNotNull(detail1);
//
//				IContext context2 = GetContext();
//
//				OrderDetail detail3 = (OrderDetail) context2.GetObjectById(detail3Id, typeof(OrderDetail));
//				Assert.IsNotNull(detail3);
//
//				detail3.Quantity = 20;
//
//				context2.Commit();
//				context2.Dispose();
//			}
//		}

		[Test()]
		public void TestDeletes()
		{
			using (IContext context = GetContext() )
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				context.SqlExecutor.ExecuteNonQuery("Delete From [Order Details]");
				context.SqlExecutor.ExecuteNonQuery("Delete From Orders");
				context.SqlExecutor.ExecuteNonQuery("Delete From Customers");

				Customer customer = (Customer) context.CreateObject(typeof(Customer));

				customer.Id = "APEYO";
				customer.CompanyName = "Puzzle";

				Order order1 = CreateOrder(context, customer);
				Order order2 = CreateOrder(context, customer);

				context.Commit();
			}

			using (IContext context = GetContext() )
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				Customer deleteCustomer = (Customer) context.TryGetObjectById("APEYO", typeof(Customer));
				if (deleteCustomer != null)
				{
					//We have to copy to a new list...every time we delete an order,
					//it is removed from the customer.Orders list. 
					IList deleteOrders = new ArrayList(deleteCustomer.Orders);
					Assert.AreEqual(2, deleteOrders.Count);
					foreach (Order order in deleteOrders)
						context.DeleteObject(order);
					context.DeleteObject(deleteCustomer);
					context.Commit();
				}
			}

		}


		[Test()]
		public void TestCommitRegionsShouldPass()
		{
			int order1Id = 0;
			int order3Id = 0;
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
				Order order3 = CreateOrder(context, customer);

				context.Commit();

				order1Id = order1.Id;
				order3Id = order3.Id;
			}			

			using (IContext context = GetContext())
			{
				Order order1 = (Order) context.GetObjectById(order1Id, typeof(Order));

				IContext context2 = GetContext();

				Order order3 = (Order) context2.GetObjectById(order3Id, typeof(Order));

				order3.ShipAddress = "Address3";

				context2.Commit();
				context2.Dispose();

				order1.ShipCity = "City1";

				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				context.Commit();
			}
		}


		[Test(), ExpectedException(typeof(UnresolvedConflictsException))]
		public void TestCommitRegionsShouldFail()
		{
			int order1Id = 0;
			int order3Id = 0;
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
				Order order3 = CreateOrder(context, customer);

				context.Commit();

				order1Id = order1.Id;
				order3Id = order3.Id;
			}			

			using (IContext context = GetContext())
			{
				Order order1 = (Order) context.GetObjectByNPath("Select *, Customer.*, Customer.Orders.* from Order Where Id = " + order1Id.ToString(), typeof(Order));

				IContext context2 = GetContext();

				Order order3 = (Order) context2.GetObjectById(order3Id, typeof(Order));

				order3.ShipAddress = "Address3";

				context2.Commit();
				context2.Dispose();

				order1.ShipCity = "City1";

				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				context.Commit();
			}
		}

		[Test()]
		public void TestCommitRegionsShouldFailThenResolveUseCachedValue()
		{
			int order1Id = 0;
			int order3Id = 0;
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
				Order order3 = CreateOrder(context, customer);

				context.Commit();

				order1Id = order1.Id;
				order3Id = order3.Id;
			}			

			using (IContext context = GetContext())
			{
				Order order1 = (Order) context.GetObjectByNPath("Select *, Customer.*, Customer.Orders.* from Order Where Id = " + order1Id.ToString(), typeof(Order));

				IContext context2 = GetContext();

				Order order3 = (Order) context2.GetObjectById(order3Id, typeof(Order));

				order3.ShipAddress = "Address3";

				context2.Commit();
				context2.Dispose();

				order1.ShipCity = "City1";

				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				try
				{
					context.Commit();					
				}
				catch (UnresolvedConflictsException ex)
				{
					foreach (IRefreshConflict conflict in ex.Conflicts)
					{
						conflict.Resolve(ConflictResolution.UseCachedValue);
					}
				}
				context.Commit();
			}
		}

		[Test()]
		public void TestCommitRegionsShouldFailThenResolveUseFreshValue()
		{
			int order1Id = 0;
			int order3Id = 0;
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
				Order order3 = CreateOrder(context, customer);

				context.Commit();

				order1Id = order1.Id;
				order3Id = order3.Id;
			}			

			using (IContext context = GetContext())
			{
				Order order1 = (Order) context.GetObjectByNPath("Select *, Customer.*, Customer.Orders.* from Order Where Id = " + order1Id.ToString(), typeof(Order));

				IContext context2 = GetContext();

				Order order3 = (Order) context2.GetObjectById(order3Id, typeof(Order));

				order3.ShipAddress = "Address3";

				context2.Commit();
				context2.Dispose();

				order1.ShipCity = "City1";

				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				try
				{
					context.Commit();					
				}
				catch (UnresolvedConflictsException ex)
				{
					foreach (IRefreshConflict conflict in ex.Conflicts)
					{
						conflict.Resolve(ConflictResolution.UseFreshValue);
					}
				}
				context.Commit();
			}
		}



		[Test(), ExpectedException(typeof(DifferentShipAddressException))]
		public void TestCommitRegionsWithValidate()
		{
			int order1Id = 0;
			int order3Id = 0;
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
				Order order3 = CreateOrder(context, customer);

				context.Commit();

				order1Id = order1.Id;
				order3Id = order3.Id;
			}			

			using (IContext context = GetContext())
			{
				Order order1 = (Order) context.GetObjectById(order1Id, typeof(Order));
				//Order order1 = (Order) context.GetObjectById(order3Id, typeof(Order));

				IContext context2 = GetContext();

				Order order3 = (Order) context2.GetObjectById(order3Id, typeof(Order));

				order3.ShipAddress = "Address3";

				context2.Commit();
				context2.Dispose();

				order1.ShipAddress = "Address1";

				context.ExecutingSql += new ExecutingSqlEventHandler(Context_ExecutingSql) ;

				try
				{
					context.Commit();										
				}
				catch (NPersistValidationException ex)
				{
					throw ex.InnerException ;
				}
			}
		}


		private Product CreateProduct(IContext context, string name, decimal price)
		{
			Category category = (Category) context.TryGetObjectByNPath("Select * from Category Where CategoryName = 'Fruit'", typeof(Category));
			if (category == null)
			{
				category = (Category) context.CreateObject(typeof(Category));				
				category.CategoryName = "Fruit";
				context.Commit();
			}

			Product product = (Product) context.CreateObject(typeof(Product));
			product.ProductName = name;
			product.UnitPrice = price;
			product.Category = category;

			return product;
		}


		private Order CreateOrder(IContext context, Customer customer)
		{
			Order order = (Order) context.CreateObject(typeof(Order));

			order.Customer = customer;

			return order;
		}

		private OrderDetail CreateOrderDetail(IContext context, Order order, Product product, short qty)
		{
			OrderDetail orderDetail = (OrderDetail) context.CreateObject(typeof(OrderDetail));
			orderDetail.Order = order;
			orderDetail.Product = product;
			orderDetail.Quantity = qty;
			orderDetail.UnitPrice = product.UnitPrice;

			return orderDetail;
		}

		private void Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}


	}
}
