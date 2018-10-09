using System;
using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for CompilerExceptionListViewItem.
	/// </summary>
	public class CompilerExceptionListViewItem : ListViewItem
	{
		public CompilerExceptionListViewItem(CompilerError ce, int imgListCount) : base(ce.ErrorText)
		{
			this.compilerError = ce;
			//this.ImageIndex = (imgListCount / 2) - 1;
			this.ImageIndex = (imgListCount / 2);
			this.SubItems.Add(ce.Line.ToString() );
			this.SubItems.Add(ce.Column.ToString() );
			this.SubItems.Add(ce.IsWarning.ToString() );
		}

		#region Property  CompilerError
		
		private CompilerError compilerError;
		
		public CompilerError CompilerError
		{
			get { return this.compilerError; }
			set { this.compilerError = value; }
		}
		
		#endregion
	}
}
