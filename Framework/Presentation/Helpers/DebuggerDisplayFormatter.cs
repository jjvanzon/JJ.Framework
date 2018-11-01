using System;
using System.Text;

namespace JJ.Framework.Presentation.Helpers
{
    internal static class DebuggerDisplayFormatter
    {
        public static string GetDebuggerDisplay(PagerViewModel pagerViewModel)
        {
            if (pagerViewModel == null) throw new ArgumentNullException(nameof(pagerViewModel));

            var sb = new StringBuilder();

            if (pagerViewModel.CanGoToFirstPage)
            {
                sb.Append("<<  ");
            }

            if (pagerViewModel.CanGoToFirstPage)
            {
                sb.Append("<  ");
            }

            if (pagerViewModel.MustShowLeftEllipsis)
            {
                sb.Append("... ");
            }

            if (pagerViewModel.VisiblePageNumbers != null)
            { 
                foreach (int visiblePageNumber in pagerViewModel.VisiblePageNumbers)
                {
                    if (visiblePageNumber == pagerViewModel.PageNumber)
                    {
                        sb.Append($"[{visiblePageNumber}] ");
                    }
                    else
                    {
                        sb.Append($"{visiblePageNumber} ");
                    }
                }
            }

            if (pagerViewModel.MustShowRightEllipsis)
            {
                sb.Append("... ");
            }

            if (pagerViewModel.CanGoToNextPage)
            {
                sb.Append(" >  ");
            }

            if (pagerViewModel.CanGoToLastPage)
            {
                sb.Append(">>  ");
            }

            sb.Append($"({nameof(pagerViewModel.PageCount)} = {pagerViewModel.PageCount}) ");

            if (pagerViewModel.VisiblePageNumbers is null)
            {
                sb.Append("<VisiblePageNumbers is null> ");
            }

            if (pagerViewModel.VisiblePageNumbers != null &&
                pagerViewModel.PageCount != 0 &&
                !pagerViewModel.VisiblePageNumbers.Contains(pagerViewModel.PageNumber))
            {
                sb.Append("<PageNumber was not in the VisiblePageNumbers> ");
            }

            sb.Append($"{{{pagerViewModel.GetType().Name}}} ");

            return sb.ToString().Trim();
        }
    }
}