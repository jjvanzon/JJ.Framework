namespace JJ.Framework.Wishes.Testing
{
    internal static class TestHelper_Copied
    {
        private const string TESTED_PROPERTY_MESSAGE = "Tested member: '{0}'.";
        
        public static string FormatTestedPropertyMessage(string propertyDescription)
            => string.Format(TESTED_PROPERTY_MESSAGE, propertyDescription);
    }
}