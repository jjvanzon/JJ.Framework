using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Common;
using JJ.Framework.Configuration;
using JJ.Framework.IO;
using JJ.Framework.Logging;
using JJ.Framework.Resources;
using JJ.Framework.Text;
using JJ.Framework.Validation;
using JJ.Framework.Validation.Resources;

// ReSharper disable MemberCanBeInternal
// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Utilities.FileDeduplication.WinForms
{
	public class FileDeduplicationPresenter
	{
		private const string DUPLICATE_FILE_PATH_PREFIX = "| ";

		// Services

		private readonly IFileDeduplicator _fileDeduplicator;
		private readonly IBulkFileDeleter _bulkFileDeleter_WithRecycleBin;
		private readonly IClipboardUtilizer _clipboardUtilizer;

		// Data

		private IList<FileDeduplicator.FilePair> _filePairs;

		// ViewModel

		public FileDeduplicationViewModel ViewModel { get; }
		private Action _viewModelChanged;

		public FileDeduplicationPresenter(
			IFileDeduplicator fileDeduplicator,
			IBulkFileDeleter bulkFileDeleter_WithRecycleBin,
			IClipboardUtilizer clipboardUtilizer)
		{
			_fileDeduplicator = fileDeduplicator;
			_bulkFileDeleter_WithRecycleBin = bulkFileDeleter_WithRecycleBin;
			_clipboardUtilizer = clipboardUtilizer;

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

			try
			{
				ViewModel.IsRunning = true;

				_filePairs = _fileDeduplicator.Scan(
					ViewModel.FolderPath, ViewModel.AlsoScanSubFolders, ViewModel.FilePattern, SetProgressMessage, () => !ViewModel.IsRunning);

				ViewModel.ListOfDuplicates = FormatFilePairs(_filePairs);
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
			IValidator validator = new FileDeduplicationViewModelValidator_ForDeleteFiles(ViewModel);
			if (!validator.IsValid)
			{
				ViewModel.ValidationMessages = validator.Messages;
				return;
			}

			try
			{
				ViewModel.IsRunning = true;

				IList<string> filePathsToDelete = ParseListOfDuplicates(ViewModel.ListOfDuplicates);

				_bulkFileDeleter_WithRecycleBin.DeleteFiles(filePathsToDelete, SetProgressMessage, () => !ViewModel.IsRunning);
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

		private string FormatFilePairs(IList<FileDeduplicator.FilePair> filePairs)
			=> string.Join(
				Environment.NewLine + Environment.NewLine,
				filePairs.GroupBy(x => x.OriginalFilePath).Select(FormatItem));

		private string FormatItem(IEnumerable<FileDeduplicator.FilePair> filePairs)
		{
			string separator = Environment.NewLine + DUPLICATE_FILE_PATH_PREFIX;
			string formattedDuplicates = DUPLICATE_FILE_PATH_PREFIX + string.Join(separator, filePairs.Select(x => x.DuplicateFilePath));
			return filePairs.First().OriginalFilePath + Environment.NewLine + formattedDuplicates;
		}

		/// <summary>
		/// Would convert a list of duplicates and the original file paths (one copy is deemed the original)
		/// in a specific format where duplicate file paths are prefixed with "| ".
		/// It would return the file paths deemed the duplicate files / files to delete.
		/// </summary>
		private IList<string> ParseListOfDuplicates(string listOfDuplicatesString)
		{
			if (string.IsNullOrWhiteSpace(listOfDuplicatesString))
			{
				return new List<string>();
			}

			IList<string> split = listOfDuplicatesString.Split(Environment.NewLine);
			IList<string> duplicateFilePaths = split.Where(x => x.StartsWith(DUPLICATE_FILE_PATH_PREFIX))
			                                        .Select(x => x.TrimFirst(DUPLICATE_FILE_PATH_PREFIX))
			                                        .ToList();
			return duplicateFilePaths;
		}

		private static string GetProgressMessage(Exception ex)
		{
			Exception innerMostException = ExceptionHelper.GetInnermostException(ex);
			var progressMessage = $"{CommonResourceFormatter.Exception}: {innerMostException.Message}";
			return progressMessage;
		}
	}
}
