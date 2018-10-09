using System;
using System.Collections;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.EventArguments;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for CompositeIdentityTests.
	/// </summary>
	[TestFixture()]
	public class CompositeIdentityTests : TestBase
	{

		[Test()]
		public void TestCreateAndUpdateAndDeleteFolderIDUsingConcatString()
		{
			using (IContext context = GetContext())
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql) ;

				FolderID f = (FolderID) context.CreateObject("Human|AB", typeof(FolderID));
				f.FolderDescript = "Mats";
				f.ID = 3;
				context.Commit();
				Assert.AreEqual("Human", f.ApCode);
				Assert.AreEqual("AB", f.FuncCode);
				f.ApCode = "Customer";
				f.FolderDescript = "Helander";
				context.Commit();
				context.DeleteObject(f);
				context.Commit();
				
			}
		}

		
		[Test()]
		public void TestCreateAndUpdateAndDeleteFolderIDUsingHashtable()
		{
			using (IContext context = GetContext())
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql) ;

				Hashtable newId = new Hashtable() ;
				newId["ApCode"] = "Human";
				newId["FuncCode"] = "AB";
				FolderID f = (FolderID) context.CreateObject(newId, typeof(FolderID));
				f.FolderDescript = "Mats";
				f.ID = 3;
				context.Commit();
				Assert.AreEqual("Human", f.ApCode);
				Assert.AreEqual("AB", f.FuncCode);
				f.ApCode = "Customer";
				f.FolderDescript = "Helander";
				context.Commit();
				context.DeleteObject(f);
				context.Commit();
				
			}
		}

	
		[Test()]
		public void TestCreateAndUpdateAndDeleteFolderIDDummyObject()
		{
			using (IContext context = GetContext())
			{
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql) ;

				FolderID dummyObject = new FolderID() ;

				dummyObject.ApCode = "Human";
				dummyObject.FuncCode = "AB";

				FolderID f = (FolderID) context.CreateObject(dummyObject, typeof(FolderID));
				f.FolderDescript = "Mats";
				f.ID = 3;
				context.Commit();
				Assert.AreEqual("Human", f.ApCode);
				Assert.AreEqual("AB", f.FuncCode);
				f.ApCode = "Customer";
				f.FolderDescript = "Helander";
				context.Commit();
				context.DeleteObject(f);
				context.Commit();
				
			}
		}

		private void m_Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}
	}
}
