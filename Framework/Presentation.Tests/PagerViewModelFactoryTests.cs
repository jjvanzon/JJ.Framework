using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Presentation.Tests
{
    [TestClass]
    public class PagerViewModelFactoryTests
    {
        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_PageSize_LessThan1()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_PageNumber_LessThan1()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_Count_LessThan0()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_MaxVisiblePageNumbers_LessThan1()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_Exception_MaxVisiblePageNumbers_PageNumberGreaterThanPageCount()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_CountIs0()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_FirstPage()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_LastPage()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_AllPagesAreVisible()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumberOutOfView_LeftBound()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumberOutOfView_RightBound()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumberOutOfView_InTheMiddle()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumberOutOfView_MustShowLeftEllipsis()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_WithPageNumberOutOfView_MustShowRightEllipsis()
        {
        }

        [TestMethod]
        public void Test_PagerViewModelFactory_FirstPage_WithPageNumberOutOfView()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 1,
                pageSize: 10,
                count: 200,
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
        public void Test_PagerViewModelFactory_Example()
        {
            PagerViewModel pagerViewModel = PagerViewModelFactory.Create(
                pageNumber: 3,
                pageSize: 10,
                count: 200,
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
