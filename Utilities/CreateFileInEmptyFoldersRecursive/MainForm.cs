using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using JJ.Framework.Collections;
using JJ.Framework.Exceptions.Files;
using JJ.Framework.WinForms.Forms;

namespace JJ.Utilities.CreateFileInEmptyFoldersRecursive
{
	public partial class MainForm : SimpleFileProcessForm
	{
		private static readonly string[] _excludedFolderNames = { ".git", ".vs" };

		public MainForm() => InitializeComponent();

		private void MainForm_OnRunProcess(object sender, EventArgs e)
		{
			string folderPath = FilePath;

			if (!Directory.Exists(folderPath))
			{
				throw new FolderDoesNotExistException(folderPath);
			}

			var mainDirectoryInfo = new DirectoryInfo(folderPath);

			IList<DirectoryInfo> emptyDirectoryInfos = mainDirectoryInfo.UnionRecursive(
				                                                            x => x.EnumerateDirectories()
				                                                                  .Where(y => !_excludedFolderNames.Contains(y.Name)))
			                                                            .Where(x => !x.EnumerateFileSystemInfos().Any())
			                                                            .ToArray();

			foreach (DirectoryInfo emptyDirectoryInfo in emptyDirectoryInfos)
			{
				string filePath = Path.Combine(emptyDirectoryInfo.FullName, "empty.txt");

				string message = $"Writing: {filePath}";
				Debug.WriteLine(message);
				ShowProgress(message);

				if (checkBoxPreviewOnly.Checked)
				{
					continue;
				}

				using (var stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
				{
					using (var writer = new StreamWriter(stream, Encoding.UTF8))
					{
						writer.Write("This folder is empty on purpose.");
					}
				}
			}

			ShowProgress("Done.");
		}
	}
}