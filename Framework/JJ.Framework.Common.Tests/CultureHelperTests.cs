namespace JJ.Framework.Common.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class CultureHelperTests
{
    [TestMethod]
    public void Test_CultureHelper_SetThreadCulture_Core_Test()
    {
        CultureInfo originalCulture   = Thread.CurrentThread.CurrentCulture;
        CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;
        try
        {
            Thread.CurrentThread.CurrentCulture   = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            
            CultureHelper.SetThreadCulture("nl-NL");
            AreEqual("nl-NL", () => Thread.CurrentThread.CurrentCulture.Name);
            AreEqual("nl-NL", () => Thread.CurrentThread.CurrentUICulture.Name);
            
            CultureHelper.SetThreadCulture("de-DE");
            AreEqual("de-DE", () => Thread.CurrentThread.CurrentCulture.Name);
            AreEqual("de-DE", () => Thread.CurrentThread.CurrentUICulture.Name);
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture   = originalCulture;
            Thread.CurrentThread.CurrentUICulture = originalUICulture;
        }
    }
}