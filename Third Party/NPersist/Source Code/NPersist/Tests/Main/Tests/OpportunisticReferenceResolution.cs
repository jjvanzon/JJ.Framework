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
	public class OpportunisticReferenceResolution : TestBase
	{
		public OpportunisticReferenceResolution()
		{
		}

		[Test()]
		public void TestInsertAndDeleteCyclicGraphWithInverses()
		{
			int idA = 0;
			int idB = 0;

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

					tx.Commit();

					idA = invCyclicA.Id;
					idB = invCyclicB.Id;
				}
				catch (Exception ex)
				{
					//Something went wrong!
					//Rollback the transaction and retheow the exception
					tx.Rollback();

					throw ex;
				}				
			}

			using (IContext context = GetContext())
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

				InvCyclicA invCyclicA = (InvCyclicA) context.GetObject(idA, typeof(InvCyclicA));
				InvCyclicB invCyclicB = (InvCyclicB) context.GetObject(idB, typeof(InvCyclicB));
				
				Assert.AreEqual(invCyclicA, invCyclicB.InvOfInvCyclicB);
				Assert.AreEqual(invCyclicB, invCyclicA.InvOfInvCyclicA);
			}
		}

		private void m_Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}

	}
}
