using System;
using System.Collections;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.EventArguments;
namespace Puzzle.NPersist.Tests.Main
{
	[TestFixture()]
	public class SingleTableInheritanceTests : TestBase
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
			SngTblPerson p = (SngTblPerson) m_Context.CreateObject(typeof(SngTblPerson));
			p.FirstName = "Mats";
			p.LastName = "Helander";
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateEmployee()
		{
			SngTblEmployee e = (SngTblEmployee) m_Context.CreateObject(typeof(SngTblEmployee));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			m_Context.Commit();
		}

		[Test()]
		public void TestCreateAndDeleteEmployee()
		{
			SngTblEmployee e = (SngTblEmployee) m_Context.CreateObject(typeof(SngTblEmployee));
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
			SngTblEmployee e = (SngTblEmployee) m_Context.CreateObject(typeof(SngTblEmployee));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			m_Context.Commit();
			m_Context2 = GetContext();
			m_Context2.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context2_ExecutingSql) ;

			SngTblEmployee e2 = (SngTblEmployee) m_Context2.GetObject(e.Id, typeof(SngTblEmployee));
			Assert.AreEqual("Mats", e2.FirstName );
			Assert.AreEqual("Helander", e2.LastName );
			Assert.AreEqual(2000, e2.Salary);
			m_Context2.Dispose();
		}

		[Test()]
		public void TestCreateEmployeeAndFolder()
		{
			SngTblEmployee e = (SngTblEmployee) m_Context.CreateObject(typeof(SngTblEmployee));
			SngTblFolder f = (SngTblFolder) m_Context.CreateObject(typeof(SngTblFolder));
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
			SngTblEmployee e = (SngTblEmployee) m_Context.CreateObject(typeof(SngTblEmployee));
			SngTblWorkFolder wf = (SngTblWorkFolder) m_Context.CreateObject(typeof(SngTblWorkFolder));
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
			SngTblEmployee e = (SngTblEmployee) m_Context.CreateObject(typeof(SngTblEmployee));
			SngTblWorkFolder wf = (SngTblWorkFolder) m_Context.CreateObject(typeof(SngTblWorkFolder));
			e.FirstName = "Mats";
			e.LastName = "Helander";
			e.Salary = 2000;
			e.EmploymentDate = DateTime.Now;
			wf.Name = "My First Folder";
			wf.Person = e;
			wf.Employee = e;			
			wf.WorkType = "Boring"; //ROGER: c'mon , be positive now
			m_Context.Commit();
			m_Context2 = GetContext();
			m_Context2.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context2_ExecutingSql) ;

			SngTblEmployee e2 = (SngTblEmployee) m_Context2.GetObject(e.Id, typeof(SngTblEmployee));
			Assert.AreEqual("Mats", e2.FirstName );
			Assert.AreEqual("Helander", e2.LastName );
			Assert.AreEqual(2000, e2.Salary);
			SngTblWorkFolder wf2 = (SngTblWorkFolder) m_Context2.GetObject(wf.Id, typeof(SngTblWorkFolder));
			Assert.AreEqual("Boring", wf2.WorkType);
			Assert.AreEqual("Mats", wf2.Employee.FirstName );
			m_Context2.Dispose();
		}


		[Test()]
		public void TestFetchAllPersons()
		{
			string npath = "Select * From SngTblPerson";
			IList list = m_Context.GetObjectsByNPath(npath, typeof(SngTblPerson));
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
