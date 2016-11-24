using System;
using System.Windows.Forms;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Exceptions;

namespace Puzzle.NPersist.Tools.DomainExplorer
{
	/// <summary>
	/// Summary description for SystemExceptionListViewItem.
	/// </summary>
	public class SystemExceptionListViewItem : ListViewItem
	{
		public SystemExceptionListViewItem(IContext context, Exception ex, int imgListCount )
		{
			this.context = context;
			this.exception = ex;
			this.ImageIndex = (imgListCount / 2);

			SetText();

			string propertyName = "";
			NPersistException npEx = this.exception as NPersistException;
			if (npEx != null)
			{
				if (npEx.PropertyName != null)
				{
					if (npEx.PropertyName.Length > 0)
					{
						propertyName = npEx.PropertyName;
					}
				}
			}

			this.SubItems.Add(propertyName );
			this.SubItems.Add(ex.Message );
			this.SubItems.Add(ex.GetType().ToString() );
		}

		#region Property  Context
		
		private IContext context;
		
		public IContext Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		
		#endregion

		private void SetText()
		{	
			NPersistException npEx = this.exception as NPersistException;
			if (npEx != null)
			{
				if (npEx.Obj != null)
				{
					this.Text = MainForm.GetObjectAsString(npEx.Obj, this.context);
					return;
				}
			}
			this.Text = "<unspecified>";
		}

		#region Property  Exception
		
		private Exception exception;
		
		public Exception Exception
		{
			get { return this.exception; }
			set { this.exception = value; }
		}
		
		#endregion

	}
}
