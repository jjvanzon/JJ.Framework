using JJ.Utilities.FileDeduplication.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JJ.Framework.IO;
using JJ.Framework.Microsoft.VisualBasic;

// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Utilities.FileDeduplication
{
	public class MainPresenter
	{
		private const bool DEFAULT_RECURSIVE = true;

		private readonly FileDeduplicator _fileDeduplicator;
		private readonly BulkFileDeleter_WithRecycleBin _bulkFileDeleter_WithRecycleBin;

		public MainViewModel ViewModel { get; }
		
		private readonly Action _viewModelChanged;

		private IList<FileDeduplicator.FilePair> _filePairs;

		// TODO: Inject services through constructor for dependency inversion?
		public MainPresenter(Action viewModelChanged)
		{
			_viewModelChanged = viewModelChanged;
			_fileDeduplicator = new FileDeduplicator();
			_bulkFileDeleter_WithRecycleBin = new BulkFileDeleter_WithRecycleBin();

			ViewModel = Show();
		}

		private MainViewModel Show()
			=> new MainViewModel
			{
				TitleBarText = Resources.ApplicationName,
				Explanation = Resources.Explanation,
				Recursive = DEFAULT_RECURSIVE
			};

		public void Analyze()
		{
			_filePairs = null; // HACK

			AnalyzeIfNeeded();
		}

		// TODO: Loosely coupled service?
		public void CopyListOfDuplicates() => Clipboard.SetText(ViewModel.ListOfDuplicates);

		public void DeleteFiles()
		{
			AnalyzeIfNeeded();

			_bulkFileDeleter_WithRecycleBin.DeleteFiles(
				_filePairs.Select(x => x.DuplicateFilePath).ToArray(),
				SetProgressMessage, () => ViewModel.IsRunning);
		}

		private void SetProgressMessage(string progressMessage)
		{
			ViewModel.ProgressMessage = progressMessage;
			_viewModelChanged?.Invoke();
		}

		private void AnalyzeIfNeeded()
		{
			if (_filePairs == null)
			{
				_filePairs = _fileDeduplicator.Analyze(
					ViewModel.FolderPath, ViewModel.Recursive,
					SetProgressMessage, () => ViewModel.IsRunning);
			}

			ViewModel.ListOfDuplicates = FormatFilePairs(_filePairs);
		}

		public void Cancel()
		{
			ViewModel.IsRunning = false;
			_viewModelChanged?.Invoke();
		}

		// Helpers

		private string FormatFilePairs(IList<FileDeduplicator.FilePair> filePairs)
			=> string.Join(
				Environment.NewLine + Environment.NewLine,
				filePairs.GroupBy(x => x.OriginalFilePath).Select(FormatItem));

		private string FormatItem(IEnumerable<FileDeduplicator.FilePair> filePairs)
		{
			string separator = Environment.NewLine + "\t";
			string formattedDuplicates = string.Join(separator, filePairs.Select(x => x.DuplicateFilePath));
			return filePairs.First().OriginalFilePath + Environment.NewLine + formattedDuplicates;
		}
	}
}
