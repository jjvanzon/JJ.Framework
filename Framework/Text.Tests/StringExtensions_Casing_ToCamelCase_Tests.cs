using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable StringLiteralTypo

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Casing_ToCamelCase_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase()
            => AssertHelper.AreEqual("thisIsASentence", () => "This is a sentence.".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_LeadingDecimalDigit_ConvertedToWord()
        {
            AssertHelper.AreEqual("zeroThings", () => "0Things".ToCamelCase());
            AssertHelper.AreEqual("oneThing", () => "1Thing".ToCamelCase());
            AssertHelper.AreEqual("twoThings", () => "2Things".ToCamelCase());
            AssertHelper.AreEqual("threeThings", () => "3Things".ToCamelCase());
            AssertHelper.AreEqual("fourThings", () => "4Things".ToCamelCase());
            AssertHelper.AreEqual("fiveThings", () => "5Things".ToCamelCase());
            AssertHelper.AreEqual("sixThings", () => "6Things".ToCamelCase());
            AssertHelper.AreEqual("sevenThings", () => "7Things".ToCamelCase());
            AssertHelper.AreEqual("eightThings", () => "8Things".ToCamelCase());
            AssertHelper.AreEqual("nineThings", () => "9Things".ToCamelCase());
        }

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_FirstCap_IsChangedToLowerCase()
            => AssertHelper.AreEqual("thing", () => "Thing".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_WordsStartWithCap_ExceptForFirst()
            => AssertHelper.AreEqual("severalWordsWITHDifferentCAsing", () => "Several words WITH Different cAsing".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_AlreadyConcatenatedWords_StayStartingWithCap()
            => AssertHelper.AreEqual("severalWordsConcatenated", () => "SeveralWordsConcatenated".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_Accents_AreRemoved()
            => AssertHelper.AreEqual("aecu", () => "àéçû".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_WhiteSpaceAndPunctuation_AreRemoved()
            => AssertHelper.AreEqual("whiteSpaceAndPunctuation", () => "White space\tand\r\npunctuation.;!?\"'".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_Underscores_AreKept()
            => AssertHelper.AreEqual("underscores_Are_Kept", () => "Underscores_are_kept".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_DisallowedCharacters_AreEscaped()
            => AssertHelper.AreEqual("u00b6u0263", () => "¶ɣ".ToCamelCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_ToCamelCase_NullInput_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => StringExtensions_Casing.ToCamelCase(null));
    }
}
