using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using JJ.Framework.Common;
using JJ.Framework.Existence.Core;
using JJ.Framework.Text.Core;
using static System.AppDomain;

namespace JJ.Framework.IO.Core
{
    public static class FileWishes
    {
        private const int DEFAULT_MAX_EXTENSION_LENGTH = 8;
        
        /// <summary>
        /// If the originalFilePath already exists,
        /// a higher and higher number is inserted into the file name 
        /// until a file name is encountered that does not exist.
        /// Then that file path is returned.
        /// </summary>
        /// <param name="originalFilePath">
        /// The path to a file name, that does not yet have a number in it.
        /// </param>
        public static string GetNumberedFilePath(
            string originalFilePath,
            string numberPrefix        = " (",
            string numberFormatString  = "#",
            string numberSuffix        = ")",
            bool   mustNumberFirstFile = false,
            int    maxExtensionLength  = DEFAULT_MAX_EXTENSION_LENGTH)
        {
            (string filePathFirstPart, int number, string filePathLastPart) =
                GetNumberedFilePathParts(originalFilePath, numberPrefix, numberSuffix, mustNumberFirstFile, maxExtensionLength);
            
            if (!mustNumberFirstFile && !File.Exists(originalFilePath))
            {
                return originalFilePath;
            }
            
            string filePath;
            do
            {
                filePath = $"{filePathFirstPart}{number.ToString(numberFormatString)}{filePathLastPart}";
                number++;
            }
            while (File.Exists(filePath));
            
            return filePath;
        }
        
        private static readonly object _createSafeFileStreamLock = new object();
        private static readonly Mutex _createSafeFileStreamMutex = CreateMutex();
        private static Mutex CreateMutex()
        {
            var mutex = new Mutex(false, "Global\\JJFrameworkIO_CreateSafeFileStreamMutex2_7f64fd76542045bb98c2e28a44d2df25");
            
            // Ensure it's released when the process exits.
            CurrentDomain.ProcessExit += (s, e) =>
            {
                //if (mutex == null)
                //{
                //    return;
                //}

                try
                {
                    // Release Mutex in case it got abandoned.
                    mutex.ReleaseMutex();
                }
                catch
                {
                    // If it didn't get abandoned, ReleaseMutex probably fails.
                }
                mutex.Dispose();
            };

            return mutex;
        }
        
        /// <summary>
        /// If the originalFilePath already exists,
        /// a higher and higher number is inserted into the file name 
        /// until a file name is encountered that does not exist.
        /// Then a file stream is returned for writing, so that
        /// the file immediately locks.
        /// Be sure to dispose the stream when you're done,
        /// so the file lock is released.
        /// </summary>
        /// <param name="originalFilePath">
        /// The absolute path to a file name, that does not yet have a number in it.
        /// </param>
        public static (string filePath, FileStream) CreateSafeFileStream(
            string originalFilePath,
            string numberPrefix        = " (",
            string numberFormatString  = "#",
            string numberSuffix        = ")",
            bool   mustNumberFirstFile = false,
            int    maxExtensionLength  = 8)
        {
            (string filePathFirstPart, int number, string filePathLastPart) =
                GetNumberedFilePathParts(originalFilePath, numberPrefix, numberSuffix, mustNumberFirstFile, maxExtensionLength);
            
            lock (_createSafeFileStreamLock)
            {
                //bool isLocked = !_createSafeFileStreamMutex.WaitOne(0);
                //if (isLocked) throw new Exception(nameof(_createSafeFileStreamMutex) + $" {_createSafeFileStreamMutex} already locked.");

                _createSafeFileStreamMutex.WaitOne();
                try
                {
                    string filePath = originalFilePath;
                    
                    if (mustNumberFirstFile || File.Exists(filePath))
                    {
                        do
                        {
                            filePath = $"{filePathFirstPart}{number.ToString(numberFormatString)}{filePathLastPart}";
                            number++;
                        }
                        while (File.Exists(filePath));
                    }
                    
                    return (filePath, new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read));
                }
                //catch (AbandonedMutexException ex)
                //{
                //    Console.WriteLine($"{nameof(AbandonedMutexException)}! Mutex was held by a dead thread. {ex.Message}");
                //    throw;
                //}
                finally
                {
                    _createSafeFileStreamMutex.ReleaseMutex();
                }
            }
        }
        
        /// <summary>
        /// Splits the original file path into three parts: the first part of the file path, 
        /// the initial number to be used for numbering, and the last part of the file path.
        /// This method is used to generate a new file path by inserting a number into the file name 
        /// if the original file path already exists.
        /// </summary>
        /// <param name="originalFilePath">The path to a file name that does not yet have a number in it.</param>
        /// <param name="numberPrefix">The prefix to be used before the number in the file name.</param>
        /// <param name="numberSuffix">The suffix to be used after the number in the file name.</param>
        /// <param name="mustNumberFirstFile">
        /// A boolean indicating whether the first file should be numbered. 
        /// If true, numbering starts from 1; otherwise, it starts from 2.
        /// </param>
        /// <returns>
        /// A tuple containing three parts: 
        /// - The first part of the file path, which includes the directory and the file name up to the number prefix.
        /// - The initial number to be used for numbering.
        /// - The last part of the file path, which includes the number suffix and the file extension.
        /// </returns>
        public static (string filePathFirstPart, int number, string filePathLastPart)
            GetNumberedFilePathParts(
                string originalFilePath,
                string numberPrefix        = " (",
                string numberSuffix        = ")",
                bool   mustNumberFirstFile = false,
                int    maxExtensionLength  = DEFAULT_MAX_EXTENSION_LENGTH)
        {
            if (string.IsNullOrEmpty(originalFilePath)) throw new Exception("originalFilePath is null or empty.");
            
            string folderPath               = Path.GetDirectoryName(originalFilePath)?.TrimEnd('\\'); // Remove slash from root (e.g. @"C:\")
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilePath);
            string fileExtension            = GetExtension(originalFilePath, maxExtensionLength);
            string separator                = !string.IsNullOrEmpty(folderPath) ? "\\" : "";
            
            string filePathFirstPart = $"{folderPath}{separator}{fileNameWithoutExtension}{numberPrefix}";
            int    number            = mustNumberFirstFile ? 1 : 2;
            string filePathLastPart  = $"{numberSuffix}{fileExtension}";
            return (filePathFirstPart, number, filePathLastPart);
        }
        
        public static string SanitizeFilePath(string filePath, string badCharReplacement = "-")
        {
            // Crashing a sanitize on an empty string seems a bit harsh.
            if (string.IsNullOrWhiteSpace(filePath)) return filePath;
            
            var forbiddenCharacters = Path.GetInvalidFileNameChars().ToHashSet();
            
            // Allow slash and colon (but not wildcards)
            forbiddenCharacters.Remove('\\');
            forbiddenCharacters.Remove('/');
            forbiddenCharacters.Remove(':');
            
            string sanitizedFilePath = new string(
                filePath.SelectMany(chr => forbiddenCharacters.Contains(chr) ? badCharReplacement : $"{chr}")
                        .ToArray());
            
            sanitizedFilePath = sanitizedFilePath.Trim(badCharReplacement);
            
            return sanitizedFilePath;
        }
        
        public static string GetFileNameWithoutExtension(string filePath, int maxExtensionLength)
        {
            if (!FilledInWishes.Has(filePath)) return filePath;
            string extension = Path.GetExtension(filePath);
            if (extension.Length > maxExtensionLength) return filePath;
            string fileNameWithoutExtension = filePath.CutRight(extension);
            return fileNameWithoutExtension;
        }
        
        public static string GetExtension(string filePath, int maxExtensionLength)
        {
            if (!FilledInWishes.Has(filePath)) return filePath;
            string extension = Path.GetExtension(filePath);
            if (extension.Length > maxExtensionLength) return "";
            return extension;
        }
        
        public static bool HasExtension(string filePath, int maxExtensionLength)
        {
            if (!FilledInWishes.Has(filePath)) return false;
            string extension = GetExtension(filePath, maxExtensionLength);
            if (extension.Length > maxExtensionLength) return false;
            return true;
        }
        
        /// <summary>
        /// If the file actually exists, true is returned.
        /// If it exists as a directory, false is returned.
        /// If the value contains invalid path characters, false is returned.
        /// Otherwise, it returns true if the path has an extension.
        /// </summary>
        public static bool IsFile(string path, int maxExtensionLength = DEFAULT_MAX_EXTENSION_LENGTH)
        {
            if (!FilledInWishes.Has(path)) return false;
            if (File.Exists(path)) return true;
            if (Directory.Exists(path)) return false;
            if (path.Contains(Path.GetInvalidPathChars())) return false;
            string extension = Path.GetExtension(path);
            if (string.IsNullOrEmpty(extension)) return false;
            return extension.Length <= maxExtensionLength;
        }
    }
}