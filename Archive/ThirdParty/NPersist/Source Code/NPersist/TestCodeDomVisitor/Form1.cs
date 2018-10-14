using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using Microsoft.CSharp;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Mapping.Transformation;

namespace TestCodeDomVisitor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
				if (components != null) 
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
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(48, 32);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(16, 64);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(256, 184);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			this.textBox1.WordWrap = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			IDomainMap domainMap = new DomainMap();
			domainMap.Name = "Test";
			domainMap.RootNamespace = "Puzzle.Testing";

			IClassMap employee = new ClassMap();
			employee.Name = "Employee";
			employee.DomainMap = domainMap;

			IPropertyMap firstName = new PropertyMap();
			firstName.Name = "FirstName";
			firstName.DataType = "System.String";
			firstName.ClassMap = employee;

			IPropertyMap lastName = new PropertyMap();
			lastName.Name = "LastName";
			lastName.DataType = "System.String";
			lastName.ClassMap = employee;

			IPropertyMap reportsTo = new PropertyMap();
			reportsTo.Name = "ReportsTo";
			reportsTo.DataType = "Employee";
			reportsTo.ClassMap = employee;

			IPropertyMap employees = new PropertyMap();
			employees.Name = "Employees";
			employees.IsCollection = true;
			employees.ItemType = "Employee";
			employees.ClassMap = employee;

			ModelToCodeTransformer modelToCodeTransformer = new ModelToCodeTransformer() ;
			string code = modelToCodeTransformer.ToCSharpCode(domainMap);
			//string code = modelToCodeTransformer.ToCSharpCodeFile(domainMap, "Test");

			//modelToCodeTransformer.ToAssemblyFile(domainMap, domainMap.Name + ".dll");
			Assembly asm = modelToCodeTransformer.ToAssembly(domainMap);
			textBox1.Text = code ;
		}










	}
}
