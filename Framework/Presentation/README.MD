# JJ.Framework.Presentation

Allows you to easily construct a pager view model, that indicates everything you need for drawing out a pager, like `CanGoToFirstPage`, `CanGoToPreviousPage`, `CanGoToNextPage`, `CanGoToLastPage`, etc.

This library is more generally named `JJ.Framework.Presentation`, because this is the spot in my architecture to put generally reusable presentation logic, independent of application and independent of specific presentation technology. It just so happens I have had nothing else to put here except a `PagerViewModel`. There were more things in here, but they were deprecated.

Example:

	PagerViewModelFactory.Create(pageIndex: 0, pageSize: 10, count: 100, maxVisiblePageNumbers = 5);

Returns:

	PagerViewModel
	{
		PageCount = 10
		CanGoToFirstPage = false,
		CanGoToPreviousPage = false,
		MustShowLeftEllipsis = false,

		VisiblePageNumbers = { 1, 2, 3, 4, 5 },

		PageNumber = 1,

		MustShowRightEllipsis = true,
		CanGoToNextPage = true, 
		CanGoToLastPage = true
	}
