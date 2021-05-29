using System.Collections.Generic;

namespace JJ.Utilities.FileNameExclusion
{
    public class FileNameExclusionViewModel
    {
        public string InputList { get; set; }
        public string ExclusionList { get; set; }
        public string OutputList { get; set; }
        public IList<string> ValidationMessages { get; set; }
        public string AreYouSureQuestion { get; set; }
        public string DonePopupMessage { get; set; }
    }
}
