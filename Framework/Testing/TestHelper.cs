namespace JJ.Framework.Testing
{
	internal static class TestHelper
	{
		private const string TESTED_PROPERTY_MESSAGE = "Tested property: '{0}'.";

		public static string FormatTestedPropertyMessage(string propertyDescription)
		{
			return string.Format(TESTED_PROPERTY_MESSAGE, propertyDescription);
		}
	}
}
