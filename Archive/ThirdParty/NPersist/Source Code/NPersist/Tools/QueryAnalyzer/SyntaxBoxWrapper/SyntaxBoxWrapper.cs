using System;
using System.IO;
using System.Reflection;
using Puzzle.SourceCode;
using Puzzle.Syntaxbox.DefaultSyntaxFiles;

namespace Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper
{
	/// <summary>
	/// Summary description for SyntaxBoxWrapper.
	/// </summary>
	public class SyntaxBoxWrapper : System.Windows.Forms.UserControl, ITextBox
	{
		private Puzzle.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
		private Puzzle.SourceCode.SyntaxDocument syntaxDocument1;
		private System.ComponentModel.IContainer components;

		public SyntaxBoxWrapper()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			SetupSyntaxBox(syntaxBoxControl1);

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.syntaxBoxControl1 = new Puzzle.Windows.Forms.SyntaxBoxControl();
			this.syntaxDocument1 = new Puzzle.SourceCode.SyntaxDocument(this.components);
			this.SuspendLayout();
			// 
			// syntaxBoxControl1
			// 
			this.syntaxBoxControl1.AllowDrop = true;
			this.syntaxBoxControl1.AutoListPosition = null;
			this.syntaxBoxControl1.AutoListSelectedText = "";
			this.syntaxBoxControl1.AutoListVisible = false;
			this.syntaxBoxControl1.BackColor = System.Drawing.Color.White;
			this.syntaxBoxControl1.CopyAsRTF = false;
			this.syntaxBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxBoxControl1.Document = this.syntaxDocument1;
			this.syntaxBoxControl1.FontName = "Courier new";
			this.syntaxBoxControl1.InfoTipCount = 1;
			this.syntaxBoxControl1.InfoTipPosition = null;
			this.syntaxBoxControl1.InfoTipSelectedIndex = 0;
			this.syntaxBoxControl1.InfoTipVisible = false;
			this.syntaxBoxControl1.Location = new System.Drawing.Point(0, 0);
			this.syntaxBoxControl1.LockCursorUpdate = false;
			this.syntaxBoxControl1.Name = "syntaxBoxControl1";
			this.syntaxBoxControl1.Size = new System.Drawing.Size(150, 150);
			this.syntaxBoxControl1.SmoothScroll = false;
			this.syntaxBoxControl1.SplitviewH = -4;
			this.syntaxBoxControl1.SplitviewV = -4;
			this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((System.Byte)(244)), ((System.Byte)(243)), ((System.Byte)(234)));
			this.syntaxBoxControl1.TabIndex = 0;
			this.syntaxBoxControl1.Text = "syntaxBoxControl1";
			this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
//			this.syntaxBoxControl1.DragOver += new System.Windows.Forms.DragEventHandler(this.syntaxBoxControl1_DragOver);
//			this.syntaxBoxControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.syntaxBoxControl1_DragDrop);
//			this.syntaxBoxControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.syntaxBoxControl1_DragEnter);
//			this.syntaxBoxControl1.DragLeave += new System.EventHandler(this.syntaxBoxControl1_DragLeave);
			// 
			// syntaxDocument1
			// 
			this.syntaxDocument1.Lines = new string[] {
														  ""};
			this.syntaxDocument1.MaxUndoBufferSize = 1000;
			this.syntaxDocument1.Modified = false;
			this.syntaxDocument1.UndoStep = 0;
			// 
			// SyntaxBoxWrapper
			// 
			this.Controls.Add(this.syntaxBoxControl1);
			this.Name = "SyntaxBoxWrapper";
			this.ResumeLayout(false);

		}
		#endregion

		//this.syntaxBoxControl1.ActiveView = Puzzle.Windows.Forms.SyntaxBox.ActiveView.BottomRight;
		//			this.syntaxBoxControl1.ShowScopeIndicator = false;		//disappeared
		//			this.syntaxBoxControl1.BorderStyle = Puzzle.Windows.Forms.BorderStyle.None;

		public void SetupNPath()
		{
			SyntaxBoxConfigurator syntaxBoxConfigurator = new SyntaxBoxConfigurator(syntaxBoxControl1);
			syntaxBoxConfigurator.SetupNPath() ;
		}


		public void SetupCSharp()
		{
			SyntaxBoxConfigurator syntaxBoxConfigurator = new SyntaxBoxConfigurator(syntaxBoxControl1);
			syntaxBoxConfigurator.SetupCSharp() ;
		}

		public void SetupVBNet()
		{
			SyntaxBoxConfigurator syntaxBoxConfigurator = new SyntaxBoxConfigurator(syntaxBoxControl1);
			syntaxBoxConfigurator.SetupVBNet() ;
		}

		public void SetupDelphi()
		{
			SyntaxBoxConfigurator syntaxBoxConfigurator = new SyntaxBoxConfigurator(syntaxBoxControl1);
			syntaxBoxConfigurator.SetupDelphi() ;
		}

		public void SetupXml()
		{
			SyntaxBoxConfigurator syntaxBoxConfigurator = new SyntaxBoxConfigurator(syntaxBoxControl1);
			syntaxBoxConfigurator.SetupXml() ;
		}

		public void SetupSqlServerSql()
		{
			SyntaxBoxConfigurator syntaxBoxConfigurator = new SyntaxBoxConfigurator(syntaxBoxControl1);
			syntaxBoxConfigurator.SetupSqlServer2KSql() ;
		}


		public Puzzle.Windows.Forms.SyntaxBoxControl SyntaxBoxControl
		{
			get { return syntaxBoxControl1; }
		}

		public Puzzle.SourceCode.SyntaxDocument SyntaxDocument
		{
			get { return syntaxDocument1; }	
		}

		public override string Text
		{
			get { return syntaxBoxControl1.Document.Text; }
			set { syntaxBoxControl1.Document.Text = value; }
		}

		public bool ReadOnly
		{
			get { return syntaxBoxControl1.ReadOnly; }
			set { syntaxBoxControl1.ReadOnly = value; }
		}

		public string SelectedText
		{
			get { return syntaxBoxControl1.Selection.Text; }
			set { syntaxBoxControl1.Selection.Text = value; }
		}

		public void LoadSyntaxString(string syntaxString)
		{
			syntaxBoxControl1.Document.Parser.Init(Language.FromSyntaxXml(syntaxString));				
		}

		public void LoadSyntaxFile(string path)
		{
			syntaxBoxControl1.Document.Parser.Init(path);				
		}
	
		private void SetupSyntaxBox(Puzzle.Windows.Forms.SyntaxBoxControl syntaxBox)
		{

			syntaxBox.AllowBreakPoints = true;
			syntaxBox.AutoListVisible = false;
			//syntaxBox.FontSize = 10.0F
			//syntaxBox.FontName = "Lucida Console"
			//syntaxBox.FontSize = 14.0F
			syntaxBox.GutterMarginBorderColor = System.Drawing.SystemColors.ControlDark;

			syntaxBox.GutterMarginColor = System.Drawing.SystemColors.Control;
			syntaxBox.GutterMarginWidth = 19;
			syntaxBox.HighLightActiveLine = false;
			syntaxBox.HighLightedLineColor = System.Drawing.Color.LightYellow;
			syntaxBox.InactiveSelectionBackColor = System.Drawing.SystemColors.Highlight;
			syntaxBox.InfoTipCount = 1;
			syntaxBox.InfoTipImage = null;
			syntaxBox.InfoTipPosition = null;
			syntaxBox.InfoTipSelectedIndex = 0;
			syntaxBox.InfoTipText = "";
			syntaxBox.InfoTipVisible = false;
			syntaxBox.LineNumberBackColor = System.Drawing.SystemColors.Window;
			syntaxBox.LineNumberBorderColor = System.Drawing.Color.Teal;
			syntaxBox.LineNumberForeColor = System.Drawing.Color.Teal;
			syntaxBox.LockCursorUpdate = false;
			syntaxBox.Name = "syntaxBox";
			syntaxBox.OutlineColor = System.Drawing.SystemColors.ControlDark;
			syntaxBox.ParseOnPaste = false;
			syntaxBox.ReadOnly = false;
			syntaxBox.RowPadding = 0;
			syntaxBox.ScopeBackColor = System.Drawing.Color.Transparent;
			syntaxBox.ScopeIndicatorColor = System.Drawing.Color.Transparent;
			syntaxBox.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			syntaxBox.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			syntaxBox.SeparatorColor = System.Drawing.SystemColors.Control;
			syntaxBox.ShowGutterMargin = true;
			syntaxBox.ShowLineNumbers = true;
			syntaxBox.ShowTabGuides = false;
			syntaxBox.ShowWhitespace = false;
			syntaxBox.Size = new System.Drawing.Size(672, 445);
			syntaxBox.SmoothScroll = false;
			syntaxBox.SmoothScrollSpeed = 2;
			syntaxBox.SplitviewH = -4;
			syntaxBox.SplitviewV = -4;
			syntaxBox.TabGuideColor = System.Drawing.Color.FromArgb((byte)244, (byte)243, (byte)234);
			syntaxBox.TabIndex = 0;
			syntaxBox.TabSize = 4;
			syntaxBox.TextDrawStyle = Puzzle.Windows.Forms.SyntaxBox.TextDraw.TextDrawType.StarBorder;
			syntaxBox.TooltipDelay = 240;
			syntaxBox.VirtualWhitespace = false;
			syntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
			//syntaxBox.KeyboardActions.Add(new SyntaxBox.KeyboardAction(Keys.C, False,True,False,True) 
		}

//		private void syntaxBoxControl1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
//		{
//			this.Text = (string) e.Data.GetData(typeof(string));		
//		}
//
//		private void syntaxBoxControl1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
//		{
//			e.Effect = DragDropEffects.Copy;
//		
//		}
//
//		private void syntaxBoxControl1_DragLeave(object sender, System.EventArgs e)
//		{
//		
//		}
//
//		private void syntaxBoxControl1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
//		{
//			e.Effect = DragDropEffects.Copy;
//		
//		}

	
	}
}
