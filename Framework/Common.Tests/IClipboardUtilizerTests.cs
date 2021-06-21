using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable NotAccessedField.Local
// ReSharper disable InconsistentNaming
#pragma warning disable IDE0052 // Remove unread private members

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class IClipboardUtilizerTests
    {
        [TestMethod]
        public void Demo_IClipboardUtilizer()
        {
            IClipboardUtilizer clipboardUtilizer = new ClipboardUtilizer();
            clipboardUtilizer.SetText("Something to put on the clipboard.");
        }

        private class ClipboardUtilizer : IClipboardUtilizer
        {
            private string _fakeStoringInClipboard;

            public void SetText(string text) => _fakeStoringInClipboard = text;
        }
    }
}
