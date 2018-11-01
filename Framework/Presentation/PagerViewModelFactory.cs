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
		public static PagerViewModel Create(int pageNumber, int pageSize, int count, int maxVisiblePageNumbers)
		{
            if (pageSize < 1) throw new LessThanException(() => pageSize, 1);
			if (pageNumber < 1) throw new LessThanException(() => pageNumber, 1);
			if (count < 0) throw new LessThanException(() => count, 0);
			if (maxVisiblePageNumbers < 1) throw new LessThanException(() => maxVisiblePageNumbers, 1);

			var pageCount = (int)Math.Ceiling((decimal)count / (decimal)pageSize);
			if (pageNumber > pageCount)
			{
			    throw new GreaterThanException(() => pageNumber, () => pageCount);
			}

			bool hasPages = pageCount != 0;
			bool isFirstPage = pageNumber == 1;
			bool isLastPage = pageNumber == pageCount;

			var viewModel = new PagerViewModel
			{
				PageCount = pageCount,
				CanGoToPreviousPage = hasPages && !isFirstPage,
				CanGoToNextPage = hasPages && !isLastPage,
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

				bool isLeftBound = pageNumber - numberOfPagesOnLeftSide <= 1;
				bool isRightBound = pageNumber + numberOfPagesOnRightSide > pageCount;

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
					firstVisiblePageNumber = pageNumber - numberOfPagesOnLeftSide + 1;
					lastVisiblePageNumber = pageNumber + numberOfPagesOnRightSide + 1;
				}
			}

			// Create page number view models
			viewModel.VisiblePageNumbers = new List<int>(maxVisiblePageNumbers);
			for (int i = firstVisiblePageNumber; i <= lastVisiblePageNumber; i++)
			{
				viewModel.VisiblePageNumbers.Add(i);
			}

			viewModel.PageNumber = pageNumber;

			viewModel.MustShowLeftEllipsis = firstVisiblePageNumber != 1;
			viewModel.MustShowRightEllipsis = lastVisiblePageNumber != pageCount;

			return viewModel;
		}
	}
}
