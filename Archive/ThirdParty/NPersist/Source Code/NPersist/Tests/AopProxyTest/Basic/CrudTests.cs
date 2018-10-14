using System;
using System.Collections;
using System.Data;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.AopProxyTest.Basic
{
	/// <summary>
	/// Summary description for CrudTests.
	/// </summary>
	[TestFixture()]
	public class CrudTests : TestBase
	{
		#region CreateEmployee
		[Test()]
		public virtual void TestCreateAndDeleteEmployee()
		{
			using (IContext context = GetContext() )
			{
				Employee emp = (Employee)context.CreateObject(typeof(Employee));

			
				emp.FirstName = "Kalle";
				emp.LastName = "Anka";
				emp.HireDate = DateTime.Now;

				Assert.IsTrue(emp.FirstName == "Kalle") ;
			}
		}

		#endregion

		
	}
}
