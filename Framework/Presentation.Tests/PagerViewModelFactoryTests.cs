using JJ.Framework.Exceptions.Comparative;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Presentation.Tests
{
    [TestClass]
    public class PagerViewModelFactoryTests
    {
        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_PageNumber_LessThan1()
            => AssertHelper.ThrowsException<LessThanException>(
                () => PagerViewModelFactory.Create(
                    pageNumber: 0,
                    pageSize: 10,
                    count: 195,
                    maxVisiblePageNumbers: 5),
                "pageNumber of 0 is less than 1.");

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_PageSize_LessThan1()
            => AssertHelper.ThrowsException<LessThanException>(
                () => PagerViewModelFactory.Create(
                    pageNumber: 1,
                    pageSize: 0,
                    count: 195,
                    maxVisiblePageNumbers: 5),
                "pageSize of 0 is less than 1.");

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_Count_LessThan0()
            => AssertHelper.ThrowsException<LessThanException>(
                () => PagerViewModelFactory.Create(
                    pageNumber: 1,
                    pageSize: 10,
                    count: -1,
                    maxVisiblePageNumbers: 5),
                "count of -1 is less than 0.");

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_MaxVisiblePageNumbers_LessThan1()
            => AssertHelper.ThrowsException<LessThanException>(
                () => PagerViewModelFactory.Create(
                    pageNumber: 1,
                    pageSize: 10,
                    count: 195,
                    maxVisiblePageNumbers: 0),
                "maxVisiblePageNumbers of 0 is less than 1.");

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_PageNumberGreaterThanPageCount()
            => AssertHelper.ThrowsException<GreaterThanException>(
                () => PagerViewModelFactory.Create(
                    pageNumber: 21,
                    pageSize: 10,
                    count: 195,
                    maxVisiblePageNumbers: 5),
                "pageNumber of 21 is greater than pageCount of 20.");

        [TestMethod]
        public void Test_PagerViewModelFactory_CountIs0()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 1,
                pageSize: 10,
                count: 0,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(0, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(0, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(default, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumbersOutOfView_FirstPage_LeftBound()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 1,
                pageSize: 10,
                count: 195,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(20, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(1, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(2, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(3, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(4, () => pagerViewModel.VisiblePageNumbers[3]);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers[4]);

            AssertHelper.AreEqual(1, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(true, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumbersOutOfView_LastPage_RightBound()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 20,
                pageSize: 10,
                count: 195,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(20, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(16, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(17, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(18, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(19, () => pagerViewModel.VisiblePageNumbers[3]);
            AssertHelper.AreEqual(20, () => pagerViewModel.VisiblePageNumbers[4]);

            AssertHelper.AreEqual(20, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumbersOutOfView_InTheMiddle()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 10,
                pageSize: 10,
                count: 195,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(20, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(8, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(9, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(10, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(11, () => pagerViewModel.VisiblePageNumbers[3]);
            AssertHelper.AreEqual(12, () => pagerViewModel.VisiblePageNumbers[4]);

            AssertHelper.AreEqual(10, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(true, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_AllPageNumbersAreVisible_FirstPage()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 1,
                pageSize: 10,
                count: 45,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(5, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(1, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(2, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(3, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(4, () => pagerViewModel.VisiblePageNumbers[3]);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers[4]);

            AssertHelper.AreEqual(1, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_AllPageNumbersAreVisible_LastPage()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 5,
                pageSize: 10,
                count: 45,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(5, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(1, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(2, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(3, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(4, () => pagerViewModel.VisiblePageNumbers[3]);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers[4]);

            AssertHelper.AreEqual(5, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_LessPageNumbers_ThanMaxVisiblePageCount()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 1,
                pageSize: 10,
                count: 35,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(4, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(4, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(1, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(2, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(3, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(4, () => pagerViewModel.VisiblePageNumbers[3]);

            AssertHelper.AreEqual(1, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_BanalExample()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 1,
                pageSize: 10,
                count: 195,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(20, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(1, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(2, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(3, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(4, () => pagerViewModel.VisiblePageNumbers[3]);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers[4]);

            AssertHelper.AreEqual(1, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(true, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToLastPage);
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_DocumentationExample()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 3,
                pageSize: 10,
                count: 195,
                maxVisiblePageNumbers: 5);

            AssertHelper.AreEqual(20, () => pagerViewModel.PageCount);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToFirstPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToPreviousPage);
            AssertHelper.AreEqual(false, () => pagerViewModel.MustShowLeftEllipsis);

            AssertHelper.IsNotNull(() => pagerViewModel.VisiblePageNumbers);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers.Count);

            AssertHelper.AreEqual(1, () => pagerViewModel.VisiblePageNumbers[0]);
            AssertHelper.AreEqual(2, () => pagerViewModel.VisiblePageNumbers[1]);
            AssertHelper.AreEqual(3, () => pagerViewModel.VisiblePageNumbers[2]);
            AssertHelper.AreEqual(4, () => pagerViewModel.VisiblePageNumbers[3]);
            AssertHelper.AreEqual(5, () => pagerViewModel.VisiblePageNumbers[4]);

            AssertHelper.AreEqual(3, () => pagerViewModel.PageNumber);

            AssertHelper.AreEqual(true, () => pagerViewModel.MustShowRightEllipsis);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToNextPage);
            AssertHelper.AreEqual(true, () => pagerViewModel.CanGoToLastPage);
        }
    }
}
