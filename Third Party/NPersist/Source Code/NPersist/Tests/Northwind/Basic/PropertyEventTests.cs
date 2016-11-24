using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind.Basic
{
	[TestFixture]
	public class PropertyEventTests : TestBase
	{
		public PropertyEventTests()
		{
		}

		[Test()]
		public virtual void DoesGetAllEvents()
		{ 
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.ReadingProperty += new ReadingPropertyEventHandler(Context_ReadingProperty_Cnt); 
				context.ReadProperty += new ReadPropertyEventHandler(Context_ReadProperty_Cnt); 
				context.WritingProperty += new WritingPropertyEventHandler(Context_WritingProperty_Cnt); 
				context.WroteProperty += new WrotePropertyEventHandler(Context_WroteProperty_Cnt); 

				ResetCnt();

				//Ask the context to fetch the employee
				Employee employee = (Employee) context.GetObjectById(id, typeof(Employee));

				AssertCnt(0, 0, 0, 0);

				//Assert that the employee has the name Nancy Davolio
				//(She should, in a standard northwind setup)
				Assert.AreEqual("Nancy", employee.FirstName);

				AssertCnt(1, 1, 0, 0);

				employee.FirstName = "Test";

				AssertCnt(1, 1, 1, 1);
			}
		}

		[Test()]
		public virtual void CanCancelReading()
		{ 
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.ReadingProperty += new ReadingPropertyEventHandler(Context_ReadingProperty_Cancel); 

				//Ask the context to fetch the employee
				Employee employee = (Employee) context.GetObjectById(id, typeof(Employee));

				//Assert that the employee has the name Nancy Davolio
				//(She should, in a standard northwind setup)
				Assert.AreEqual("Permission denied", employee.FirstName);
			}
		}

		[Test()]
		public virtual void CanCancelRead()
		{ 
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.ReadProperty += new ReadPropertyEventHandler(Context_ReadProperty_Cancel); 

				//Ask the context to fetch the employee
				Employee employee = (Employee) context.GetObjectById(id, typeof(Employee));

				//Assert that the employee has the name Nancy Davolio
				//(She should, in a standard northwind setup)
				Assert.AreEqual("Name hidden", employee.FirstName);
				Assert.AreEqual(id, employee.Id);
			}
		}

		[Test()]
		public virtual void CanCancelWriting()
		{ 
			int bossid = EnsureBoss();
			int id = EnsureNancy(bossid);

			using (IContext context = GetContext() )
			{
				context.WritingProperty += new WritingPropertyEventHandler(Context_WritingProperty_Cancel); 

				//Ask the context to fetch the employee
				Employee employee = (Employee) context.GetObjectById(id, typeof(Employee));

				//Assert that the employee has the name Nancy Davolio
				//(She should, in a standard northwind setup)
				Assert.AreEqual("Nancy", employee.FirstName);

				employee.FirstName = "Test";

				//Assert that the employee has the name Nancy Davolio
				//(She should, in a standard northwind setup)
				Assert.AreEqual("Nancy", employee.FirstName);
			}
		}


		private void ResetCnt()
		{
			readingCnt = 0;
			readCnt = 0;
			writingCnt = 0;
			wroteCnt = 0;
		}

		private void AssertCnt(int readingCnt, int readCnt, int writingCnt, int wroteCnt)
		{
			Assert.AreEqual(readingCnt, this.readingCnt);
			Assert.AreEqual(readCnt, this.readCnt);
			Assert.AreEqual(writingCnt, this.writingCnt);
			Assert.AreEqual(wroteCnt, this.wroteCnt);
		}

		private int readingCnt;
		private int readCnt;
		private int writingCnt;
		private int wroteCnt;

		public void Context_ReadingProperty_Cnt(object sender, PropertyCancelEventArgs e)
		{
			readingCnt++;
		}

		public void Context_ReadProperty_Cnt(object sender, PropertyEventArgs e)
		{
			readCnt++;
		}

		public void Context_WritingProperty_Cnt(object sender, PropertyCancelEventArgs e)
		{
			writingCnt++;
		}
	
		public void Context_WroteProperty_Cnt(object sender, PropertyEventArgs e)
		{
			wroteCnt++;
		}

		public void Context_ReadingProperty_Cancel(object sender, PropertyCancelEventArgs e)
		{
			e.Value = "Permission denied";
			e.Cancel = true;
		}

		public void Context_ReadProperty_Cancel(object sender, PropertyEventArgs e)
		{
			if (e.Value.Equals("Nancy"))
			{
				e.Value = "Name hidden";
			}
			readCnt++;
		}

		public void Context_WritingProperty_Cancel(object sender, PropertyCancelEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
