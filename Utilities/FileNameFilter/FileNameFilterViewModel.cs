using System.Collections.Generic;

namespace JJ.Utilities.FileNameFilter
{
	public class FileNameFilterViewModel
	{
		public string InputList { get; set; }
		public string ListOfFileNamesToKeep { get; set; }
		public string OutputList { get; set; }
		public IList<string> ValidationMessages { get; set; }
		public string AreYouSureQuestion { get; set; }
		public string DonePopupMessage { get; set; }
	}
}
