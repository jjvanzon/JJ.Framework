using JJ.Framework.Resources;

namespace JJ.Utilities.FileDeduplication
{
	public static class ResourceFormatter
	{
		private static readonly ResourceFormatterHelper _helper = new ResourceFormatterHelper(Resources.ResourceManager);

		public static string ApplicationName => _helper.GetText();
		public static string Explanation => _helper.GetText();
		public static string PleaseFirst_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Duplicates => _helper.GetText();
	}
}
