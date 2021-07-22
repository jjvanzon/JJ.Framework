using System;
using System.Collections.Generic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Split_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_ComplexExample()
        {
            string input = "1234,'1234','12,34','12''34',1'23'4,'12'34','12'34','''','',";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(9, () => split.Count);
            AssertHelper.AreEqual("1234", () => split[0]);
            AssertHelper.AreEqual("1234", () => split[1]);
            AssertHelper.AreEqual("12,34", () => split[2]);
            AssertHelper.AreEqual("12'34", () => split[3]);
            AssertHelper.AreEqual("1234", () => split[4]);
            AssertHelper.AreEqual("1234,1234", () => split[5]);
            AssertHelper.AreEqual("'", () => split[6]);
            AssertHelper.AreEqual("", () => split[7]);
            AssertHelper.AreEqual("", () => split[8]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_WithoutQuotes()
        {
            string input = "0123,456789";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("456789", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_WithQuotes()
        {
            string input = "'0123','456789'";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("456789", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_SeparatorCharInQuotes_BecomesPartOfValue()
        {
            string input = "'012,34','56,789'";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("012,34", () => split[0]);
            AssertHelper.AreEqual("56,789", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_EscapedQuotes_WorkWithinQuotes()
        {
            string input = "'01''23','4567''89'";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("01'23", () => split[0]);
            AssertHelper.AreEqual("4567'89", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_EscapedQuotes_OutsideOfQuotes_CancelOut()
        {
            string input = "01''23,4567''89";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("456789", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_QuotationInMiddleOfValue_IsPossible()
        {
            string input = "0'1,2'3,45'6,78'9";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("01,23", () => split[0]);
            AssertHelper.AreEqual("456,789", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_QuotesOpenAndCloseAllOverThePlace()
        {
            string input = "0'12'3',4'567,89";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123,4567", () => split[0]);
            AssertHelper.AreEqual("89", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_EmptyValueWithQuotes()
        {
            string input = "0123,'',456789";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(3, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("", () => split[1]);
            AssertHelper.AreEqual("456789", () => split[2]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_EmptyValueWithoutQuotes()
        {
            string input = "01234,,56789";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(3, () => split.Count);
            AssertHelper.AreEqual("01234", () => split[0]);
            AssertHelper.AreEqual("", () => split[1]);
            AssertHelper.AreEqual("56789", () => split[2]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_LineEndsWithSeparator_MeansEmptyValue()
        {
            string input = "012345,6789,";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(3, () => split.Count);
            AssertHelper.AreEqual("012345", () => split[0]);
            AssertHelper.AreEqual("6789", () => split[1]);
            AssertHelper.AreEqual("", () => split[2]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_LastValueNoClosingQuote_IsAccepted()
        {
            string input = "0123456,'789";

            IList<string> split = input.SplitWithQuotation(',', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123456", () => split[0]);
            AssertHelper.AreEqual("789", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_InputNullOrEmpty_ReturnsEmptyList()
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
        public void Test_StringExtensions_SplitWithQuotation_SeparatorNullOrEmpty_ThrowsException()
        {
            string input = "01234,56789";

            AssertHelper.ThrowsException<ArgumentException>(
                () => input.SplitWithQuotation(null, "'"),
                "separator is null or empty.");

            AssertHelper.ThrowsException<ArgumentException>(
                () => input.SplitWithQuotation("", "'"),
                "separator is null or empty.");
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_Separator_SpaceIsAllowed()
        {
            string input = "0123 '456 789'";

            IList<string> split = input.SplitWithQuotation(' ', '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("456 789", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_QuoteNull_SplitsWithoutQuotation()
        {
            string input = "0'12'3,456'789'";

            IList<string> split = input.SplitWithQuotation(",", null);

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0'12'3", () => split[0]);
            AssertHelper.AreEqual("456'789'", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_QuoteEmpty_SplitsWithoutQuotation()
        {
            string input = "0'12'3,456'789'";

            IList<string> split = input.SplitWithQuotation(",", "");

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0'12'3", () => split[0]);
            AssertHelper.AreEqual("456'789'", () => split[1]);
        }

        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation_SeparatorAndQuoteStrings_SingleCharacter_CallsOverloadWithChars()
        {
            string input = "'0123','456789'";

            IList<string> split = input.SplitWithQuotation(",", "'");

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(2, () => split.Count);
            AssertHelper.AreEqual("0123", () => split[0]);
            AssertHelper.AreEqual("456789", () => split[1]);
        }
    }
}
