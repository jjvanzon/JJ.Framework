using System;
using System.Collections;
using System.Data;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	/// <summary>
	/// Summary description for GetDataTableTests.
	/// </summary>
	[TestFixture()]
	public class GetDataTableTests : TestBase
	{

		#region TestFetchEmployees

		/// <summary>
		/// Fetch an employee object by identity
		/// </summary>
		[Test()]
		public virtual void TestFetchEmployeesAsDataTable()
		{
			using (IContext context = GetContext() )
			{
				//we want to fetch the top 9 employees
				string npath = "Select * From Employee";

				//Ask the context to fetch the employee
				DataTable result = context.GetDataTable(npath, typeof(Employee));

				//Assert that the context didn't return a null value
				Assert.IsNotNull(result);

				PrintTable(result);
			}
		}


		[Test()]
		public virtual void TestFetchEmployeesWithAliases()
		{
			using (IContext context = GetContext() )
			{
				//we want to fetch the top 9 employees
				string npath = "Select Id as Identity, FirstName as FName From Employee";

				//Ask the context to fetch the employee
				DataTable result = context.GetDataTable(npath, typeof(Employee));

				//Assert that the context didn't return a null value
				Assert.IsNotNull(result);

				PrintTable(result);
			}
		}

		[Test()]
		public virtual void TestFetchEmployeesWithFunctions()
		{
			using (IContext context = GetContext() )
			{
				//we want to fetch the top 9 employees
				string npath = "Select Id as Identity, FirstName + ' ' + LastName as Name, Id * 2 As DoubleId From Employee";

				//Ask the context to fetch the employee
				DataTable result = context.GetDataTable(npath, typeof(Employee));

				//Assert that the context didn't return a null value
				Assert.IsNotNull(result);

				PrintTable(result);
			}
		}

		private void PrintTable(DataTable table)
		{
			 
			foreach (DataColumn column in table.Columns)
				Console.Out.Write(column.Caption + ", ");
			
			Console.Out.WriteLine("");
			foreach (DataRow row in table.Rows)
			{
				foreach (object value in row.ItemArray)
					Console.Out.Write(value.ToString() + ", ");

				Console.Out.WriteLine("");
			}


		}

		#endregion
	}
}
