using System.Diagnostics;
using JetBrains.Annotations;

namespace JJ.Framework.IO
{
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public class DuplicateFilePair
    {
        public string OriginalFilePath { get; set; }
        public string DuplicateFilePath { get; set; }

        private string DebuggerDisplay => DiagnosticsFormatter.GetDebuggerDisplay(this);
    }
}
