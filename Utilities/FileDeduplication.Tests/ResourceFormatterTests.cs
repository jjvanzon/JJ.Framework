using JJ.Framework.Resources.Tests;
using JJ.Utilities.FileDeduplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable IDE0002 // Simplify Member Access

namespace FileDeduplication.Tests
{
	[TestClass]
	public class ResourceFormatterTests : ResourceFormatterTestBase
	{
		public ResourceFormatterTests()
			: base(typeof(ResourceFormatter), 
			       knownCultureNames: new[] { "nl-NL", "en-US" },
			       unknownCultureName: "zh-CN") { }

		[TestMethod]
		public new void Test_ResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures()
			=> base.Test_ResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures();

		[TestMethod]
		public new void Test_ResourceFormatter_UnknownCulture_DefaultsToEnUS()
			=> base.Test_ResourceFormatter_UnknownCulture_DefaultsToEnUS();
	}
}
