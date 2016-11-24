using System;
using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using QuickStart.Domain;

namespace QuickStart.WinGui
{
	/// <summary>
	/// Summary description for AuthorServices.
	/// </summary>
	public class AuthorServices
	{
		public AuthorServices()
		{
		}

		public static Author CreateAuthor(IContext context, string firstName, string lastName)
		{
			//Ask the context to create a new author object
			Author author = (Author) context.CreateObject(typeof(Author));

			//Set the properties
			author.FirstName = firstName;
			author.LastName = lastName;

			//Commit the new object to the database
			context.Commit();

			return author;
		}

		public static Author FetchAuthorById(IContext context, int authorId)
		{
			//Ask the context to fetch an author object by identity
			Author author = (Author) context.GetObjectById(authorId, typeof(Author));

			//return the author object
			return author;
		}

		public static Author UpdateAuthor(
			IContext context, 
			int authorId, 
			string firstName, 
			string lastName)
		{
			//Ask the context to fetch an author object by identity
			Author author = (Author) context.GetObjectById(authorId, typeof(Author));

			//Set the properties
			author.FirstName = firstName;
			author.LastName = lastName;

			//Commit the updated object to the database
			context.Commit();

			return author;
		}

		public static void DeleteAuthor(IContext context, int authorId)
		{
			//Ask the context to fetch an author object by identity
			Author author = (Author) context.GetObjectById(authorId, typeof(Author));

			//Ask the context to mark the object 
			//for deletion during the next commit
			context.DeleteObject(author);

			//Commit the deletion of the object from the database
			context.Commit();
		}

		public static void AddAuthorToBook(
			IContext context, 
			int bookId, 
			int authorId)
		{
			//Ask the context to fetch a book object by identity
			Book book = (Book) context.GetObjectById(bookId, typeof(Book));

			//Ask the context to fetch an author object by identity
			Author author = (Author) context.GetObjectById(authorId, typeof(Author));

			//Set up the relationship
			// (could also be done with
			// author.Books.Add(book);
			book.Authors.Add(author);

			//Commit the changes to the database
			context.Commit();
		}

		public static void RemoveAuthorFromBook(
			IContext context, 
			int bookId, 
			int authorId)
		{
			//Ask the context to fetch a book object by identity
			Book book = (Book) context.GetObjectById(bookId, typeof(Book));

			//Ask the context to fetch an author object by identity
			Author author = (Author) context.GetObjectById(authorId, typeof(Author));

			//Set up the relationship
			// (could also be done with
			// book.Authors.Remove(author);
			author.Books.Remove(book);

			//Commit the changes to the database
			context.Commit();
		}

		public static IList FetchAllAuthors(IContext context)
		{
			//Ask the context to fetch all authors
			IList authors = context.GetObjects(typeof(Author));

			return authors;
		}

		public static IList FilterAuthors(
			IContext context, 
			string firstName, 
			string lastName)
		{
			//Pad the first and last names with wildcard symbols
			firstName = "%" + firstName + "%";
			lastName = "%" + lastName + "%";

			//Create the npath query string
			string npathString = "Select * From Author Where " +
				"FirstName Like ? and LastName Like ?";

			//Create the npath query object
			NPathQuery npathQuery = new NPathQuery(npathString, typeof(Author));

			//Add the parameters to the npath query object
			npathQuery.Parameters.Add(
				new QueryParameter(DbType.AnsiString, firstName));
			
			npathQuery.Parameters.Add(
				new QueryParameter(DbType.AnsiString, lastName));

			//Ask the context to fetch all authors matching the npath query
			IList authors = context.GetObjectsByNPath(npathQuery);

			return authors;
		}

	}
}
