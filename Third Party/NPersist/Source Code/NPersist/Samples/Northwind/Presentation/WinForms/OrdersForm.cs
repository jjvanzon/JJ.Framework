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
	/// Summary description for OrdersForm.
	/// </summary>
	public class OrdersForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.ListView ordersListView;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button fetchButton;
		private System.Windows.Forms.DateTimePicker toDateTimePicker;
		private System.Windows.Forms.DateTimePicker fromDateTimePicker;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OrdersForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			fromDateTimePicker.Value = DateTime.Parse("1996-01-01");
			toDateTimePicker.Value = DateTime.Parse("1997-01-01");
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
			this.closeButton = new System.Windows.Forms.Button();
			this.ordersListView = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.fetchButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(552, 304);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 20;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// ordersListView
			// 
			this.ordersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ordersListView.FullRowSelect = true;
			this.ordersListView.Location = new System.Drawing.Point(16, 80);
			this.ordersListView.MultiSelect = false;
			this.ordersListView.Name = "ordersListView";
			this.ordersListView.Size = new System.Drawing.Size(616, 208);
			this.ordersListView.TabIndex = 19;
			this.ordersListView.View = System.Windows.Forms.View.Details;
			this.ordersListView.DoubleClick += new System.EventHandler(this.ordersListView_DoubleClick);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(16, 304);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(432, 23);
			this.label1.TabIndex = 25;
			this.label1.Text = "Hint: By double clicking an order in the list you can open it for inspection";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(384, 23);
			this.label2.TabIndex = 26;
			this.label2.Text = "Fetch all orders that were placed between the following dates:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 32);
			this.label3.Name = "label3";
			this.label3.TabIndex = 27;
			this.label3.Text = "From";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(256, 32);
			this.label4.Name = "label4";
			this.label4.TabIndex = 28;
			this.label4.Text = "To";
			// 
			// fromDateTimePicker
			// 
			this.fromDateTimePicker.Location = new System.Drawing.Point(16, 48);
			this.fromDateTimePicker.Name = "fromDateTimePicker";
			this.fromDateTimePicker.TabIndex = 29;
			// 
			// toDateTimePicker
			// 
			this.toDateTimePicker.Location = new System.Drawing.Point(256, 48);
			this.toDateTimePicker.Name = "toDateTimePicker";
			this.toDateTimePicker.TabIndex = 30;
			// 
			// fetchButton
			// 
			this.fetchButton.Location = new System.Drawing.Point(472, 48);
			this.fetchButton.Name = "fetchButton";
			this.fetchButton.TabIndex = 31;
			this.fetchButton.Text = "Fetch";
			this.fetchButton.Click += new System.EventHandler(this.fetchButton_Click);
			// 
			// OrdersForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 342);
			this.Controls.Add(this.fetchButton);
			this.Controls.Add(this.toDateTimePicker);
			this.Controls.Add(this.fromDateTimePicker);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.ordersListView);
			this.Name = "OrdersForm";
			this.Text = "Orders";
			this.ResumeLayout(false);

		}
		#endregion

		#region Methods

		#region FetchOrders

		//Fetch a list of all the orders in the database placed between
		//the specified dates, ordered by their order dates
		private void FetchOrders()
		{
			//set up the list view columns
			SetupListViewColumns();

			//clearing any old list view items
			ordersListView.Items.Clear() ;

			using (IContext context = ContextFactory.GetContext())
			{
				//For this query we will be using an NPathQuery object
				//for comfortable handling of parameters
				NPathQuery npathQuery = new NPathQuery() ;

				//Set the type that we want to fetch objects of
				npathQuery.PrimaryType = typeof(Order);

				//This is the query string for our query, 
				//formulated in the query langauge NPath 
				string npathQueryString = "Select * From Order ";

				//add the where clause to the query string
				npathQueryString += "Where OrderDate Between ? And ? ";

				//create the parameters
				QueryParameter fromDateParameter = new QueryParameter(DbType.DateTime, fromDateTimePicker.Value);
				QueryParameter toDateParameter = new QueryParameter(DbType.DateTime, toDateTimePicker.Value);

				//add the parameters to our query object
				npathQuery.Parameters.Add(fromDateParameter); 
				npathQuery.Parameters.Add(toDateParameter); 

				//Add order by clause
				npathQueryString += "Order By OrderDate";

				//Add our query string to our query object
				npathQuery.Query = npathQueryString;

				//Ask the context to execute the query and return the matching orders
				IList orders = context.GetObjectsByQuery(npathQuery);

				//Add the resulting orders to the list view
				foreach (Order order in orders)
				{
					AddOrderToListView(order);
				}
			}
		}
		#endregion

		#region AddOrderToListView

		private void AddOrderToListView(Order order)
		{
			ListViewItem listViewItem = new ListViewItem(order.Id.ToString());
			listViewItem.SubItems.Add(order.OrderDate.ToShortDateString());
			listViewItem.SubItems.Add(order.GetTotal().ToString() );
			listViewItem.SubItems.Add(order.Customer.CompanyName);
	
			ordersListView.Items.Add(listViewItem);
		}

		#endregion

		#region SetupListViewColumns

		private void SetupListViewColumns()
		{
			if (ordersListView.Columns.Count < 1)
			{
				ordersListView.Columns.Add("Id", 50, HorizontalAlignment.Left);
				ordersListView.Columns.Add("Order date", 100, HorizontalAlignment.Left);
				ordersListView.Columns.Add("Total", 100, HorizontalAlignment.Right);
				ordersListView.Columns.Add("Customer", 150, HorizontalAlignment.Left);
			}
		
		}

		#endregion

		#region OpenOrder

		private void OpenOrder()
		{
			if (ordersListView.SelectedItems.Count < 1)
				return;

			string orderId = "";
			foreach (ListViewItem selectedItem in ordersListView.SelectedItems)
			{
				orderId = selectedItem.Text ;					
				break;
			}

			if (orderId.Length > 0)
			{
				OrderForm orderForm = new OrderForm(orderId);
				orderForm.ShowDialog(this);
			}
		}

		#endregion

		#endregion

		#region Event Handlers

		private void fetchButton_Click(object sender, System.EventArgs e)
		{
			FetchOrders();		
		}

		private void ordersListView_DoubleClick(object sender, System.EventArgs e)
		{
			OpenOrder();
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion

	}
}
