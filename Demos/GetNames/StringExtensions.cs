namespace JJ.Demos.GetNames
{
	public static class StringExtensions
	{
		public static string CutLeft(this string str, string start)
		{
			if (str.StartsWith(start)) return str.CutLeft(start.Length);
			return str;
		}

		public static string CutLeft(this string str, int length)
		{
			return str.Right(str.Length - length);
		}

		public static string Right(this string str, int length)
		{
			return str.Substring(str.Length - length, length);
		}
	}
}
