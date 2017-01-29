using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;

namespace JJ.Framework.Presentation
{
    public static class PagerViewModelFactory
    {
        public static PagerViewModel Create(int selectedPageIndex, int pageSize, int count, int maxVisiblePageNumbers)
        {
            if (pageSize < 1) throw new LessThanException(() => pageSize, 1);
            if (selectedPageIndex < 0) throw new LessThanException(() => selectedPageIndex, 0);
            if (count < 0) throw new LessThanException(() => count, 0);
            if (maxVisiblePageNumbers < 1) throw new LessThanException(() => maxVisiblePageNumbers, 1);

            int pageCount = (int)Math.Ceiling((decimal)count / (decimal)pageSize);
            if (selectedPageIndex > pageCount)
            {
                throw new Exception($"pageIndex {selectedPageIndex} is larger than pageCount {pageCount}.");
            }

            bool hasPages = pageCount != 0;
            bool isFirstPage = selectedPageIndex == 0;
            bool isLastPage = selectedPageIndex == pageCount - 1;

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
            int firstVisiblePageIndex;
            int lastVisiblePageIndex;

            bool allPageNumbersAreVisible = pageCount <= maxVisiblePageNumbers;
            if (allPageNumbersAreVisible)
            {
                firstVisiblePageIndex = 0;
                lastVisiblePageIndex = pageCount - 1;
            }
            else
            {
                // Numbers do not fit.

                // The -1 is the selected page.
                int numberOfPagesOnLeftSide = (maxVisiblePageNumbers - 1) / 2; // Sneekily make use of integer division to get less on the left side in case of an even number of visible pages.
                int numberOfPagesOnRightSide = maxVisiblePageNumbers - numberOfPagesOnLeftSide - 1;

                bool isLeftBound = selectedPageIndex - numberOfPagesOnLeftSide <= 0;
                bool isRightBound = selectedPageIndex + numberOfPagesOnRightSide > pageCount - 1;

                if (isLeftBound)
                {
                    firstVisiblePageIndex = 0;
                    lastVisiblePageIndex = maxVisiblePageNumbers - 1;
                }
                else if (isRightBound)
                {
                    lastVisiblePageIndex = pageCount - 1;
                    firstVisiblePageIndex = pageCount - maxVisiblePageNumbers;
                }
                else
                {
                    // Is is somewhere in the middle.
                    firstVisiblePageIndex = selectedPageIndex - numberOfPagesOnLeftSide;
                    lastVisiblePageIndex = selectedPageIndex + numberOfPagesOnRightSide;
                }
            }

            // Create page number view models
            viewModel.VisiblePageNumbers = new List<int>(maxVisiblePageNumbers);
            for (int i = firstVisiblePageIndex; i <= lastVisiblePageIndex; i++)
            {
                int pageNumber = i + 1;
                viewModel.VisiblePageNumbers.Add(pageNumber);
            }

            viewModel.PageNumber = selectedPageIndex + 1;

            viewModel.MustShowLeftEllipsis = firstVisiblePageIndex != 0;
            viewModel.MustShowRightEllipsis = lastVisiblePageIndex != pageCount - 1;

            return viewModel;
        }
    }
}
