using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Common;
using JJ.Framework.Configuration;
using JJ.Framework.IO;
using JJ.Framework.Logging;
using JJ.Framework.Resources;

// ReSharper disable MemberCanBeInternal
// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Utilities.FileDeduplication.WinForms
{
	public class FileDeduplicationPresenter
	{
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
				FolderPath = AppSettingsReader<IAppSettings>.Get(x => x.DefaultFolderPath)
			};

		public void Scan()
		{
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
			try
			{
				ViewModel.IsRunning = true;

				if (_filePairs == null)
				{
					ViewModel.ProgressMessage = ResourceFormatter.PleaseFirst_WithName(CommonResourceFormatter.Scan);
					return;
				}

				_bulkFileDeleter_WithRecycleBin.DeleteFiles(
					_filePairs.Select(x => x.DuplicateFilePath).ToArray(), SetProgressMessage, () => !ViewModel.IsRunning);
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
			string separator = Environment.NewLine + "| ";
			string formattedDuplicates = "| " + string.Join(separator, filePairs.Select(x => x.DuplicateFilePath));
			return filePairs.First().OriginalFilePath + Environment.NewLine + formattedDuplicates;
		}

		private static string GetProgressMessage(Exception ex)
		{
			Exception innerMostException = ExceptionHelper.GetInnermostException(ex);
			var progressMessage = $"{CommonResourceFormatter.Exception}: {innerMostException.Message}";
			return progressMessage;
		}
	}
}
