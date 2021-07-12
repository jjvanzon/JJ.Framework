using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Casing_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithCap() 
            => AssertHelper.AreEqual("This is a sentence.", () => "this is a sentence.".StartWithCap());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithCap_DoesNotTouchOtherCharacters()
            => AssertHelper.AreEqual("This Is A Sentence.", () => "this Is A Sentence.".StartWithCap());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithCap_SingleCharacter()
            => AssertHelper.AreEqual("A", () => "a".StartWithCap());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithCap_TwoCharacters()
            => AssertHelper.AreEqual("Ab", () => "ab".StartWithCap());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithCap_EmptyString()
            => AssertHelper.AreEqual("", () => "".StartWithCap());

        [TestMethod]
        public void Test_StringExtensions_Casing_StartWithCap_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions_Casing.StartWithCap(null),
                "Object reference not set to an instance of an object.");
    }
}
