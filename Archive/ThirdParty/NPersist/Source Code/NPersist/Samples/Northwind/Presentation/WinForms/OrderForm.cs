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
	/// Summary description for OrderForm.
	/// </summary>
	public class OrderForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox orderDateTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox totalTextBox;
		private System.Windows.Forms.TextBox customerTextBox;
		private System.Windows.Forms.ListView orderDetailsListView;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OrderForm()
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
			this.closeButton = new System.Windows.Forms.Button();
			this.orderDetailsListView = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.orderDateTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.totalTextBox = new System.Windows.Forms.TextBox();
			this.customerTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(408, 352);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 22;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// orderDetailsListView
			// 
			this.orderDetailsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.orderDetailsListView.FullRowSelect = true;
			this.orderDetailsListView.Location = new System.Drawing.Point(16, 128);
			this.orderDetailsListView.MultiSelect = false;
			this.orderDetailsListView.Name = "orderDetailsListView";
			this.orderDetailsListView.Size = new System.Drawing.Size(464, 208);
			this.orderDetailsListView.TabIndex = 21;
			this.orderDetailsListView.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 23;
			this.label1.Text = "Order date:";
			// 
			// orderDateTextBox
			// 
			this.orderDateTextBox.Location = new System.Drawing.Point(184, 24);
			this.orderDateTextBox.Name = "orderDateTextBox";
			this.orderDateTextBox.ReadOnly = true;
			this.orderDateTextBox.Size = new System.Drawing.Size(288, 20);
			this.orderDateTextBox.TabIndex = 24;
			this.orderDateTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.TabIndex = 25;
			this.label2.Text = "Total:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.TabIndex = 26;
			this.label3.Text = "Customer:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 112);
			this.label4.Name = "label4";
			this.label4.TabIndex = 27;
			this.label4.Text = "Order details";
			// 
			// totalTextBox
			// 
			this.totalTextBox.Location = new System.Drawing.Point(184, 48);
			this.totalTextBox.Name = "totalTextBox";
			this.totalTextBox.ReadOnly = true;
			this.totalTextBox.Size = new System.Drawing.Size(288, 20);
			this.totalTextBox.TabIndex = 28;
			this.totalTextBox.Text = "";
			// 
			// customerTextBox
			// 
			this.customerTextBox.Location = new System.Drawing.Point(184, 72);
			this.customerTextBox.Name = "customerTextBox";
			this.customerTextBox.ReadOnly = true;
			this.customerTextBox.Size = new System.Drawing.Size(288, 20);
			this.customerTextBox.TabIndex = 29;
			this.customerTextBox.Text = "";
			// 
			// OrderForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 390);
			this.Controls.Add(this.customerTextBox);
			this.Controls.Add(this.totalTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.orderDateTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.orderDetailsListView);
			this.Controls.Add(this.label4);
			this.Name = "OrderForm";
			this.Text = "Order";
			this.ResumeLayout(false);

		}
		#endregion


		#region Special Constructors

		public OrderForm(string orderId) : this()
		{
			this.orderId = orderId;
			LoadOrder();
		}

		#endregion

		#region Private Members

		private string orderId = "";		
				
		#endregion

		#region Methods

		#region LoadOrder

		private void LoadOrder()
		{
			using (IContext context = ContextFactory.GetContext() )
			{
				//ask the context for the order with the current order id
				Order order = (Order) context.GetObjectById(this.orderId, typeof(Order));

				//transfer the values from the employee object properties to the controls
				orderDateTextBox.Text = order.OrderDate.ToLongDateString() ;
				totalTextBox.Text = order.GetTotal().ToString() ;
				customerTextBox.Text = order.Customer.CompanyName ;

				//Set up the list view columns
				SetupListViewColumns();

				//loop through the order details belonging to the order.
				//the order.OrderDetails property will be "lazy loaded",
				//meaning it will be loaded with values from the database
				//the first time the proprty is accessed. This means that
				//at the point of this comment, the order.OrderDetails property 
				//still isn't loaded with any values from the database!
				foreach (OrderDetail orderDetail in order.OrderDetails)
				{
					//Add each order detail to the list view
					ListViewItem listViewItem = new ListViewItem(orderDetail.Product.ProductName);
					listViewItem.SubItems.Add(orderDetail.Quantity.ToString());
					listViewItem.SubItems.Add(orderDetail.UnitPrice.ToString() );
					listViewItem.SubItems.Add(orderDetail.GetTotal().ToString() );
	
					orderDetailsListView.Items.Add(listViewItem);				}
			}			
		}

		#endregion

		#region SetupListViewColumns

		private void SetupListViewColumns()
		{
			if (orderDetailsListView.Columns.Count < 1)
			{
				orderDetailsListView.Columns.Add("Product", 150, HorizontalAlignment.Left);
				orderDetailsListView.Columns.Add("Quantity", 75, HorizontalAlignment.Left);
				orderDetailsListView.Columns.Add("Unit price", 100, HorizontalAlignment.Right);
				orderDetailsListView.Columns.Add("Total", 100, HorizontalAlignment.Right);
			}
		
		}

		#endregion

		#endregion

		#region Event Handlers

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion

	}
}
