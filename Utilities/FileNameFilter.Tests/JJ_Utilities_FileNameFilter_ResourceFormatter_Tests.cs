using JJ.Framework.Resources.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable IDE0002 // Simplify Member Access

namespace JJ.Utilities.FileNameFilter.Tests
{
	[TestClass]
	public class JJ_Utilities_FileNameFilter_ResourceFormatter_Tests : ResourceFormatterTestsBase
	{
		public JJ_Utilities_FileNameFilter_ResourceFormatter_Tests()
			: base(typeof(ResourceFormatter),
				   knownCultureNames: new[] { "nl-NL", "en-US" },
				   unknownCultureName: "zh-CN")
		{ }

		[TestMethod]
		public void Test_JJ_Utilities_FileNameFilter_ResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures()
			=> base.Test_ResourceFormatter_AllPublicStaticMembers_ReturnText_ForKnownCultures();

		[TestMethod]
		public void Test_JJ_Utilities_FileNameFilter_ResourceFormatter_UnknownCulture_DefaultsToEnUS()
			=> base.Test_ResourceFormatter_UnknownCulture_DefaultsToEnUS();
	}
}
