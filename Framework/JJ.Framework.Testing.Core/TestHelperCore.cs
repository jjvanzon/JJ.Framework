namespace JJ.Framework.Testing.Core
{
    public static class TestHelperCore
    {
        public static string FormatTestedExpressionMessage(string messageOrExpression) 
            => Has(messageOrExpression) ? $"Tested: '{messageOrExpression}'." : "";
        
        // ReSharper disable AssignNullToNotNullAttribute
        [NoTrim(ObjectGetType)]
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