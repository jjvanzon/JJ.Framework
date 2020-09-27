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
	
		private readonly Action<MainViewModel> _viewModelChanged;

		private IList<FileDeduplicator.FilePair> _filePairs;

		// TODO: Inject services through constructor for dependency inversion?
		public MainPresenter(Action<MainViewModel> viewModelChanged)
		{
			_viewModelChanged = viewModelChanged;
			_fileDeduplicator = new FileDeduplicator();
			_bulkFileDeleter_WithRecycleBin = new BulkFileDeleter_WithRecycleBin();
		}

		public MainViewModel Show()
			=> new MainViewModel
			{
				TitleBarText = Resources.ApplicationName,
				Explanation = Resources.Explanation,
				Recursive = DEFAULT_RECURSIVE
			};

		public MainViewModel Analyze(MainViewModel viewModel)
		{
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			_filePairs = null; // HACK
			viewModel = AnalyzeIfNeeded(viewModel);

			return viewModel;
		}

		public MainViewModel CopyListOfDuplicates(MainViewModel viewModel)
		{
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			// TODO: Loosely coupled service?
			Clipboard.SetText(viewModel.ListOfDuplicates);

			return viewModel;
		}

		public MainViewModel DeleteFiles(MainViewModel viewModel)
		{
			AnalyzeIfNeeded(viewModel);

			_bulkFileDeleter_WithRecycleBin.DeleteFiles(
				_filePairs.Select(x => x.DuplicateFilePath).ToArray(),
				x => SetProgressMessage(viewModel, x), () => viewModel.IsRunning);

			return viewModel;
		}

		private void SetProgressMessage(MainViewModel viewModel, string progressMessage)
		{
			viewModel.ProgressMessage = progressMessage;
			_viewModelChanged(viewModel);
		}

		private MainViewModel AnalyzeIfNeeded(MainViewModel viewModel)
		{
			if (_filePairs == null)
			{
				_filePairs = _fileDeduplicator.Analyze(
					viewModel.FolderPath, viewModel.Recursive,
					x => SetProgressMessage(viewModel, x), () => viewModel.IsRunning);
			}

			viewModel.ListOfDuplicates = FormatFilePairs(_filePairs);

			return viewModel;
		}

		public MainViewModel Cancel(MainViewModel viewModel)
		{
			viewModel.IsRunning = false;
			return viewModel;
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
