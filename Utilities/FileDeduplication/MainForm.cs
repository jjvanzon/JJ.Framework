using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JJ.Framework.IO;
using JJ.Framework.WinForms.Forms;
// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Utilities.FileDeduplication
{
	public partial class MainForm : SimpleFileProcessForm
	{
		private readonly FileDeduplicator _fileDeduplicator;

		private IList<FileDeduplicator.FilePair> _filePairs;

		public MainForm()
		{
			InitializeComponent();

			Description =
				"This utility aims to look up duplicate files (recursively) in a folder. " +
				"It might first analyze which duplicates there may be and report them visually. " +
				"After that it would be an option to have this utility delete those files. " +
				"This utility may depend on the contents of the directory not changing while it is processing. " +
				"So use with caution. That may be good tip in general.";

			_fileDeduplicator = new FileDeduplicator();
		}

		private void MainForm_OnRunProcess(object sender, EventArgs e)
		{
			if (_filePairs == null) _filePairs = _fileDeduplicator.Analyze(FilePath, checkBoxRecursive.Checked, ShowProgress);
			_fileDeduplicator.DeleteDuplicates(_filePairs, ShowProgress);
		}

		private void ButtonAnalyze_Click(object sender, EventArgs e)
			=> _filePairs = _fileDeduplicator.Analyze(FilePath, checkBoxRecursive.Checked, ShowProgress);

		private void ButtonShowListOfDuplicates_Click(object sender, EventArgs e)
		{
			if (_filePairs == null) _filePairs = _fileDeduplicator.Analyze(FilePath, checkBoxRecursive.Checked, ShowProgress);
			string message = FormatFilePairs(_filePairs);
			MessageBox.Show(message);
		}

		private string FormatFilePairs(IList<FileDeduplicator.FilePair> filePairs)
			=> string.Join(Environment.NewLine + Environment.NewLine,  filePairs.GroupBy(x => x.OriginalFilePath).Select(FormatItem));

		private string FormatItem(IEnumerable<FileDeduplicator.FilePair> filePairs)
		{
			string separator = Environment.NewLine + "\t";
			string formattedDuplicates = string.Join(separator, filePairs.Select(x => x.DuplicateFilePath));
			return filePairs.First().OriginalFilePath + Environment.NewLine + formattedDuplicates;
		}
	}
}
