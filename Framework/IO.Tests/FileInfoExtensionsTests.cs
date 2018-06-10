using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.IO.Tests
{
	[TestClass]
	public class FileInfoExtensionsTests
	{
		private readonly FileFunctionsTests _base;

		public FileInfoExtensionsTests() => _base = new FileFunctionsTests();

	    [TestMethod]
		public void Test_FileInfoExtensions_Hide_Show()
		{
			string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
			var file = new FileInfo(filePath);
			_base.Test_FileFunctions_HideFile_ShowFile(
				filePath,
				() => file.Hide(),
				() => file.Show());
		}

		[TestMethod]
		public void Test_FileInfoExtensions_IsHidden()
		{
			string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
			var file = new FileInfo(filePath);

			_base.Test_FileFunctions_IsHidden(
				filePath,
				() =>
				{
					file.Refresh();
					return file.IsHidden();
				});
		}

		[TestMethod]
		public void Test_FileInfoExtensions_MakeReadOnly_MakeWritable()
		{
			string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
			var file = new FileInfo(filePath);
			_base.Test_FileFunctions_MakeReadOnly_MakeWritable(
				filePath,
				() => file.MakeReadOnly(),
				() => file.MakeWritable());
		}

		[TestMethod]
		public void Test_FileInfoExtensions_IsReadOnly()
		{
			string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
			var file = new FileInfo(filePath);

			_base.Test_FileFunctions_IsReadOnly(
				filePath,
				() =>
				{
					file.Refresh();
					return file.IsReadOnly();
				});
		}
	}
}