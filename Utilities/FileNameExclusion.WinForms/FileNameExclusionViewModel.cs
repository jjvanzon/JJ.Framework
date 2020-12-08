using System.Collections.Generic;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	public class FileNameExclusionViewModel
	{
		// TODO: Clearer names?
		public string InputList { get; set; }
		public string ExclusionList { get; set; }
		public string OutputList { get; set; }
		public IList<string> ValidationMessages { get; set; }
	}
}
