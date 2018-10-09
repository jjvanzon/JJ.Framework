using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Tools.QueryAnalyzer;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for NewDomainConfigWizard.
	/// </summary>
	public class NewDomainConfigWizard : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button prevButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Panel startWizardPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox webServiceUrlTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.RadioButton wrapDbOnTheFlyRadioButton;
		private System.Windows.Forms.RadioButton useMapFileSourcesRadioButton;
		private System.Windows.Forms.RadioButton useCustomSourceRadioButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel finishWizardPanel;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox domainConfigNameTextBox;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox summaryTextBox;
		private System.Windows.Forms.Panel localMapFilePanel;
		private System.Windows.Forms.Panel mapFileNamePanel;
		private System.Windows.Forms.Panel mapFileLocationPanel;
		private System.Windows.Forms.RadioButton localMapfileRadioButton;
		private System.Windows.Forms.RadioButton webServiceMapFileRadioButton;
		private System.Windows.Forms.Panel customDataSourcePanel;
		private System.Windows.Forms.Panel selectAssemblyPanel;
		private System.Windows.Forms.Panel databasePanel;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.RadioButton useDatabaseRadioButton;
		private System.Windows.Forms.RadioButton useWebServiceRadioButton;
		private System.Windows.Forms.RadioButton useXmlDocumentRadioButton;
		private System.Windows.Forms.TextBox webServiceDataSourceUrlTextBox;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox xmlDocumentDataSourcePathTextBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.RadioButton generateAssemblyRadioButton;
		private System.Windows.Forms.RadioButton selectAssemblyRadioButton;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox assemblyPathTextBox;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button browseAssemblyButton;
		private System.Windows.Forms.Button browseXmlDocButton;
		private System.Windows.Forms.TextBox connectionStringTextBox;
		private System.Windows.Forms.Button browseMapFileButton;
		private System.Windows.Forms.TextBox mapPathTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.OpenFileDialog openFileDialogMapPath;
		private System.Windows.Forms.OpenFileDialog openFileDialogDllPath;
		private System.Windows.Forms.Button testConnectionButton;
		private System.Windows.Forms.ComboBox providerTypeComboBox;
		private System.Windows.Forms.ComboBox sourceTypeComboBox;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox webServiceDataSourceDomainKeyTextBox;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox webServiceDomainKeyTextBox;
		private System.ComponentModel.IContainer components;

		public NewDomainConfigWizard()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewDomainConfigWizard));
			this.panelBottom = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.prevButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.finishButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panelMain = new System.Windows.Forms.Panel();
			this.databasePanel = new System.Windows.Forms.Panel();
			this.testConnectionButton = new System.Windows.Forms.Button();
			this.providerTypeComboBox = new System.Windows.Forms.ComboBox();
			this.sourceTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.connectionStringTextBox = new System.Windows.Forms.TextBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.selectAssemblyPanel = new System.Windows.Forms.Panel();
			this.browseAssemblyButton = new System.Windows.Forms.Button();
			this.assemblyPathTextBox = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.selectAssemblyRadioButton = new System.Windows.Forms.RadioButton();
			this.generateAssemblyRadioButton = new System.Windows.Forms.RadioButton();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.customDataSourcePanel = new System.Windows.Forms.Panel();
			this.webServiceDataSourceDomainKeyTextBox = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.browseXmlDocButton = new System.Windows.Forms.Button();
			this.xmlDocumentDataSourcePathTextBox = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.webServiceDataSourceUrlTextBox = new System.Windows.Forms.TextBox();
			this.useXmlDocumentRadioButton = new System.Windows.Forms.RadioButton();
			this.useWebServiceRadioButton = new System.Windows.Forms.RadioButton();
			this.useDatabaseRadioButton = new System.Windows.Forms.RadioButton();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.mapFileNamePanel = new System.Windows.Forms.Panel();
			this.domainConfigNameTextBox = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.finishWizardPanel = new System.Windows.Forms.Panel();
			this.summaryTextBox = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.localMapFilePanel = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.useCustomSourceRadioButton = new System.Windows.Forms.RadioButton();
			this.useMapFileSourcesRadioButton = new System.Windows.Forms.RadioButton();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.mapFileLocationPanel = new System.Windows.Forms.Panel();
			this.webServiceDomainKeyTextBox = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.browseMapFileButton = new System.Windows.Forms.Button();
			this.mapPathTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.wrapDbOnTheFlyRadioButton = new System.Windows.Forms.RadioButton();
			this.webServiceUrlTextBox = new System.Windows.Forms.TextBox();
			this.localMapfileRadioButton = new System.Windows.Forms.RadioButton();
			this.webServiceMapFileRadioButton = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.startWizardPanel = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.openFileDialogMapPath = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialogDllPath = new System.Windows.Forms.OpenFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panelBottom.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.databasePanel.SuspendLayout();
			this.panel9.SuspendLayout();
			this.selectAssemblyPanel.SuspendLayout();
			this.panel6.SuspendLayout();
			this.customDataSourcePanel.SuspendLayout();
			this.panel4.SuspendLayout();
			this.mapFileNamePanel.SuspendLayout();
			this.panel7.SuspendLayout();
			this.finishWizardPanel.SuspendLayout();
			this.panel8.SuspendLayout();
			this.localMapFilePanel.SuspendLayout();
			this.panel5.SuspendLayout();
			this.mapFileLocationPanel.SuspendLayout();
			this.panel3.SuspendLayout();
			this.startWizardPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.cancelButton);
			this.panelBottom.Controls.Add(this.prevButton);
			this.panelBottom.Controls.Add(this.nextButton);
			this.panelBottom.Controls.Add(this.finishButton);
			this.panelBottom.Controls.Add(this.groupBox1);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 518);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(752, 48);
			this.panelBottom.TabIndex = 0;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(424, 16);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 24);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// prevButton
			// 
			this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.prevButton.Location = new System.Drawing.Point(504, 16);
			this.prevButton.Name = "prevButton";
			this.prevButton.Size = new System.Drawing.Size(75, 24);
			this.prevButton.TabIndex = 3;
			this.prevButton.Text = "< Prev";
			this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(584, 16);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 24);
			this.nextButton.TabIndex = 2;
			this.nextButton.Text = "Next >";
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.finishButton.Enabled = false;
			this.finishButton.Location = new System.Drawing.Point(664, 16);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 24);
			this.finishButton.TabIndex = 1;
			this.finishButton.Text = "Finish";
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(752, 8);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.databasePanel);
			this.panelMain.Controls.Add(this.selectAssemblyPanel);
			this.panelMain.Controls.Add(this.customDataSourcePanel);
			this.panelMain.Controls.Add(this.mapFileNamePanel);
			this.panelMain.Controls.Add(this.finishWizardPanel);
			this.panelMain.Controls.Add(this.localMapFilePanel);
			this.panelMain.Controls.Add(this.mapFileLocationPanel);
			this.panelMain.Controls.Add(this.startWizardPanel);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(752, 518);
			this.panelMain.TabIndex = 1;
			// 
			// databasePanel
			// 
			this.databasePanel.Controls.Add(this.testConnectionButton);
			this.databasePanel.Controls.Add(this.providerTypeComboBox);
			this.databasePanel.Controls.Add(this.sourceTypeComboBox);
			this.databasePanel.Controls.Add(this.label26);
			this.databasePanel.Controls.Add(this.label27);
			this.databasePanel.Controls.Add(this.connectionStringTextBox);
			this.databasePanel.Controls.Add(this.panel9);
			this.databasePanel.Controls.Add(this.label25);
			this.databasePanel.Location = new System.Drawing.Point(32, 288);
			this.databasePanel.Name = "databasePanel";
			this.databasePanel.Size = new System.Drawing.Size(448, 224);
			this.databasePanel.TabIndex = 7;
			// 
			// testConnectionButton
			// 
			this.testConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.testConnectionButton.Location = new System.Drawing.Point(368, 208);
			this.testConnectionButton.Name = "testConnectionButton";
			this.testConnectionButton.Size = new System.Drawing.Size(40, 20);
			this.testConnectionButton.TabIndex = 11;
			this.testConnectionButton.Text = "Test";
			// 
			// providerTypeComboBox
			// 
			this.providerTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.providerTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.providerTypeComboBox.Items.AddRange(new object[] {
																	  "SqlClient",
																	  "OleDb",
																	  "Odbc"});
			this.providerTypeComboBox.Location = new System.Drawing.Point(32, 160);
			this.providerTypeComboBox.Name = "providerTypeComboBox";
			this.providerTypeComboBox.Size = new System.Drawing.Size(376, 21);
			this.providerTypeComboBox.TabIndex = 10;
			// 
			// sourceTypeComboBox
			// 
			this.sourceTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sourceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sourceTypeComboBox.Items.AddRange(new object[] {
																	"MS Sql Server",
																	"MS Access"});
			this.sourceTypeComboBox.Location = new System.Drawing.Point(32, 112);
			this.sourceTypeComboBox.Name = "sourceTypeComboBox";
			this.sourceTypeComboBox.Size = new System.Drawing.Size(376, 21);
			this.sourceTypeComboBox.TabIndex = 9;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(32, 96);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(224, 23);
			this.label26.TabIndex = 7;
			this.label26.Text = "Database type:";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(32, 144);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(332, 23);
			this.label27.TabIndex = 8;
			this.label27.Text = "Provider type:";
			// 
			// connectionStringTextBox
			// 
			this.connectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.connectionStringTextBox.Location = new System.Drawing.Point(32, 208);
			this.connectionStringTextBox.Name = "connectionStringTextBox";
			this.connectionStringTextBox.Size = new System.Drawing.Size(336, 21);
			this.connectionStringTextBox.TabIndex = 2;
			this.connectionStringTextBox.Text = "";
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.SystemColors.Info;
			this.panel9.Controls.Add(this.label23);
			this.panel9.Controls.Add(this.label24);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(448, 72);
			this.panel9.TabIndex = 1;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(48, 32);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(408, 32);
			this.label23.TabIndex = 3;
			this.label23.Text = "Select the relational database that you would like to use for persistence";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label24.Location = new System.Drawing.Point(24, 8);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(416, 23);
			this.label24.TabIndex = 2;
			this.label24.Text = "Select relational database";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(32, 192);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(208, 23);
			this.label25.TabIndex = 3;
			this.label25.Text = "Connection string:";
			// 
			// selectAssemblyPanel
			// 
			this.selectAssemblyPanel.Controls.Add(this.browseAssemblyButton);
			this.selectAssemblyPanel.Controls.Add(this.assemblyPathTextBox);
			this.selectAssemblyPanel.Controls.Add(this.label22);
			this.selectAssemblyPanel.Controls.Add(this.selectAssemblyRadioButton);
			this.selectAssemblyPanel.Controls.Add(this.generateAssemblyRadioButton);
			this.selectAssemblyPanel.Controls.Add(this.panel6);
			this.selectAssemblyPanel.Location = new System.Drawing.Point(360, 24);
			this.selectAssemblyPanel.Name = "selectAssemblyPanel";
			this.selectAssemblyPanel.Size = new System.Drawing.Size(128, 128);
			this.selectAssemblyPanel.TabIndex = 6;
			// 
			// browseAssemblyButton
			// 
			this.browseAssemblyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseAssemblyButton.Enabled = false;
			this.browseAssemblyButton.Location = new System.Drawing.Point(64, 176);
			this.browseAssemblyButton.Name = "browseAssemblyButton";
			this.browseAssemblyButton.Size = new System.Drawing.Size(24, 21);
			this.browseAssemblyButton.TabIndex = 6;
			this.browseAssemblyButton.Text = "...";
			this.browseAssemblyButton.Click += new System.EventHandler(this.browseAssemblyButton_Click);
			// 
			// assemblyPathTextBox
			// 
			this.assemblyPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.assemblyPathTextBox.Enabled = false;
			this.assemblyPathTextBox.Location = new System.Drawing.Point(48, 176);
			this.assemblyPathTextBox.Name = "assemblyPathTextBox";
			this.assemblyPathTextBox.Size = new System.Drawing.Size(16, 21);
			this.assemblyPathTextBox.TabIndex = 5;
			this.assemblyPathTextBox.Text = "";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(48, 160);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(400, 16);
			this.label22.TabIndex = 4;
			this.label22.Text = "Path to compiled assembly file (dll) containing domain model classes";
			// 
			// selectAssemblyRadioButton
			// 
			this.selectAssemblyRadioButton.Location = new System.Drawing.Point(32, 136);
			this.selectAssemblyRadioButton.Name = "selectAssemblyRadioButton";
			this.selectAssemblyRadioButton.Size = new System.Drawing.Size(304, 24);
			this.selectAssemblyRadioButton.TabIndex = 3;
			this.selectAssemblyRadioButton.Text = "I want to use the following compiled assembly:";
			this.selectAssemblyRadioButton.CheckedChanged += new System.EventHandler(this.selectAssemblyRadioButton_CheckedChanged);
			// 
			// generateAssemblyRadioButton
			// 
			this.generateAssemblyRadioButton.Checked = true;
			this.generateAssemblyRadioButton.Location = new System.Drawing.Point(32, 96);
			this.generateAssemblyRadioButton.Name = "generateAssemblyRadioButton";
			this.generateAssemblyRadioButton.Size = new System.Drawing.Size(384, 32);
			this.generateAssemblyRadioButton.TabIndex = 2;
			this.generateAssemblyRadioButton.TabStop = true;
			this.generateAssemblyRadioButton.Text = "I want to generate my domain model assembly dynamically from the NPersist xml map" +
				"ping file";
			this.generateAssemblyRadioButton.CheckedChanged += new System.EventHandler(this.generateAssemblyRadioButton_CheckedChanged);
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.SystemColors.Info;
			this.panel6.Controls.Add(this.label20);
			this.panel6.Controls.Add(this.label21);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(128, 72);
			this.panel6.TabIndex = 1;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(48, 32);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(408, 32);
			this.label20.TabIndex = 3;
			this.label20.Text = "Select the assembly containing your domain model classes.";
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.Location = new System.Drawing.Point(24, 8);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(416, 23);
			this.label21.TabIndex = 2;
			this.label21.Text = "Select assembly";
			// 
			// customDataSourcePanel
			// 
			this.customDataSourcePanel.Controls.Add(this.webServiceDataSourceDomainKeyTextBox);
			this.customDataSourcePanel.Controls.Add(this.label28);
			this.customDataSourcePanel.Controls.Add(this.browseXmlDocButton);
			this.customDataSourcePanel.Controls.Add(this.xmlDocumentDataSourcePathTextBox);
			this.customDataSourcePanel.Controls.Add(this.label19);
			this.customDataSourcePanel.Controls.Add(this.webServiceDataSourceUrlTextBox);
			this.customDataSourcePanel.Controls.Add(this.useXmlDocumentRadioButton);
			this.customDataSourcePanel.Controls.Add(this.useWebServiceRadioButton);
			this.customDataSourcePanel.Controls.Add(this.useDatabaseRadioButton);
			this.customDataSourcePanel.Controls.Add(this.panel4);
			this.customDataSourcePanel.Controls.Add(this.label18);
			this.customDataSourcePanel.Location = new System.Drawing.Point(392, 184);
			this.customDataSourcePanel.Name = "customDataSourcePanel";
			this.customDataSourcePanel.Size = new System.Drawing.Size(152, 152);
			this.customDataSourcePanel.TabIndex = 5;
			// 
			// webServiceDataSourceDomainKeyTextBox
			// 
			this.webServiceDataSourceDomainKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.webServiceDataSourceDomainKeyTextBox.Enabled = false;
			this.webServiceDataSourceDomainKeyTextBox.Location = new System.Drawing.Point(48, 280);
			this.webServiceDataSourceDomainKeyTextBox.Name = "webServiceDataSourceDomainKeyTextBox";
			this.webServiceDataSourceDomainKeyTextBox.Size = new System.Drawing.Size(64, 21);
			this.webServiceDataSourceDomainKeyTextBox.TabIndex = 11;
			this.webServiceDataSourceDomainKeyTextBox.Text = "";
			this.toolTip1.SetToolTip(this.webServiceDataSourceDomainKeyTextBox, "An NPersist Web Service can serve multiple domains. By supplying a domain key you" +
				" let the Web Service know which domain you want to work with.");
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(48, 264);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(416, 23);
			this.label28.TabIndex = 10;
			this.label28.Text = "Domain key: (leave blank for the default domain of the NPersist Web Service)";
			this.toolTip1.SetToolTip(this.label28, "An NPersist Web Service can serve multiple domains. By supplying a domain key you" +
				" let the Web Service know which domain you want to work with.");
			// 
			// browseXmlDocButton
			// 
			this.browseXmlDocButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseXmlDocButton.Enabled = false;
			this.browseXmlDocButton.Location = new System.Drawing.Point(88, 168);
			this.browseXmlDocButton.Name = "browseXmlDocButton";
			this.browseXmlDocButton.Size = new System.Drawing.Size(24, 21);
			this.browseXmlDocButton.TabIndex = 9;
			this.browseXmlDocButton.Text = "...";
			this.browseXmlDocButton.Click += new System.EventHandler(this.browseXmlDocButton_Click);
			// 
			// xmlDocumentDataSourcePathTextBox
			// 
			this.xmlDocumentDataSourcePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.xmlDocumentDataSourcePathTextBox.Enabled = false;
			this.xmlDocumentDataSourcePathTextBox.Location = new System.Drawing.Point(48, 168);
			this.xmlDocumentDataSourcePathTextBox.Name = "xmlDocumentDataSourcePathTextBox";
			this.xmlDocumentDataSourcePathTextBox.Size = new System.Drawing.Size(40, 21);
			this.xmlDocumentDataSourcePathTextBox.TabIndex = 7;
			this.xmlDocumentDataSourcePathTextBox.Text = "";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(48, 152);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(224, 23);
			this.label19.TabIndex = 8;
			this.label19.Text = "Path to xml document:";
			// 
			// webServiceDataSourceUrlTextBox
			// 
			this.webServiceDataSourceUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.webServiceDataSourceUrlTextBox.Enabled = false;
			this.webServiceDataSourceUrlTextBox.Location = new System.Drawing.Point(48, 240);
			this.webServiceDataSourceUrlTextBox.Name = "webServiceDataSourceUrlTextBox";
			this.webServiceDataSourceUrlTextBox.Size = new System.Drawing.Size(64, 21);
			this.webServiceDataSourceUrlTextBox.TabIndex = 5;
			this.webServiceDataSourceUrlTextBox.Text = "";
			// 
			// useXmlDocumentRadioButton
			// 
			this.useXmlDocumentRadioButton.Location = new System.Drawing.Point(32, 128);
			this.useXmlDocumentRadioButton.Name = "useXmlDocumentRadioButton";
			this.useXmlDocumentRadioButton.Size = new System.Drawing.Size(232, 24);
			this.useXmlDocumentRadioButton.TabIndex = 4;
			this.useXmlDocumentRadioButton.Text = "I want to use an Xml Document";
			this.useXmlDocumentRadioButton.CheckedChanged += new System.EventHandler(this.useXmlDocumentRadioButton_CheckedChanged);
			// 
			// useWebServiceRadioButton
			// 
			this.useWebServiceRadioButton.Location = new System.Drawing.Point(32, 200);
			this.useWebServiceRadioButton.Name = "useWebServiceRadioButton";
			this.useWebServiceRadioButton.Size = new System.Drawing.Size(352, 24);
			this.useWebServiceRadioButton.TabIndex = 3;
			this.useWebServiceRadioButton.Text = "I want to use an NPersist Web Service";
			this.useWebServiceRadioButton.CheckedChanged += new System.EventHandler(this.useWebServiceRadioButton_CheckedChanged);
			// 
			// useDatabaseRadioButton
			// 
			this.useDatabaseRadioButton.Checked = true;
			this.useDatabaseRadioButton.Location = new System.Drawing.Point(32, 96);
			this.useDatabaseRadioButton.Name = "useDatabaseRadioButton";
			this.useDatabaseRadioButton.Size = new System.Drawing.Size(248, 24);
			this.useDatabaseRadioButton.TabIndex = 2;
			this.useDatabaseRadioButton.TabStop = true;
			this.useDatabaseRadioButton.Text = "I want to use a relational database";
			this.useDatabaseRadioButton.CheckedChanged += new System.EventHandler(this.useDatabaseRadioButton_CheckedChanged);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.Info;
			this.panel4.Controls.Add(this.label5);
			this.panel4.Controls.Add(this.label17);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(152, 72);
			this.panel4.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(48, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(352, 32);
			this.label5.TabIndex = 1;
			this.label5.Text = "Select the data source that you want to use for persistence";
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label17.Location = new System.Drawing.Point(24, 8);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(368, 23);
			this.label17.TabIndex = 0;
			this.label17.Text = "Select data source";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(48, 224);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(224, 23);
			this.label18.TabIndex = 6;
			this.label18.Text = "Url to NPersist Web Service:";
			// 
			// mapFileNamePanel
			// 
			this.mapFileNamePanel.Controls.Add(this.domainConfigNameTextBox);
			this.mapFileNamePanel.Controls.Add(this.label13);
			this.mapFileNamePanel.Controls.Add(this.panel7);
			this.mapFileNamePanel.Location = new System.Drawing.Point(568, 232);
			this.mapFileNamePanel.Name = "mapFileNamePanel";
			this.mapFileNamePanel.Size = new System.Drawing.Size(144, 176);
			this.mapFileNamePanel.TabIndex = 4;
			// 
			// domainConfigNameTextBox
			// 
			this.domainConfigNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.domainConfigNameTextBox.Location = new System.Drawing.Point(32, 112);
			this.domainConfigNameTextBox.Name = "domainConfigNameTextBox";
			this.domainConfigNameTextBox.Size = new System.Drawing.Size(72, 21);
			this.domainConfigNameTextBox.TabIndex = 3;
			this.domainConfigNameTextBox.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(32, 96);
			this.label13.Name = "label13";
			this.label13.TabIndex = 2;
			this.label13.Text = "Connection name:";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.SystemColors.Info;
			this.panel7.Controls.Add(this.label11);
			this.panel7.Controls.Add(this.label12);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(144, 72);
			this.panel7.TabIndex = 1;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(48, 32);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(336, 32);
			this.label11.TabIndex = 3;
			this.label11.Text = "Enter a name for your connection that you can use for finding it in your list of " +
				"connections";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(24, 8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(416, 23);
			this.label12.TabIndex = 2;
			this.label12.Text = "Enter a name for your new connection";
			// 
			// finishWizardPanel
			// 
			this.finishWizardPanel.Controls.Add(this.summaryTextBox);
			this.finishWizardPanel.Controls.Add(this.label16);
			this.finishWizardPanel.Controls.Add(this.panel8);
			this.finishWizardPanel.Location = new System.Drawing.Point(560, 24);
			this.finishWizardPanel.Name = "finishWizardPanel";
			this.finishWizardPanel.Size = new System.Drawing.Size(144, 176);
			this.finishWizardPanel.TabIndex = 3;
			// 
			// summaryTextBox
			// 
			this.summaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.summaryTextBox.Location = new System.Drawing.Point(32, 112);
			this.summaryTextBox.Multiline = true;
			this.summaryTextBox.Name = "summaryTextBox";
			this.summaryTextBox.ReadOnly = true;
			this.summaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.summaryTextBox.Size = new System.Drawing.Size(72, 40);
			this.summaryTextBox.TabIndex = 3;
			this.summaryTextBox.Text = "";
			this.summaryTextBox.WordWrap = false;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(32, 96);
			this.label16.Name = "label16";
			this.label16.TabIndex = 2;
			this.label16.Text = "Summary:";
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.SystemColors.Info;
			this.panel8.Controls.Add(this.label14);
			this.panel8.Controls.Add(this.label15);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(144, 72);
			this.panel8.TabIndex = 1;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(48, 32);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(512, 32);
			this.label14.TabIndex = 3;
			this.label14.Text = "The wizard is ready to create your new connection.";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label15.Location = new System.Drawing.Point(24, 8);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(416, 23);
			this.label15.TabIndex = 2;
			this.label15.Text = "Create connection";
			// 
			// localMapFilePanel
			// 
			this.localMapFilePanel.Controls.Add(this.label6);
			this.localMapFilePanel.Controls.Add(this.useCustomSourceRadioButton);
			this.localMapFilePanel.Controls.Add(this.useMapFileSourcesRadioButton);
			this.localMapFilePanel.Controls.Add(this.panel5);
			this.localMapFilePanel.Location = new System.Drawing.Point(24, 136);
			this.localMapFilePanel.Name = "localMapFilePanel";
			this.localMapFilePanel.Size = new System.Drawing.Size(136, 136);
			this.localMapFilePanel.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(408, 40);
			this.label6.TabIndex = 7;
			this.label6.Text = "Does your NPersist xml mapping file include specifications for the data source or" +
				" sources that you want to work against or do you want to specify information for" +
				" such a data source yourself ?";
			// 
			// useCustomSourceRadioButton
			// 
			this.useCustomSourceRadioButton.Location = new System.Drawing.Point(32, 192);
			this.useCustomSourceRadioButton.Name = "useCustomSourceRadioButton";
			this.useCustomSourceRadioButton.Size = new System.Drawing.Size(336, 48);
			this.useCustomSourceRadioButton.TabIndex = 5;
			this.useCustomSourceRadioButton.Text = "I want to specify a data source myself (overriding any data source(s) that may al" +
				"ready be specified in the NPersist xml mapping file)";
			// 
			// useMapFileSourcesRadioButton
			// 
			this.useMapFileSourcesRadioButton.Checked = true;
			this.useMapFileSourcesRadioButton.Location = new System.Drawing.Point(32, 152);
			this.useMapFileSourcesRadioButton.Name = "useMapFileSourcesRadioButton";
			this.useMapFileSourcesRadioButton.Size = new System.Drawing.Size(336, 32);
			this.useMapFileSourcesRadioButton.TabIndex = 4;
			this.useMapFileSourcesRadioButton.TabStop = true;
			this.useMapFileSourcesRadioButton.Text = "My NPersist xml mapping file contains the information about the data source(s) I " +
				"will use for persistence";
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.SystemColors.Info;
			this.panel5.Controls.Add(this.label9);
			this.panel5.Controls.Add(this.label10);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(136, 72);
			this.panel5.TabIndex = 0;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(48, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(408, 32);
			this.label9.TabIndex = 3;
			this.label9.Text = "Select if you want to use the data source(s) specified in the NPersist xml mappin" +
				"g file or if you want to specify your own data source.";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(24, 8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(416, 23);
			this.label10.TabIndex = 2;
			this.label10.Text = "Select data source specification";
			// 
			// mapFileLocationPanel
			// 
			this.mapFileLocationPanel.Controls.Add(this.webServiceDomainKeyTextBox);
			this.mapFileLocationPanel.Controls.Add(this.label29);
			this.mapFileLocationPanel.Controls.Add(this.browseMapFileButton);
			this.mapFileLocationPanel.Controls.Add(this.mapPathTextBox);
			this.mapFileLocationPanel.Controls.Add(this.label4);
			this.mapFileLocationPanel.Controls.Add(this.wrapDbOnTheFlyRadioButton);
			this.mapFileLocationPanel.Controls.Add(this.webServiceUrlTextBox);
			this.mapFileLocationPanel.Controls.Add(this.localMapfileRadioButton);
			this.mapFileLocationPanel.Controls.Add(this.webServiceMapFileRadioButton);
			this.mapFileLocationPanel.Controls.Add(this.panel3);
			this.mapFileLocationPanel.Controls.Add(this.label3);
			this.mapFileLocationPanel.Location = new System.Drawing.Point(168, 136);
			this.mapFileLocationPanel.Name = "mapFileLocationPanel";
			this.mapFileLocationPanel.Size = new System.Drawing.Size(184, 136);
			this.mapFileLocationPanel.TabIndex = 1;
			// 
			// webServiceDomainKeyTextBox
			// 
			this.webServiceDomainKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.webServiceDomainKeyTextBox.Enabled = false;
			this.webServiceDomainKeyTextBox.Location = new System.Drawing.Point(56, 280);
			this.webServiceDomainKeyTextBox.Name = "webServiceDomainKeyTextBox";
			this.webServiceDomainKeyTextBox.Size = new System.Drawing.Size(80, 21);
			this.webServiceDomainKeyTextBox.TabIndex = 13;
			this.webServiceDomainKeyTextBox.Text = "";
			this.toolTip1.SetToolTip(this.webServiceDomainKeyTextBox, "An NPersist Web Service can serve multiple domains. By supplying a domain key you" +
				" let the Web Service know which domain you want to work with.");
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(56, 264);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(416, 23);
			this.label29.TabIndex = 12;
			this.label29.Text = "Domain key: (leave blank for the default domain of the NPersist Web Service)";
			this.toolTip1.SetToolTip(this.label29, "An NPersist Web Service can serve multiple domains. By supplying a domain key you" +
				" let the Web Service know which domain you want to work with.");
			// 
			// browseMapFileButton
			// 
			this.browseMapFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseMapFileButton.Location = new System.Drawing.Point(112, 136);
			this.browseMapFileButton.Name = "browseMapFileButton";
			this.browseMapFileButton.Size = new System.Drawing.Size(24, 21);
			this.browseMapFileButton.TabIndex = 9;
			this.browseMapFileButton.Text = "...";
			this.browseMapFileButton.Click += new System.EventHandler(this.browseMapFileButton_Click);
			// 
			// mapPathTextBox
			// 
			this.mapPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.mapPathTextBox.Location = new System.Drawing.Point(56, 136);
			this.mapPathTextBox.Name = "mapPathTextBox";
			this.mapPathTextBox.Size = new System.Drawing.Size(56, 21);
			this.mapPathTextBox.TabIndex = 7;
			this.mapPathTextBox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(56, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(200, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Path to NPersist xml mapping file:";
			// 
			// wrapDbOnTheFlyRadioButton
			// 
			this.wrapDbOnTheFlyRadioButton.Location = new System.Drawing.Point(32, 168);
			this.wrapDbOnTheFlyRadioButton.Name = "wrapDbOnTheFlyRadioButton";
			this.wrapDbOnTheFlyRadioButton.Size = new System.Drawing.Size(432, 24);
			this.wrapDbOnTheFlyRadioButton.TabIndex = 6;
			this.wrapDbOnTheFlyRadioButton.Text = "I have a relational database that I would like to wrap on the fly";
			this.wrapDbOnTheFlyRadioButton.CheckedChanged += new System.EventHandler(this.wrapDbOnTheFlyRadioButton_CheckedChanged);
			// 
			// webServiceUrlTextBox
			// 
			this.webServiceUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.webServiceUrlTextBox.Enabled = false;
			this.webServiceUrlTextBox.Location = new System.Drawing.Point(56, 240);
			this.webServiceUrlTextBox.Name = "webServiceUrlTextBox";
			this.webServiceUrlTextBox.Size = new System.Drawing.Size(80, 21);
			this.webServiceUrlTextBox.TabIndex = 4;
			this.webServiceUrlTextBox.Text = "";
			// 
			// localMapfileRadioButton
			// 
			this.localMapfileRadioButton.Checked = true;
			this.localMapfileRadioButton.Location = new System.Drawing.Point(32, 96);
			this.localMapfileRadioButton.Name = "localMapfileRadioButton";
			this.localMapfileRadioButton.Size = new System.Drawing.Size(368, 24);
			this.localMapfileRadioButton.TabIndex = 2;
			this.localMapfileRadioButton.TabStop = true;
			this.localMapfileRadioButton.Text = "I have an NPersist xml mapping file on my local machine";
			this.localMapfileRadioButton.CheckedChanged += new System.EventHandler(this.localConnectionRadioButton_CheckedChanged);
			// 
			// webServiceMapFileRadioButton
			// 
			this.webServiceMapFileRadioButton.Location = new System.Drawing.Point(32, 200);
			this.webServiceMapFileRadioButton.Name = "webServiceMapFileRadioButton";
			this.webServiceMapFileRadioButton.Size = new System.Drawing.Size(440, 24);
			this.webServiceMapFileRadioButton.TabIndex = 1;
			this.webServiceMapFileRadioButton.Text = "I have an url to an NPersist Web Service providing the NPersist xml mapping file";
			this.webServiceMapFileRadioButton.CheckedChanged += new System.EventHandler(this.remoteConnectionRadioButton_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Info;
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(184, 72);
			this.panel3.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(48, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(352, 32);
			this.label8.TabIndex = 1;
			this.label8.Text = "Begin by telling the wizard how to find the NPersist xml mapping file containing " +
				"your domain model and mapping information";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(24, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(368, 23);
			this.label7.TabIndex = 0;
			this.label7.Text = "Select NPersist xml mapping file location";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(56, 224);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(192, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Url to NPersist Web Service:";
			// 
			// startWizardPanel
			// 
			this.startWizardPanel.Controls.Add(this.panel2);
			this.startWizardPanel.Controls.Add(this.panel1);
			this.startWizardPanel.Location = new System.Drawing.Point(16, 24);
			this.startWizardPanel.Name = "startWizardPanel";
			this.startWizardPanel.Size = new System.Drawing.Size(320, 96);
			this.startWizardPanel.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Info;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(160, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(160, 96);
			this.panel2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "Welcome to the Domain Explorer Connection Setup Wizard";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(160, 96);
			this.panel1.TabIndex = 0;
			// 
			// NewDomainConfigWizard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(752, 566);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.panelBottom);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NewDomainConfigWizard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Connection Wizard";
			this.panelBottom.ResumeLayout(false);
			this.panelMain.ResumeLayout(false);
			this.databasePanel.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.selectAssemblyPanel.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.customDataSourcePanel.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.mapFileNamePanel.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.finishWizardPanel.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.localMapFilePanel.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.mapFileLocationPanel.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.startWizardPanel.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Setup()
		{
			this.Size = new Size(502, 454);
			HidePanels();

			startWizardPanel.Dock = DockStyle.Fill ;
			finishWizardPanel.Dock = DockStyle.Fill ;
			mapFileLocationPanel.Dock = DockStyle.Fill ;
			localMapFilePanel.Dock = DockStyle.Fill ;
			customDataSourcePanel.Dock = DockStyle.Fill ;
			selectAssemblyPanel.Dock = DockStyle.Fill ;
			databasePanel.Dock = DockStyle.Fill ;
			mapFileNamePanel.Dock = DockStyle.Fill ;

			startWizardPanel.Visible = true;

			sourceTypeComboBox.SelectedIndex = 0;
			providerTypeComboBox.SelectedIndex = 0;
		}


		private void Cancel()
		{
			
		}

		private void GoNext()
		{
			finishButton.Enabled = false;
			if (startWizardPanel.Visible)
			{
				GoMapFileLocationPanel();				
			}
			else if (mapFileLocationPanel.Visible)
			{
				if (webServiceMapFileRadioButton.Checked)
				{
					if (webServiceUrlTextBox.Text.Length < 1)
					{
						MessageBox.Show("Please enter the url to your NPersist Web Service first!");
					}
					else
					{
						GoMapFileNamePanel();						
					}
				}
				else if (localMapfileRadioButton.Checked)
				{
					if (mapPathTextBox.Text.Length < 1)
					{
						MessageBox.Show("Please enter the path to your NPersist xml mapping file first!");
					}
					else
					{
						GoLocalMapFilePanel();
					}
				}
				else if (wrapDbOnTheFlyRadioButton.Checked)
				{
					GoDatabasePanel();
				}
			}
			else if (localMapFilePanel.Visible)
			{
				if (useCustomSourceRadioButton.Checked)
				{
					GoCustomDataSourcePanel();									
				}
				else
				{
					GoSelectAssemblyPanel();					
				}
			}
			else if (customDataSourcePanel.Visible)
			{
				if (useDatabaseRadioButton.Checked)
				{
					GoDatabasePanel();
				}
				else if (useWebServiceRadioButton.Checked) 
				{
					if (webServiceDataSourceUrlTextBox.Text.Length < 1)
					{
						MessageBox.Show("Please enter the url to your NPersist Web Service first!");
					}
					else
					{
						GoSelectAssemblyPanel();					
					}
				}
				else if (useXmlDocumentRadioButton.Checked) 
				{
					if (xmlDocumentDataSourcePathTextBox.Text.Length < 1)
					{
						MessageBox.Show("Please enter the path to your xml document first!");
					}
					else
					{
						GoSelectAssemblyPanel();					
					}
				}
			}			
			else if (databasePanel.Visible)
			{
				if (connectionStringTextBox.Text.Length < 1)
				{
					MessageBox.Show("Please enter the connection string to your database first!");
				}
				else
				{
					if (wrapDbOnTheFlyRadioButton.Checked)
					{
						GoMapFileNamePanel();
					}
					else
					{
						GoSelectAssemblyPanel();
					}
				}
			}			
			else if (selectAssemblyPanel.Visible)
			{
				if (generateAssemblyRadioButton.Checked)
				{
					GoMapFileNamePanel();					
				}
				else
				{
					if (assemblyPathTextBox.Text.Length < 1)
					{
						MessageBox.Show("Please enter the path to your assembly file first!");
					}
					else
					{
						GoMapFileNamePanel();					
					}					
				}
			}			
			else if (mapFileNamePanel.Visible)
			{
				if (domainConfigNameTextBox.Text.Length < 1)
				{
					MessageBox.Show("Please enter a name for your new connection first!");
				}
				else
				{
					string find = domainConfigNameTextBox.Text.ToLower();
					foreach (DomainConfig domainConfig in MainForm.domainConfigList.DomainConfigs)
					{
						if (domainConfig.Name.ToLower() == find)
						{
							if (MessageBox.Show("You already have a connection with this name! Do you want to overwrite that connection)", "Overwrite Existing Connection?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
							{
								return;
							}
							break;
						}
					}
					GoFinishWizardPanel();				
				}					
			}			
		}

		private void GoPrev()
		{
			if (finishWizardPanel.Visible)
			{
				GoMapFileNamePanel();
			}
			else if (mapFileLocationPanel.Visible)
			{
				GoStartWizardPanel();								
			}
			else if (localMapFilePanel.Visible)
			{
				GoMapFileLocationPanel();								
			}
			else if (customDataSourcePanel.Visible)
			{
				GoLocalMapFilePanel();				
			}			
			else if (databasePanel.Visible)
			{
				if (wrapDbOnTheFlyRadioButton.Checked)
				{
					GoMapFileLocationPanel();									
				}
				else
				{
					GoCustomDataSourcePanel();					
				}
			}			
			else if (selectAssemblyPanel.Visible)
			{
				if (useCustomSourceRadioButton.Checked)
				{
					if (useDatabaseRadioButton.Checked)
					{
						GoDatabasePanel();
					}
					else
					{
						GoCustomDataSourcePanel();					
					}
				}
				else
				{
					GoLocalMapFilePanel();					
				}
			}			
			else if (mapFileNamePanel.Visible)
			{
				if (webServiceMapFileRadioButton.Checked)
				{
					GoMapFileLocationPanel();
				}
				else if (localMapfileRadioButton.Checked)
				{
					if (wrapDbOnTheFlyRadioButton.Checked)
					{
						GoDatabasePanel();					
					}
					else
					{
						GoSelectAssemblyPanel();					
					}
				}
				else if (wrapDbOnTheFlyRadioButton.Checked)
				{
					GoDatabasePanel();				
				}
			}			
			
		}

		private void Finish()
		{
			SaveDomainConfig();
		}

		private void HidePanels()
		{
			startWizardPanel.Visible = false ;
			finishWizardPanel.Visible = false;
			mapFileLocationPanel.Visible = false ;
			localMapFilePanel.Visible = false ;
			customDataSourcePanel.Visible = false ;
			selectAssemblyPanel.Visible = false ;
			databasePanel.Visible = false ;
			mapFileNamePanel.Visible = false ;
		}

		private void GoStartWizardPanel()
		{
			HidePanels();
			startWizardPanel.Visible = true;
		}

		private void GoMapFileLocationPanel()
		{
			HidePanels();
			mapFileLocationPanel.Visible = true;
		}

		
		private void GoLocalMapFilePanel()
		{
			HidePanels();
			localMapFilePanel.Visible = true;
		}
		
		private void GoCustomDataSourcePanel()
		{
			HidePanels();
			customDataSourcePanel.Visible = true;
		}
		
		private void GoSelectAssemblyPanel()
		{
			HidePanels();
			selectAssemblyPanel.Visible = true;
		}
		
		private void GoDatabasePanel()
		{
			HidePanels();
			databasePanel.Visible = true;
		}
		
		private void GoMapFileNamePanel()
		{
			HidePanels();
			mapFileNamePanel.Visible = true;
		}

		private void GoFinishWizardPanel()
		{
			HidePanels();
			finishWizardPanel.Visible = true;
			CreateReport();
			finishButton.Enabled = true;
		}

		private void CreateReport()
		{
			string report = "Create new domain model connection: " + domainConfigNameTextBox.Text + Environment.NewLine + Environment.NewLine ;

			if (localMapfileRadioButton.Checked)
			{
				report += "Use local NPersist xml mapping file: " + Environment.NewLine ;
				report += mapPathTextBox.Text + Environment.NewLine + Environment.NewLine ;

				if (useCustomSourceRadioButton.Checked)
				{
					if (useWebServiceRadioButton.Checked)
					{
						report += "Use NPersist Web Service data source: " + Environment.NewLine ;
						report += webServiceDataSourceUrlTextBox.Text + Environment.NewLine + Environment.NewLine ;						
					}
					else if (useXmlDocumentRadioButton.Checked)
					{
						report += "Use xml document data source: " + Environment.NewLine ;
						report += xmlDocumentDataSourcePathTextBox.Text + Environment.NewLine + Environment.NewLine ;												
					}
					else
					{
						report += "Use relational database data source: " + Environment.NewLine ;
						report += "Database type: " + sourceTypeComboBox.Text + Environment.NewLine ;								
						report += "Provider type: " + providerTypeComboBox.Text + Environment.NewLine ;								
						report += "Connection string: " + Environment.NewLine ;
						report += connectionStringTextBox.Text + Environment.NewLine + Environment.NewLine ;								
					}										
				}
				else
				{
					report += "Use data source(s) specified in NPersist xml mapping file. " + Environment.NewLine + Environment.NewLine ;
				}
			}
			else if (webServiceMapFileRadioButton.Checked)
			{
				report += "Get NPersist xml mapping file from NPersist Web Service: " + Environment.NewLine ;
				report += webServiceUrlTextBox.Text + Environment.NewLine + Environment.NewLine ;				
			}
			else if (wrapDbOnTheFlyRadioButton.Checked)
			{
				report += "Create NPersist xml mapping file on the fly from database: " + Environment.NewLine ;
				report += "Database type: " + sourceTypeComboBox.Text + Environment.NewLine ;								
				report += "Provider type: " + providerTypeComboBox.Text + Environment.NewLine ;								
				report += "Connection string: " + Environment.NewLine ;								
				report += connectionStringTextBox.Text + Environment.NewLine + Environment.NewLine ;								
			}

			if (!wrapDbOnTheFlyRadioButton.Checked)
			{
				if (generateAssemblyRadioButton.Checked)
				{
					report += "Generate assembly with domain model classes from NPersist xml mapping file. " + Environment.NewLine ;
				}
				else
				{
					report += "Use local assembly with domain model classes: " + Environment.NewLine ;
					report += assemblyPathTextBox.Text + Environment.NewLine + Environment.NewLine ;					
				}
			}

			summaryTextBox.Text = report;
		}

		private void BrowseForMapPath()
		{
			if (mapPathTextBox.Text != "")
			{
				openFileDialogMapPath.FileName = mapPathTextBox.Text; 				
			}
			openFileDialogMapPath.Filter = "NPersist Files (*.npersist)|*.npersist|All files (*.*)|*.*";
			if (openFileDialogMapPath.ShowDialog() != DialogResult.Cancel)
			{
				mapPathTextBox.Text = openFileDialogMapPath.FileName;
			}
		}

		private void BrowseForAssemblyPath()
		{
			if (assemblyPathTextBox.Text != "")
			{
				openFileDialogDllPath.FileName = assemblyPathTextBox.Text; 				
			}
			openFileDialogDllPath.Filter = "Assembly Files (*.dll)|*.dll|All files (*.*)|*.*";
			if (openFileDialogDllPath.ShowDialog() != DialogResult.Cancel)
			{
				assemblyPathTextBox.Text = openFileDialogDllPath.FileName;
			}			
		}

		private void SaveDomainConfig()
		{
			DomainConfig config = new DomainConfig() ;
			string find = domainConfigNameTextBox.Text.ToLower();
			foreach (DomainConfig domainConfig in MainForm.domainConfigList.DomainConfigs)
			{
				if (domainConfig.Name.ToLower() == find)
				{
					MainForm.domainConfigList.DomainConfigs.Remove(domainConfig);
					break;
				}
			}
			config.Name = domainConfigNameTextBox.Text;

			if (localMapfileRadioButton.Checked)
			{
				config.MapPath = mapPathTextBox.Text ;

				if (useCustomSourceRadioButton.Checked)
				{
					config.UseCustomDataSource = true ;
					if (useWebServiceRadioButton.Checked)
					{
						config.PersistenceType = PersistenceType.ObjectService ;
						config.Url = webServiceDataSourceUrlTextBox.Text ;
						config.DomainKey = webServiceDataSourceDomainKeyTextBox.Text ;
					}
					else if (useXmlDocumentRadioButton.Checked)
					{
						config.PersistenceType = PersistenceType.ObjectDocument ;
						config.XmlPath = xmlDocumentDataSourcePathTextBox.Text ;
					}
					else
					{
						config.PersistenceType = PersistenceType.ObjectRelational ;
						GetSourceAndProviderType(config);
						config.ConnectionString = connectionStringTextBox.Text ;
					}										
				}
			}
			else if (webServiceMapFileRadioButton.Checked)
			{
				config.Url = webServiceUrlTextBox.Text;				
				config.DomainKey = webServiceDomainKeyTextBox.Text;				
			}
			else if (wrapDbOnTheFlyRadioButton.Checked)
			{
				GetSourceAndProviderType(config);
				config.ConnectionString = connectionStringTextBox.Text ;
			}

			if (!wrapDbOnTheFlyRadioButton.Checked)
			{
				if (!generateAssemblyRadioButton.Checked)
				{
					config.AssemblyPath = assemblyPathTextBox.Text ;					
				}
			}

			MainForm.domainConfigList.DomainConfigs.Insert(0, config);
			MainForm.domainConfigList.Save(MainForm.domainConfigListPath);
		}

		private void GetSourceAndProviderType(DomainConfig config)
		{
			if (sourceTypeComboBox.SelectedIndex == 0)
				config.SourceType = SourceType.MSSqlServer ;
			else
				config.SourceType = SourceType.MSAccess ;

			if (providerTypeComboBox.SelectedIndex == 0)
				config.ProviderType = ProviderType.SqlClient ;
			else if (providerTypeComboBox.SelectedIndex == 1)
				config.ProviderType = ProviderType.OleDb ;
			else
				config.ProviderType = ProviderType.Odbc ;

		}


		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			Cancel();
		}

		private void prevButton_Click(object sender, System.EventArgs e)
		{
			GoPrev();		
		}

		private void nextButton_Click(object sender, System.EventArgs e)
		{
			GoNext();
		}

		private void finishButton_Click(object sender, System.EventArgs e)
		{
			Finish();
		}

		private void localConnectionRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			webServiceUrlTextBox.Enabled = webServiceMapFileRadioButton.Checked;			
			webServiceDomainKeyTextBox.Enabled = webServiceMapFileRadioButton.Checked;			
			mapPathTextBox.Enabled = localMapfileRadioButton.Checked;			
			browseMapFileButton.Enabled = localMapfileRadioButton.Checked;
		}

		private void remoteConnectionRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			webServiceUrlTextBox.Enabled = webServiceMapFileRadioButton.Checked;			
			webServiceDomainKeyTextBox.Enabled = webServiceMapFileRadioButton.Checked;			
			mapPathTextBox.Enabled = localMapfileRadioButton.Checked;			
			browseMapFileButton.Enabled = localMapfileRadioButton.Checked;
		}

		private void wrapDbOnTheFlyRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			webServiceUrlTextBox.Enabled = webServiceMapFileRadioButton.Checked;					
			webServiceDomainKeyTextBox.Enabled = webServiceMapFileRadioButton.Checked;			
			mapPathTextBox.Enabled = localMapfileRadioButton.Checked;			
			browseMapFileButton.Enabled = localMapfileRadioButton.Checked;
		}

		private void generateAssemblyRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			assemblyPathTextBox.Enabled = selectAssemblyRadioButton.Checked;
			browseAssemblyButton.Enabled = selectAssemblyRadioButton.Checked;		
		}

		private void selectAssemblyRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			assemblyPathTextBox.Enabled = selectAssemblyRadioButton.Checked;
			browseAssemblyButton.Enabled = selectAssemblyRadioButton.Checked;
		}

		private void useDatabaseRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			webServiceDataSourceUrlTextBox.Enabled = useWebServiceRadioButton.Checked ;
			webServiceDataSourceDomainKeyTextBox.Enabled = useWebServiceRadioButton.Checked ;
			xmlDocumentDataSourcePathTextBox.Enabled = useXmlDocumentRadioButton.Checked ;
			browseXmlDocButton.Enabled = useXmlDocumentRadioButton.Checked ;
		}

		private void useWebServiceRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			webServiceDataSourceUrlTextBox.Enabled = useWebServiceRadioButton.Checked ;
			webServiceDataSourceDomainKeyTextBox.Enabled = useWebServiceRadioButton.Checked ;
			xmlDocumentDataSourcePathTextBox.Enabled = useXmlDocumentRadioButton.Checked ;
			browseXmlDocButton.Enabled = useXmlDocumentRadioButton.Checked ;		
		}

		private void useXmlDocumentRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			webServiceDataSourceUrlTextBox.Enabled = useWebServiceRadioButton.Checked ;
			webServiceDataSourceDomainKeyTextBox.Enabled = useWebServiceRadioButton.Checked ;
			xmlDocumentDataSourcePathTextBox.Enabled = useXmlDocumentRadioButton.Checked ;
			browseXmlDocButton.Enabled = useXmlDocumentRadioButton.Checked ;		
		}

		private void browseMapFileButton_Click(object sender, System.EventArgs e)
		{
			BrowseForMapPath();
		}

		private void browseXmlDocButton_Click(object sender, System.EventArgs e)
		{
//			if (openFileDialog1.ShowDialog() != DialogResult.Cancel )
//			{
//				mapPathTextBox.Text = openFileDialog1.FileName ;
//			}		
		}

		private void browseAssemblyButton_Click(object sender, System.EventArgs e)
		{
			BrowseForAssemblyPath();
		}



	}
}
