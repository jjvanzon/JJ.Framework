using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for ReadConsistencyTests.
	/// </summary>
	[TestFixture()]
	public class ReadConsistencyTests : TestBase
	{
		public ReadConsistencyTests()
		{
		}

		[Test(), ExpectedException(typeof(ReadConsistencyException))]
		public virtual void LoadObjectOutsideTxShouldFail()
		{
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.ReadConsistency = ConsistencyMode.Pessimistic;

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));
			}
		}

		[Test()]
		public virtual void LoadObjectInsideTxShouldWork()
		{
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.ReadConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction();

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));

				tx.Commit();
			}
		}

		[Test(), ExpectedException(typeof(ReadConsistencyException))]
		public virtual void LazyLoadObjectsOutsideTxShouldFail()
		{
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.ReadConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction();

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));

				tx.Commit();

				foreach (Employee employee in boss.Employees)
					break;
			}
		}

		[Test()]
		public virtual void LazyLoadObjectsInsideTxShouldWork()
		{
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.ReadConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction();

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));

				foreach (Employee employee in boss.Employees)
					break;

				tx.Commit();
			}
		}

	}
}
