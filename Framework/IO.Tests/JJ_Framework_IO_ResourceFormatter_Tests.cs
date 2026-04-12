#pragma warning disable IDE0002 // Simplify Member Access
// ReSharper disable RedundantBaseQualifier

using JJ.Framework.ResourceStrings;

namespace JJ.Framework.IO.Tests
{
    [TestClass]
    public class JJ_Framework_IO_ResourceFormatter_Tests : StringResourceTester
    {
        public JJ_Framework_IO_ResourceFormatter_Tests()
            : base(typeof(ResourceFormatter), 
                   @default: "en-US",
                   known: [ "nl-NL", "" ], 
                   unknown: "zh-CN") { }

        [TestMethod]
        public void Test_JJ_Framework_IO_ResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures()
            => base.AssertAllMembers();

        [TestMethod]
        public void Test_JJ_Framework_IO_ResourceFormatter_UnknownCulture_DefaultsToEnUS()
            => base.AssertUnknownCulture();
    }
}
