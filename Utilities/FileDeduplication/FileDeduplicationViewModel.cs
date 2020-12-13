using System.Collections.Generic;

// ReSharper disable MemberCanBeInternal

namespace JJ.Utilities.FileDeduplication
{
	public class FileDeduplicationViewModel
	{
		public string TitleBarText { get; set; }
		public string Explanation { get; set; }
		public bool AlsoScanSubFolders { get; set; }
		public string FilePattern { get; set; }
		/// <summary>
		/// The list of duplicate file paths and the original file paths (one copy is deemed the original),
		/// in a specific format where duplicate file paths are prefixed with "| ".
		/// </summary>
		public string ListOfDuplicates { get; set; }
		public string FolderPath { get; set; }
		public string ProgressMessage { get; set; }
		/// <summary>
		/// Might use this property to determine whether to disable some controls while IsRunning = true.
		/// </summary>
		public bool IsRunning { get; set; }
		public IList<string> ValidationMessages { get; set; }
		public string ScanQuestion { get; set; }
		public string DeleteFilesQuestion { get; set; }
	}
}
