// ReSharper disable RedundantBaseQualifier

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.ResourceStrings.Tests
{
    [TestClass]
    public class CommonResourceFormatterTests : ResourceStringTestBase
    {
        public CommonResourceFormatterTests()
            : base(typeof(CommonResourceFormatter), 
                   @default: "en-US",
                   known: [ "pl-PL", "nl-NL", "" ], 
                   unknown: "zh-CN") { }

        [TestMethod]
        public void Test_CommonResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures()
            => base.Test_Resources_AllPublicStatics_ReturnText_ForKnownCultures();

        [TestMethod]
        public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS() 
            => base.Test_Resources_UnknownCulture_UsesDefaultCulture();
    }
}
