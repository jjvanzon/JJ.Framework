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
	/// Summary description for EmployeeForm.
	/// </summary>
	public class EmployeeForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmployeeForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.DateTimePicker hireDateDateTimePicker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.GroupBox groupBox1;

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
			this.label1 = new System.Windows.Forms.Label();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.hireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.updateButton = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "First name";
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Location = new System.Drawing.Point(24, 40);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.firstNameTextBox.TabIndex = 1;
			this.firstNameTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Last name";
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Location = new System.Drawing.Point(24, 88);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.lastNameTextBox.TabIndex = 3;
			this.lastNameTextBox.Text = "";
			// 
			// hireDateDateTimePicker
			// 
			this.hireDateDateTimePicker.Location = new System.Drawing.Point(24, 136);
			this.hireDateDateTimePicker.Name = "hireDateDateTimePicker";
			this.hireDateDateTimePicker.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 120);
			this.label3.Name = "label3";
			this.label3.TabIndex = 5;
			this.label3.Text = "Hire date";
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(144, 176);
			this.updateButton.Name = "updateButton";
			this.updateButton.TabIndex = 6;
			this.updateButton.Text = "Update";
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(24, 176);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(144, 224);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.TabIndex = 8;
			this.deleteButton.Text = "Delete";
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(24, 208);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 8);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// EmployeeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 262);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.hireDateDateTimePicker);
			this.Controls.Add(this.lastNameTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.firstNameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Name = "EmployeeForm";
			this.Text = "Employee ";
			this.ResumeLayout(false);

		}
		#endregion

		#region Special Constructors

		public EmployeeForm(string employeeId) : this()
		{
			this.employeeId = employeeId;
			LoadEmployee();
		}

		#endregion

		#region Private Members

		private string EmployeeNotFoundMessage = "The employee with the identity you have selected no longer exists in the database!";
		private string employeeId = "";		
				
		#endregion

		#region Methods

		#region LoadEmployee

		private void LoadEmployee()
		{
			using (IContext context = ContextFactory.GetContext() )
			{
				//ask the context for the employee with the current employee id
				//by using TryGet... we will get a null reference instead of an exception
				//if the employee with this id does not exist (if someone has just
				//deleted it for example)
				Employee employee = (Employee) context.TryGetObjectById(this.employeeId, typeof(Employee));

				//Make sure that the employee with the id was found
				if (employee != null)
				{
					//transfer the values from the employee object properties to the controls
					firstNameTextBox.Text = employee.FirstName;
					lastNameTextBox.Text = employee.LastName;

					//Note that since the HireDate property can contain null
					//values, we should remember to check for this..
					if (context.GetNullValueStatus(employee, "HireDate") == false) 
						hireDateDateTimePicker.Value = employee.HireDate;
					
				}
				else
				{
					ShowEmployeeNotFoundMessage();
				}
			}			
		}

		#endregion

		#region UpdateEmployee

		private void UpdateEmployee()
		{
			if (VerifyControls())
			{
				using (IContext context = ContextFactory.GetContext() )
				{
					//ask the context for the employee with the current employee id
					Employee employee = (Employee) context.GetObjectById(this.employeeId, typeof(Employee));

					//Make sure that the employee with the id was found
					if (employee != null)
					{
						//transfer the values from the controls back to the employee object properties
						employee.FirstName = firstNameTextBox.Text ;
						employee.LastName = lastNameTextBox.Text ;
						employee.HireDate = hireDateDateTimePicker.Value;

						//save all changes to the database -
						//in this case: save the updated employee 
						//(the context will know that the employee object 
						//has been updated and needs to be saved since it
						//uses dirty tracking)
						context.Commit() ;
					
					}
					else
					{
						ShowEmployeeNotFoundMessage();
					}
				}							

				this.Close() ;
			}
		}

		#endregion

		#region DeleteEmployee

		private void DeleteEmployee()
		{
			using (IContext context = ContextFactory.GetContext() )
			{
				//ask the context for the employee with the current employee id
				Employee employee = (Employee) context.GetObjectById(this.employeeId, typeof(Employee));

				//Make sure that the employee with the id was found
				if (employee != null)
				{
					//ask the context to regster the object as deleted
					context.DeleteObject(employee);

					//save all changes to the database -
					//in this case: remove the deleted object
					context.Commit() ;					
				}
				else
				{
					ShowEmployeeNotFoundMessage();
				}
			}			

			//close the form
			this.Close() ;
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

		#region ShowEmployeeNotFoundMessage

		private void ShowEmployeeNotFoundMessage()
		{
			MessageBox.Show(EmployeeNotFoundMessage);
			firstNameTextBox.Enabled = false;
			lastNameTextBox.Enabled = false;
			hireDateDateTimePicker.Enabled = false;
			updateButton.Enabled = false;
			deleteButton.Enabled = false;
		}

		#endregion

		#endregion

		#region Event Handlers

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void updateButton_Click(object sender, System.EventArgs e)
		{
			UpdateEmployee();
		}

		private void deleteButton_Click(object sender, System.EventArgs e)
		{
			DeleteEmployee();		
		}

		#endregion

	}
}
