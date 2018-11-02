using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Presentation.Helpers;

namespace JJ.Framework.Presentation
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public sealed class PagerViewModel
	{
		public int PageCount { get; set; }
		public bool CanGoToFirstPage { get; set; }
		public bool CanGoToPreviousPage { get; set; }
		public bool MustShowLeftEllipsis { get; set; }

		/// <summary> 1-based </summary>
		public IList<int> VisiblePageNumbers { get; set; }

		/// <summary> 1-based </summary>
		public int PageNumber { get; set; }

		public bool MustShowRightEllipsis { get; set; }
		public bool CanGoToNextPage { get; set; }
		public bool CanGoToLastPage { get; set; }

	    private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
