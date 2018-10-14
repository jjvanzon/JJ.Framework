using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Puzzle.NPersist.Tools.QueryAnalyzer
{
	/// <summary>
	/// Summary description for DomainConfigForm.
	/// </summary>
	public class DomainConfigForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textMapPath;
		private System.Windows.Forms.TextBox textAssemblyPath;
		private System.Windows.Forms.TextBox textConnectionString;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonBrowseMapPath;
		private System.Windows.Forms.Button buttonBrowseAssmeblyPath;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.OpenFileDialog openFileDialogMapPath;
		private System.Windows.Forms.OpenFileDialog openFileDialogDllPath;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ComboBox comboDomainConfigs;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DomainConfigForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DomainConfigForm));
			this.textMapPath = new System.Windows.Forms.TextBox();
			this.textAssemblyPath = new System.Windows.Forms.TextBox();
			this.textConnectionString = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonBrowseMapPath = new System.Windows.Forms.Button();
			this.buttonBrowseAssmeblyPath = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textName = new System.Windows.Forms.TextBox();
			this.openFileDialogMapPath = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialogDllPath = new System.Windows.Forms.OpenFileDialog();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboDomainConfigs = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// textMapPath
			// 
			this.textMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textMapPath.Location = new System.Drawing.Point(13, 146);
			this.textMapPath.Name = "textMapPath";
			this.textMapPath.Size = new System.Drawing.Size(491, 20);
			this.textMapPath.TabIndex = 0;
			this.textMapPath.Text = "";
			// 
			// textAssemblyPath
			// 
			this.textAssemblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textAssemblyPath.Location = new System.Drawing.Point(13, 194);
			this.textAssemblyPath.Name = "textAssemblyPath";
			this.textAssemblyPath.Size = new System.Drawing.Size(491, 20);
			this.textAssemblyPath.TabIndex = 1;
			this.textAssemblyPath.Text = "";
			// 
			// textConnectionString
			// 
			this.textConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textConnectionString.Location = new System.Drawing.Point(13, 243);
			this.textConnectionString.Name = "textConnectionString";
			this.textConnectionString.Size = new System.Drawing.Size(515, 20);
			this.textConnectionString.TabIndex = 2;
			this.textConnectionString.Text = "";
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(13, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Please enter the path to your npersist xml mapping file:";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(13, 180);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(487, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Please enter the path to your compiled assembly containing your domain model clas" +
				"ses:";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(13, 229);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(494, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Please enter the connection string to your database:";
			// 
			// buttonBrowseMapPath
			// 
			this.buttonBrowseMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseMapPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonBrowseMapPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.buttonBrowseMapPath.Location = new System.Drawing.Point(504, 146);
			this.buttonBrowseMapPath.Name = "buttonBrowseMapPath";
			this.buttonBrowseMapPath.Size = new System.Drawing.Size(26, 20);
			this.buttonBrowseMapPath.TabIndex = 6;
			this.buttonBrowseMapPath.Text = "...";
			this.buttonBrowseMapPath.Click += new System.EventHandler(this.buttonBrowseMapPath_Click);
			// 
			// buttonBrowseAssmeblyPath
			// 
			this.buttonBrowseAssmeblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseAssmeblyPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonBrowseAssmeblyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.buttonBrowseAssmeblyPath.Location = new System.Drawing.Point(504, 194);
			this.buttonBrowseAssmeblyPath.Name = "buttonBrowseAssmeblyPath";
			this.buttonBrowseAssmeblyPath.Size = new System.Drawing.Size(26, 20);
			this.buttonBrowseAssmeblyPath.TabIndex = 7;
			this.buttonBrowseAssmeblyPath.Text = "...";
			this.buttonBrowseAssmeblyPath.Click += new System.EventHandler(this.buttonBrowseAssmeblyPath_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(400, 333);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(62, 20);
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(13, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(374, 20);
			this.label4.TabIndex = 9;
			this.label4.Text = "Please enter a name for your domain configuration:";
			// 
			// textName
			// 
			this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textName.Location = new System.Drawing.Point(13, 97);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(515, 20);
			this.textName.TabIndex = 10;
			this.textName.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(487, 20);
			this.label5.TabIndex = 12;
			this.label5.Text = "Domain configurations:";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(464, 333);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(62, 20);
			this.buttonCancel.TabIndex = 13;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// comboDomainConfigs
			// 
			this.comboDomainConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboDomainConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDomainConfigs.Location = new System.Drawing.Point(13, 42);
			this.comboDomainConfigs.Name = "comboDomainConfigs";
			this.comboDomainConfigs.Size = new System.Drawing.Size(515, 21);
			this.comboDomainConfigs.TabIndex = 14;
			this.comboDomainConfigs.SelectedIndexChanged += new System.EventHandler(this.comboDomainConfigs_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Location = new System.Drawing.Point(13, 263);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(494, 28);
			this.label6.TabIndex = 15;
			this.label6.Text = "Note: If your npersist xml mapping file already contains the connection string th" +
				"at you want to use you don\'t have to enter it again and you can leave this contr" +
				"ol blank!";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(13, 305);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(515, 7);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// DomainConfigForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 360);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.comboDomainConfigs);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBrowseAssmeblyPath);
			this.Controls.Add(this.buttonBrowseMapPath);
			this.Controls.Add(this.textConnectionString);
			this.Controls.Add(this.textAssemblyPath);
			this.Controls.Add(this.textMapPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DomainConfigForm";
			this.Text = "Domain Configuration";
			this.ResumeLayout(false);

		}
		#endregion

		private DomainConfig config;

		public void SetConfig(DomainConfig value)
		{
			this.config = value;
			textName.Text = this.config.Name;
			textMapPath.Text = this.config.MapPath;
			textAssemblyPath.Text = this.config.AssemblyPath;
			textConnectionString.Text = this.config.ConnectionString;
			LoadDomainConfigList();
		}

		private void SelectDomainConfig()
		{
			if ( comboDomainConfigs.SelectedItem == null ) { return; }	
			DomainConfig domainConfig = (DomainConfig) comboDomainConfigs.SelectedItem;
			textName.Text = domainConfig.Name;
			textMapPath.Text = domainConfig.MapPath;
			textAssemblyPath.Text = domainConfig.AssemblyPath;
			textConnectionString.Text = domainConfig.ConnectionString;
		}

		private void BrowseForMapPath()
		{
			if (textMapPath.Text != "")
			{
				openFileDialogMapPath.FileName = textMapPath.Text; 				
			}
			openFileDialogMapPath.Filter = "NPersist Files (*.npersist)|*.npersist|All files (*.*)|*.*";
			if (openFileDialogMapPath.ShowDialog() != DialogResult.Cancel)
			{
				textMapPath.Text = openFileDialogMapPath.FileName;
			}
		}

		private void BrowseForAssemblyPath()
		{
			if (textAssemblyPath.Text != "")
			{
				openFileDialogDllPath.FileName = textAssemblyPath.Text; 				
			}
			openFileDialogDllPath.Filter = "Assembly Files (*.dll)|*.dll|All files (*.*)|*.*";
			if (openFileDialogDllPath.ShowDialog() != DialogResult.Cancel)
			{
				textAssemblyPath.Text = openFileDialogDllPath.FileName;
			}			
		}

		private void LoadDomainConfigList()
		{
			foreach (DomainConfig domainConfig in Form1.domainConfigList.DomainConfigs)
			{
				comboDomainConfigs.Items.Add(domainConfig);
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			if (!(VerifyControls())) { return; }
			SaveDomainConfig();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonBrowseMapPath_Click(object sender, System.EventArgs e)
		{
			BrowseForMapPath();
		}

		private void buttonBrowseAssmeblyPath_Click(object sender, System.EventArgs e)
		{
			BrowseForAssemblyPath();		
		}

		private bool VerifyControls()
		{
			if (textName.Text.Length < 1)
			{
				MessageBox.Show("Please enter a name for your domain configuration first!");
				textName.Focus();
				return false;
			}
			if (textMapPath.Text.Length < 1)
			{
				MessageBox.Show("Please enter the path to your npersist xml mapping file first!");
				textMapPath.Focus();
				return false;
			}
			if (textAssemblyPath.Text.Length < 1)
			{
				MessageBox.Show("Please enter the path to the compiled assembly file containing your domain model first!");
				textAssemblyPath.Focus();
				return false;
			}
			return true;
		} 

		private void SaveDomainConfig()
		{
			string find = textName.Text.ToLower();
			foreach (DomainConfig domainConfig in Form1.domainConfigList.DomainConfigs)
			{
				if (domainConfig.Name.ToLower() == find)
				{
					Form1.domainConfigList.DomainConfigs.Remove(domainConfig);
					break;
				}
			}
			this.config.Name = textName.Text;
			this.config.MapPath = textMapPath.Text ;
			this.config.AssemblyPath = textAssemblyPath.Text ;
			this.config.ConnectionString = textConnectionString.Text ;
			Form1.domainConfigList.DomainConfigs.Insert(0, config);
			Form1.domainConfigList.Save(Form1.domainConfigListPath);
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void comboDomainConfigs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectDomainConfig();
		}
	}
}
