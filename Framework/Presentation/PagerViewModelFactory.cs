using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Comparative;
// ReSharper disable RedundantCast

namespace JJ.Framework.Presentation
{
    [PublicAPI]
	public static class PagerViewModelFactory
	{
		public static PagerViewModel Create(int selectedPageNumber, int pageSize, int itemCount, int maxVisiblePageNumbers)
		{
			if (selectedPageNumber < 1) throw new LessThanException(() => selectedPageNumber, 1);
            if (pageSize < 1) throw new LessThanException(() => pageSize, 1);
			if (itemCount < 0) throw new LessThanException(() => itemCount, 0);
			if (maxVisiblePageNumbers < 1) throw new LessThanException(() => maxVisiblePageNumbers, 1);

            if (itemCount == 0)
            {
                return new PagerViewModel { VisiblePageNumbers = new List<int>() };
            }

			var pageCount = (int)Math.Ceiling((decimal)itemCount / (decimal)pageSize);
			if (selectedPageNumber > pageCount)
			{
			    throw new GreaterThanException(() => selectedPageNumber, () => pageCount);
			}

			bool hasPages = pageCount != 0;
			bool isFirstPage = selectedPageNumber == 1;
			bool isLastPage = selectedPageNumber == pageCount;

			var viewModel = new PagerViewModel
			{
				PageCount = pageCount,
				CanGoToPreviousPage = hasPages && !isFirstPage,
				CanGoToNextPage = hasPages && !isLastPage,
			    PageNumber = selectedPageNumber,
			    VisiblePageNumbers = new List<int>(maxVisiblePageNumbers)
			};

			viewModel.CanGoToFirstPage = viewModel.CanGoToPreviousPage;
			viewModel.CanGoToLastPage = viewModel.CanGoToNextPage;

			// Get a max set of heading or trailing page numbers around the selected page number.

			// This did not work when we were at the end and not all page numbers fit. 
			// Then we would end up with half of the maxVisiblePageNumbers.
			//int numberOfPagesOnLeftSide = (maxVisiblePageNumbers - 1) / 2;

			//int firstVisiblePageIndex = selectedPageIndex - numberOfPagesOnLeftSide;
			//if (firstVisiblePageIndex < 0) firstVisiblePageIndex = 0;

			//int lastVisiblePageIndex = firstVisiblePageIndex + maxVisiblePageNumbers - 1;
			//if (lastVisiblePageIndex > pageCount - 1) lastVisiblePageIndex = pageCount - 1;

			// There must be a simpler way than this, but I cannot figure it out.
			int firstVisiblePageNumber;
			int lastVisiblePageNumber;

			bool allPageNumbersAreVisible = pageCount <= maxVisiblePageNumbers;
			if (allPageNumbersAreVisible)
			{
				firstVisiblePageNumber = 1;
				lastVisiblePageNumber = pageCount;
			}
			else
			{
				// Numbers do not fit.

				// The -1 is the selected page.
				int numberOfPagesOnLeftSide = (maxVisiblePageNumbers - 1) / 2; // Sneakily make use of integer division to get less on the left side in case of an even number of visible pages.
				int numberOfPagesOnRightSide = maxVisiblePageNumbers - numberOfPagesOnLeftSide - 1;

				bool isLeftBound = selectedPageNumber - numberOfPagesOnLeftSide <= 1;
				bool isRightBound = selectedPageNumber + numberOfPagesOnRightSide > pageCount;

				if (isLeftBound)
				{
					firstVisiblePageNumber = 1;
					lastVisiblePageNumber = maxVisiblePageNumbers;
				}
				else if (isRightBound)
				{
					lastVisiblePageNumber = pageCount;
					firstVisiblePageNumber = pageCount - maxVisiblePageNumbers + 1;
				}
				else
				{
					// Is is somewhere in the middle.
					firstVisiblePageNumber = selectedPageNumber - numberOfPagesOnLeftSide;
					lastVisiblePageNumber = selectedPageNumber + numberOfPagesOnRightSide;
				}
			}

			// Create page number view models
			for (int i = firstVisiblePageNumber; i <= lastVisiblePageNumber; i++)
			{
				viewModel.VisiblePageNumbers.Add(i);
			}

			viewModel.MustShowLeftEllipsis = firstVisiblePageNumber != 1;
			viewModel.MustShowRightEllipsis = lastVisiblePageNumber != pageCount;

			return viewModel;
		}
	}
}
