// ReSharper disable MemberCanBeInternal
namespace JJ.Utilities.FileDeduplication
{
	public class FileDeduplicationViewModel
	{
		public string TitleBarText { get; set; }
		public string Explanation { get; set; }
		public bool Recursive { get; set; }
		public string ListOfDuplicates { get; set; }
		public string FolderPath { get; set; }
		public string ProgressMessage { get; set; }
		/// <summary>
		/// Might use this property to determine whether to disable some controls while IsRunning = true.
		/// </summary>
		public bool IsRunning { get; set; }
	}
}
