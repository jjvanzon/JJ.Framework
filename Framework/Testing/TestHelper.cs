namespace JJ.Framework.Testing
{
    internal static class TestHelper
    {
        private const string TESTED_EXPRESSION_MESSAGE = "Tested expression: '{0}'.";

        public static string FormatTestedPropertyMessage(string propertyDescription) 
            => string.Format(TESTED_EXPRESSION_MESSAGE, propertyDescription);
    }
}
