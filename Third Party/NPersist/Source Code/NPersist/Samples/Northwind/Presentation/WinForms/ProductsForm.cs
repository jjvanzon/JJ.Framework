using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Samples.Northwind.Presentation.WinForms
{
	/// <summary>
	/// Summary description for ProductsForm.
	/// </summary>
	public class ProductsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button fetchButton;
		private System.Windows.Forms.DataGrid productsDataGrid;
		private System.Windows.Forms.Button closeButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProductsForm()
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
			this.fetchButton = new System.Windows.Forms.Button();
			this.productsDataGrid = new System.Windows.Forms.DataGrid();
			this.closeButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.productsDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// fetchButton
			// 
			this.fetchButton.Location = new System.Drawing.Point(8, 16);
			this.fetchButton.Name = "fetchButton";
			this.fetchButton.TabIndex = 0;
			this.fetchButton.Text = "Fetch";
			this.fetchButton.Click += new System.EventHandler(this.fetchButton_Click);
			// 
			// productsDataGrid
			// 
			this.productsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.productsDataGrid.DataMember = "";
			this.productsDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.productsDataGrid.Location = new System.Drawing.Point(8, 48);
			this.productsDataGrid.Name = "productsDataGrid";
			this.productsDataGrid.Size = new System.Drawing.Size(624, 240);
			this.productsDataGrid.TabIndex = 1;
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(552, 304);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// ProductsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 342);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.productsDataGrid);
			this.Controls.Add(this.fetchButton);
			this.Name = "ProductsForm";
			this.Text = "Products";
			((System.ComponentModel.ISupportInitialize)(this.productsDataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void fetchButton_Click(object sender, System.EventArgs e)
		{
			using (IContext context = ContextFactory.GetContext())
			{
				string npath = "Select *, Category.CategoryName As CategoryName From Product";
				DataTable dataTable = context.GetDataTable(npath, typeof(Product));
				productsDataGrid.DataSource = dataTable;
			}
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close() ;
		}
	}
}
