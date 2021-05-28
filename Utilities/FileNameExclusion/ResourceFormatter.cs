using JJ.Framework.ResourceStrings;

namespace JJ.Utilities.FileNameExclusion
{
	public static class ResourceFormatter
	{
		private static readonly ResourceFormatterHelper _helper = new ResourceFormatterHelper(Resources.ResourceManager);

		public static string ApplicationName => _helper.GetText();
		public static string ExclusionList => _helper.GetText();
		public static string Explanation => _helper.GetText();
		public static string InputList => _helper.GetText();
		public static string OutputList => _helper.GetText();
	}
}
