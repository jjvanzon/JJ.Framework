using System.Collections.Generic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_SplitWithQuotation_WithCharParameters_Tests
    {
        [TestMethod]
        public void ComplexExample()
        {
            string input = "0123,'1234','23,45','34''56',4'56'7,'56'78','67'89','''','',";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(9, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("1234", () => split[1]);
            AssertHelper.AreEqual("23,45", () => split[2]);
            AssertHelper.AreEqual("34'56", () => split[3]);
            AssertHelper.AreEqual("4567", () => split[4]);
            AssertHelper.AreEqual("5678,6789", () => split[5]);
            AssertHelper.AreEqual("'", () => split[6]);
            AssertHelper.AreEqual("", () => split[7]);
            AssertHelper.AreEqual("", () => split[8]);
        }

        [TestMethod]
        public void NoQuotes()
        {
            string input = "0123,456789";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("456789", () => split[1]);
        }

        [TestMethod]
        public void WithQuotes()
        {
            string input = "'12345','67890'";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("12345", () => split[0]);
            AssertHelper.AreEqual("67890", () => split[1]);
        }

        [TestMethod]
        public void SeparatorCharInQuotes_BecomesPartOfValue()
        {
            string input = "'234,567','890,1'";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("234,567", () => split[0]);
            AssertHelper.AreEqual("890,1", () => split[1]);
        }

        [TestMethod]
        public void EscapedQuotes_WorkWithinQuotes()
        {
            string input = "'3456''789','0''12'";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("3456'789", () => split[0]);
            AssertHelper.AreEqual("0'12", () => split[1]);
        }

        [TestMethod]
        public void EscapedQuotes_OutsideOfQuotes_CancelOut()
        {
            string input = "45''678901,2''3";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("45678901", () => split[0]);
            AssertHelper.AreEqual("23", () => split[1]);
        }

        [TestMethod]
        public void QuotationInMiddleOfValue_IsPossible()
        {
            string input = "5'6,'7,890'1,23'4";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("56,7", () => split[0]);
            AssertHelper.AreEqual("8901,234", () => split[1]);
        }

        [TestMethod]
        public void QuotesOpenAndCloseAllOverThePlace()
        {
            string input = "6'78'9',0'123,45";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("6789,0123", () => split[0]);
            AssertHelper.AreEqual("45", () => split[1]);
        }

        [TestMethod]
        public void EmptyValueWithQuotes()
        {
            string input = "890123456,'',7";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(3, () => split.Count);
            AssertHelper.AreEqual("890123456", () => split[0]);
            AssertHelper.AreEqual("", () => split[1]);
            AssertHelper.AreEqual("7", () => split[2]);
        }

        [TestMethod]
        public void EmptyValueWithoutQuotes()
        {
            string input = "9,,012345678";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(3, () => split.Count);
            AssertHelper.AreEqual("9", () => split[0]);
            AssertHelper.AreEqual("", () => split[1]);
            AssertHelper.AreEqual("012345678", () => split[2]);
        }

        [TestMethod]
        public void LineEndsWithSeparator_MeansEmptyValue()
        {
            string input = "01,23456789,";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(3, () => split.Count);
            AssertHelper.AreEqual("01", () => split[0]);
            AssertHelper.AreEqual("23456789", () => split[1]);
            AssertHelper.AreEqual("", () => split[2]);
        }

        [TestMethod]
        public void LastValueNoClosingQuote_IsAccepted()
        {
            string input = "123,'4567890";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("123", () => split[0]);
            AssertHelper.AreEqual("4567890", () => split[1]);
        }

        [TestMethod]
        public void InputNullOrEmpty_ReturnsEmptyList()
        {
            {
                IList<string> splitNull = StringExtensions_Split.SplitWithQuotation(null, ',', '\'');
                AssertHelper.IsNotNull(() => splitNull);
                AssertHelper.AreEqual(0, () => splitNull.Count);
            }
            {
                IList<string> splitEmptyString = "".SplitWithQuotation(',', '\'');
                AssertHelper.IsNotNull(() => splitEmptyString);
                AssertHelper.AreEqual(0, () => splitEmptyString.Count);
            }
        }

        [TestMethod]
        public void Separator_SpaceIsAllowed()
        {
            string input = "34567 '89 012'";

            IList<string> split = input.SplitWithQuotation(' ', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("34567", () => split[0]);
            AssertHelper.AreEqual("89 012", () => split[1]);
        }
    }
}
