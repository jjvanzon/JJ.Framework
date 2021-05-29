using JetBrains.Annotations;
using JJ.Framework.Exceptions.TypeChecking;
using System;
using System.Windows.Forms;

namespace JJ.Framework.WinForms.Extensions
{
    [PublicAPI]
    public static class CommonDialogExtensions
    {
        /// <summary>
        /// Would return FileName if commonDialog is a FileDialog.
        /// Would return SelectedPath if commonDialog is a FolderBrowserDialog.
        /// Otherwise an exception is thrown.
        /// </summary>
        public static string GetPath_OrException(this CommonDialog commonDialog)
        {
            if (commonDialog == null) throw new ArgumentNullException(nameof(commonDialog));

            switch (commonDialog)
            {
                case FileDialog fileDialog: 
                    return fileDialog.FileName;

                case FolderBrowserDialog folderBrowserDialog: 
                    return folderBrowserDialog.SelectedPath;

                default: 
                    throw new UnexpectedTypeException(() => commonDialog);
            }
        }

        /// <summary>
        /// Would set the FileName if commonDialog is a FileDialog.
        /// Would set the SelectedPath if commonDialog is a FolderBrowserDialog.
        /// Otherwise an exception is thrown.
        /// </summary>
        public static void SetPath_OrException(this CommonDialog commonDialog, string path)
        {
            if (commonDialog == null) throw new ArgumentNullException(nameof(commonDialog));

            switch (commonDialog)
            {
                case FileDialog fileDialog:
                    fileDialog.FileName = path;
                    break;

                case FolderBrowserDialog folderBrowserDialog:
                    folderBrowserDialog.SelectedPath = path;
                    break;

                default:
                    throw new UnexpectedTypeException(() => commonDialog);
            }
        }
    }
}
