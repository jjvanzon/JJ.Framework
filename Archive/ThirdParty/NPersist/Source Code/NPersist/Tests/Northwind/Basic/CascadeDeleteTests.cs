using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for CascadeDeleteTests.
	/// </summary>
	[TestFixture]
	public class CascadeDeleteTests : TestBase
	{
		public CascadeDeleteTests()
		{
		}

		#region TestFetchEmployeeById

		[Test()]
		public virtual void TestCascadeDelete()
		{ 
			using (IContext context = GetContextWithCascadeDelete() )
			{
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				Order order =  (Order) context.CreateObject(typeof(Order));

				order.Employee = employee;

				context.DeleteObject(employee);
			}
		}

		#endregion
	}
}
