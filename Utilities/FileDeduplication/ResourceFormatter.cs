namespace JJ.Utilities.FileDeduplication
{
	public static class ResourceFormatter
	{
		public static string ApplicationName => Resources.ApplicationName;
		public static string Explanation => Resources.Explanation;
		public static string PleaseFirst_WithName(string name) => string.Format(Resources.PleaseFirst_WithName, name);
		public static string Duplicates => Resources.Duplicates;
	}
}
