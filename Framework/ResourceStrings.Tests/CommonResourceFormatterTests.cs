using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable IDE0002 // Simplify Member Access

namespace JJ.Framework.ResourceStrings.Tests
{
	[TestClass]
	public class CommonResourceFormatterTests : ResourceFormatterTestsBase
	{
		public CommonResourceFormatterTests()
			: base(typeof(CommonResourceFormatter), 
			       knownCultureNames: new[] { "pl-PL", "nl-NL", "en-US" }, 
			       unknownCultureName: "zh-CN") { }

		[TestMethod]
		public void Test_CommonResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures()
			=> Test_ResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures();

		[TestMethod]
		public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS() => Test_ResourceFormatter_UnknownCulture_DefaultsToEnUS();
	}
}
