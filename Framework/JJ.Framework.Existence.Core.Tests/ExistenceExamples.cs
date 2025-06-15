namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class ExistenceExamples
{
    int? num = null;
    string? text = null;
    IEnumerable<int> list = [ 1, 2, 3 ];
    
    [TestMethod]
    public void Existence_Examples_Before()
    {
        if (IsNullOrWhiteSpace(text)) { }
        if (num.HasValue && num.Value != 0) { }
        if (list != null && list.Any()) { }
        if (list?.Any() ?? false) { }
    }
    
    [TestMethod]
    public void Existence_Examples_After()
    {
        if (Has(text, spaceMatters)) { }
        if (num.IsNully()) { }
        list = list.Where(FilledIn);
    }
}