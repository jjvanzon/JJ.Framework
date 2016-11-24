using System.Windows.Forms;
using Puzzle.NPersist.Framework;

namespace Puzzle.NPersist.Tools.DomainExplorer.Merging
{
	/// <summary>
	/// Summary description for MergeTextValues.
	/// </summary>
	public class MergeTextValues : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton useSourceRadioButton;
		private System.Windows.Forms.RadioButton useLocalRadioButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel4;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper cachedTextBox;
		private Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper freshTextBox;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label objectLabel;
		private System.Windows.Forms.Label propertyLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MergeTextValues()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.freshTextBox.ReadOnly = true;
		}

		public MergeTextValues(IContext context, object obj, string propertyName, object cached, object fresh, object current) : this()
		{
			this.context = context;
			this.obj = obj;
			this.propertyName = propertyName;
			this.cached = cached;
			this.fresh = fresh;
			this.current = current;
			if (cached == null)
				cached = "<null>";
			if (current == null)
				current = "<null>";
			cachedTextBox.Text = current.ToString() ;
			freshTextBox.Text = fresh.ToString() ;
			objectLabel.Text = context.ObjectManager.GetObjectKeyOrIdentity(obj);
			propertyLabel.Text = propertyName;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MergeTextValues));
			this.useSourceRadioButton = new System.Windows.Forms.RadioButton();
			this.useLocalRadioButton = new System.Windows.Forms.RadioButton();
			this.okButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.propertyLabel = new System.Windows.Forms.Label();
			this.objectLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.freshTextBox = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cachedTextBox = new Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper.SyntaxBoxWrapper();
			this.panel5 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// useSourceRadioButton
			// 
			this.useSourceRadioButton.Location = new System.Drawing.Point(56, 0);
			this.useSourceRadioButton.Name = "useSourceRadioButton";
			this.useSourceRadioButton.Size = new System.Drawing.Size(112, 24);
			this.useSourceRadioButton.TabIndex = 15;
			this.useSourceRadioButton.Text = "Use source value";
			// 
			// useLocalRadioButton
			// 
			this.useLocalRadioButton.Location = new System.Drawing.Point(48, 0);
			this.useLocalRadioButton.Name = "useLocalRadioButton";
			this.useLocalRadioButton.Size = new System.Drawing.Size(128, 24);
			this.useLocalRadioButton.TabIndex = 14;
			this.useLocalRadioButton.Text = "Use local value";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(376, 16);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 13;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(277, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "Source:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 24);
			this.label1.TabIndex = 10;
			this.label1.Text = "Local: ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(464, 16);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 16;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.propertyLabel);
			this.panel1.Controls.Add(this.objectLabel);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(552, 48);
			this.panel1.TabIndex = 17;
			this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
			// 
			// propertyLabel
			// 
			this.propertyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyLabel.Location = new System.Drawing.Point(80, 24);
			this.propertyLabel.Name = "propertyLabel";
			this.propertyLabel.Size = new System.Drawing.Size(472, 23);
			this.propertyLabel.TabIndex = 3;
			this.propertyLabel.Text = "property";
			// 
			// objectLabel
			// 
			this.objectLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.objectLabel.Location = new System.Drawing.Point(80, 8);
			this.objectLabel.Name = "objectLabel";
			this.objectLabel.Size = new System.Drawing.Size(472, 23);
			this.objectLabel.TabIndex = 2;
			this.objectLabel.Text = "object";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "Property:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Object:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(552, 174);
			this.panel2.TabIndex = 18;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.freshTextBox);
			this.panel4.Controls.Add(this.useSourceRadioButton);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(275, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(277, 174);
			this.panel4.TabIndex = 15;
			// 
			// freshTextBox
			// 
			this.freshTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.freshTextBox.Location = new System.Drawing.Point(0, 23);
			this.freshTextBox.Name = "freshTextBox";
			this.freshTextBox.ReadOnly = false;
			this.freshTextBox.SelectedText = "";
			this.freshTextBox.Size = new System.Drawing.Size(277, 151);
			this.freshTextBox.TabIndex = 16;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(272, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 174);
			this.splitter1.TabIndex = 14;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.cachedTextBox);
			this.panel3.Controls.Add(this.useLocalRadioButton);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(272, 174);
			this.panel3.TabIndex = 13;
			// 
			// cachedTextBox
			// 
			this.cachedTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cachedTextBox.Location = new System.Drawing.Point(0, 24);
			this.cachedTextBox.Name = "cachedTextBox";
			this.cachedTextBox.ReadOnly = false;
			this.cachedTextBox.SelectedText = "";
			this.cachedTextBox.Size = new System.Drawing.Size(272, 150);
			this.cachedTextBox.TabIndex = 15;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.groupBox1);
			this.panel5.Controls.Add(this.okButton);
			this.panel5.Controls.Add(this.cancelButton);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(0, 222);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(552, 48);
			this.panel5.TabIndex = 19;
			// 
			// groupBox1
			// 
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(552, 8);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			// 
			// MergeTextValues
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(552, 270);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel5);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MergeTextValues";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Compare Values";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		#region Property  Context
		
		private IContext context;
		
		public IContext Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		
		#endregion

		#region Property  Obj
		
		private object obj;
		
		public object Obj
		{
			get { return this.obj; }
			set { this.obj = value; }
		}
		
		#endregion

		#region Property  PropertyName
		
		private string propertyName;
		
		public string PropertyName
		{
			get { return this.propertyName; }
			set { this.propertyName = value; }
		}
		
		#endregion

		#region Property  Cached
		
		private object cached;
		
		public object Cached
		{
			get { return this.cached; }
			set { this.cached = value; }
		}
		
		#endregion

		#region Property  Fresh
		
		private object fresh;
		
		public object Fresh
		{
			get { return this.fresh; }
			set { this.fresh = value; }
		}
		
		#endregion

		#region Property  Current
		
		private object current;
		
		public object Current
		{
			get { return this.current; }
			set { this.current = value; }
		}
		
		#endregion

		private bool Merge()
		{
			if (useLocalRadioButton.Checked == false && useSourceRadioButton.Checked == false)
			{
				MessageBox.Show("Please select local value or source value first!");
				return false;
			}
			if (useLocalRadioButton.Checked)
			{
				//overwrite original with fresh
				this.context.ObjectManager.SetOriginalPropertyValue(obj, propertyName, fresh);
			}
			else
			{
				//overwrite original and local with fresh
				this.context.ObjectManager.SetOriginalPropertyValue(obj, propertyName, fresh);
				this.context.ObjectManager.SetPropertyValue(obj, propertyName, fresh);				
			}
			return true;
		}


		private void okButton_Click(object sender, System.EventArgs e)
		{
			if (Merge())
			{
				this.Close();
			}
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void panel1_Resize(object sender, System.EventArgs e)
		{
			panel3.Width = panel2.Width / 2;
		}
	}
}
