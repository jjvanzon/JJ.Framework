# JJ.Framework.Presentation

Easily construct a pager view model with properties like `CanGoToFirstPage`, `CanGoToPreviousPage`, `CanGoToNextPage`, `CanGoToLastPage`.

Example call:

	PagerViewModelFactory.Create(
		pageNumber: 3, 
		pageSize: 10, 
		count: 200, 
		maxVisiblePageNumbers: 5);

This returns:

	PagerViewModel
	{
		PageCount = 20,
		CanGoToFirstPage = true,
		CanGoToPreviousPage = true,
		MustShowLeftEllipsis = false,

		VisiblePageNumbers = { 1, 2, 3, 4, 5 },

		PageNumber = 3,

		MustShowRightEllipsis = true,
		CanGoToNextPage = true, 
		CanGoToLastPage = true
	}

You can render it any way you want. But you might present it as follows:

	<<  <  1 2 [3] 4 5 ...  >  >>

Here is an example of how you could render it with a StringBuilder:

    var sb = new StringBuilder();

    if (pagerViewModel.CanGoToFirstPage) sb.Append("<< ");
    if (pagerViewModel.CanGoToPreviousPage) sb.Append("< ");
    if (pagerViewModel.MustShowLeftEllipsis) sb.Append("... ");

    foreach (int i in pagerViewModel.VisiblePageNumbers)
    {
        if (i == pagerViewModel.PageNumber)
        {
            sb.Append($"[{i}] ");
        }
        else
        {
            sb.Append($"{i} ");
        }
    }

    if (pagerViewModel.MustShowRightEllipsis) sb.Append("... ");
    if (pagerViewModel.CanGoToNextPage) sb.Append(" > ");
    if (pagerViewModel.CanGoToLastPage) sb.Append(">>");
