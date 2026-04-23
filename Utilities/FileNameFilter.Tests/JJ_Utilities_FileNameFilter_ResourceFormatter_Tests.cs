#pragma warning disable IDE0002 // Simplify Member Access
// ReSharper disable RedundantBaseQualifier

using JJ.Framework.ResourceStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Utilities.FileNameFilter.Tests
{
    [TestClass]
    public class JJ_Utilities_FileNameFilter_ResourceFormatter_Tests : StringResourceTester
    {
        public JJ_Utilities_FileNameFilter_ResourceFormatter_Tests()
            : base(typeof(ResourceFormatter),
                   @default: "en-US",
                   known: [ "nl-NL", "" ], 
                   unknown: "zh-CN") { }

        [TestMethod]
        public void Test_JJ_Utilities_FileNameFilter_ResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures()
            => base.AssertResourceMembers();

        [TestMethod]
        public void Test_JJ_Utilities_FileNameFilter_ResourceFormatter_UnknownCulture_DefaultsToEnUS()
            => base.AssertCultureFallback();
    }
}
