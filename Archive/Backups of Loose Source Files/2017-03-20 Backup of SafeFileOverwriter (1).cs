//using System;
//using System.IO;
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
//        private readonly bool _hasOriginalFile;
//        private string _tempFilePath;
//        private bool _tempFileIsOpen;

//        /// <summary> nullable </summary>
//        private FileLock _fileLock;

//        // Construction, Destruction

//        public SafeFileOverwriter(string destFilePath)
//        {
//            if (destFilePath == null) throw new NullException(() => destFilePath);

//            _destFilePath = destFilePath;
//            _hasOriginalFile = File.Exists(_destFilePath);

//            LockFile();
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

//        private void LockFile()
//        {
//            if (_hasOriginalFile)
//            {
//                _fileLock = new FileLock(_destFilePath, LockEnum.Write);
//            }
//        }

//        private void UnlockFile()
//        {
//            _fileLock?.Dispose();
//        }

//        // Temp File

//        public FileStream Stream { get; private set; }

//        private void OpenTempFile()
//        {
//            _tempFilePath = GenerateTempFilePath(_destFilePath);
//            Stream = new FileStream(_tempFilePath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read);
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

//            Stream.Close();
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

//        private string GenerateTempFilePath(string originalFilePath)
//        {
//            string folderPath = Path.GetDirectoryName(originalFilePath).TrimEnd('\\'); // Remove slash from root (e.g. @"C:\")
//            string fileName = Path.GetFileName(originalFilePath);
//            string tempFilePath;
//            do
//            {
//                // Putting the random thing at the end of the temp file name
//                // makes a multiple-file write gone bad easier to recover manually
//                // by sorting the files by name, 
//                // deleting the original files that have a temp version
//                // and renaming the temp files to the original file names.
//                // That would complete the file save manually.
//                tempFilePath = folderPath + @"\" + fileName + "~" + Path.GetRandomFileName();
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
//            using (var tempFileStream = new FileStream(_tempFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
//            {
//                Stream destStream;

//                if (_hasOriginalFile)
//                {
//                    destStream = _fileLock.Stream;
//                }
//                else
//                {
//                    destStream = new FileStream(_destFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
//                }

//                using (destStream)
//                {
//                    destStream.Position = 0;
//                    tempFileStream.CopyTo(destStream);
//                }
//            }
//        }
//    }
//}