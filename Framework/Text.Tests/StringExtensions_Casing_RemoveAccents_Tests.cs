using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable StringLiteralTypo

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Casing_RemoveAccents_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_Casing_RemoveAccents()
            => AssertHelper.AreEqual("aecu and more words.", () => "àéçû and more words.".RemoveAccents());

        [TestMethod]
        public void Test_StringExtensions_Casing_RemoveAccents_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions_Casing.RemoveAccents(null),
                "Object reference not set to an instance of an object.");
    }
}
