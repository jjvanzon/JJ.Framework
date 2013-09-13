using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;

namespace Puzzle.NPersist.Tests.Main.Tests
{
	/// <summary>
	/// Summary description for InheritanceTests.
	/// </summary>
	[TestFixture]
	public class InheritanceTests : TestBase
	{
		public InheritanceTests()
		{
		}

		[Test]
		public void InheritanceWorks()
		{
			int id = 0;
			using (IContext context = GetContext())
			{
				Employee employee = (Employee) context.CreateObject(typeof(Employee));
				employee.Name = "Test";
				employee.Salary = 0;

				Child child = (Child) context.CreateObject(typeof(Child));
				child.NickName = "Nick";

				child.Person = employee;

				context.Commit();

				id = employee.Id;
			}

			using (IContext context = GetContext())
			{
				Employee employee = (Employee) context.GetObjectById(id, typeof(Employee));
				Assert.AreEqual(1, employee.Children.Count);
			}
		}
	}
}
