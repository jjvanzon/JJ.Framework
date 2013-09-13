using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.EventArguments;
namespace Puzzle.NPersist.Tests.Main
{
	[TestFixture()]
	public class ConcreteTableInheritanceTests : TestBase
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
			CncTblPerson p = (CncTblPerson) m_Context.CreateObject(typeof(CncTblPerson));
			p.FirstName = "Mats";
			p.LastName = "Helander";
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateEmployee()
		{
			CncTblEmployee e = (CncTblEmployee) m_Context.CreateObject(typeof(CncTblEmployee));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateAndDeleteEmployee()
		{
			CncTblEmployee e = (CncTblEmployee) m_Context.CreateObject(typeof(CncTblEmployee));
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
			CncTblEmployee e = (CncTblEmployee) m_Context.CreateObject(typeof(CncTblEmployee));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			m_Context.Commit();
			m_Context2 = GetContext();
			m_Context2.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context2_ExecutingSql) ;

			CncTblEmployee e2 = (CncTblEmployee) m_Context2.GetObject(e.Id, typeof(CncTblEmployee));
			Assert.AreEqual("Mats", e2.FirstName );
			Assert.AreEqual("Helander", e2.LastName );
			Assert.AreEqual(2000, e2.Salary);
			m_Context2.Dispose();
		}

		[Test()]
		public void TestCreateEmployeeAndFolder()
		{
			CncTblEmployee e = (CncTblEmployee) m_Context.CreateObject(typeof(CncTblEmployee));
			CncTblFolder f = (CncTblFolder) m_Context.CreateObject(typeof(CncTblFolder));
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
			CncTblEmployee e = (CncTblEmployee) m_Context.CreateObject(typeof(CncTblEmployee));
			CncTblWorkFolder wf = (CncTblWorkFolder) m_Context.CreateObject(typeof(CncTblWorkFolder));
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
			CncTblEmployee e = (CncTblEmployee) m_Context.CreateObject(typeof(CncTblEmployee));
			CncTblWorkFolder wf = (CncTblWorkFolder) m_Context.CreateObject(typeof(CncTblWorkFolder));
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

			CncTblEmployee e2 = (CncTblEmployee) m_Context2.GetObject(e.Id, typeof(CncTblEmployee));
			Assert.AreEqual("Mats", e2.FirstName );
			Assert.AreEqual("Helander", e2.LastName );
			Assert.AreEqual(2000, e2.Salary);
			CncTblWorkFolder wf2 = (CncTblWorkFolder) m_Context2.GetObject(wf.Id, typeof(CncTblWorkFolder));
			Assert.AreEqual("Boring", wf2.WorkType);
			Assert.AreEqual("Mats", wf2.Employee.FirstName );
			m_Context2.Dispose();
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
