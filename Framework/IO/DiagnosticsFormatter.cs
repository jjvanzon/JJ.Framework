using System;
using System.Text;

namespace JJ.Framework.IO
{
    internal class DiagnosticsFormatter
    {
        public static string GetDebuggerDisplay(FileDeduplicator.FileTuple fileTuple)
        {
            if (fileTuple == null) throw new ArgumentNullException(nameof(fileTuple));

            var sb = new StringBuilder();

            sb.Append($"{{{fileTuple.GetType().Name}}} ");

            sb.Append($" '{fileTuple.FilePath}'");
            sb.Append($" ({fileTuple.FileSize} bytes)");

            if (fileTuple.FileBytes != null)
            {
                sb.Append(" (loaded)");
            }
            
            if (fileTuple.OriginalFileTuple != null)
            {
                sb.Append(@$" => '{fileTuple.OriginalFileTuple.FilePath}'");
            }

            return sb.ToString();
        }

        internal static string GetDebuggerDisplay(DuplicateFilePair duplicateFilePair)
        {
            if (duplicateFilePair == null) throw new ArgumentNullException(nameof(duplicateFilePair));
            var debuggerDisplay = @$"{{{duplicateFilePair.GetType().Name}}} '{duplicateFilePair.DuplicateFilePath}' => '{duplicateFilePair.OriginalFilePath}'";
            return debuggerDisplay;
        }
    }
}
