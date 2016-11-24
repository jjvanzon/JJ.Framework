using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;

namespace Puzzle.NPersist.Tests.Main
{
	[TestFixture()]
	public class InMemTests : TestBase
	{
		private IContext m_Context;

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

		[Test]
		public void CreateObject()
		{
			ClsTblEmployee emp = (ClsTblEmployee)m_Context.CreateObject(typeof(ClsTblEmployee));

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
