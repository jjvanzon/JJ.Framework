using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Tools.QueryAnalyzer;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for DomainConfigForm.
	/// </summary>
	public class DomainConfigForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.OpenFileDialog openFileDialogMapPath;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboDomainConfigs;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.OpenFileDialog openFileDialogDllPath;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonBrowseAssmeblyPath;
		private System.Windows.Forms.Button buttonBrowseMapPath;
		private System.Windows.Forms.TextBox textConnectionString;
		private System.Windows.Forms.TextBox textAssemblyPath;
		private System.Windows.Forms.TextBox textMapPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton objectRelationalRadioButton;
		private System.Windows.Forms.RadioButton objectServiceRadioButton;
		private System.Windows.Forms.TextBox textUrl;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textDocPath;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton objectDocumentRadioButton;
		private System.Windows.Forms.CheckBox useObjectToStringCheckBox;
		private System.Windows.Forms.TextBox domainKeyTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
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
			this.openFileDialogMapPath = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboDomainConfigs = new System.Windows.Forms.ComboBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.openFileDialogDllPath = new System.Windows.Forms.OpenFileDialog();
			this.label5 = new System.Windows.Forms.Label();
			this.textName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonBrowseAssmeblyPath = new System.Windows.Forms.Button();
			this.buttonBrowseMapPath = new System.Windows.Forms.Button();
			this.textConnectionString = new System.Windows.Forms.TextBox();
			this.textAssemblyPath = new System.Windows.Forms.TextBox();
			this.textMapPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.objectRelationalRadioButton = new System.Windows.Forms.RadioButton();
			this.objectServiceRadioButton = new System.Windows.Forms.RadioButton();
			this.textUrl = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textDocPath = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.objectDocumentRadioButton = new System.Windows.Forms.RadioButton();
			this.useObjectToStringCheckBox = new System.Windows.Forms.CheckBox();
			this.domainKeyTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(16, 568);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 7);
			this.groupBox1.TabIndex = 32;
			this.groupBox1.TabStop = false;
			// 
			// comboDomainConfigs
			// 
			this.comboDomainConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboDomainConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDomainConfigs.Location = new System.Drawing.Point(16, 32);
			this.comboDomainConfigs.Name = "comboDomainConfigs";
			this.comboDomainConfigs.Size = new System.Drawing.Size(584, 21);
			this.comboDomainConfigs.TabIndex = 30;
			this.comboDomainConfigs.SelectedIndexChanged += new System.EventHandler(this.comboDomainConfigs_SelectedIndexChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(536, 592);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(62, 20);
			this.buttonCancel.TabIndex = 29;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(487, 20);
			this.label5.TabIndex = 28;
			this.label5.Text = "Domain configurations:";
			// 
			// textName
			// 
			this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textName.Location = new System.Drawing.Point(16, 88);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(584, 20);
			this.textName.TabIndex = 27;
			this.textName.Text = "";
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(16, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(374, 20);
			this.label4.TabIndex = 26;
			this.label4.Text = "Please enter a name for your domain configuration:";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(472, 592);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(62, 20);
			this.buttonOK.TabIndex = 25;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonBrowseAssmeblyPath
			// 
			this.buttonBrowseAssmeblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseAssmeblyPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonBrowseAssmeblyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.buttonBrowseAssmeblyPath.Location = new System.Drawing.Point(576, 184);
			this.buttonBrowseAssmeblyPath.Name = "buttonBrowseAssmeblyPath";
			this.buttonBrowseAssmeblyPath.Size = new System.Drawing.Size(26, 20);
			this.buttonBrowseAssmeblyPath.TabIndex = 24;
			this.buttonBrowseAssmeblyPath.Text = "...";
			this.buttonBrowseAssmeblyPath.Click += new System.EventHandler(this.buttonBrowseAssmeblyPath_Click);
			// 
			// buttonBrowseMapPath
			// 
			this.buttonBrowseMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseMapPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonBrowseMapPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.buttonBrowseMapPath.Location = new System.Drawing.Point(576, 136);
			this.buttonBrowseMapPath.Name = "buttonBrowseMapPath";
			this.buttonBrowseMapPath.Size = new System.Drawing.Size(26, 20);
			this.buttonBrowseMapPath.TabIndex = 23;
			this.buttonBrowseMapPath.Text = "...";
			this.buttonBrowseMapPath.Click += new System.EventHandler(this.buttonBrowseMapPath_Click);
			// 
			// textConnectionString
			// 
			this.textConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textConnectionString.Location = new System.Drawing.Point(32, 312);
			this.textConnectionString.Name = "textConnectionString";
			this.textConnectionString.Size = new System.Drawing.Size(544, 20);
			this.textConnectionString.TabIndex = 19;
			this.textConnectionString.Text = "";
			// 
			// textAssemblyPath
			// 
			this.textAssemblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textAssemblyPath.Location = new System.Drawing.Point(16, 184);
			this.textAssemblyPath.Name = "textAssemblyPath";
			this.textAssemblyPath.Size = new System.Drawing.Size(560, 20);
			this.textAssemblyPath.TabIndex = 18;
			this.textAssemblyPath.Text = "";
			// 
			// textMapPath
			// 
			this.textMapPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textMapPath.Location = new System.Drawing.Point(16, 136);
			this.textMapPath.Name = "textMapPath";
			this.textMapPath.Size = new System.Drawing.Size(560, 20);
			this.textMapPath.TabIndex = 17;
			this.textMapPath.Text = "";
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(16, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(552, 20);
			this.label1.TabIndex = 20;
			this.label1.Text = "Please enter the path to your npersist xml mapping file: (leave blank if you get " +
				"the map from a Web Service)";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(16, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(487, 20);
			this.label2.TabIndex = 21;
			this.label2.Text = "Please enter the path to your compiled assembly containing your domain model clas" +
				"ses:";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(32, 296);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(494, 20);
			this.label3.TabIndex = 22;
			this.label3.Text = "Please enter the connection string to your database:";
			// 
			// objectRelationalRadioButton
			// 
			this.objectRelationalRadioButton.Checked = true;
			this.objectRelationalRadioButton.Location = new System.Drawing.Point(16, 264);
			this.objectRelationalRadioButton.Name = "objectRelationalRadioButton";
			this.objectRelationalRadioButton.Size = new System.Drawing.Size(272, 24);
			this.objectRelationalRadioButton.TabIndex = 33;
			this.objectRelationalRadioButton.TabStop = true;
			this.objectRelationalRadioButton.Text = "Work directly against a relational database";
			// 
			// objectServiceRadioButton
			// 
			this.objectServiceRadioButton.Location = new System.Drawing.Point(16, 352);
			this.objectServiceRadioButton.Name = "objectServiceRadioButton";
			this.objectServiceRadioButton.Size = new System.Drawing.Size(224, 24);
			this.objectServiceRadioButton.TabIndex = 34;
			this.objectServiceRadioButton.Text = "Work against an NPersist Web Service";
			// 
			// textUrl
			// 
			this.textUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textUrl.Location = new System.Drawing.Point(32, 392);
			this.textUrl.Name = "textUrl";
			this.textUrl.Size = new System.Drawing.Size(544, 20);
			this.textUrl.TabIndex = 35;
			this.textUrl.Text = "";
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Location = new System.Drawing.Point(32, 376);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(494, 20);
			this.label7.TabIndex = 36;
			this.label7.Text = "Please enter the url to your NPersist Web Service:";
			// 
			// textDocPath
			// 
			this.textDocPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textDocPath.Location = new System.Drawing.Point(32, 520);
			this.textDocPath.Name = "textDocPath";
			this.textDocPath.Size = new System.Drawing.Size(544, 20);
			this.textDocPath.TabIndex = 38;
			this.textDocPath.Text = "";
			// 
			// label8
			// 
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.Location = new System.Drawing.Point(32, 504);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(494, 20);
			this.label8.TabIndex = 39;
			this.label8.Text = "Please enter the path to the directory containing your XML files:";
			// 
			// objectDocumentRadioButton
			// 
			this.objectDocumentRadioButton.Location = new System.Drawing.Point(16, 480);
			this.objectDocumentRadioButton.Name = "objectDocumentRadioButton";
			this.objectDocumentRadioButton.Size = new System.Drawing.Size(224, 24);
			this.objectDocumentRadioButton.TabIndex = 37;
			this.objectDocumentRadioButton.Text = "Work against Xml Documents on disk";
			// 
			// useObjectToStringCheckBox
			// 
			this.useObjectToStringCheckBox.Location = new System.Drawing.Point(16, 216);
			this.useObjectToStringCheckBox.Name = "useObjectToStringCheckBox";
			this.useObjectToStringCheckBox.Size = new System.Drawing.Size(560, 40);
			this.useObjectToStringCheckBox.TabIndex = 40;
			this.useObjectToStringCheckBox.Text = "Yes, my domain objects all implement ToString() in a manner suitable for display " +
				"in the explorer and I would indeed like to use this representation instead of ju" +
				"st showing identities!";
			// 
			// domainKeyTextBox
			// 
			this.domainKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.domainKeyTextBox.Location = new System.Drawing.Point(32, 440);
			this.domainKeyTextBox.Name = "domainKeyTextBox";
			this.domainKeyTextBox.Size = new System.Drawing.Size(544, 20);
			this.domainKeyTextBox.TabIndex = 41;
			this.domainKeyTextBox.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 424);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(544, 23);
			this.label6.TabIndex = 42;
			this.label6.Text = "Domain key identifying your domain to the Web Service (leave blank if default dom" +
				"ain for Web Service)";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(504, 264);
			this.button1.Name = "button1";
			this.button1.TabIndex = 43;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DomainConfigForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 622);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.domainKeyTextBox);
			this.Controls.Add(this.useObjectToStringCheckBox);
			this.Controls.Add(this.textDocPath);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.objectDocumentRadioButton);
			this.Controls.Add(this.textUrl);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.objectServiceRadioButton);
			this.Controls.Add(this.objectRelationalRadioButton);
			this.Controls.Add(this.buttonCancel);
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
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.comboDomainConfigs);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DomainConfigForm";
			this.Text = "DomainConfigForm";
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
			useObjectToStringCheckBox.Checked = this.config.UseObjectToString;
			textConnectionString.Text = this.config.ConnectionString;
			textUrl.Text = this.config.Url;
			domainKeyTextBox.Text = this.config.DomainKey;
			objectRelationalRadioButton.Checked = (this.config.PersistenceType == PersistenceType.ObjectRelational);
			objectServiceRadioButton.Checked = (this.config.PersistenceType == PersistenceType.ObjectService);
			objectDocumentRadioButton.Checked = (this.config.PersistenceType == PersistenceType.ObjectDocument);
			LoadDomainConfigList();
		}

		private void SelectDomainConfig()
		{
			if ( comboDomainConfigs.SelectedItem == null ) { return; }	
			DomainConfig domainConfig = (DomainConfig) comboDomainConfigs.SelectedItem;
			textName.Text = domainConfig.Name;
			textMapPath.Text = domainConfig.MapPath;
			textAssemblyPath.Text = domainConfig.AssemblyPath;
			useObjectToStringCheckBox.Checked = domainConfig.UseObjectToString;
			textUrl.Text = domainConfig.Url;
			domainKeyTextBox.Text = domainConfig.DomainKey;
			textConnectionString.Text = domainConfig.ConnectionString;
			objectRelationalRadioButton.Checked = (domainConfig.PersistenceType == PersistenceType.ObjectRelational);
			objectServiceRadioButton.Checked = (domainConfig.PersistenceType == PersistenceType.ObjectService);
			objectDocumentRadioButton.Checked = (domainConfig.PersistenceType == PersistenceType.ObjectDocument);
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
			foreach (DomainConfig domainConfig in MainForm.domainConfigList.DomainConfigs)
			{
				comboDomainConfigs.Items.Add(domainConfig);
			}
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
				if (objectServiceRadioButton.Checked == false)
				{
					MessageBox.Show("Please enter the path to your npersist xml mapping file first!");
					textMapPath.Focus();
					return false;					
				}
			}
//			if (textAssemblyPath.Text.Length < 1)
//			{
//				MessageBox.Show("Please enter the path to the compiled assembly file containing your domain model first!");
//				textAssemblyPath.Focus();
//				return false;
//			}
			return true;
		} 

		private void SaveDomainConfig()
		{
			string find = textName.Text.ToLower();
			foreach (DomainConfig domainConfig in MainForm.domainConfigList.DomainConfigs)
			{
				if (domainConfig.Name.ToLower() == find)
				{
					MainForm.domainConfigList.DomainConfigs.Remove(domainConfig);
					break;
				}
			}
			this.config.Name = textName.Text;
			this.config.MapPath = textMapPath.Text ;
			this.config.AssemblyPath = textAssemblyPath.Text ;
			this.config.ConnectionString = textConnectionString.Text ;
			this.config.Url = textUrl.Text ;
			this.config.DomainKey = domainKeyTextBox.Text ;
			this.config.UseObjectToString = useObjectToStringCheckBox.Checked  ;
			if (objectRelationalRadioButton.Checked)
				this.config.PersistenceType = PersistenceType.ObjectRelational  ;
			else if (objectServiceRadioButton.Checked)
				this.config.PersistenceType = PersistenceType.ObjectService ;
			else if (objectDocumentRadioButton.Checked)
				this.config.PersistenceType = PersistenceType.ObjectDocument  ;

			MainForm.domainConfigList.DomainConfigs.Insert(0, config);
			MainForm.domainConfigList.Save(MainForm.domainConfigListPath);
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

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void comboDomainConfigs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectDomainConfig();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			NewDomainConfigWizard frm = new NewDomainConfigWizard() ;
			frm.ShowDialog(); 
		}

	
	}
}
