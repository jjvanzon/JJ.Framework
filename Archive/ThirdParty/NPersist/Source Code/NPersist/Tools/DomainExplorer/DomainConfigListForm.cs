using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Puzzle.NPersist.Tools.QueryAnalyzer;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for DomainConfigListForm.
	/// </summary>
	public class DomainConfigListForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button newConnectionButton;
		private System.Windows.Forms.Button openConnectionButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox connectionListPathTextBox;
		private System.Windows.Forms.Button browseConnectionListPathButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView connectionListView;
		private System.Windows.Forms.Button loadConnectionListButton;
		private System.Windows.Forms.Button delecteConnectionButton;
		private System.ComponentModel.IContainer components;

		public DomainConfigListForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Setup();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DomainConfigListForm));
			this.connectionListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.newConnectionButton = new System.Windows.Forms.Button();
			this.openConnectionButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.connectionListPathTextBox = new System.Windows.Forms.TextBox();
			this.browseConnectionListPathButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.loadConnectionListButton = new System.Windows.Forms.Button();
			this.delecteConnectionButton = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// connectionListView
			// 
			this.connectionListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.connectionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.columnHeader1});
			this.connectionListView.Location = new System.Drawing.Point(192, 168);
			this.connectionListView.Name = "connectionListView";
			this.connectionListView.Size = new System.Drawing.Size(304, 208);
			this.connectionListView.SmallImageList = this.imageList1;
			this.connectionListView.TabIndex = 0;
			this.connectionListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 250;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(192, 152);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Connections:";
			// 
			// newConnectionButton
			// 
			this.newConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.newConnectionButton.Location = new System.Drawing.Point(520, 168);
			this.newConnectionButton.Name = "newConnectionButton";
			this.newConnectionButton.TabIndex = 2;
			this.newConnectionButton.Text = "New...";
			this.newConnectionButton.Click += new System.EventHandler(this.newConnectionButton_Click);
			// 
			// openConnectionButton
			// 
			this.openConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openConnectionButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.openConnectionButton.Location = new System.Drawing.Point(520, 200);
			this.openConnectionButton.Name = "openConnectionButton";
			this.openConnectionButton.TabIndex = 3;
			this.openConnectionButton.Text = "Open";
			this.openConnectionButton.Click += new System.EventHandler(this.openConnectionButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(520, 352);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(160, 406);
			this.panel1.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Info;
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(160, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(464, 72);
			this.panel2.TabIndex = 6;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(48, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(408, 32);
			this.label9.TabIndex = 5;
			this.label9.Text = "Select an existing connection from the list below or create a new connection.";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(24, 8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(416, 23);
			this.label10.TabIndex = 4;
			this.label10.Text = "Select a domain model connection";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(192, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Connection list file:";
			// 
			// connectionListPathTextBox
			// 
			this.connectionListPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.connectionListPathTextBox.Location = new System.Drawing.Point(192, 104);
			this.connectionListPathTextBox.Name = "connectionListPathTextBox";
			this.connectionListPathTextBox.Size = new System.Drawing.Size(280, 21);
			this.connectionListPathTextBox.TabIndex = 8;
			this.connectionListPathTextBox.Text = "";
			this.connectionListPathTextBox.TextChanged += new System.EventHandler(this.connectionListPathTextBox_TextChanged);
			// 
			// browseConnectionListPathButton
			// 
			this.browseConnectionListPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseConnectionListPathButton.Location = new System.Drawing.Point(472, 104);
			this.browseConnectionListPathButton.Name = "browseConnectionListPathButton";
			this.browseConnectionListPathButton.Size = new System.Drawing.Size(24, 21);
			this.browseConnectionListPathButton.TabIndex = 9;
			this.browseConnectionListPathButton.Text = "...";
			this.browseConnectionListPathButton.Click += new System.EventHandler(this.browseConnectionListPathButton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
			// 
			// loadConnectionListButton
			// 
			this.loadConnectionListButton.Location = new System.Drawing.Point(520, 104);
			this.loadConnectionListButton.Name = "loadConnectionListButton";
			this.loadConnectionListButton.TabIndex = 10;
			this.loadConnectionListButton.Text = "Load";
			this.loadConnectionListButton.Click += new System.EventHandler(this.loadConnectionListButton_Click);
			// 
			// delecteConnectionButton
			// 
			this.delecteConnectionButton.Location = new System.Drawing.Point(520, 232);
			this.delecteConnectionButton.Name = "delecteConnectionButton";
			this.delecteConnectionButton.TabIndex = 11;
			this.delecteConnectionButton.Text = "Delete";
			this.delecteConnectionButton.Click += new System.EventHandler(this.delecteConnectionButton_Click);
			// 
			// DomainConfigListForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(624, 406);
			this.Controls.Add(this.delecteConnectionButton);
			this.Controls.Add(this.loadConnectionListButton);
			this.Controls.Add(this.browseConnectionListPathButton);
			this.Controls.Add(this.connectionListPathTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.openConnectionButton);
			this.Controls.Add(this.newConnectionButton);
			this.Controls.Add(this.connectionListView);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DomainConfigListForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connection Manager";
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Setup()
		{
			connectionListPathTextBox.Text = MainForm.domainConfigListPath;

			ListConnections();
			if (MainForm.domainConfigList.DomainConfigs.Count < 1)
			{
				OpenNewConnectionWizard();
			}
		}

		private void ListConnections()
		{
			connectionListView.Items.Clear() ;
			foreach (DomainConfig config in MainForm.domainConfigList.DomainConfigs  )
			{
				ListViewItem listViewItem = new ListViewItem(config.Name, 0) ;		
				connectionListView.Items.Add(listViewItem);
			}
		}

		public void DeleteDomainConfig()
		{
			DomainConfig config = SelectedDomainConfig;
			if (config != null)
			{
				MainForm.domainConfigList.DomainConfigs.Remove(config);
				MainForm.domainConfigList.Save(MainForm.domainConfigListPath);
				ListConnections();
			}
		}

		public DomainConfig SelectedDomainConfig
		{
			get
			{
				foreach (ListViewItem listViewItem in connectionListView.SelectedItems)
				{
					return MainForm.domainConfigList.GetDomainConfig(listViewItem.Text);
				}
				return null;
			}
		}

		private void OpenNewConnectionWizard()
		{
			NewDomainConfigWizard wizard = new NewDomainConfigWizard() ;
			if (wizard.ShowDialog() != DialogResult.Cancel)
			{
				ListConnections();
				if (connectionListView.Items.Count > 0)
				{
					connectionListView.SelectedItems.Clear() ;
					connectionListView.Items[0].Selected = true;
				}
			} 
		}

		private void newConnectionButton_Click(object sender, System.EventArgs e)
		{
			OpenNewConnectionWizard();
		}

		private void openConnectionButton_Click(object sender, System.EventArgs e)
		{
			this.Close() ;
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close() ;		
		}

		private void browseConnectionListPathButton_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.Cancel )
				connectionListPathTextBox.Text = openFileDialog1.FileName;
		}

		private void delecteConnectionButton_Click(object sender, System.EventArgs e)
		{
			DeleteDomainConfig();
		}

		private void connectionListPathTextBox_TextChanged(object sender, System.EventArgs e)
		{

		}

		private void loadConnectionListButton_Click(object sender, System.EventArgs e)
		{
			if (connectionListPathTextBox.Text.Length > 0)
			{
				if (File.Exists(connectionListPathTextBox.Text))
				{
					MainForm.domainConfigListPath = connectionListPathTextBox.Text;
					MainForm.LoadDomainConfigList() ;
					ListConnections();
				}				
			}		
		}

	}
}
