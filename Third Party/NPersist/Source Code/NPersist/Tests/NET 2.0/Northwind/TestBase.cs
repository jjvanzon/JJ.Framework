using System;
using System.Reflection;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind
{
	/// <summary>
	/// Summary description for TestBase.
	/// </summary>
	public abstract class TestBase
	{

		public virtual IContext GetContext()
		{
			return ContextFactory.CreateContext() ;
		}

		protected int EnsureNancy(int bossId)
		{
			int id = 0;
			using (IContext context = GetContext() )
			{
				ITransaction trans = context.BeginTransaction ();				
				context.SqlExecutor.ExecuteNonQuery("insert Employees (FirstName,LastName,ReportsTo) values('Nancy','Davolio'," + bossId.ToString()  + ")");
				id = Convert.ToInt32(context.SqlExecutor.ExecuteScalar("select @@identity"));
				trans.Commit() ;
			}	
			return id;
		}

		protected int EnsureBoss()
		{
			int id = 0;
			using (IContext context = GetContext() )
			{
				ITransaction trans = context.BeginTransaction ();
				context.SqlExecutor.ExecuteNonQuery("delete from Employees");
				context.SqlExecutor.ExecuteNonQuery("insert Employees (FirstName,LastName) values('Mr boss','boss')");
				id = Convert.ToInt32(context.SqlExecutor.ExecuteScalar("select @@identity"));
				trans.Commit() ;
			}	
			return id;
		}
	}
}
