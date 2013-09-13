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
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox connectionStringTextBox;
		private System.Windows.Forms.Button buttonOpenEmployeesFrom;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Button ordersButton;
		private System.Windows.Forms.Button productsButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
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
			this.label1 = new System.Windows.Forms.Label();
			this.connectionStringTextBox = new System.Windows.Forms.TextBox();
			this.buttonOpenEmployeesFrom = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.ordersButton = new System.Windows.Forms.Button();
			this.productsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(336, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Connection string to your Northwind database:";
			// 
			// connectionStringTextBox
			// 
			this.connectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.connectionStringTextBox.Location = new System.Drawing.Point(8, 32);
			this.connectionStringTextBox.Name = "connectionStringTextBox";
			this.connectionStringTextBox.Size = new System.Drawing.Size(408, 20);
			this.connectionStringTextBox.TabIndex = 1;
			this.connectionStringTextBox.Text = "SERVER=(local);UID=sa;PWD=;DATABASE=Northwind;";
			this.connectionStringTextBox.TextChanged += new System.EventHandler(this.connectionStringTextBox_TextChanged);
			// 
			// buttonOpenEmployeesFrom
			// 
			this.buttonOpenEmployeesFrom.Location = new System.Drawing.Point(8, 64);
			this.buttonOpenEmployeesFrom.Name = "buttonOpenEmployeesFrom";
			this.buttonOpenEmployeesFrom.TabIndex = 2;
			this.buttonOpenEmployeesFrom.Text = "Employees";
			this.buttonOpenEmployeesFrom.Click += new System.EventHandler(this.buttonOpenEmployeesFrom_Click);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.Location = new System.Drawing.Point(336, 64);
			this.exitButton.Name = "exitButton";
			this.exitButton.TabIndex = 3;
			this.exitButton.Text = "Exit";
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// ordersButton
			// 
			this.ordersButton.Location = new System.Drawing.Point(96, 64);
			this.ordersButton.Name = "ordersButton";
			this.ordersButton.TabIndex = 4;
			this.ordersButton.Text = "Orders";
			this.ordersButton.Click += new System.EventHandler(this.ordersButton_Click);
			// 
			// productsButton
			// 
			this.productsButton.Location = new System.Drawing.Point(184, 64);
			this.productsButton.Name = "productsButton";
			this.productsButton.TabIndex = 5;
			this.productsButton.Text = "Products";
			this.productsButton.Click += new System.EventHandler(this.productsButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 102);
			this.Controls.Add(this.productsButton);
			this.Controls.Add(this.ordersButton);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.buttonOpenEmployeesFrom);
			this.Controls.Add(this.connectionStringTextBox);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "Northwind Sample";
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new MainForm());
		}

		#region Event Handlers

		private void connectionStringTextBox_TextChanged(object sender, System.EventArgs e)
		{
			ContextFactory.ConnectionString = connectionStringTextBox.Text;
		}

		private void buttonOpenEmployeesFrom_Click(object sender, System.EventArgs e)
		{
			EmployeesForm employeesForm = new EmployeesForm();
			employeesForm.ShowDialog(this);
		}

		private void ordersButton_Click(object sender, System.EventArgs e)
		{
			OrdersForm ordersForm = new OrdersForm();
			ordersForm.ShowDialog(this);		
		}

		
		private void productsButton_Click(object sender, System.EventArgs e)
		{
			ProductsForm productsForm = new ProductsForm();
			productsForm.ShowDialog(this);				
		}

		private void exitButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion


	}
}
