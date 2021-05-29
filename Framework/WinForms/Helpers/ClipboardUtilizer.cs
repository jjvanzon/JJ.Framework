using System.Windows.Forms;
using JJ.Framework.Common;

namespace JJ.Framework.WinForms.Helpers
{
    public class ClipboardUtilizer : IClipboardUtilizer
    {
        public void SetText(string text) => Clipboard.SetText(text);
    }
}
