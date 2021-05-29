using JetBrains.Annotations;
using JJ.Framework.IO;
using Microsoft.VisualBasic.FileIO;

namespace JJ.Framework.Microsoft.VisualBasic
{
    /// <summary>
    /// Would delete the files, while progress might be reported.
    /// Deleted files would be sent to the Windows recycle bin.
    /// </summary>
    public class BulkFileDeleter_WithRecycleBin : BulkFileDeleterBase
    {
        /// <inheritdoc cref="BulkFileDeleter_WithRecycleBin" />
        [UsedImplicitly]  public BulkFileDeleter_WithRecycleBin() { }

        protected override void DeleteFile(string filePath)
            => FileSystem.DeleteFile(
                filePath,
                UIOption.OnlyErrorDialogs,
                RecycleOption.SendToRecycleBin,
                UICancelOption.DoNothing);
    }
}
