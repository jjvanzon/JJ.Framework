// ReSharper disable ReturnTypeCanBeNotNullable
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Misc_Tests
{
    [TestMethod]
    public void Test_NotNullWhen_Correctly_Applied()
    {
        string? text = GetText();

        // Compiler says no.
        //int lengthNo = text.Length;

        if (Has(text))
        {
            // Compiler says yes.
            int length = text.Length;

            AreEqual(3, length);
        }
    }

    private string? GetText() => "Hi!";
}