using System;
using System.Collections;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.EventArguments;
namespace Puzzle.NPersist.Tests.Main
{
	[TestFixture()]
	public class ClassTableInheritanceTests : TestBase
	{
		private IContext m_Context;
		private IContext m_Context2;

		[TestFixtureSetUp()]
		public void SetupTestFixture()
		{
			m_Context = GetContext();
			m_Context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql) ;
		}

		[TestFixtureTearDown()]
		public void TearDownTestFixture()
		{
			m_Context.Dispose();
		}

		[Test()]
		public void TestCreatePerson()
		{
			ClsTblPerson p = (ClsTblPerson) m_Context.CreateObject(typeof(ClsTblPerson));
			p.FirstName = "Mats";
			p.LastName = "Helander";
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateEmployee()
		{
			ClsTblEmployee e = (ClsTblEmployee) m_Context.CreateObject(typeof(ClsTblEmployee));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateAndDeleteEmployee()
		{
			ClsTblEmployee e = (ClsTblEmployee) m_Context.CreateObject(typeof(ClsTblEmployee));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			m_Context.Commit();
			m_Context.DeleteObject(e);
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateAndFetchEmployee()
		{
			ClsTblEmployee e = (ClsTblEmployee) m_Context.CreateObject(typeof(ClsTblEmployee));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			m_Context.Commit();
			m_Context2 = GetContext();
			m_Context2.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context2_ExecutingSql) ;
			ClsTblEmployee e2 = (ClsTblEmployee) m_Context2.GetObject(e.Id, typeof(ClsTblEmployee));
			Assert.AreEqual("Mats", e2.FirstName );
			Assert.AreEqual("Helander", e2.LastName );
			Assert.AreEqual(2000, e2.Salary);
			m_Context2.Dispose();
		}

		[Test()]
		public void TestCreateEmployeeAndFolder()
		{
			ClsTblEmployee e = (ClsTblEmployee) m_Context.CreateObject(typeof(ClsTblEmployee));
			ClsTblFolder f = (ClsTblFolder) m_Context.CreateObject(typeof(ClsTblFolder));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			f.Name = "My First Folder";
			f.Person = e;
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateEmployeeAndWorkFolder()
		{
			ClsTblEmployee e = (ClsTblEmployee) m_Context.CreateObject(typeof(ClsTblEmployee));
			ClsTblWorkFolder wf = (ClsTblWorkFolder) m_Context.CreateObject(typeof(ClsTblWorkFolder));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			wf.Name = "My First Folder";
			wf.Person = e;
			wf.Employee = e;
			wf.WorkType = "Boring";
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateAndFetchEmployeeAndWorkFolder()
		{
			ClsTblEmployee e = (ClsTblEmployee) m_Context.CreateObject(typeof(ClsTblEmployee));
			ClsTblWorkFolder wf = (ClsTblWorkFolder) m_Context.CreateObject(typeof(ClsTblWorkFolder));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			wf.Name = "My First Folder";
			wf.Person = e;
			wf.Employee = e;
			wf.WorkType = "Boring";
			m_Context.Commit();
			m_Context2 = GetContext();
			m_Context2.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context2_ExecutingSql) ;
			ClsTblEmployee e2 = (ClsTblEmployee ) m_Context2.GetObject(e.Id, typeof(ClsTblEmployee));
			Assert.AreEqual("Mats", e2.FirstName );
			Assert.AreEqual("Helander", e2.LastName );
			Assert.AreEqual(2000, e2.Salary);
			ClsTblWorkFolder wf2 = (ClsTblWorkFolder) m_Context2.GetObject(wf.Id, typeof(ClsTblWorkFolder));
			Assert.AreEqual("Boring", wf2.WorkType);
			Assert.AreEqual("Mats", wf2.Employee.FirstName );
			m_Context2.Dispose();
		}

		[Test()]
		public void TestFetchAllPersons()
		{
			string npath = "Select * From ClsTblPerson";
			IList list = m_Context.GetObjectsByNPath(npath, typeof(ClsTblPerson));
			Assert.IsTrue(list.Count > 0);
		}


		private void m_Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}

		private void m_Context2_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}
	}
}
