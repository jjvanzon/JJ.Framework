using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using Puzzle.NPersist.Framework;
using QuickStart.Domain;

namespace QuickStart.WinGui
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button createAuthorButton;
		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button fetchAuthorButton;
		private System.Windows.Forms.Button updateAuthorButton;
		private System.Windows.Forms.Button deleteAuthorButton;
		private System.Windows.Forms.Button listAuthorButton;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox firstNameFilterTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox lastNameFilterTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button filterButton;
		private System.Windows.Forms.TextBox bookIdTextBox;
		private System.Windows.Forms.TextBox isbnTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox titleTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button deleteBookButton;
		private System.Windows.Forms.Button updateBookButton;
		private System.Windows.Forms.Button fetchBookButton;
		private System.Windows.Forms.Button createBookButton;
		private System.Windows.Forms.Button addToAuthorButton;
		private System.Windows.Forms.Button removeAuthorButton;
		private System.Windows.Forms.Button listBooksButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//The name of the embedded resource that is the xml mapping file
		private string mapName = @"QuickStart.Domain.QuickStart.npersist";

		//The connection string to the database
		private string connectionString = "SERVER=(local);UID=sa;PWD=;DATABASE=QuickStart";

		private IContext context;

		private void InitializeContext()
		{
			//Get the assembly containing the 
			//xml mapping file as an embedded resource
			Assembly asm = typeof(Author).Assembly;

			//Create a new NPersist context object
			context = new Context(asm, mapName); 

			//Set the connection string to the database.
			context.SetConnectionString(connectionString);
		}

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			InitializeContext();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
				if (context != null)
				{
					context.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.createAuthorButton = new System.Windows.Forms.Button();
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.fetchAuthorButton = new System.Windows.Forms.Button();
			this.updateAuthorButton = new System.Windows.Forms.Button();
			this.deleteAuthorButton = new System.Windows.Forms.Button();
			this.listAuthorButton = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.firstNameFilterTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lastNameFilterTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.filterButton = new System.Windows.Forms.Button();
			this.deleteBookButton = new System.Windows.Forms.Button();
			this.updateBookButton = new System.Windows.Forms.Button();
			this.fetchBookButton = new System.Windows.Forms.Button();
			this.bookIdTextBox = new System.Windows.Forms.TextBox();
			this.createBookButton = new System.Windows.Forms.Button();
			this.isbnTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.titleTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.addToAuthorButton = new System.Windows.Forms.Button();
			this.removeAuthorButton = new System.Windows.Forms.Button();
			this.listBooksButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "First Name";
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Location = new System.Drawing.Point(16, 72);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.TabIndex = 1;
			this.firstNameTextBox.Text = "";
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Location = new System.Drawing.Point(16, 120);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.TabIndex = 3;
			this.lastNameTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Last Name";
			// 
			// createAuthorButton
			// 
			this.createAuthorButton.Location = new System.Drawing.Point(152, 24);
			this.createAuthorButton.Name = "createAuthorButton";
			this.createAuthorButton.Size = new System.Drawing.Size(104, 23);
			this.createAuthorButton.TabIndex = 4;
			this.createAuthorButton.Text = "Create Author";
			this.createAuthorButton.Click += new System.EventHandler(this.createAuthorButton_Click);
			// 
			// idTextBox
			// 
			this.idTextBox.Location = new System.Drawing.Point(16, 24);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.TabIndex = 5;
			this.idTextBox.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.TabIndex = 6;
			this.label3.Text = "Id";
			// 
			// fetchAuthorButton
			// 
			this.fetchAuthorButton.Location = new System.Drawing.Point(152, 56);
			this.fetchAuthorButton.Name = "fetchAuthorButton";
			this.fetchAuthorButton.Size = new System.Drawing.Size(104, 23);
			this.fetchAuthorButton.TabIndex = 7;
			this.fetchAuthorButton.Text = "Fetch Author";
			this.fetchAuthorButton.Click += new System.EventHandler(this.fetchAuthorButton_Click);
			// 
			// updateAuthorButton
			// 
			this.updateAuthorButton.Location = new System.Drawing.Point(152, 88);
			this.updateAuthorButton.Name = "updateAuthorButton";
			this.updateAuthorButton.Size = new System.Drawing.Size(104, 23);
			this.updateAuthorButton.TabIndex = 8;
			this.updateAuthorButton.Text = "Update Author";
			this.updateAuthorButton.Click += new System.EventHandler(this.updateAuthorButton_Click);
			// 
			// deleteAuthorButton
			// 
			this.deleteAuthorButton.Location = new System.Drawing.Point(152, 120);
			this.deleteAuthorButton.Name = "deleteAuthorButton";
			this.deleteAuthorButton.Size = new System.Drawing.Size(104, 23);
			this.deleteAuthorButton.TabIndex = 9;
			this.deleteAuthorButton.Text = "Delete Author";
			this.deleteAuthorButton.Click += new System.EventHandler(this.deleteAuthorButton_Click);
			// 
			// listAuthorButton
			// 
			this.listAuthorButton.Location = new System.Drawing.Point(16, 304);
			this.listAuthorButton.Name = "listAuthorButton";
			this.listAuthorButton.Size = new System.Drawing.Size(104, 23);
			this.listAuthorButton.TabIndex = 10;
			this.listAuthorButton.Text = "List Authors";
			this.listAuthorButton.Click += new System.EventHandler(this.listAuthorButton_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 336);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(504, 128);
			this.dataGrid1.TabIndex = 11;
			// 
			// firstNameFilterTextBox
			// 
			this.firstNameFilterTextBox.Location = new System.Drawing.Point(416, 256);
			this.firstNameFilterTextBox.Name = "firstNameFilterTextBox";
			this.firstNameFilterTextBox.TabIndex = 12;
			this.firstNameFilterTextBox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(416, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 24);
			this.label4.TabIndex = 13;
			this.label4.Text = "First Name:";
			// 
			// lastNameFilterTextBox
			// 
			this.lastNameFilterTextBox.Location = new System.Drawing.Point(416, 304);
			this.lastNameFilterTextBox.Name = "lastNameFilterTextBox";
			this.lastNameFilterTextBox.TabIndex = 14;
			this.lastNameFilterTextBox.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(416, 288);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 24);
			this.label5.TabIndex = 15;
			this.label5.Text = "Last Name:";
			// 
			// filterButton
			// 
			this.filterButton.Location = new System.Drawing.Point(416, 208);
			this.filterButton.Name = "filterButton";
			this.filterButton.Size = new System.Drawing.Size(104, 23);
			this.filterButton.TabIndex = 16;
			this.filterButton.Text = "Filter Authors";
			this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
			// 
			// deleteBookButton
			// 
			this.deleteBookButton.Location = new System.Drawing.Point(416, 120);
			this.deleteBookButton.Name = "deleteBookButton";
			this.deleteBookButton.Size = new System.Drawing.Size(104, 23);
			this.deleteBookButton.TabIndex = 26;
			this.deleteBookButton.Text = "Delete Book";
			this.deleteBookButton.Click += new System.EventHandler(this.deleteBookButton_Click);
			// 
			// updateBookButton
			// 
			this.updateBookButton.Location = new System.Drawing.Point(416, 88);
			this.updateBookButton.Name = "updateBookButton";
			this.updateBookButton.Size = new System.Drawing.Size(104, 23);
			this.updateBookButton.TabIndex = 25;
			this.updateBookButton.Text = "Update Book";
			this.updateBookButton.Click += new System.EventHandler(this.updateBookButton_Click);
			// 
			// fetchBookButton
			// 
			this.fetchBookButton.Location = new System.Drawing.Point(416, 56);
			this.fetchBookButton.Name = "fetchBookButton";
			this.fetchBookButton.Size = new System.Drawing.Size(104, 23);
			this.fetchBookButton.TabIndex = 24;
			this.fetchBookButton.Text = "Fetch Book";
			this.fetchBookButton.Click += new System.EventHandler(this.fetchBookButton_Click);
			// 
			// bookIdTextBox
			// 
			this.bookIdTextBox.Location = new System.Drawing.Point(280, 24);
			this.bookIdTextBox.Name = "bookIdTextBox";
			this.bookIdTextBox.TabIndex = 22;
			this.bookIdTextBox.Text = "";
			// 
			// createBookButton
			// 
			this.createBookButton.Location = new System.Drawing.Point(416, 24);
			this.createBookButton.Name = "createBookButton";
			this.createBookButton.Size = new System.Drawing.Size(104, 23);
			this.createBookButton.TabIndex = 21;
			this.createBookButton.Text = "Create Book";
			this.createBookButton.Click += new System.EventHandler(this.createBookButton_Click);
			// 
			// isbnTextBox
			// 
			this.isbnTextBox.Location = new System.Drawing.Point(280, 120);
			this.isbnTextBox.Name = "isbnTextBox";
			this.isbnTextBox.TabIndex = 20;
			this.isbnTextBox.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(280, 104);
			this.label6.Name = "label6";
			this.label6.TabIndex = 19;
			this.label6.Text = "Isbn";
			// 
			// titleTextBox
			// 
			this.titleTextBox.Location = new System.Drawing.Point(280, 72);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.TabIndex = 18;
			this.titleTextBox.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(280, 56);
			this.label7.Name = "label7";
			this.label7.TabIndex = 17;
			this.label7.Text = "Title";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(280, 8);
			this.label8.Name = "label8";
			this.label8.TabIndex = 23;
			this.label8.Text = "Id";
			// 
			// addToAuthorButton
			// 
			this.addToAuthorButton.Location = new System.Drawing.Point(216, 160);
			this.addToAuthorButton.Name = "addToAuthorButton";
			this.addToAuthorButton.Size = new System.Drawing.Size(104, 23);
			this.addToAuthorButton.TabIndex = 27;
			this.addToAuthorButton.Text = "Add Author";
			this.addToAuthorButton.Click += new System.EventHandler(this.addToAuthorButton_Click);
			// 
			// removeAuthorButton
			// 
			this.removeAuthorButton.Location = new System.Drawing.Point(216, 192);
			this.removeAuthorButton.Name = "removeAuthorButton";
			this.removeAuthorButton.Size = new System.Drawing.Size(104, 23);
			this.removeAuthorButton.TabIndex = 28;
			this.removeAuthorButton.Text = "Remove Author";
			this.removeAuthorButton.Click += new System.EventHandler(this.removeAuthorButton_Click);
			// 
			// listBooksButton
			// 
			this.listBooksButton.Location = new System.Drawing.Point(128, 304);
			this.listBooksButton.Name = "listBooksButton";
			this.listBooksButton.Size = new System.Drawing.Size(104, 23);
			this.listBooksButton.TabIndex = 29;
			this.listBooksButton.Text = "List Books";
			this.listBooksButton.Click += new System.EventHandler(this.listBooksButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 473);
			this.Controls.Add(this.listBooksButton);
			this.Controls.Add(this.removeAuthorButton);
			this.Controls.Add(this.addToAuthorButton);
			this.Controls.Add(this.deleteBookButton);
			this.Controls.Add(this.updateBookButton);
			this.Controls.Add(this.fetchBookButton);
			this.Controls.Add(this.bookIdTextBox);
			this.Controls.Add(this.createBookButton);
			this.Controls.Add(this.isbnTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.titleTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.filterButton);
			this.Controls.Add(this.lastNameFilterTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.firstNameFilterTextBox);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.listAuthorButton);
			this.Controls.Add(this.deleteAuthorButton);
			this.Controls.Add(this.updateAuthorButton);
			this.Controls.Add(this.fetchAuthorButton);
			this.Controls.Add(this.idTextBox);
			this.Controls.Add(this.createAuthorButton);
			this.Controls.Add(this.lastNameTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.firstNameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void createAuthorButton_Click(object sender, System.EventArgs e)
		{
			//Call the service layer and 
			//ask it to create a new author object
			Author author = AuthorServices.CreateAuthor(
				context, 
				firstNameTextBox.Text, 
				lastNameTextBox.Text);

			//Display the id of the new author
			idTextBox.Text = author.Id.ToString();
		}

		private void fetchAuthorButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered an author id
			if (idTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the author first!");	
				return;
			}

			//Call the service layer and 
			//ask it to fetch an author by id
			Author author = AuthorServices.FetchAuthorById(
				context, 
				int.Parse(idTextBox.Text));

			//Display the author's name
			firstNameTextBox.Text = author.FirstName; 
			lastNameTextBox.Text = author.LastName;			
		}

		private void updateAuthorButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered an author id
			if (idTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the author first!");	
				return;
			}
		
			//Call the service layer and 
			//ask it to update the author
			AuthorServices.UpdateAuthor(
				context, 
				int.Parse(idTextBox.Text), 
				firstNameTextBox.Text,  
				lastNameTextBox.Text);
		}

		private void deleteAuthorButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered an author id
			if (idTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the author first!");	
				return;
			}

			//Call the service layer and 
			//ask it to delete the author
			AuthorServices.DeleteAuthor(
				context, 
				int.Parse(idTextBox.Text));
		}

		private void createBookButton_Click(object sender, System.EventArgs e)
		{
			//Call the service layer and 
			//ask it to create a new book object
			Book book = BookServices.CreateBook(
				context, 
				titleTextBox.Text, 
				isbnTextBox.Text);

			//Display the id of the new author
			bookIdTextBox.Text = book.Id.ToString();		
		}

		private void fetchBookButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered a book id
			if (bookIdTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the book first!");	
				return;
			}

			//Call the service layer and 
			//ask it to fetch a book by id
			Book book = BookServices.FetchBookById(
				context, 
				int.Parse(bookIdTextBox.Text));

			//Display the title and isbn
			titleTextBox.Text = book.Title; 
			isbnTextBox.Text = book.Isbn;					
		}

		private void updateBookButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered a book id
			if (bookIdTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the book first!");	
				return;
			}

			//Call the service layer and 
			//ask it to update the book
			BookServices.UpdateBook(
				context, 
				int.Parse(bookIdTextBox.Text), 
				titleTextBox.Text,  
				isbnTextBox.Text);		
		}

		private void deleteBookButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered a book id
			if (bookIdTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the book first!");	
				return;
			}

			//Call the service layer and 
			//ask it to delete the book
			BookServices.DeleteBook(
				context, 
				int.Parse(bookIdTextBox.Text));		
		}

		private void addToAuthorButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered an author id
			if (idTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the author first!");	
				return;
			}

			//Make sure the user has entered a book id
			if (bookIdTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the book first!");	
				return;
			}

			//Call the service layer and 
			//ask it to add the author to the book
			AuthorServices.AddAuthorToBook(
				context, 
				int.Parse(bookIdTextBox.Text), 
				int.Parse(idTextBox.Text));				
		}

		private void removeAuthorButton_Click(object sender, System.EventArgs e)
		{
			//Make sure the user has entered an author id
			if (idTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the author first!");	
				return;
			}

			//Make sure the user has entered a book id
			if (bookIdTextBox.Text == "")
			{
				MessageBox.Show("Please enter the id of the book first!");	
				return;
			}

			//Call the service layer and 
			//ask it to remove the author from the book
			AuthorServices.RemoveAuthorFromBook(
				context, 
				int.Parse(bookIdTextBox.Text), 
				int.Parse(idTextBox.Text));						
		}

		private void listAuthorButton_Click(object sender, System.EventArgs e)
		{
			//clear the data grid
			dataGrid1.DataSource = null;

			//Call the service layer and 
			//ask it to fetch all authors
			IList authors = AuthorServices.FetchAllAuthors(context);

			//bind the result to the data grid
			dataGrid1.DataSource = authors;
		}

		private void listBooksButton_Click(object sender, System.EventArgs e)
		{
			//clear the data grid
			dataGrid1.DataSource = null;

			//Call the service layer and 
			//ask it to fetch all books
			IList books = BookServices.FetchAllBooks(context);

			//bind the result to the data grid
			dataGrid1.DataSource = books;		
		}


		private void filterButton_Click(object sender, System.EventArgs e)
		{
			//clear the data grid
			dataGrid1.DataSource = null;

			//Call the service layer and 
			//ask it to fetch all authors
			//matching the filter
			IList authors = AuthorServices.FilterAuthors(
				context,
				firstNameFilterTextBox.Text, 
				lastNameFilterTextBox.Text);

			//bind the result to the data grid
			dataGrid1.DataSource = authors;		
		}
	}
}
