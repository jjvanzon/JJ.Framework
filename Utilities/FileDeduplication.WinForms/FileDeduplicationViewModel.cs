using System.Collections.Generic;

// ReSharper disable MemberCanBeInternal

namespace JJ.Utilities.FileDeduplication.WinForms
{
	public class FileDeduplicationViewModel
	{
		public string TitleBarText { get; set; }
		public string Explanation { get; set; }
		public bool AlsoScanSubFolders { get; set; }
		public string FilePattern { get; set; }
		public string ListOfDuplicates { get; set; }
		public string FolderPath { get; set; }
		public string ProgressMessage { get; set; }
		/// <summary>
		/// Might use this property to determine whether to disable some controls while IsRunning = true.
		/// </summary>
		public bool IsRunning { get; set; }
		public IList<string> ValidationMessages { get; set; }
	}
}
