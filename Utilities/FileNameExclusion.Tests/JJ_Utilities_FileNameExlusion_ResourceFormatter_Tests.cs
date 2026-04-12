// ReSharper disable RedundantBaseQualifier

using JJ.Framework.ResourceStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Utilities.FileNameExclusion.Tests
{
    [TestClass]
    public class JJ_Utilities_FileNameExclusion_ResourceFormatter_Tests : StringResourceTester
    {
        public JJ_Utilities_FileNameExclusion_ResourceFormatter_Tests()
            : base(typeof(ResourceFormatter),
                   @default: "en-US",
                   known: [ "nl-NL", "" ], 
                   unknown: "zh-CN") { }

        [TestMethod]
        public void Test_JJ_Utilities_FileNameExclusion_ResourceFormatter_AllPublicStatics_ReturnText_ForKnownCultures()
            => base.AssertAllMembers();

        [TestMethod]
        public void Test_JJ_Utilities_FileNameExclusion_ResourceFormatter_UnknownCulture_DefaultsToEnUS()
            => base.AssertUnknownCulture();
    }
}
