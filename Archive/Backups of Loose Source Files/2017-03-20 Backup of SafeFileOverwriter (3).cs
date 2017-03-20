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
//        private readonly string _tempFilePath;
//        [CanBeNull] private Stream _originalFileStream;

//        // Construction, Destruction

//        public SafeFileOverwriter(string destFilePath)
//        {
//            if (string.IsNullOrEmpty(destFilePath)) throw new NullOrEmptyException(() => destFilePath);

//            _destFilePath = destFilePath;

//            if (File.Exists(_destFilePath))
//            {
//                _originalFileStream = new FileStream(_destFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
//            }

//            _tempFilePath = GenerateTempFilePath(_destFilePath);

//            TempFileStream = new FileStream(_tempFilePath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read);

//            FileHelper.HideFile(_tempFilePath);
//        }

//        ~SafeFileOverwriter()
//        {
//            Dispose();
//        }

//        public void Dispose()
//        {
//            if (TempFileStream != null)
//            {
//                TempFileStream.Close();
//                File.Delete(_tempFilePath);
//            }

//            if (_originalFileStream != null)
//            {
//                _originalFileStream.Dispose();
//                _originalFileStream = null;
//            }

//            GC.SuppressFinalize(this);
//        }

//        // Temp File

//        public FileStream TempFileStream { get; }

//        public void Save()
//        {
//            TempFileStream.Close();
//            OverwriteFile();
//            File.Delete(_tempFilePath);
//            Dispose();
//        }

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