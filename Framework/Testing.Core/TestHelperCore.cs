namespace JJ.Framework.Testing.Core
{
    public static class TestHelperCore
    {
        public static string FormatTestedExpressionMessage(string messageOrExpression) 
            => Has(messageOrExpression) ? $"Tested: '{messageOrExpression}'." : "";

        // TODO: This message build-up could be customized
        //  independently from Legacy. Does not need to be like legacy.
        //  Remove Legacy suffix after refactoring.
        
        internal static string GetExpectedActualMessageLegacy<T>(string methodName, T expected, T actual, string message)
            => $@"Assert.{methodName} failed. Expected <{(expected != null ? expected.ToString() : "null")}>, Actual <{(actual != null ? actual.ToString() : "null")}>.{(!string.IsNullOrEmpty(message) ? " " : "")}{message}";
        
        internal static string GetFailureMessageLegacy(string methodName, string message)
        {
            string separator = !string.IsNullOrEmpty(message) ? " " : "";

            return $"Assert.{methodName} failed.{separator}{message}";
        }

        // ReSharper disable AssignNullToNotNullAttribute
        [TrimWarn(ObjectGetType)]
        public static bool CurrentTestIsInCategory(string category)
        {
            var methodQuery = new StackTrace().GetFrames().Select(x => x.GetMethod());
            
            var attributeQuery
                = methodQuery.SelectMany(method => method!.GetCustomAttributes()
                                                          .Union(method!.DeclaringType?.GetCustomAttributes() ?? []));
            var categoryQuery
                = attributeQuery.Where(attr => attr.GetType().Name == "TestCategoryAttribute")
                                .Select(attr => attr.GetType().GetProperty("TestCategories")?.GetValue(attr))
                                .OfType<IEnumerable<string>>()
                                .SelectMany(x => x);
            
            bool isInCategory = categoryQuery.Any(x => String.Equals(x, category, StringComparison.OrdinalIgnoreCase));
            
            return isInCategory;
        }
    }
}