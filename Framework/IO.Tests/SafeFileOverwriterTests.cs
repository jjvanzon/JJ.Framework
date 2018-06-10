using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.IO.Tests
{
	[TestClass]
	public class SafeFileOverwriterTests
	{
		/// <summary>
		/// Originally these tests were not thread safe, when 
		/// ported from a code base from 2012.
		/// They all reuse the same temp file name.
		/// It would be a ton of work to refactor so that each test uses its own unique file.
		/// That is why we just put a lock around each test.
		/// TODO: Low priority: make each test use and clean up its own files.
		/// </summary>
		private static readonly object _testLock = new object();

		public SafeFileOverwriterTests()
		{
			InitializeFolderPath();
			InitializeFilePath();
		}

		[TestCleanup]
		public void Cleanup() => FinalizeFolderPath();

	    [TestMethod]
		public void Test_SafeFileOverwriter_Example()
		{
			lock (_testLock)
			{
				string filePath = Path.Combine(_folderPath, "test.txt");

				using (var safeFileOverwriter = new SafeFileOverwriter(filePath))
				{
					using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
					{
						writer.WriteLine("This is the new file.");
					}

					safeFileOverwriter.Save();
				}

				// Clean up
				File.Delete(filePath);
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_ConditionViolation_FilePathNullOrEmpty()
		{
			lock (_testLock)
			{
				AssertHelper.ThrowsException(
					() => new SafeFileOverwriter(null),
					"destFilePath is null or empty.");

				AssertHelper.ThrowsException(
					() => new SafeFileOverwriter(""),
					"destFilePath is null or empty.");
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Construction_LockFile()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					using (new SafeFileOverwriter(_filePath))
					{
						const LockEnum expectedLockEnum = LockEnum.Write;
						AssertHelper.AreEqual(expectedLockEnum, () => FileLock.DetermineLock(_filePath));
					}

					AssertHelper.AreEqual(LockEnum.None, () => FileLock.DetermineLock(_filePath));
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_ExceptionWhenFileAlreadyLocked()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					using (new FileLock(_filePath, LockEnum.Write))
					{
						AssertHelper.ThrowsException(() => new SafeFileOverwriter(_filePath));
					}
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_ExceptionWhenFileReadOnly()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();
					FileHelper.MakeReadOnly(_filePath);

					AssertHelper.ThrowsException(() => new SafeFileOverwriter(_filePath));
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Construction_OpenTempFile()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					// AssertHelper that only the original file is there.
					AssertHelper.IsTrue(() => OnlyOriginalFileExists());

					using (new SafeFileOverwriter(_filePath))
					{
						// Assert temp file exists.
						AssertHelper.IsTrue(() => OriginalFileAndTempFileExist());

						// Get the temp file
						FileInfo tempFile = GetTempFileInfo();
						string tempFilePath = tempFile.FullName;

						// Check if it is locked.
						const LockEnum expectedLock = LockEnum.Write;
						LockEnum actualLock = FileLock.DetermineLock(tempFilePath);
						Assert.AreEqual(expectedLock, actualLock, "LockEnum");

						// Check if it is hidden.
						Assert.IsTrue(FileHelper.IsHidden(tempFilePath), "IsHidden");
					}
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_TempStream()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.Write(NEW_FILE_CONTENT);
						}

						Assert.AreEqual(ORIGINAL_FILE_CONTENT, FileHelper.ReadAllText(_filePath, requireWriteAccess: false), "Original file content");

						safeFileOverwriter.Save();

						Assert.AreEqual(NEW_FILE_CONTENT, File.ReadAllText(_filePath), "New file content");
					}
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Save_CloseTempFile_DeleteTempFile()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						AssertHelper.IsTrue(() => OriginalFileAndTempFileExist());

						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.Write(NEW_FILE_CONTENT);
						}

						safeFileOverwriter.Save();

						AssertHelper.IsTrue(() => OnlyOriginalFileExists());
					}
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Save_OverwiteFile()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					AssertHelper.IsTrue(() => OnlyOriginalFileExists());
					Assert.AreEqual(ORIGINAL_FILE_CONTENT, File.ReadAllText(_filePath), "Original file content");

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.Write(NEW_FILE_CONTENT);
						}

						safeFileOverwriter.Save();

						Assert.AreEqual(NEW_FILE_CONTENT, File.ReadAllText(_filePath), "New file content");
					}
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Save_UnlockFile()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					const LockEnum expectedLock1 = LockEnum.None;
					LockEnum actualLock1 = FileLock.DetermineLock(_filePath);
					Assert.AreEqual(expectedLock1, actualLock1, "LockEnum before opening");

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						const LockEnum expectedLock2 = LockEnum.Write;
						LockEnum actualLock2 = FileLock.DetermineLock(_filePath);
						Assert.AreEqual(expectedLock2, actualLock2, "LockEnum after opening");

						safeFileOverwriter.Save();

						const LockEnum expectedLock3 = LockEnum.None;
						LockEnum actualLock3 = FileLock.DetermineLock(_filePath);
						Assert.AreEqual(expectedLock3, actualLock3, "LockEnum after saving");
					}
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Dispose_WhenAlreadyDisposed_NoException()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					SafeFileOverwriter safeFileOverwriter;

					using (safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{ }

					safeFileOverwriter.Dispose();
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Dispose_CloseTempFile_DeleteTempFile()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					AssertHelper.IsTrue(() => OnlyOriginalFileExists());

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						AssertHelper.IsTrue(() => OriginalFileAndTempFileExist());

						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.Write(NEW_FILE_CONTENT);
						}
					}

					AssertHelper.IsTrue(() => OnlyOriginalFileExists());
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_Dispose_UnlockFile()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					const LockEnum expectedLock1 = LockEnum.None;
					LockEnum actualLock1 = FileLock.DetermineLock(_filePath);
					Assert.AreEqual(expectedLock1, actualLock1, "LockEnum before opening");

					using (new SafeFileOverwriter(_filePath))
					{
						const LockEnum expectedLock2 = LockEnum.Write;
						LockEnum actualLock2 = FileLock.DetermineLock(_filePath);
						Assert.AreEqual(expectedLock2, actualLock2, "LockEnum after opening");

					}

					const LockEnum expectedLock3 = LockEnum.None;
					LockEnum actualLock3 = FileLock.DetermineLock(_filePath);
					Assert.AreEqual(expectedLock3, actualLock3, "LockEnum after saving");
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_OnFailure_OriginalFileStillPresent()
		{
			lock (_testLock)
			{
				const string failureMessage = "Intentionally failing file save.";

				try
				{
					CreateFile();

					AssertHelper.AreEqual(ORIGINAL_FILE_CONTENT, () => File.ReadAllText(_filePath));

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.Write(NEW_FILE_CONTENT);
						}

						throw new Exception(failureMessage);
					}
				}
				catch (Exception ex)
				{
					if (ex.Message == failureMessage)
					{
						AssertHelper.AreEqual(ORIGINAL_FILE_CONTENT, () => File.ReadAllText(_filePath));
					}
					else
					{
						throw;
					}
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_NoOriginalFile()
		{
			lock (_testLock)
			{
				try
				{
					AssertHelper.IsFalse(() => File.Exists(_filePath));

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{

						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.Write(NEW_FILE_CONTENT);
						}

						safeFileOverwriter.Save();
					}

					AssertHelper.IsTrue(() => File.Exists(_filePath));
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_OverwriteRetainsAttributes()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					const FileAttributes attributes = FileAttributes.Archive | FileAttributes.Hidden | FileAttributes.Temporary;

					// ReSharper disable once UseObjectOrCollectionInitializer
					var fileInfo1 = new FileInfo(_filePath);
					fileInfo1.Attributes = attributes;

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.WriteLine(NEW_FILE_CONTENT);
						}

						safeFileOverwriter.Save();
					}

					var fileInfo2 = new FileInfo(_filePath);
					AssertHelper.AreEqual(attributes, () => fileInfo2.Attributes);
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		[TestMethod]
		public void Test_SafeFileOverwriter_OverwriteRetainsSecuritySettings()
		{
			lock (_testLock)
			{
				try
				{
					CreateFile();

					string identity = WindowsIdentity.GetCurrent().Name;

					var fileInfo = new FileInfo(_filePath);
					FileSecurity security = fileInfo.GetAccessControl();
					int originalAccessRuleCount = security.GetAccessRules(true, false, typeof(SecurityIdentifier)).Count;

					var rule = new FileSystemAccessRule(identity, FileSystemRights.WriteAttributes, AccessControlType.Deny);
					security.SetAccessRule(rule);
					int newAccessRuleCount1 = security.GetAccessRules(true, false, typeof(SecurityIdentifier)).Count;
					AssertHelper.NotEqual(originalAccessRuleCount, () => newAccessRuleCount1);

					using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
					{
						using (var writer = new StreamWriter(safeFileOverwriter.TempStream))
						{
							writer.WriteLine(NEW_FILE_CONTENT);
						}

						safeFileOverwriter.Save();
					}

					int newRuleCount2 = security.GetAccessRules(true, false, typeof(SecurityIdentifier)).Count;
					AssertHelper.NotEqual(originalAccessRuleCount, () => newRuleCount2);

					security.RemoveAccessRule(rule);

					int newRuleCount3 = security.GetAccessRules(true, false, typeof(SecurityIdentifier)).Count;
					AssertHelper.AreEqual(originalAccessRuleCount, () => newRuleCount3);
				}
				finally
				{
					DeleteFileIfNeeded();
				}
			}
		}

		// FolderPath

		private string _folderPath;

		private void InitializeFolderPath()
		{
			_folderPath = $"{typeof(SafeFileOverwriterTests).Name}_{Guid.NewGuid()}";
			Directory.CreateDirectory(_folderPath);
		}

		private void FinalizeFolderPath()
		{
			if (Directory.Exists(_folderPath))
			{
				Directory.Delete(_folderPath);
			}
		}

		// FileName

		private const string FILE_NAME = "File.txt";

		// FilePath

		private string _filePath;

		private void InitializeFilePath() => _filePath = Path.Combine(_folderPath, FILE_NAME);

	    // File Helpers

		private const string ORIGINAL_FILE_CONTENT = "This is the original file.";
		private const string NEW_FILE_CONTENT = "This is the new file.";

		private void CreateFile()
		{
			using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
			{
				using (var writer = new StreamWriter(stream))
				{
					writer.Write(ORIGINAL_FILE_CONTENT);
				}
			}
		}

		private void DeleteFileIfNeeded()
		{
			if (!File.Exists(_filePath)) return;
			FileHelper.MakeWritable(_filePath);
			File.Delete(_filePath);
		}

		private bool OnlyOriginalFileExists()
		{
			var dir = new DirectoryInfo(_folderPath);
			FileInfo[] files = dir.GetFiles(FILE_NAME + "*");
			return
				files.Length == 1 &&
				string.Equals(files[0].Name, FILE_NAME, StringComparison.OrdinalIgnoreCase);
		}

		private bool OriginalFileAndTempFileExist()
		{
			var dir = new DirectoryInfo(_folderPath);
			FileInfo[] files = dir.GetFiles(FILE_NAME + "*");
			return
				files.Length == 2 &&
				files.Any(x => string.Equals(x.Name, FILE_NAME, StringComparison.OrdinalIgnoreCase));
		}

		private FileInfo GetTempFileInfo()
		{
			var dir = new DirectoryInfo(_folderPath);
			FileInfo[] files = dir.GetFiles(FILE_NAME + "*");
			return files.Where(x => !string.Equals(x.Name, FILE_NAME, StringComparison.OrdinalIgnoreCase)).Single();
		}
	}
}
