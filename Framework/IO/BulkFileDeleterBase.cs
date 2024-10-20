﻿using JetBrains.Annotations;
using JJ.Framework.ResourceStrings;
using System;
using System.Collections.Generic;
using System.IO;

namespace JJ.Framework.IO
{
    /// <summary> Might deleting multiple files, while progress would be reported. </summary>
    [PublicAPI]
    public abstract class BulkFileDeleterBase : IBulkFileDeleter
    {
        /// <summary>
        /// Might be overridden to call File.Delete, or call a method that may move the file to the Recycle Bin.
        /// </summary>
        protected abstract void DeleteFile(string filePath);

        /// <inheritdoc cref="BulkFileDeleterBase" />
        public void DeleteFiles(
            IList<string> filePaths,
            Action<string> progressCallback = null,
            Func<bool> cancelCallback = null)
        {
            if (filePaths == null) throw new ArgumentNullException(nameof(filePaths));

            int count = filePaths.Count;
            for (var i = 0; i < count; i++)
            {
                string filePath = filePaths[i];

                // Progress
                decimal percentage = 100m * i / count;
                progressCallback?.Invoke(
                    ResourceFormatter.DeletingFiles_WithPercentage_AndFileName(percentage, Path.GetFileName(filePath)));

                // Cancel
                if (IsCancelled(cancelCallback))
                {
                    progressCallback?.Invoke(CommonResourceFormatter.Cancelled);
                    return;
                }

                // Action
                DeleteFile(filePath);
            }

            progressCallback?.Invoke(ResourceFormatter.DoneDeletingFiles_WithCount(count));
        }

        private static bool IsCancelled(Func<bool> cancelCallback) => cancelCallback?.Invoke() ?? false;
    }
}
