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
	public class CascadeTests : TestBase
	{

		[Test()]
		public void TestCascadingCreateAndDelete()
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

					//Create a new book object
					//This should, in addition to creating a new book object,
					//cause a new Cover object to be created and a reference to
					//this object should be added to the Cover property of the new book.
					//Likewise a new BookInfo object should be created and referenced.
					Book b = (Book) context.CreateObject(typeof(Book));

					Assert.IsNotNull(b.Cover, "The cover should have been created and referenced!");
					Assert.IsNotNull(b.BookInfo, "The book-info should have been created and referenced!");

					//Set values on the new objects
					b.Name = "Moby Dick";
					b.Cover.Color = "Brown";
					b.BookInfo.ISBN = "123456";

					//Assert that all three objects are registered as up for creation
					Assert.AreEqual(ObjectStatus.UpForCreation.ToString(), context.GetObjectStatus(b).ToString());
					Assert.AreEqual(ObjectStatus.UpForCreation.ToString(), context.GetObjectStatus(b.Cover).ToString());
					Assert.AreEqual(ObjectStatus.UpForCreation.ToString(), context.GetObjectStatus(b.BookInfo).ToString());

					//Make sure that the properties we have written to are dirty
					Assert.AreEqual(PropertyStatus.Dirty.ToString(), context.GetPropertyStatus(b, "Name").ToString());
					Assert.AreEqual(PropertyStatus.Dirty.ToString(), context.GetPropertyStatus(b, "Cover").ToString());
Console.WriteLine("Apa");
					//insert the new objects into the database
					context.Commit();
Console.WriteLine("Gnu");
				
					//Make sure that the properties we have written to are now clean
					Assert.AreEqual(PropertyStatus.Clean.ToString(), context.GetPropertyStatus(b, "Name").ToString());
					Assert.AreEqual(PropertyStatus.Clean.ToString(), context.GetPropertyStatus(b, "Cover").ToString());
				
					//Assert that all three objects have gotten new ids from the database (they all have autoincreaser ids)
					Assert.IsTrue(b.Id > 0, "The book should have got a new id from the database!");
					Assert.IsTrue(b.Cover.Id > 0, "The cover should have got a new id from the database!");
					Assert.IsTrue(b.BookInfo.Id > 0, "The book info should have got a new id from the database!");
				
					//Assert that all three objects are now clean
					Assert.AreEqual(ObjectStatus.Clean.ToString(), context.GetObjectStatus(b).ToString());
					Assert.AreEqual(ObjectStatus.Clean.ToString(), context.GetObjectStatus(b.Cover).ToString());
					Assert.AreEqual(ObjectStatus.Clean.ToString(), context.GetObjectStatus(b.BookInfo).ToString());

					//save references to the cover and bookinfo objects since
					//we won't be able to read the properties of the deleted book object later
					Cover c = b.Cover;
					BookInfo bi = b.BookInfo;

					//Delete the book object. This should
					//also cause the Cover and BookInfo objects to be cascade deleted
					context.DeleteObject(b);

					//Assert that all three objects are now up for deletion
					Assert.AreEqual(ObjectStatus.UpForDeletion.ToString(), context.GetObjectStatus(b).ToString());
					Assert.AreEqual(ObjectStatus.UpForDeletion.ToString(), context.GetObjectStatus(c).ToString());
					Assert.AreEqual(ObjectStatus.UpForDeletion.ToString(), context.GetObjectStatus(bi).ToString());
				
					//remove the objects from the database
					context.Commit();
				
					//Assert that all three objects are now deleted
					Assert.AreEqual(ObjectStatus.Deleted.ToString(), context.GetObjectStatus(b).ToString());
					Assert.AreEqual(ObjectStatus.Deleted.ToString(), context.GetObjectStatus(c).ToString());
					Assert.AreEqual(ObjectStatus.Deleted.ToString(), context.GetObjectStatus(bi).ToString());
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
