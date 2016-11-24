using System;
using NUnit.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for OneOneTests.
	/// </summary>
	[TestFixture()]
	public class OneOneTests : TestBase
	{

		[Test()]
		public void TestLazyLoadOneOne()
		{
			long bookId = 0;

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

					b.Name = "Moby Dick";
					b.Cover.Color = "Brown";
					b.BookInfo.ISBN = "123456";

					context.Commit();

					context.DeleteObject(b.BookInfo);

					context.Commit();

					tx.Commit();

					bookId = b.Id;
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
				//Hook up an event handler for the executing sql event, allowinng us to log the sql to the console
				context.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

				Book b = (Book) context.GetObjectById(bookId, typeof(Book));

				Assert.IsNotNull(b);
				Assert.IsNull(b.BookInfo);
			}
		}

		[Test()]
		public void TestLazyLoadOneOneNestedContext()
		{
			long bookId = 0;
			long bookInfoId = 0;

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

					b.Name = "Moby Dick";
					b.Cover.Color = "Brown";
					b.BookInfo.ISBN = "123456";

					context.Commit();

					tx.Commit();

					bookId = b.Id;
					bookInfoId = b.BookInfo.Id;
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
				using (IContext childContext = new Context(context))
				{
					//Hook up an event handler for the executing sql event, allowinng us to log the sql to the console
					childContext.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

					Book b = (Book) childContext.GetObjectById(bookId, typeof(Book));

					Assert.IsNotNull(b);
					Assert.IsNotNull(b.BookInfo);
					Assert.AreEqual(bookInfoId, b.BookInfo.Id);
				}
			}

			using (IContext context = GetContext())
			{
				using (IContext childContext = new Context(context))
				{
					//Hook up an event handler for the executing sql event, allowinng us to log the sql to the console
					childContext.ExecutingSql += new ExecutingSqlEventHandler(this.m_Context_ExecutingSql);

					BookInfo bi = (BookInfo) childContext.GetObjectById(bookInfoId, typeof(BookInfo));

					Assert.IsNotNull(bi);
					Assert.IsNotNull(bi.Book);
					Assert.AreEqual(bookId, bi.Book.Id);
				}
			}
		}


		private void m_Context_ExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			Console.Out.WriteLine(e.Sql);
		}

	}
}
