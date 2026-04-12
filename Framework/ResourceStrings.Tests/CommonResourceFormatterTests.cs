// ReSharper disable RedundantBaseQualifier

using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.ResourceStrings.Tests
{
    [TestClass]
    public class CommonResourceFormatterTests : StringResourceTester
    {
        public CommonResourceFormatterTests()
            : base(typeof(CommonResourceFormatter), 
                   @default: "en-US",
                   known: [ "pl-PL", "nl-NL", "" ], 
                   unknown: "zh-CN") { }

        [TestMethod]
        public void Test_CommonResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures()
            => base.AssertAllMembers();

        [TestMethod]
        public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS() 
            => base.AssertUnknownCulture();

        protected override object GetArg(ParameterInfo param)
        {
            if (string.Equals(param.Name, "id"))
            {
                return 100 + param.Position;
            }
            return base.GetArg(param);
        }
    }
}
