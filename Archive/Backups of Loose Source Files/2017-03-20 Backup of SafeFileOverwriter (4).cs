//using System;
//using System.IO;
//using JetBrains.Annotations;
//using JJ.Framework.Common;
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
//        private readonly string _tempFilePath;
//        private readonly FileStream _tempFileStream;
//        private readonly Stream _destFileStream;

//        // Construction, Destruction

//        public SafeFileOverwriter(string destFilePath)
//        {
//            if (string.IsNullOrEmpty(destFilePath)) throw new NullOrEmptyException(() => destFilePath);

//            _destFileStream = new FileStream(destFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
//            _tempFilePath = GenerateTempFilePath(destFilePath);
//            _tempFileStream = new FileStream(_tempFilePath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read);

//            FileHelper.HideFile(_tempFilePath);
//        }

//        ~SafeFileOverwriter()
//        {
//            Dispose();
//        }

//        public void Dispose()
//        {
//            if (_tempFileStream != null)
//            {
//                _tempFileStream.Dispose();

//                File.Delete(_tempFilePath);
//            }

//            _destFileStream?.Dispose();

//            GC.SuppressFinalize(this);
//        }

//        // ReSharper disable once ConvertToAutoPropertyWhenPossible
//        public FileStream TempStream => _tempFileStream;

//        /// <summary> Overwrites one file with the contents of another file. Retains security settings and custom properties.
//        /// </summary>
//        public void Save()
//        {
//            using (_tempFileStream)
//            {
//                _tempFileStream.Flush();
//                _tempFileStream.Position = 0;

//                using (_destFileStream)
//                {
//                    _destFileStream.SetLength(0);
//                    _tempFileStream.CopyTo(_destFileStream);
//                    _destFileStream.Flush();
//                }
//            }

//            File.Delete(_tempFilePath);
//        }

//        private string GenerateTempFilePath(string destFilePath)
//        {
//            string tempFilePath;
//            do
//            {
//                tempFilePath = destFilePath + "~" + Path.GetRandomFileName().TrimEndUntil(".").TrimEnd('.');
//            }
//            while (File.Exists(tempFilePath));
//            return tempFilePath;
//        }
//    }
//}