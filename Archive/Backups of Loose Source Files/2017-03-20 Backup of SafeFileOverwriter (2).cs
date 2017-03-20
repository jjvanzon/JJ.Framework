//using System;
//using System.IO;
//using JetBrains.Annotations;
//using JJ.Framework.Exceptions;

//namespace JJ.Framework.IO
//{
//    /// <summary>
//    /// This class allows a safe file overwrite,
//    /// by first writing to a temporary file and only when all
//    /// went well, the original file is overwritten.
//    /// The security settings and file attributes and file properties are retained
//    /// as the temp file replaces the original.
//    /// </summary>
//    public class SafeFileOverwriter : IDisposable
//    {
//        private readonly string _destFilePath;
//        private string _tempFilePath;
//        private bool _tempFileIsOpen;
//        [CanBeNull] private Stream _originalFileStream;

//        // Construction, Destruction

//        public SafeFileOverwriter(string destFilePath)
//        {
//            if (destFilePath == null) throw new NullException(() => destFilePath);

//            _destFilePath = destFilePath;
//            if (File.Exists(_destFilePath))
//            {
//                _originalFileStream = new FileStream(_destFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
//            }

//            OpenTempFile();
//        }

//        ~SafeFileOverwriter()
//        {
//            Dispose();
//        }

//        private bool _isDisposed;

//        public void Dispose()
//        {
//            if (_isDisposed) return;
//            _isDisposed = true;

//            Cancel();

//            GC.SuppressFinalize(this);
//        }

//        // FileLock

//        private void UnlockFile()
//        {
//            _originalFileStream?.Dispose();
//            _originalFileStream = null;
//        }

//        // Temp File

//        public FileStream TempFileStream { get; private set; }

//        private void OpenTempFile()
//        {
//            _tempFilePath = GenerateTempFilePath(_destFilePath);
//            TempFileStream = new FileStream(_tempFilePath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read);
//            _tempFileIsOpen = true;

//            FileHelper.HideFile(_tempFilePath);
//        }

//        public void Save()
//        {
//            if (!_tempFileIsOpen) throw new Exception("File already closed.");

//            CloseTempFile();
//            OverwriteFile();
//            DeleteTempFileIfNeeded();
//            UnlockFile();
//        }

//        public void Cancel()
//        {
//            // It is not unlikely that someone might Cancel the saving based on a certain condition 
//            // and then Cancel is called again when disposing.
//            if (!_tempFileIsOpen) return;

//            CloseTempFile();
//            DeleteTempFileIfNeeded();
//            UnlockFile();
//        }

//        private void CloseTempFile()
//        {
//            if (!_tempFileIsOpen) return;

//            TempFileStream.Close();
//            _tempFileIsOpen = false;
//        }

//        private void DeleteTempFileIfNeeded()
//        {
//            if (File.Exists(_tempFilePath))
//            {
//                File.Delete(_tempFilePath);
//            }
//        }

//        // Helpers

//        private string GenerateTempFilePath(string destFilePath)
//        {
//            string tempFilePath;
//            do
//            {
//                tempFilePath = destFilePath + "~" + Path.GetRandomFileName();
//            }
//            while (File.Exists(tempFilePath));
//            return tempFilePath;
//        }

//        /// <summary>
//        /// Overwrites one file with the contents of another file.
//        /// Retains security settings and custom properties.
//        /// </summary>
//        private void OverwriteFile()
//        {
//            // TODO: Why do I make a new temp file stream after I just closed the temporary file's stream?
//            // Why not just keep that temp file stream open?
//            using (Stream tempFileStream = new FileStream(_tempFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
//            {
//                using (Stream destStream = _originalFileStream ?? new FileStream(_destFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
//                {
//                    destStream.Position = 0;
//                    tempFileStream.CopyTo(destStream);
//                }
//            }
//        }
//    }
//}