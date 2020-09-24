using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JJ.Framework.IO;
using JJ.Framework.WinForms.Forms;
using JJ.Utilities.FileDeduplication.Properties;
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

			Text = Resources.ApplicationName;

			_fileDeduplicator = new FileDeduplicator();
		}

		// Actions

		private void ButtonAnalyze_Click(object sender, EventArgs e)
		{
			_filePairs = null; // HACK
			AnalyzeIfNeeded();
		}

		private void ButtonCopyListOfDuplicates_Click(object sender, EventArgs e)
		{
			//AnalyzeIfNeeded();
			Clipboard.SetText(labelListOfDuplicates.Text);
		}

		private void MainForm_OnRunProcess(object sender, EventArgs e)
		{
			AnalyzeIfNeeded();
			_fileDeduplicator.DeleteDuplicates(_filePairs, ShowProgress, () => IsRunning);
		}

		private void AnalyzeIfNeeded()
		{
			if (_filePairs == null)
			{
				_filePairs = _fileDeduplicator.Analyze(FilePath, checkBoxRecursive.Checked, ShowProgress, () => IsRunning);
			}

			labelListOfDuplicates.Text = FormatFilePairs(_filePairs);
		}

		// Helpers

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
