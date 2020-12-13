using System;
using System.Collections.Generic;
using JJ.Framework.Common;
using JJ.Framework.Configuration;
using JJ.Framework.IO;
using JJ.Framework.Logging;
using JJ.Framework.Resources;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileDeduplication
{
	public class FileDeduplicationPresenter
	{
		// Services

		private readonly IFileDeduplicator _fileDeduplicator;
		private readonly IBulkFileDeleter _bulkFileDeleter_WithRecycleBin;
		private readonly IClipboardUtilizer _clipboardUtilizer;
		private readonly IListOfDuplicatesParserFormatter _listOfDuplicatesParserFormatter;

		// ViewModel

		public FileDeduplicationViewModel ViewModel { get; }
		private Action _viewModelChanged;

		public FileDeduplicationPresenter(
			IFileDeduplicator fileDeduplicator,
			IBulkFileDeleter bulkFileDeleter_WithRecycleBin,
			IClipboardUtilizer clipboardUtilizer,
			IListOfDuplicatesParserFormatter listOfDuplicatesParserFormatter)
		{
			_fileDeduplicator = fileDeduplicator;
			_bulkFileDeleter_WithRecycleBin = bulkFileDeleter_WithRecycleBin;
			_clipboardUtilizer = clipboardUtilizer;
			_listOfDuplicatesParserFormatter = listOfDuplicatesParserFormatter;

			ViewModel = Show();
		}

		public void Initialize(Action viewModelChanged) => _viewModelChanged = viewModelChanged;

		private FileDeduplicationViewModel Show()
			=> new FileDeduplicationViewModel
			{
				TitleBarText = ResourceFormatter.ApplicationName,
				Explanation = ResourceFormatter.Explanation,
				AlsoScanSubFolders = true,
				FilePattern = "*.*",
				FolderPath = AppSettingsReader<IAppSettings>.Get(x => x.DefaultFolderPath),
				ValidationMessages = new List<string>()
			};

		public void Scan()
		{
			IValidator validator = new FileDeduplicationViewModelValidator_ForScan(ViewModel);
			if (!validator.IsValid)
			{
				ViewModel.ValidationMessages = validator.Messages;
				return;
			}

			if (!string.IsNullOrWhiteSpace(ViewModel.ListOfDuplicates))
			{
				ViewModel.ScanQuestion = ResourceFormatter.ScanQuestion;
			}
			else
			{
				ScanYes();
			}
		}

		public void ScanYes()
		{
			try
			{
				ViewModel.IsRunning = true;

				IList<DuplicateFilePair> duplicateFilePairs = _fileDeduplicator.Scan(
					ViewModel.FolderPath, ViewModel.AlsoScanSubFolders, ViewModel.FilePattern,
					SetProgressMessage, () => !ViewModel.IsRunning, FileDeduplicatorCallbackCountEnum.Hundred);

				ViewModel.ListOfDuplicates = _listOfDuplicatesParserFormatter.FormatDuplicateFilePairs(duplicateFilePairs);
			}
			catch (Exception ex)
			{
				ViewModel.ProgressMessage = GetProgressMessage(ex);
				throw;
			}
			finally
			{
				ViewModel.IsRunning = false;
			}
		}

		public void CopyListOfDuplicates() => _clipboardUtilizer.SetText(ViewModel.ListOfDuplicates);

		public void DeleteFiles()
		{
			IValidator validator = new FileDeduplicationViewModelValidator_ForDeleteFiles(ViewModel, _listOfDuplicatesParserFormatter);
			if (!validator.IsValid)
			{
				ViewModel.ValidationMessages = validator.Messages;
				return;
			}

			ViewModel.DeleteFilesQuestion = ResourceFormatter.DeleteFilesQuestion;
		}

		public void DeleteFilesYes()
		{
			try
			{
				ViewModel.IsRunning = true;

				IList<string> duplicateFilePaths = _listOfDuplicatesParserFormatter.GetDuplicateFilePaths(ViewModel.ListOfDuplicates);

				_bulkFileDeleter_WithRecycleBin.DeleteFiles(duplicateFilePaths, SetProgressMessage, () => !ViewModel.IsRunning);
			}
			catch (Exception ex)
			{
				ViewModel.ProgressMessage = GetProgressMessage(ex);
				throw;
			}
			finally
			{
				ViewModel.IsRunning = false;
			}
		}

		public void Cancel()
		{
			ViewModel.IsRunning = false;
			_viewModelChanged?.Invoke();
		}

		private void SetProgressMessage(string progressMessage)
		{
			ViewModel.ProgressMessage = progressMessage;
			_viewModelChanged?.Invoke();
		}

		// Helpers

		private static string GetProgressMessage(Exception ex)
		{
			Exception innerMostException = ExceptionHelper.GetInnermostException(ex);
			var progressMessage = $"{CommonResourceFormatter.Exception}: {innerMostException.Message}";
			return progressMessage;
		}
	}
}
