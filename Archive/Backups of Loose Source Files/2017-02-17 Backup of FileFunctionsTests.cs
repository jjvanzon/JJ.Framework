//using System;
//using System.IO;
//using JJ.Framework.Testing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//// ReSharper disable ImplicitlyCapturedClosure
//// ReSharper disable AccessToModifiedClosure

//namespace JJ.Framework.IO.Tests
//{
//    [TestClass]
//    public class FileFunctionsTests
//    {
//        // Initialization, Clean-Up

//        [TestCleanup]
//        public void Cleanup()
//        {
//            FinalizeFolderPath();
//        }

//        // ClearFolder

//        public void Test_FileFunctions_ClearFolder(Action overloadToTest)
//        {
//            string folderPath = Path.Combine(FolderPath, "temp");
//            string filePath1 = Path.Combine(folderPath, @"temp (1).txt");
//            string filePath2 = Path.Combine(folderPath, @"temp (2).txt");
//            try
//            {
//                Directory.CreateDirectory(folderPath);
//                File.Create(filePath1).Close();
//                File.Create(filePath2).Close();

//                Assert.AreEqual(2, Directory.GetFiles(folderPath).Length, "temp file count");
//                overloadToTest();
//                Assert.AreEqual(0, Directory.GetFiles(folderPath).Length, "temp file count");
//            }
//            finally
//            {
//                if (File.Exists(filePath1)) File.Delete(filePath1);
//                if (File.Exists(filePath2)) File.Delete(filePath2);
//                if (Directory.Exists(folderPath)) Directory.Delete(folderPath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ClearFolder_Path()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            Test_FileFunctions_ClearFolder(() => FileHelper.ClearFolder(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ClearFolder_DirectoryInfo()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            DirectoryInfo directory = new DirectoryInfo(path);
//            Test_FileFunctions_ClearFolder(() => FileHelper.ClearFolder(directory));
//        }

//        // ClearFolderRecursive

//        public void Test_FileFunctions_ClearFolderRecursive(Action overloadToTest)
//        {
//            string file1 = Path.Combine(FolderPath, "File1.txt");
//            string file2 = Path.Combine(FolderPath, "File2.txt");
//            string subFolder1 = Path.Combine(FolderPath, "Subfolder1");
//            string subFolder2 = Path.Combine(FolderPath, "Subfolder2");
//            string subFolder2File1 = Path.Combine(subFolder2, "Subfolder2 file1.txt");
//            string subFolder2File2 = Path.Combine(subFolder2, "Subfolder2 file2.txt");

//            Action cleanup = () =>
//            {
//                if (File.Exists(file1)) File.Delete(file1);
//                if (File.Exists(file2)) File.Delete(file2);
//                if (Directory.Exists(subFolder1)) Directory.Delete(subFolder1);
//                // ReSharper disable once InvertIf
//                if (Directory.Exists(subFolder2))
//                {
//                    if (File.Exists(subFolder2File1)) File.Delete(subFolder2File1);
//                    if (File.Exists(subFolder2File2)) File.Delete(subFolder2File2);
//                    Directory.Delete(subFolder2);
//                }
//            };

//            cleanup();

//            try
//            {
//                // Create structure
//                File.Create(file1).Close();
//                File.Create(file2).Close();
//                Directory.CreateDirectory(subFolder1);
//                Directory.CreateDirectory(subFolder2);
//                File.Create(subFolder2File1).Close();
//                File.Create(subFolder2File2).Close();

//                // AssertHelper exists
//                AssertHelper.IsTrue(() => File.Exists(file1));
//                AssertHelper.IsTrue(() => File.Exists(file2));
//                AssertHelper.IsTrue(() => Directory.Exists(subFolder1));
//                AssertHelper.IsTrue(() => Directory.Exists(subFolder2));
//                AssertHelper.IsTrue(() => File.Exists(subFolder2File1));
//                AssertHelper.IsTrue(() => File.Exists(subFolder2File2));

//                // Call method to test
//                overloadToTest();

//                // AssertHelper not exists
//                AssertHelper.IsFalse(() => File.Exists(file1));
//                AssertHelper.IsFalse(() => File.Exists(file2));
//                AssertHelper.IsFalse(() => Directory.Exists(subFolder1));
//                AssertHelper.IsFalse(() => Directory.Exists(subFolder2));
//                AssertHelper.IsFalse(() => File.Exists(subFolder2File1));
//                AssertHelper.IsFalse(() => File.Exists(subFolder2File2));

//                // AssertHelper directory itself is not removed
//                AssertHelper.IsTrue(() => Directory.Exists(FolderPath));
//            }
//            finally
//            {
//                cleanup();
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ClearFolderRecursive_Path()
//        {
//            Test_FileFunctions_ClearFolderRecursive(() => FileHelper.ClearFolderRecursive(FolderPath));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ClearFolderRecursive_DirectoryInfo()
//        {
//            var directory = new DirectoryInfo(FolderPath);
//            Test_FileFunctions_ClearFolderRecursive(() => FileHelper.ClearFolderRecursive(directory));
//        }

//        // ApplicationPath

//        [TestMethod]
//        public void Test_FileFunctions_ApplicationPath()
//        {
//            string exeName = typeof(FileFunctionsTests).Assembly.ManifestModule.Name;
//            Assert.IsTrue(File.Exists(Path.Combine(FileHelper.ApplicationFolderPath, exeName)));
//        }

//        // IsFolder

//        [TestMethod]
//        public void Test_FileFunctions_IsFolder_True_Existing()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            try
//            {
//                Directory.CreateDirectory(path);
//                AssertHelper.IsTrue(() => FileHelper.IsFolder(path));
//            }
//            finally
//            {
//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsFolder_True_NonExistent()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            DeleteFileOrFolder(path);
//            AssertHelper.IsTrue(() => FileHelper.IsFolder(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsFolder_True_LooksLikeFile_Existent()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                DeleteFileOrFolder(path);
//                Directory.CreateDirectory(path);

//                AssertHelper.IsTrue(() => FileHelper.IsFolder(path));
//            }
//            finally
//            {
//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsFolder_False_ClearlyLooksLikeFile_NonExistent()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");

//            DeleteFileOrFolder(path);

//            AssertHelper.IsFalse(() => FileHelper.IsFolder(path));
//        }


//        [TestMethod]
//        public void Test_FileFunctions_IsFolder_False_HasPeriodButClearlyNotFile()
//        {
//            string path = Path.Combine(FolderPath, "Circle.Framework.Storage.Files");

//            DeleteFileOrFolder(path);

//            AssertHelper.IsFalse(() => FileHelper.IsFolder(path));
//        }

//        // IsFile

//        [TestMethod]
//        public void Test_FileFunctions_IsFile_True_Existing()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(path).Close();

//                AssertHelper.IsTrue(() => FileHelper.IsFile(path));
//            }
//            finally
//            {
//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsFile_True_NonExistent()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            DeleteFileOrFolder(path);
//            AssertHelper.IsTrue(() => FileHelper.IsFile(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsFile_True_LooksLikeFolder_Existing()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            try
//            {
//                DeleteFileOrFolder(path);
//                File.Create(path).Close();
//                AssertHelper.IsTrue(() => FileHelper.IsFile(path));
//            }
//            finally
//            {
//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsFile_False_LooksLikeFolder_NonExistent()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            DeleteFileOrFolder(path);
//            AssertHelper.IsFalse(() => FileHelper.IsFile(path));
//        }

//        // GetFolderSize

//        public void Test_FileFunctions_GetFolderSize(Func<long> overloadToTest)
//        {
//            string folderPath = Path.Combine(FolderPath, "temp");
//            string filePath1 = Path.Combine(FolderPath, @"temp\temp (1).txt");
//            string filePath2 = Path.Combine(FolderPath, @"temp\temp (2).txt");

//            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
//            FileHelper.ClearFolder(folderPath);

//            try
//            {
//                using (var writer = File.CreateText(filePath1))
//                {
//                    writer.Write("1234567890");
//                }

//                using (var writer = File.CreateText(filePath2))
//                {
//                    writer.Write("12345");
//                }

//                long folderSize = overloadToTest();

//                AssertHelper.AreEqual(15, () => folderSize);
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath1);
//                DeleteFileOrFolder(filePath2);
//                DeleteFileOrFolder(folderPath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_GetFolderSize_Path()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            Test_FileFunctions_GetFolderSize(() => FileHelper.GetFolderSize(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_GetFolderSize_DirectoryInfo()
//        {
//            string path = Path.Combine(FolderPath, "temp");
//            Test_FileFunctions_GetFolderSize(() => FileHelper.GetFolderSize(path));
//        }

//        // GetFolderSizeRecursive

//        public void Test_FileFunctions_GetFolderSizeRecursive(Func<long> overloadToTest)
//        {
//            string file1 = Path.Combine(FolderPath, "File1.txt");
//            string file2 = Path.Combine(FolderPath, "File2.txt");
//            string subFolder1 = Path.Combine(FolderPath, "Subfolder1");
//            string subFolder2 = Path.Combine(FolderPath, "Subfolder2");
//            string subFolder2File1 = Path.Combine(subFolder2, "Subfolder2 file1.txt");
//            string subFolder2File2 = Path.Combine(subFolder2, "Subfolder2 file2.txt");

//            Action cleanup = () =>
//            {
//                if (File.Exists(file1)) File.Delete(file1);
//                if (File.Exists(file2)) File.Delete(file2);
//                if (Directory.Exists(subFolder1)) Directory.Delete(subFolder1);
//                // ReSharper disable once InvertIf
//                if (Directory.Exists(subFolder2))
//                {
//                    if (File.Exists(subFolder2File1)) File.Delete(subFolder2File1);
//                    if (File.Exists(subFolder2File2)) File.Delete(subFolder2File2);
//                    Directory.Delete(subFolder2);
//                }
//            };

//            cleanup();

//            try
//            {
//                // Create structure
//                File.WriteAllBytes(file1, new byte[] { 0x10 });
//                File.WriteAllBytes(file2, new byte[] { 0x20, 0x30 });
//                Directory.CreateDirectory(subFolder1);
//                Directory.CreateDirectory(subFolder2);
//                File.WriteAllBytes(subFolder2File1, new byte[] { 0x40, 0x50, 0x60 });
//                File.WriteAllBytes(subFolder2File2, new byte[] { 0x70, 0x80, 0x90, 0xA0 });

//                // AssertHelper exists
//                AssertHelper.IsTrue(() => File.Exists(file1));
//                AssertHelper.IsTrue(() => File.Exists(file2));
//                AssertHelper.IsTrue(() => Directory.Exists(subFolder1));
//                AssertHelper.IsTrue(() => Directory.Exists(subFolder2));
//                AssertHelper.IsTrue(() => File.Exists(subFolder2File1));
//                AssertHelper.IsTrue(() => File.Exists(subFolder2File2));

//                // Call method to test
//                long size = overloadToTest();

//                AssertHelper.AreEqual(10, () => size);
//            }
//            finally
//            {
//                cleanup();
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_GetFolderSizeRecursive_Path()
//        {
//            Test_FileFunctions_GetFolderSizeRecursive(() => FileHelper.GetFolderSizeRecursive(FolderPath));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_GetFolderSizeRecursive_DirectoryInfo()
//        {
//            var directory = new DirectoryInfo(FolderPath);
//            Test_FileFunctions_GetFolderSizeRecursive(() => FileHelper.GetFolderSizeRecursive(directory));
//        }

//        // CountFilesRecursive

//        public void Test_FileFunctions_CountFilesRecursive(Func<int> overloadToTest)
//        {
//            string file1 = Path.Combine(FolderPath, "File1.txt");
//            string file2 = Path.Combine(FolderPath, "File2.txt");
//            string subFolder1 = Path.Combine(FolderPath, "Subfolder1");
//            string subFolder2 = Path.Combine(FolderPath, "Subfolder2");
//            string subFolder2File1 = Path.Combine(subFolder2, "Subfolder2 file1.txt");
//            string subFolder2File2 = Path.Combine(subFolder2, "Subfolder2 file2.txt");

//            Action cleanup = () =>
//            {
//                if (File.Exists(file1)) File.Delete(file1);
//                if (File.Exists(file2)) File.Delete(file2);
//                if (Directory.Exists(subFolder1)) Directory.Delete(subFolder1);
//                // ReSharper disable once InvertIf
//                if (Directory.Exists(subFolder2))
//                {
//                    if (File.Exists(subFolder2File1)) File.Delete(subFolder2File1);
//                    if (File.Exists(subFolder2File2)) File.Delete(subFolder2File2);
//                    Directory.Delete(subFolder2);
//                }
//            };

//            cleanup();

//            try
//            {
//                // Create structure
//                File.Create(file1).Close();
//                File.Create(file2).Close();
//                Directory.CreateDirectory(subFolder1);
//                Directory.CreateDirectory(subFolder2);
//                File.Create(subFolder2File1).Close();
//                File.Create(subFolder2File2).Close();

//                // AssertHelper exists
//                AssertHelper.IsTrue(() => File.Exists(file1));
//                AssertHelper.IsTrue(() => File.Exists(file2));
//                AssertHelper.IsTrue(() => Directory.Exists(subFolder1));
//                AssertHelper.IsTrue(() => Directory.Exists(subFolder2));
//                AssertHelper.IsTrue(() => File.Exists(subFolder2File1));
//                AssertHelper.IsTrue(() => File.Exists(subFolder2File2));

//                // Call method to test
//                int count = overloadToTest();

//                AssertHelper.AreEqual(4, () => count);
//            }
//            finally
//            {
//                cleanup();
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_CountFilesRecursive_Path()
//        {
//            Test_FileFunctions_CountFilesRecursive(() => FileHelper.CountFilesRecursive(FolderPath));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_CountFilesRecursive_DirectoryInfo()
//        {
//            var directory = new DirectoryInfo(FolderPath);
//            Test_FileFunctions_CountFilesRecursive(() => FileHelper.CountFilesRecursive(directory));
//        }

//        // FolderIsEmpty

//        public void Test_FileFunctions_FolderIsEmpty(Func<bool> overloadToTest)
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            // ReSharper disable once JoinDeclarationAndInitializer
//            bool folderIsEmpty;

//            DeleteFileOrFolder(filePath);
//            folderIsEmpty = overloadToTest();
//            AssertHelper.IsTrue(() => folderIsEmpty);

//            try
//            {
//                File.Create(filePath).Close();
//                folderIsEmpty = overloadToTest();
//                AssertHelper.IsFalse(() => folderIsEmpty);
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_FolderIsEmpty_Path()
//        {
//            Test_FileFunctions_FolderIsEmpty(() => FileHelper.FolderIsEmpty(FolderPath));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_FolderIsEmpty_DirectoryInfo()
//        {
//            var directory = new DirectoryInfo(FolderPath);
//            Test_FileFunctions_FolderIsEmpty(() => FileHelper.FolderIsEmpty(directory));
//        }

//        // HideFile, ShowFile

//        public void Test_FileFunctions_HideFile_ShowFile(Action hideFileOverload, Action showFileOverload)
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(path).Close();

//                hideFileOverload();
//                var fileInfo1 = new FileInfo(path);
//                AssertHelper.AreEqual(FileAttributes.Archive | FileAttributes.Hidden, () => fileInfo1.Attributes);

//                showFileOverload();
//                var fileInfo2 = new FileInfo(path);
//                AssertHelper.AreEqual(FileAttributes.Archive, () => fileInfo2.Attributes);
//            }
//            finally
//            {
//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_HideFile_ShowFile_Path()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            Test_FileFunctions_HideFile_ShowFile(
//                () => FileHelper.HideFile(path),
//                () => FileHelper.ShowFile(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_HideFile_ShowFile_FileInfo()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            var file = new FileInfo(path);
//            Test_FileFunctions_HideFile_ShowFile(
//                () => FileHelper.HideFile(file),
//                () => FileHelper.ShowFile(file));
//        }

//        // IsHidden

//        public void Test_FileFunctions_IsHidden(Func<bool> overloadToTest)
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(path).Close();
//                var fileInfo = new FileInfo(path);

//                // ReSharper disable once JoinDeclarationAndInitializer
//                bool isHidden;
//                isHidden = overloadToTest();
//                AssertHelper.IsFalse(() => isHidden);

//                fileInfo.Attributes |= FileAttributes.Hidden;
//                isHidden = overloadToTest();
//                AssertHelper.IsTrue(() => isHidden);
//            }
//            finally
//            {
//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsHidden_Path()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            Test_FileFunctions_IsHidden(() => FileHelper.IsHidden(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsHidden_FileInfo()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            Test_FileFunctions_IsHidden(() => FileHelper.IsHidden(new FileInfo(path)));
//        }

//        // MakeReadOnly, MakeWritable

//        public void Test_FileFunctions_MakeReadOnly_MakeWritable(Action makeReadOnlyOverload, Action makeWritableOverload)
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(path).Close();

//                makeReadOnlyOverload();
//                var fileInfo1 = new FileInfo(path);
//                AssertHelper.AreEqual(FileAttributes.Archive | FileAttributes.ReadOnly, () => fileInfo1.Attributes);

//                makeWritableOverload();
//                var fileInfo2 = new FileInfo(path);
//                AssertHelper.AreEqual(FileAttributes.Archive, () => fileInfo2.Attributes);
//            }
//            finally
//            {
//                var fileInfo = new FileInfo(path);
//                fileInfo.Attributes &= ~FileAttributes.ReadOnly;
//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_MakeReadOnly_MakeWritable_Path()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            Test_FileFunctions_MakeReadOnly_MakeWritable(
//                () => FileHelper.MakeReadOnly(path),
//                () => FileHelper.MakeWritable(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_MakeReadOnly_MakeWritable_FilePath()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            var file = new FileInfo(path);
//            Test_FileFunctions_MakeReadOnly_MakeWritable(
//                () => FileHelper.MakeReadOnly(file),
//                () => FileHelper.MakeWritable(file));
//        }

//        // IsReadOnly

//        public void Test_FileFunctions_IsReadOnly(Func<bool> overloadToTest)
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(path).Close();
//                var fileInfo = new FileInfo(path);

//                // ReSharper disable once JoinDeclarationAndInitializer
//                bool isReadOnly;
//                isReadOnly = overloadToTest();
//                AssertHelper.IsFalse(() => isReadOnly);

//                fileInfo.Attributes |= FileAttributes.ReadOnly;
//                isReadOnly = overloadToTest();
//                AssertHelper.IsTrue(() => isReadOnly);
//            }
//            finally
//            {
//                var fileInfo = new FileInfo(path);
//                fileInfo.Attributes &= ~FileAttributes.ReadOnly;

//                DeleteFileOrFolder(path);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsReadOnly_Path()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            Test_FileFunctions_IsReadOnly(() => FileHelper.IsReadOnly(path));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_IsReadOnly_FileInfo()
//        {
//            string path = Path.Combine(FolderPath, "temp.txt");
//            Test_FileFunctions_IsReadOnly(() => FileHelper.IsReadOnly(new FileInfo(path)));
//        }

//        // ReadAllText

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllText_OriginalRequiresWriteAccess()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(filePath).Close();
//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    AssertHelper.ThrowsException<IOException>(() => { File.ReadAllText(filePath); });
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllText_RequireWriteAccess_False()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(filePath).Close();
//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    FileHelper.ReadAllText(filePath, requireWriteAccess: false);
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllText_RequireWriteAccess_True()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(filePath).Close();
//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    // ReSharper disable once RedundantArgumentDefaultValue
//                    AssertHelper.ThrowsException<IOException>(() => { FileHelper.ReadAllText(filePath, requireWriteAccess: true); });
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllText_RequireWriteAccess_Default_True()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                File.Create(filePath).Close();
//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    AssertHelper.ThrowsException<IOException>(() => { FileHelper.ReadAllText(filePath); });
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        // ReadAllLines

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllLines_OriginalRequiresWriteAccess()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                string[] lines = { "Line 1", "Line 2" };
//                File.WriteAllLines(filePath, lines);

//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    AssertHelper.ThrowsException<IOException>(() => { File.ReadAllLines(filePath); });
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllLines_RequireWriteAccess_False()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                string[] lines = { "Line 1", "Line 2" };
//                File.WriteAllLines(filePath, lines);

//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    FileHelper.ReadAllLines(filePath, requireWriteAccess: false);
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllLines_RequireWriteAccess_True()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                string[] lines = { "Line 1", "Line 2" };
//                File.WriteAllLines(filePath, lines);

//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    AssertHelper.ThrowsException<IOException>(() =>
//                    {
//                        // ReSharper disable once RedundantArgumentDefaultValue
//                        FileHelper.ReadAllLines(filePath, requireWriteAccess: true);
//                    });
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ReadAllLines_RequireWriteAccess_Default_True()
//        {
//            string filePath = Path.Combine(FolderPath, "temp.txt");
//            try
//            {
//                string[] lines = { "Line 1", "Line 2" };
//                File.WriteAllLines(filePath, lines);

//                using (new FileLock(filePath, LockEnum.Write))
//                {
//                    AssertHelper.ThrowsException<IOException>(() =>
//                    {
//                        FileHelper.ReadAllLines(filePath);
//                    });
//                }
//            }
//            finally
//            {
//                DeleteFileOrFolder(filePath);
//            }
//        }

//        // Condition Violations

//        [TestMethod]
//        public void Test_FileFunctions_ConditionViolations_PathNullOrEmpty()
//        {
//            Action[] folderPathActions = {
//                () => FileHelper.ClearFolder((string)null),
//                () => FileHelper.ClearFolder(""),
//                () => FileHelper.ClearFolderRecursive((string)null),
//                () => FileHelper.ClearFolderRecursive(""),
//                () => FileHelper.GetFolderSize((string)null),
//                () => FileHelper.GetFolderSize(""),
//                () => FileHelper.GetFolderSizeRecursive((string)null),
//                () => FileHelper.GetFolderSizeRecursive(""),
//                () => FileHelper.CountFilesRecursive((string)null),
//                () => FileHelper.CountFilesRecursive(""),
//                () => FileHelper.FolderIsEmpty((string)null),
//                () => FileHelper.FolderIsEmpty("")};

//            foreach (var action in folderPathActions)
//            {
//                AssertHelper.ThrowsException(() => action(), "folderPath is null or empty.");
//            }

//            Action[] filePathActions = {
//                () => FileHelper.IsHidden((string)null),
//                () => FileHelper.IsHidden(""),
//                () => FileHelper.MakeReadOnly((string)null),
//                () => FileHelper.MakeReadOnly(""),
//                () => FileHelper.MakeWritable((string)null),
//                () => FileHelper.MakeWritable(""),
//                () => FileHelper.IsReadOnly((string)null),
//                () => FileHelper.IsReadOnly(""),
//                () => FileHelper.HideFile((string)null),
//                () => FileHelper.HideFile(""),
//                () => FileHelper.ShowFile((string)null),
//                () => FileHelper.ShowFile("")};

//            foreach (var action in filePathActions)
//            {
//                AssertHelper.ThrowsException(() => action(), "filePath is null or empty.");
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ConditionViolations_NotExists()
//        {
//            string path = Path.Combine(FolderPath, Guid.NewGuid().ToString());

//            Action[] folderPathActions = {
//                () => FileHelper.ClearFolder(path),
//                () => FileHelper.ClearFolderRecursive(path),
//                () => FileHelper.GetFolderSize(path),
//                () => FileHelper.GetFolderSizeRecursive(path),
//                () => FileHelper.CountFilesRecursive(path),
//                () => FileHelper.FolderIsEmpty(path)};

//            foreach (var action in folderPathActions)
//            {
//                AssertHelper.ThrowsException(
//                    () => action(),
//                    $"Folder '{path}' does not exist.");
//            }

//            Action[] filePathActions = {
//                () => FileHelper.HideFile(path),
//                () => FileHelper.ShowFile(path),
//                () => FileHelper.IsHidden(path),
//                () => FileHelper.MakeReadOnly(path),
//                () => FileHelper.MakeWritable(path),
//                () => FileHelper.IsReadOnly(path)};

//            foreach (var action in filePathActions)
//            {
//                AssertHelper.ThrowsException(
//                    () => action(),
//                    $"File '{path}' does not exist.");
//            }
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ConditionViolations_FileSystemInfoNull()
//        {
//            Action[] directoryActions = {
//                () => FileHelper.ClearFolder((DirectoryInfo)null),
//                () => FileHelper.ClearFolderRecursive((DirectoryInfo)null),
//                () => FileHelper.GetFolderSize((DirectoryInfo)null),
//                () => FileHelper.GetFolderSizeRecursive((DirectoryInfo)null),
//                () => FileHelper.CountFilesRecursive((DirectoryInfo)null),
//                () => FileHelper.FolderIsEmpty((DirectoryInfo)null)};

//            foreach (var action in directoryActions)
//            {
//                AssertHelper.ThrowsException(
//                    () => action(),
//                    "directoryInfo is null.");
//            }

//            Action[] fileActions = {
//                () => FileHelper.HideFile((FileInfo)null),
//                () => FileHelper.ShowFile((FileInfo)null),
//                () => FileHelper.IsHidden((FileInfo)null),
//                () => FileHelper.MakeReadOnly((FileInfo)null),
//                () => FileHelper.MakeWritable((FileInfo)null),
//                () => FileHelper.IsReadOnly((FileInfo)null)};

//            foreach (var action in fileActions)
//            {
//                AssertHelper.ThrowsException(
//                    () => action(),
//                    "fileInfo is null.");
//            }
//        }

//        // Relative to absolute and back

//        [TestMethod]
//        public void Test_FileFunctions_ToAbsolutePath_ToRelativePath()
//        {
//            const string originalRelativePath = @"SubFolder2\..\SubFolder2\File.txt";

//            string absolutePath = FileHelper.ToAbsolutePath(@"SubFolder1", originalRelativePath);
//            string expectedAbsolutePath = Path.Combine(Environment.CurrentDirectory, @"SubFolder1", @"SubFolder2\File.txt");
//            AssertHelper.AreEqual(expectedAbsolutePath, () => absolutePath);

//            string relativePath = FileHelper.ToRelativePath(@"SubFolder1\..\SubFolder1", absolutePath);
//            const string expectedRelativePath = @"SubFolder2\File.txt";
//            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ToAbsolutePath_BasePathNull()
//        {
//            string absolutePath = FileHelper.ToAbsolutePath("Folder");
//            string expectedAbsolutePath = Path.Combine(Environment.CurrentDirectory, "Folder");
//            AssertHelper.AreEqual(expectedAbsolutePath, () => absolutePath);
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ToAbsolutePath_RelativePathNull()
//        {
//            string basePath = Environment.CurrentDirectory;
//            string absolutePath = FileHelper.ToAbsolutePath(basePath, null);
//            AssertHelper.AreEqual(basePath, () => absolutePath);
//        }

//        [TestMethod]
//        public void Test_FileFunctions_RelativePath_BasePathNull()
//        {
//            string relativePath = FileHelper.ToRelativePath("SubFolder");
//            const string expectedRelativePath = "SubFolder";
//            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ToRelativePath_AbsolutePathNull()
//        {
//            string relativePath = FileHelper.ToRelativePath("BaseSubFolder", null);
//            const string expectedRelativePath = "";
//            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ToRelativePath_OverloadWithoutBasePath()
//        {
//            string absolutePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Folder", "File.txt"));
//            const string expectedRelativePath = @"Folder\File.txt";
//            string relativePath = FileHelper.ToRelativePath(absolutePath);
//            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
//        }

//        [TestMethod]
//        public void Test_FileFunctions_PathsAreEqual()
//        {
//            string absolutePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Folder"));
//            string relativePath = FileHelper.ToRelativePath(absolutePath);
//            AssertHelper.IsTrue(() => FileHelper.PathsAreEqual(absolutePath, relativePath));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_PathsAreEqual_False()
//        {
//            string absolutePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Folder"));
//            string relativePath = FileHelper.ToRelativePath(absolutePath);

//            // Change one of the paths.
//            absolutePath = Path.Combine(absolutePath, "Folder2");

//            AssertHelper.IsFalse(() => FileHelper.PathsAreEqual(absolutePath, relativePath));
//        }

//        [TestMethod]
//        public void Test_FileFunctions_ToAbsolutePath_OverloadWithSingleStringParameter()
//        {
//            Assert.Inconclusive();
//        }

//        // Helpers

//        public string FolderPath { get; } = InitializeFolderPath();

//        private static string InitializeFolderPath()
//        {
//            string subFolderName = $"{typeof(FileFunctionsTests).Name}_{Guid.NewGuid()}";
//            string fullPath = Path.GetFullPath(subFolderName);
//            Directory.CreateDirectory(fullPath);
//            return fullPath;
//        }

//        private void FinalizeFolderPath()
//        {
//            // ReSharper disable once InvertIf
//            if (Directory.Exists(FolderPath))
//            {
//                FileHelper.ClearFolder(FolderPath);
//                Directory.Delete(FolderPath);
//            }
//        }

//        private void DeleteFileOrFolder(string path)
//        {
//            if (File.Exists(path)) File.Delete(path);
//            if (Directory.Exists(path)) Directory.Delete(path);
//        }
//    }
//}
