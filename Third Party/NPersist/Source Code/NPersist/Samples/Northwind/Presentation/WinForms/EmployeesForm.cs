using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Samples.Northwind.Presentation.WinForms
{
	/// <summary>
	/// Summary description for EmployeesForm.
	/// </summary>
	public class EmployeesForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView employeesListView;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button filterButton;
		private System.Windows.Forms.Button fetchAllbutton;
		private System.Windows.Forms.TextBox filterTextBox;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmployeesForm()
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
			this.employeesListView = new System.Windows.Forms.ListView();
			this.closeButton = new System.Windows.Forms.Button();
			this.filterButton = new System.Windows.Forms.Button();
			this.fetchAllbutton = new System.Windows.Forms.Button();
			this.filterTextBox = new System.Windows.Forms.TextBox();
			this.addButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// employeesListView
			// 
			this.employeesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.employeesListView.FullRowSelect = true;
			this.employeesListView.Location = new System.Drawing.Point(16, 48);
			this.employeesListView.MultiSelect = false;
			this.employeesListView.Name = "employeesListView";
			this.employeesListView.Size = new System.Drawing.Size(624, 264);
			this.employeesListView.TabIndex = 16;
			this.employeesListView.View = System.Windows.Forms.View.Details;
			this.employeesListView.DoubleClick += new System.EventHandler(this.employeesListView_DoubleClick);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(560, 328);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 18;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// filterButton
			// 
			this.filterButton.Location = new System.Drawing.Point(128, 16);
			this.filterButton.Name = "filterButton";
			this.filterButton.TabIndex = 20;
			this.filterButton.Text = "Filter";
			this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
			// 
			// fetchAllbutton
			// 
			this.fetchAllbutton.Location = new System.Drawing.Point(208, 16);
			this.fetchAllbutton.Name = "fetchAllbutton";
			this.fetchAllbutton.TabIndex = 21;
			this.fetchAllbutton.Text = "Fetch all";
			this.fetchAllbutton.Click += new System.EventHandler(this.fetchAllbutton_Click);
			// 
			// filterTextBox
			// 
			this.filterTextBox.Location = new System.Drawing.Point(16, 16);
			this.filterTextBox.Name = "filterTextBox";
			this.filterTextBox.TabIndex = 22;
			this.filterTextBox.Text = "";
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.Location = new System.Drawing.Point(560, 16);
			this.addButton.Name = "addButton";
			this.addButton.TabIndex = 23;
			this.addButton.Text = "Add new";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(16, 328);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(432, 23);
			this.label1.TabIndex = 24;
			this.label1.Text = "Hint: By double clicking an employee in the list you can open it for editing";
			// 
			// EmployeesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 366);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.filterTextBox);
			this.Controls.Add(this.fetchAllbutton);
			this.Controls.Add(this.filterButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.employeesListView);
			this.Name = "EmployeesForm";
			this.Text = "Employees";
			this.ResumeLayout(false);

		}
		#endregion

		#region Methods

		#region FetchAllEmployees

		//Fetch a list of all the employees in the database ordered by 
		//first name and last name and add them to the list view
		private void FetchAllEmployees()
		{
			//set up the list view columns
			SetupListViewColumns();

			//clearing any old list view items
			employeesListView.Items.Clear() ;

			using (IContext context = ContextFactory.GetContext())
			{
				//This is the query string for our query, 
				//formulated in the query langauge NPath 
				string npathQueryString = "Select * From Employee Order By FirstName, LastName";

				//Ask the context to execute the query and return the matching employees
				IList employees = context.GetObjectsByNPath(npathQueryString, typeof(Employee));

				//Add the resulting employees to the list view
				foreach (Employee employee in employees)
				{
					AddEmployeeToListView(employee);
				}
			}
		}

		#endregion

		#region FilterEmployees

		//Fetch a list of all the employees in the database where the
		//first or last name contains the string in the filter text box,
		//ordered by first name and last name and add them to the list view
		private void FilterEmployees()
		{
			//set up the list view columns
			SetupListViewColumns();

			//clearing any old list view items
			employeesListView.Items.Clear() ;

			using (IContext context = ContextFactory.GetContext())
			{
				//For this query we will be using an NPathQuery object
				//for comfortable handling of parameters
				NPathQuery npathQuery = new NPathQuery() ;

				//Set the type that we want to fetch objects of
				npathQuery.PrimaryType = typeof(Employee);

				//This is the query string for our query, 
				//formulated in the query langauge NPath 
				string npathQueryString = "Select * From Employee ";

				string filter = filterTextBox.Text ;

				//Add where clause (unless filter text box is empty)
				if (filter.Length > 0)
				{
					//add wildcards to the filter
					filter = "%" + filter + "%";

					//add the where clause to the query string
					npathQueryString += "Where FirstName LIKE ? or LastName LIKE ?";

					//create the parameters
					QueryParameter firstNameParameter = new QueryParameter(DbType.String, filter);
					QueryParameter lastNameParameter = new QueryParameter(DbType.String, filter);

					//add the parameters to our query object
					npathQuery.Parameters.Add(firstNameParameter); 
					npathQuery.Parameters.Add(lastNameParameter); 
				}

				//Add order by clause
				npathQueryString += "Order By FirstName, LastName";

				//Add our query string to our query object
				npathQuery.Query = npathQueryString;

				//Ask the context to execute the query and return the matching employees
				IList employees = context.GetObjectsByQuery(npathQuery);

				//Add the resulting employees to the list view
				foreach (Employee employee in employees)
				{
					AddEmployeeToListView(employee);
				}
			}
		}

		#endregion

		#region AddEmployeeToListView

		private void AddEmployeeToListView(Employee employee)
		{
			ListViewItem listViewItem = new ListViewItem(employee.Id.ToString());
			listViewItem.SubItems.Add(employee.FirstName);
			listViewItem.SubItems.Add(employee.LastName);
			listViewItem.SubItems.Add(employee.HireDate.ToString());
	
			employeesListView.Items.Add(listViewItem);
		}

		#endregion

		#region SetupListViewColumns

		private void SetupListViewColumns()
		{
			if (employeesListView.Columns.Count < 1)
			{
				employeesListView.Columns.Add("Id", 50, HorizontalAlignment.Left);
				employeesListView.Columns.Add("First name", 150, HorizontalAlignment.Left);
				employeesListView.Columns.Add("Last name", 150, HorizontalAlignment.Left);
				employeesListView.Columns.Add("Hire date", 150, HorizontalAlignment.Left);
			}
		
		}

		#endregion

		#region AddNewEmployee

		private void AddNewEmployee()
		{
			AddEmployeeForm addEmployeeForm = new AddEmployeeForm() ;
			addEmployeeForm.ShowDialog(this);
		}

		#endregion

		#region OpenEmployee

		private void OpenEmployee()
		{
			if (employeesListView.SelectedItems.Count < 1)
				return;

			string employeeId = "";
			foreach (ListViewItem selectedItem in employeesListView.SelectedItems)
			{
				employeeId = selectedItem.Text ;					
				break;
			}

			if (employeeId.Length > 0)
			{
				EmployeeForm employeeForm = new EmployeeForm(employeeId);
				employeeForm.ShowDialog(this);
			}
		}

		#endregion

		#endregion

		#region Event Handlers

		private void fetchAllbutton_Click(object sender, System.EventArgs e)
		{
			FetchAllEmployees();		
		}

		private void filterButton_Click(object sender, System.EventArgs e)
		{
			FilterEmployees();				
		}

		private void addButton_Click(object sender, System.EventArgs e)
		{
			AddNewEmployee();
		}

		private void employeesListView_DoubleClick(object sender, System.EventArgs e)
		{
			OpenEmployee();
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	
		#endregion
	
	}
}
