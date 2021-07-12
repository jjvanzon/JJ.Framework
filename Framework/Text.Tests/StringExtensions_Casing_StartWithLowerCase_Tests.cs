using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Casing_StartWithLowerCase_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithLowerCase()
            => AssertHelper.AreEqual("not a sentence", () => "Not a sentence".StartWithLowerCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithLowerCase_DoesNotTouchOtherCharacters()
            => AssertHelper.AreEqual("not A Sentence", () => "Not A Sentence".StartWithLowerCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithLowerCase_SingleCharacter()
            => AssertHelper.AreEqual("a", () => "A".StartWithLowerCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithLowerCase_TwoCharacters()
            => AssertHelper.AreEqual("ab", () => "Ab".StartWithLowerCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithLowerCase_EmptyString()
            => AssertHelper.AreEqual("", () => "".StartWithLowerCase());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithLowerCase_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions_Casing.StartWithLowerCase(null),
                "Object reference not set to an instance of an object.");
    }
}
