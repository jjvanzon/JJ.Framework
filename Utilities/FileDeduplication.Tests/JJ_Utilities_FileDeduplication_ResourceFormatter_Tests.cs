// ReSharper disable RedundantBaseQualifier

using JJ.Framework.ResourceStrings.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Utilities.FileDeduplication.Tests
{
    [TestClass]
    public class JJ_Utilities_FileDeduplication_ResourceFormatter_Tests : ResourceStringTester
    {
        public JJ_Utilities_FileDeduplication_ResourceFormatter_Tests()
            : base(typeof(ResourceFormatter), 
                   @default: "en-US",
                   known: [ "nl-NL", "" ], 
                   unknown: "zh-CN") { }

        [TestMethod]
        public void Test_JJ_Utilities_FileDeduplication_ResourceFormatter_AllPublicStatics_ReturnText_ForKnownCultures()
            => base.Assert_AllPublicStatics_ReturnText_ForKnownCultures();

        [TestMethod]
        public void Test_JJ_Utilities_FileDeduplication_ResourceFormatter_UnknownCulture_DefaultsToEnUS()
            => base.Assert_UnknownCulture_UsesDefaultCulture();
    }
}
