using System.IO;

namespace JJ.Framework.IO
{
    /// <summary>
    /// Would delete the files, while progress might be reported.
    /// Surpasses the Windows recycle bin.
    /// To use the recycle bin, the following class might be available: BulkFileDeleterWithRecycleBin
    /// in JJ.Framework.Microsoft.VisualBasic.
    /// </summary>
    public class PermanentBulkFileDeleter : BulkFileDeleterBase
    {
        protected override void DeleteFile(string filePath) => File.Delete(filePath);
    }
}
