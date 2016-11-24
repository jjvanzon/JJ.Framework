using System;
using System.Data;
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
	public class WriteConsistencyTests : TestBase
	{
		public WriteConsistencyTests()
		{
		}

		[Test(), ExpectedException(typeof(WriteConsistencyException))]
		public virtual void CreateObjectOutsideTxShouldFail()
		{
			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));
			}
		}

		[Test()]
		public virtual void CreateObjectInsideTxShouldWork()
		{
			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				tx.Commit();
			}
		}

		[Test(), ExpectedException(typeof(WriteConsistencyException))]
		public virtual void InsertObjectOutsideTxShouldFail()
		{
			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				boss.FirstName = "Test";
				boss.LastName = "Test";
				boss.BirthDate = DateTime.Parse("2008-01-01");

				tx.Commit();

				context.Commit();
			}
		}


		[Test()]
		public virtual void InsertObjectInsideTxShouldWork()
		{
			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				boss.FirstName = "Test";
				boss.LastName = "Test";
				boss.BirthDate = DateTime.Parse("2008-01-01");

				context.Commit();
			}
		}

		[Test(), ExpectedException(typeof(WriteConsistencyException))]
		public virtual void WriteToPropertyOutsideTxShouldFail()
		{
			int bossid = EnsureBoss();

			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				tx.Commit();

				boss.FirstName = "Test";
			}
		}

		[Test(), ExpectedException(typeof(WriteConsistencyException))]
		public virtual void UpdateObjectOutsideTxShouldFail()
		{
			int bossid = 0;
			using (IContext context = GetContext() )
			{
				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				boss.FirstName = "Test";
				boss.LastName = "Test";
				boss.BirthDate = DateTime.Parse("2008-01-01");

				context.Commit();

				bossid = boss.Id;
			}

			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));

				boss.FirstName = "NewTest";

				tx.Commit();

				context.Commit();
			}
		}

		[Test()]
		public virtual void UpdateObjectInsideTxShouldWork()
		{
			int bossid = 0;
			using (IContext context = GetContext() )
			{
				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				boss.FirstName = "Test";
				boss.LastName = "Test";
				boss.BirthDate = DateTime.Parse("2008-01-01");

				context.Commit();

				bossid = boss.Id;
			}

			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));

				boss.FirstName = "NewTest";

				context.Commit();

				tx.Commit();
			}
		}


		[Test(), ExpectedException(typeof(WriteConsistencyException))]
		public virtual void DeleteObjectOutsideTxShouldFail()
		{
			int bossid = 0;
			using (IContext context = GetContext() )
			{
				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				boss.FirstName = "Test";
				boss.LastName = "Test";
				boss.BirthDate = DateTime.Parse("2008-01-01");

				context.Commit();

				bossid = boss.Id;
			}

			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));

				context.DeleteObject( boss );

				tx.Commit();

				context.Commit();
			}
		}

		[Test()]
		public virtual void DeleteObjectInsideTxShouldWork()
		{
			int bossid = 0;
			using (IContext context = GetContext() )
			{
				//Ask the context to fetch the employee with id = 2
				Employee boss = (Employee) context.CreateObject(typeof(Employee));

				boss.FirstName = "Test";
				boss.LastName = "Test";
				boss.BirthDate = DateTime.Parse("2008-01-01");

				context.Commit();

				bossid = boss.Id;
			}

			using (IContext context = GetContext() )
			{
				context.WriteConsistency = ConsistencyMode.Pessimistic;

				ITransaction tx = context.BeginTransaction(IsolationLevel.Serializable, false);

				Employee boss = (Employee) context.GetObjectById(bossid, typeof(Employee));

				context.DeleteObject( boss );

				context.Commit();

				tx.Commit();
			}
		}

	}
}