using System;
using System.IO;
using System.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.IO.Tests
{
    [TestClass]
    public class FileLockTests
    {
        [TestMethod]
        public void Test_FileLock_ConditionViolation_PathNullOrEmpty()
        {
            AssertHelper.ThrowsException(
                () => new FileLock((string)null, LockEnum.None),
                "filePath is null or empty.");

            AssertHelper.ThrowsException(
                () => new FileLock("", LockEnum.None),
                "filePath is null or empty.");
        }

        [TestMethod]
        public void Test_FileLock_ConditionViolation_FileExistsFalse()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());

            if (File.Exists(tempFilePath)) File.Delete(tempFilePath);

            AssertHelper.ThrowsException(
                () => new FileLock(tempFilePath, LockEnum.None),
                $"File '{tempFilePath}' does not exist.");
        }

        [TestMethod]
        public void Test_FileLock_Construct_WithNoLock()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (new FileLock(tempFilePath, LockEnum.None))
                {
                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_Construct_WithReadLock()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                AssertFileCanBeRead(tempFilePath);
                AssertFileCanBeWritten(tempFilePath);

                using (new FileLock(tempFilePath, LockEnum.Read))
                {
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_Construct_WithWriteLock()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                AssertFileCanBeRead(tempFilePath);
                AssertFileCanBeWritten(tempFilePath);

                using (new FileLock(tempFilePath, LockEnum.Write))
                {
                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }

                AssertFileCanBeRead(tempFilePath);
                AssertFileCanBeWritten(tempFilePath);
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_ChangeLock_NoneToRead()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.None))
                {
                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);

                    fileLock.LockEnum = LockEnum.Read;

                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_ChangeLock_NoneToWrite()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.None))
                {
                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);

                    fileLock.LockEnum = LockEnum.Write;

                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_ChangeLock_ReadToNone()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.Read))
                {
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));

                    fileLock.LockEnum = LockEnum.None;

                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_ChangeLock_ReadToWrite()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.Read))
                {
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));

                    fileLock.LockEnum = LockEnum.Write;

                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_ChangeLock_WriteToNone()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.Write))
                {
                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));

                    fileLock.LockEnum = LockEnum.None;

                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_ChangeLock_WriteToRead()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.Write))
                {
                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));

                    fileLock.LockEnum = LockEnum.Read;

                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_ChangeLock()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (FileLock fileLock = new FileLock(tempFilePath, LockEnum.None))
                {
                    // Check no lock
                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);

                    // Change lock from None to Write
                    fileLock.LockEnum = LockEnum.Write;
                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));

                    // Change lock from Write to None
                    fileLock.LockEnum = LockEnum.None;
                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);

                    // Change lock from None to Read
                    fileLock.LockEnum = LockEnum.Read;
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));

                    // Change lock from Read to None
                    fileLock.LockEnum = LockEnum.None;
                    AssertFileCanBeRead(tempFilePath);
                    AssertFileCanBeWritten(tempFilePath);

                    // Change lock from Read to Write
                    fileLock.LockEnum = LockEnum.Read;
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                    fileLock.LockEnum = LockEnum.Write;
                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));

                    // Change lock from Write to Read
                    fileLock.LockEnum = LockEnum.Write;
                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                    fileLock.LockEnum = LockEnum.Read;
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_FileLockException_Read_UponConstruction()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (File.Open(tempFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    AssertHelper.ThrowsException<FileLockException>(
                        () =>
                        {
                            using (new FileLock(tempFilePath, LockEnum.Read))
                            { }
                        },
                        "Failed to lock file.");
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_FileLockException_Write_UponConstruction()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (File.Open(tempFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    AssertHelper.ThrowsException<FileLockException>(
                        () =>
                        {
                            using (new FileLock(tempFilePath, LockEnum.Write))
                            { }
                        },
                        "Failed to lock file.");
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_FileLockException_Read_UponLockPromotion()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (File.Open(tempFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    using (var fileLock = new FileLock(tempFilePath, LockEnum.None))
                    {
                        AssertHelper.ThrowsException<FileLockException>(
                            // ReSharper disable once AccessToDisposedClosure
                            () => fileLock.LockEnum = LockEnum.Read,
                            "Failed to lock file.");
                    }
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_FileLockException_Write_UponLockPromotion()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (File.Open(tempFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var fileLock = new FileLock(tempFilePath, LockEnum.Write))
                    {
                        AssertHelper.ThrowsException<FileLockException>(
                            // ReSharper disable once AccessToDisposedClosure
                            () => fileLock.LockEnum = LockEnum.Read,
                            "Failed to lock file.");
                    }
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_Stream_Write()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.Write))
                {
                    fileLock.Stream.Write(new byte[] { 0x10, 0x20 }, 0, 2);
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_Stream_Read()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.Write))
                {
                    byte[] bytes = { 0x10, 0x20 };
                    fileLock.Stream.Write(bytes, 0, 2);
                    fileLock.Stream.Read(bytes, 0, 2);
                    AssertHelper.AreEqual(0x10, () => bytes[0]);
                    AssertHelper.AreEqual(0x20, () => bytes[1]);
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_Disposal()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (new FileLock(tempFilePath, LockEnum.Read))
                {
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }

                AssertFileCanBeRead(tempFilePath);
                AssertFileCanBeWritten(tempFilePath);

                using (new FileLock(tempFilePath, LockEnum.Write))
                {
                    AssertFileCanBeRead(tempFilePath);
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }

                AssertFileCanBeRead(tempFilePath);
                AssertFileCanBeWritten(tempFilePath);
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_Constructor_WithFileInfo()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                var fileInfo = new FileInfo(tempFilePath);

                using (new FileLock(fileInfo, LockEnum.Read))
                {
                    AssertHelper.ThrowsException(() => AssertFileCanBeRead(tempFilePath));
                    AssertHelper.ThrowsException(() => AssertFileCanBeWritten(tempFilePath));
                }

                AssertFileCanBeRead(tempFilePath);
                AssertFileCanBeWritten(tempFilePath);
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_DetermineLock()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                CreateTempFile(tempFilePath);

                using (new FileLock(tempFilePath, LockEnum.None))
                {
                    AssertHelper.AreEqual(LockEnum.None, () => FileLock.DetermineLock(tempFilePath));
                }

                using (new FileLock(tempFilePath, LockEnum.Read))
                {
                    AssertHelper.AreEqual(LockEnum.Read, () => FileLock.DetermineLock(tempFilePath));
                }

                using (new FileLock(tempFilePath, LockEnum.Write))
                {
                    AssertHelper.AreEqual(LockEnum.Write, () => FileLock.DetermineLock(tempFilePath));
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        [TestMethod]
        public void Test_FileLock_DetermineLock_ConditionViolation_PathNullOrEmpty()
        {
            AssertHelper.ThrowsException(
                () => FileLock.DetermineLock(null),
                "filePath is null or empty.");

            AssertHelper.ThrowsException(
                () => FileLock.DetermineLock(""),
                "filePath is null or empty.");
        }

        [TestMethod]
        public void Test_FileLock_DetermineLock_ConditionViolation_FileExistsFalse()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());

            if (File.Exists(tempFilePath)) File.Delete(tempFilePath);

            AssertHelper.ThrowsException(
                () => FileLock.DetermineLock(tempFilePath),
                $"File '{tempFilePath}' does not exist.");
        }

        [TestMethod]
        public void Test_FileLock_SwitchingLockRetainsStreamPosition()
        {
            string tempFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());

            try
            {
                CreateTempFile(tempFilePath);

                using (var fileLock = new FileLock(tempFilePath, LockEnum.Write))
                {
                    fileLock.Stream.Write(new byte[] { 0x10, 0x20, 0x30 }, 0, 3);
                    // ReSharper disable once AccessToDisposedClosure
                    AssertHelper.AreEqual(3, () => fileLock.Stream.Position);

                    fileLock.LockEnum = LockEnum.Read;
                    // ReSharper disable once AccessToDisposedClosure
                    AssertHelper.AreEqual(3, () => fileLock.Stream.Position);

                    fileLock.LockEnum = LockEnum.Write;
                    // ReSharper disable once AccessToDisposedClosure
                    AssertHelper.AreEqual(3, () => fileLock.Stream.Position);
                }
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        // File Helpers

        private void CreateTempFile(string filePath)
        {
            File.Create(filePath).Close();
        }

        private void DeleteTempFile(string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }

        private void AssertFileCanBeRead(string filePath)
        {
            File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite).Close();
        }

        private void AssertFileCanBeWritten(string filePath)
        {
            File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite).Close();
        }
    }
}