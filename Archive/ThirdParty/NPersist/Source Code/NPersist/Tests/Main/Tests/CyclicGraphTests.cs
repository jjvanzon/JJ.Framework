using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for CyclicGraphTests.
	/// </summary>
	[TestFixture()]
	public class CyclicGraphTests : TestBase
	{
		public CyclicGraphTests()
		{
		}

		[Test()]
		public void TestInsertWithReferenceToDeleted()
		{
			using (IContext context = GetContext())
			{
				//Hook up an event handler for the executing sql event, allowinng us to log the sql to the console
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{
					CyclicB cyclicB = (CyclicB) context.CreateObject(typeof(CyclicB));


					cyclicB.SomeText = "More Testing";

					context.Commit();

					CyclicA cyclicA = (CyclicA) context.CreateObject(typeof(CyclicA));

					cyclicA.SomeText = "Testing";

					cyclicA.CyclicB = cyclicB;
					cyclicB.CyclicA = cyclicA;

					context.DeleteObject(cyclicB);

					context.Commit();

					context.DeleteObject(cyclicA);

					context.Commit();
				}
				catch (Exception ex)
				{
					//Something went wrong!
					//Rollback the transaction and retheow the exception
					tx.Rollback();

					throw ex;
				}				
			}
		}


		[Test(), ExpectedException(typeof(DeletedObjectException))]
		public void TestSetReferenceToDeleted()
		{
			using (IContext context = GetContext())
			{
				//Hook up an event handler for the executing sql event, allowinng us to log the sql to the console
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{
					CyclicB cyclicB = (CyclicB) context.CreateObject(typeof(CyclicB));


					cyclicB.SomeText = "More Testing";

					context.Commit();

					CyclicA cyclicA = (CyclicA) context.CreateObject(typeof(CyclicA));

					cyclicA.SomeText = "Testing";

					cyclicB.CyclicA = cyclicA;

					context.DeleteObject(cyclicB);

					cyclicA.CyclicB = cyclicB;

				}
				catch (Exception ex)
				{
					//Something went wrong!
					//Rollback the transaction and retheow the exception
					tx.Rollback();

					throw ex;
				}				
			}
		}

		[Test()]
		public void TestInsertAndDeleteCyclicGraphWithInverses()
		{
			using (IContext context = GetContext())
			{
				//Hook up an event handler for the executing sql event, allowinng us to log the sql to the console
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{
					InvCyclicA invCyclicA = (InvCyclicA) context.CreateObject(typeof(InvCyclicA));
					InvCyclicB invCyclicB = (InvCyclicB) context.CreateObject(typeof(InvCyclicB));

					invCyclicA.InvCyclicB = invCyclicB;
					invCyclicB.InvCyclicA = invCyclicA;

					Assert.AreEqual(invCyclicA, invCyclicB.InvOfInvCyclicB);
					Assert.AreEqual(invCyclicB, invCyclicA.InvOfInvCyclicA);
					
					invCyclicA.SomeText = "Testing";
					invCyclicB.SomeText = "More Testing";

					context.Commit();

					context.DeleteObject(invCyclicA);
					context.DeleteObject(invCyclicB);

					context.Commit();
				}
				catch (Exception ex)
				{
					//Something went wrong!
					//Rollback the transaction and retheow the exception
					tx.Rollback();

					throw ex;
				}				
			}
		}

		[Test()]
		public void TestInsertAndDeleteCyclicGraph()
		{
			using (IContext context = GetContext())
			{
				//Hook up an event handler for the executing sql event, allowinng us to log the sql to the console
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

				//Encapsulate our whole test in a transaction,
				//so that any changes to the database are rolled back in case
				//of a test failure
				ITransaction tx = context.BeginTransaction();

				try
				{
					CyclicA cyclicA = (CyclicA) context.CreateObject(typeof(CyclicA));
					CyclicB cyclicB = (CyclicB) context.CreateObject(typeof(CyclicB));

					cyclicA.CyclicB = cyclicB;
					cyclicB.CyclicA = cyclicA;

					cyclicA.SomeText = "Testing";
					cyclicB.SomeText = "More Testing";

					context.Commit();

					context.DeleteObject(cyclicA);
					context.DeleteObject(cyclicB);

					context.Commit();
				}
				catch (Exception ex)
				{
					//Something went wrong!
					//Rollback the transaction and retheow the exception
					tx.Rollback();

					throw ex;
				}				
			}
		}

		private void m_Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}

	}
}
