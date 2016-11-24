using System;
using System.Collections;
using Puzzle.NPersist.Framework;
using QuickStart.Domain;

namespace QuickStart.WinGui
{
	/// <summary>
	/// Summary description for BookServices.
	/// </summary>
	public class BookServices
	{
		public BookServices()
		{
		}

		public static Book CreateBook(IContext context, string title, string isbn)
		{
			//Ask the context to create a new book object
			Book book = (Book) context.CreateObject(typeof(Book));

			//Set the properties
			book.Title = title;
			book.Isbn = isbn;

			//Commit the new object to the database
			context.Commit();

			return book;
		}

		public static Book FetchBookById(IContext context, int bookId)
		{
			//Ask the context to fetch a book object by identity
			Book book = (Book) context.GetObjectById(bookId, typeof(Book));

			//return the book object
			return book;
		}

		public static Book UpdateBook(IContext context, int bookId, string title, string isbn)
		{
			//Ask the context to fetch a book object by identity
			Book book = (Book) context.GetObjectById(bookId, typeof(Book));

			//Set the properties
			book.Title = title;
			book.Isbn = isbn;

			//Commit the updated object to the database
			context.Commit();

			return book;
		}

		public static void DeleteBook(IContext context, int bookId)
		{
			//Ask the context to fetch a book object by identity
			Book book = (Book) context.GetObjectById(bookId, typeof(Book));

			//Ask the context to mark the object 
			//for deletion during the next commit
			context.DeleteObject(book);

			//Commit the deletion of the object from the database
			context.Commit();
		}

		public static IList FetchAllBooks(IContext context)
		{
			//Ask the context to fetch all books
			IList books = context.GetObjects(typeof(Book));

			return books;
		}
		
	}
}
