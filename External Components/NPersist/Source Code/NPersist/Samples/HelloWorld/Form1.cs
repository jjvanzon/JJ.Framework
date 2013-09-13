using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Puzzle.NPersist.Framework;

namespace HelloWorld
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button fetchButton;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button fetchAllButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.createButton = new System.Windows.Forms.Button();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.fetchButton = new System.Windows.Forms.Button();
			this.updateButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.fetchAllButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// createButton
			// 
			this.createButton.Location = new System.Drawing.Point(176, 24);
			this.createButton.Name = "createButton";
			this.createButton.TabIndex = 0;
			this.createButton.Text = "Create";
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(16, 64);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.TabIndex = 1;
			this.nameTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Name:";
			// 
			// idTextBox
			// 
			this.idTextBox.Location = new System.Drawing.Point(16, 24);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.TabIndex = 3;
			this.idTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "Id:";
			// 
			// fetchButton
			// 
			this.fetchButton.Location = new System.Drawing.Point(176, 56);
			this.fetchButton.Name = "fetchButton";
			this.fetchButton.TabIndex = 5;
			this.fetchButton.Text = "Fetch";
			this.fetchButton.Click += new System.EventHandler(this.fetchButton_Click);
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(176, 88);
			this.updateButton.Name = "updateButton";
			this.updateButton.TabIndex = 6;
			this.updateButton.Text = "Update";
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(176, 120);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.TabIndex = 7;
			this.deleteButton.Text = "Delete";
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// fetchAllButton
			// 
			this.fetchAllButton.Location = new System.Drawing.Point(176, 152);
			this.fetchAllButton.Name = "fetchAllButton";
			this.fetchAllButton.TabIndex = 8;
			this.fetchAllButton.Text = "Fetch All";
			this.fetchAllButton.Click += new System.EventHandler(this.fetchAllButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 193);
			this.Controls.Add(this.fetchAllButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.fetchButton);
			this.Controls.Add(this.idTextBox);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Name = "Form1";
			this.Text = "NPersist Hello World";
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

		private IContext GetContext()
		{
			//Create a context object passing the assembly
			//containing the domain model to the constructor
			IContext context = new Context(this.GetType().Assembly);

			//Set the connection string to the database
			context.SetConnectionString("SERVER=(local);UID=sa;PWD=;DATABASE=HelloWorld");

			//return the new context
			return context;
		}

		private void createButton_Click(object sender, System.EventArgs e)
		{
			//Create a context object
			using (IContext context = GetContext())
			{
				//Ask the context to create a new employee
				Employee employee = (Employee) context.CreateObject(typeof(Employee));

				//Set the name of the new employee
				employee.Name = nameTextBox.Text;

				//Save the new employee to the database
				context.Commit();

				//Write the id of the new property to the textbox
				idTextBox.Text = employee.Id.ToString();

				//Notify the user
				MessageBox.Show("A new employee has been created and got the id " + employee.Id.ToString());
			}
		}

		private void fetchButton_Click(object sender, System.EventArgs e)
		{
			//Create a context object
			using (IContext context = GetContext())
			{
				//Ask the context to fetch the object with the id from the textbox
				Employee employee = (Employee) context.GetObjectById(
						int.Parse(idTextBox.Text), 
						typeof(Employee));

				//Write the name to the name textbox
				nameTextBox.Text = employee.Name;
			}
		}

		private void updateButton_Click(object sender, System.EventArgs e)
		{
			//Create a context object
			using (IContext context = GetContext())
			{
				//Ask the context to fetch the object with the id from the textbox
				Employee employee = (Employee) context.GetObjectById(
					int.Parse(idTextBox.Text), 
					typeof(Employee));

				//Update the name from teh textbox
				employee.Name = nameTextBox.Text;

				//Save the changes to the database
				context.Commit();

				//Notify the user
				MessageBox.Show("The employee has been updated.");
			}		
		}

		private void deleteButton_Click(object sender, System.EventArgs e)
		{
			//Create a context object
			using (IContext context = GetContext())
			{
				//Ask the context to fetch the object with the id from the textbox
				Employee employee = (Employee) context.GetObjectById(
					int.Parse(idTextBox.Text), 
					typeof(Employee));

				//Ask the context to delete the employee
				context.DeleteObject(employee);

				//Save the changes to the database
				context.Commit();

				//Notify the user
				MessageBox.Show("The employee has been deleted.");
			}		
		}

		private void fetchAllButton_Click(object sender, System.EventArgs e)
		{
			//Create a context object
			using (IContext context = GetContext())
			{
				//Ask the context to fetch all employees
				foreach (Employee employee in context.GetObjects(typeof(Employee)))
				{
					//Show each employee to the user
					MessageBox.Show("Id: " + employee.Id.ToString() + 
						", Name: " + employee.Name);					
				}
			}		
		}
	}
}
