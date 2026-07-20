namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class CommonStringExtensionsCore_Obsolete_Tests
{
    [TestMethod]
    public void Test_CommonStringExtensionsCore_RemoveAccents_Obsolete()
    {
        var accessor = new CommonStringExtensionsCore_Obsolete_Accessor();
        const string expectedMessage = "Use StringExtensionsCore.RemoveAccents from JJ.Framework.Text.Core instead.";
        AreEqual(expectedMessage, accessor.ObsoleteMessage);
        Throws(() => accessor.RemoveAccentsObsolete("Bla"), expectedMessage);
        Throws(() => accessor.RemoveAccents("Bla"), expectedMessage);
    }
}