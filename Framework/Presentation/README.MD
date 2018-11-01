# JJ.Framework.Presentation

Allows you to easily construct a pager view model, that indicates everything you need for drawing out a pager, like `CanGoToFirstPage`, `CanGoToPreviousPage`, `CanGoToNextPage`, `CanGoToLastPage`, etc. This was trickier than I thought.

This library is more generally named `JJ.Framework.Presentation`, because this is the spot in my architecture to put generally reusable presentation logic, independent of application and independent of specific presentation technology. It just so happens I have had nothing else to put here except a `PagerViewModel`. There were more things in here, but they were deprecated.

Example:

	PagerViewModelFactory.Create(
		pageNumber: 3, 
		pageSize: 10, 
		count: 200, 
		maxVisiblePageNumbers: 5);

Returns:

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
