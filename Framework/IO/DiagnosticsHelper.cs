using System;
using System.Text;

namespace JJ.Framework.IO
{
	internal class DiagnosticsHelper
	{
		public static string GetDebuggerDisplay(FileDeduplicator.FileTuple fileTuple)
		{
			if (fileTuple == null) throw new ArgumentNullException(nameof(fileTuple));

			var sb = new StringBuilder();

			sb.Append($"{{{fileTuple.GetType().Name}}} ");

			if (fileTuple.IsDuplicate)
			{
				sb.Append(" (duplicate)");
			}

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

		internal static string GetDebuggerDisplay(FileDeduplicator.FilePair filePair)
		{
			if (filePair == null) throw new ArgumentNullException(nameof(filePair));
			var debuggerDisplay = @$"{{{filePair.GetType().Name}}} '{filePair.DuplicateFilePath}' => '{filePair.OriginalFilePath}'";
			return debuggerDisplay;
		}
	}
}
