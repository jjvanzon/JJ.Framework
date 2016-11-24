using System;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Exceptions;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for ExceptionListViewItem.
	/// </summary>
	public class ExceptionListViewItem : ListViewItem
	{
		public ExceptionListViewItem(IContext context, NPersistValidationException validationException, int imgListCount) : base()
		{
			this.context = context;
			this.nPersistValidationException = validationException;
			this.imgListCount = imgListCount;
			Setup();
		}

		#region Property  Context
		
		private IContext context;
		
		public IContext Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		
		#endregion

		#region Property  NPersistValidationException
		
		private NPersistValidationException nPersistValidationException;
		
		public NPersistValidationException NPersistValidationException
		{
			get { return this.nPersistValidationException; }
			set { this.nPersistValidationException = value; }
		}
		
		#endregion

		private int imgListCount;
		
		private void SetText()
		{	
			string text = MainForm.GetObjectAsString(this.nPersistValidationException.Obj, this.context);
			this.Text = text;
		}

		private void SetIcon()
		{	
			if (this.nPersistValidationException.PropertyName.Length > 0)
				this.ImageIndex = 1 + (imgListCount / 2);
			else
				this.ImageIndex = (imgListCount / 2);
		}

		private void Setup()
		{
			SetText();
			SetIcon();
			this.SubItems.Add(this.nPersistValidationException.Message);
			object text = "" ;
			if (this.nPersistValidationException.PropertyName.Length > 0)
			{
				text = this.nPersistValidationException.PropertyName;
			}
			this.SubItems.Add(text.ToString());
			text = this.nPersistValidationException.Limit ;
			if (text == null) { text = ""; };
			this.SubItems.Add(text.ToString() );
			text = this.nPersistValidationException.Actual ;
			if (text == null) { text = ""; };
			this.SubItems.Add(text.ToString() );
			text = this.nPersistValidationException.Value ;
			if (text == null) { text = ""; };
			this.SubItems.Add(text.ToString() );
 
		}
	}
}
