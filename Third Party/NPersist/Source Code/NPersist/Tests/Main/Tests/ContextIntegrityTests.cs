using System;
using System.Collections;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;

namespace Puzzle.NPersist.Tests.Main
{
	[TestFixture()]
	public class ContextIntegrityTests : TestBase
	{
		private IContext m_Context;
		private IContext m_Context2;
		[TestFixtureSetUp()]
		public void SetupTestFixture()
		{
			m_Context = GetContext();
			m_Context2 = GetContext();
			m_Context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql) ;
		}

		[TestFixtureTearDown()]
		public void TearDownTestFixture()
		{
			m_Context.Dispose();
		}

		private void m_Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}

		[Test()]
		[ExpectedException (typeof(NPersistException))]
		public void AssignUnmanagedObjectToProperty()
		{			
			try
			{
				SngTblWorkFolder wf = (SngTblWorkFolder) m_Context.CreateObject(typeof(SngTblWorkFolder));
				//this should fail
				wf.Employee = new SngTblEmployee() ;
				
			}
			catch (Exception ex)
			{				
				throw ex;
			}
		}

		[Test()]
		[ExpectedException (typeof(NPersistException))]
		public void AssignManagedObjectOfOtherContextToProperty()
		{			
			SngTblWorkFolder wf = (SngTblWorkFolder) m_Context.CreateObject(typeof(SngTblWorkFolder));
			SngTblEmployee e = (SngTblEmployee) m_Context2.CreateObject(typeof(SngTblEmployee));
			//this should fail
			wf.Employee = e ;
		}

		[Test()]
		[ExpectedException (typeof(NPersistException))]
		public void AssignUnmanagedListToListProperty()
		{						
			SngTblEmployee e = (SngTblEmployee) m_Context2.CreateObject(typeof(SngTblEmployee));
			//this should fail
			e.WorkFolders = new ArrayList();
		}
	}
}
