using System.IO;

namespace JJ.Framework.IO
{
    /// <summary> Fully unit tested. </summary>
    public static class DirectoryInfoExtensions
    {
        public static void Clear(this DirectoryInfo directoryInfo) => FileHelper.ClearFolder(directoryInfo);
        public static void ClearRecursive(this DirectoryInfo directoryInfo) => FileHelper.ClearFolderRecursive(directoryInfo);
        public static long GetSize(this DirectoryInfo directoryInfo) => FileHelper.GetFolderSize(directoryInfo);
        public static long GetSizeRecursive(this DirectoryInfo directoryInfo) => FileHelper.GetFolderSizeRecursive(directoryInfo);
        public static int CountFilesRecursive(this DirectoryInfo directoryInfo) => FileHelper.CountFilesRecursive(directoryInfo);
        public static bool IsEmpty(this DirectoryInfo directoryInfo) => FileHelper.FolderIsEmpty(directoryInfo);
    }
}
