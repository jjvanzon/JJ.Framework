using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Samples.Northwind.Presentation.WinForms
{
	/// <summary>
	/// Summary description for AddEmployeeForm.
	/// </summary>
	public class AddEmployeeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DateTimePicker hireDateDateTimePicker;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button addButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddEmployeeForm()
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
				if(components != null)
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.hireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(24, 176);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(144, 176);
			this.addButton.Name = "addButton";
			this.addButton.TabIndex = 14;
			this.addButton.Text = "Add";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// hireDateDateTimePicker
			// 
			this.hireDateDateTimePicker.Location = new System.Drawing.Point(24, 136);
			this.hireDateDateTimePicker.Name = "hireDateDateTimePicker";
			this.hireDateDateTimePicker.TabIndex = 12;
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Location = new System.Drawing.Point(24, 88);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.lastNameTextBox.TabIndex = 11;
			this.lastNameTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 24);
			this.label2.TabIndex = 10;
			this.label2.Text = "Last name";
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Location = new System.Drawing.Point(24, 40);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.firstNameTextBox.TabIndex = 9;
			this.firstNameTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 8;
			this.label1.Text = "First name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 120);
			this.label3.Name = "label3";
			this.label3.TabIndex = 13;
			this.label3.Text = "Hire date";
			// 
			// AddEmployeeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 222);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.hireDateDateTimePicker);
			this.Controls.Add(this.lastNameTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.firstNameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Name = "AddEmployeeForm";
			this.Text = "Add new employee";
			this.ResumeLayout(false);

		}
		#endregion

		#region Methods

		#region AddEmployee

		private void AddEmployee()
		{
			if (VerifyControls())
			{
				using (IContext context = ContextFactory.GetContext() )
				{
					//ask the context to create a new employee
					//note that we do not have to supply any Id for our new emplyee,
					//since the Id property maps to an auto increasig property in the 
					//database. If we want to create an object where the id property value
					//is /not/ generated by the database, we have to pass the identity
					//for the new object to the first parameter of the overloaded version
					//of the context.CreateObject() method.
					Employee employee = (Employee) context.CreateObject(typeof(Employee));

					//transfer the values from the controls to the employee object properties
					employee.FirstName = firstNameTextBox.Text ;
					employee.LastName = lastNameTextBox.Text ;
					employee.HireDate = hireDateDateTimePicker.Value;

					//save all changes to the database -
					//in this case: insert the employee into the database
					context.Commit() ;
				}							

				this.Close() ;
			}
		}

		#endregion

		#region VerifyControls

		private bool VerifyControls()
		{
			if (firstNameTextBox.Text.Length < 1)
			{
				MessageBox.Show("Please enter a first name!");
				return false;
			}

			if (lastNameTextBox.Text.Length < 1)
			{
				MessageBox.Show("Please enter a last name!");
				return false;
			}

			return true;
		}

		#endregion

		#endregion

		#region Event Handlers

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void addButton_Click(object sender, System.EventArgs e)
		{
			AddEmployee();
		}

		#endregion

	}
}
