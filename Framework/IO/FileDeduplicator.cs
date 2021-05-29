using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.ResourceStrings;
// ReSharper disable SuggestVarOrType_BuiltInTypes

#pragma warning disable IDE0066 // Convert switch statement to expression
// ReSharper disable ConvertSwitchStatementToSwitchExpression
// ReSharper disable InvokeAsExtensionMethod

namespace JJ.Framework.IO
{
	/// <summary>
	/// Aims to look up duplicate files (recursively) in a folder.
	/// It might analyze which duplicates there and report them.
	/// It wouldn't actually delete the files yet.
	/// PermanentFileDeleter or FileDeleterWithRecycleBin might be used for that.
	/// </summary>
	[PublicAPI]
	public class FileDeduplicator : IFileDeduplicator
	{
		/// <inheritdoc cref="FileDeduplicator" />
		[UsedImplicitly] public FileDeduplicator() { }

		[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
		internal class FileTuple
		{
			public string FilePath { get; set; }
			public long FileSize { get; set; }
			public byte[] FileBytes { get; set; }
			public bool IsDuplicate { get; set; }
			public FileTuple OriginalFileTuple { get; set; }

			private string DebuggerDisplay => DiagnosticsFormatter.GetDebuggerDisplay(this);
		}

		/// <inheritdoc />
		public IList<DuplicateFilePair> Scan(
			string folderPath, bool recursive, string filePattern = "", 
			Action<string> progressCallback = null, Func<bool> cancelCallback = null, 
			FileDeduplicatorCallbackCountEnum callbackCountEnum = FileDeduplicatorCallbackCountEnum.Thousand)
		{
			// Verify Parameters
			FileHelper.AssertFolderExists(folderPath);
			long callbackCount = GetAndAssertCallBackCount(callbackCountEnum);
			if (string.IsNullOrWhiteSpace(filePattern)) filePattern = "*.*";

			progressCallback?.Invoke(ResourceFormatter.ListingFiles);

			// List files
			SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			IList<string> filePaths = Directory.GetFiles(folderPath, filePattern, searchOption);

			// Get basic info
			List<FileTuple> fileTuples = filePaths.Select(GetBasicFileTuple).ToList();

			// Prevent nested loop from failing when only one file.
			if (fileTuples.Count == 1)
			{
				return new List<DuplicateFilePair>();
			}

			long ticks = 0;
			// Total iterations is determined like this:
			// First iteration loops through about all items.
			// Last iteration loops through about 0 items.
			// So averagely an iteration would loop through half of the items.
			long totalTicks = fileTuples.Count * fileTuples.Count / 2;
			long ticksPerCallback = totalTicks / callbackCount;
			if (ticksPerCallback == 0) ticksPerCallback = 1;

			progressCallback?.Invoke(ResourceFormatter.ScanningForDuplicates);

			// Compare files
			for (var i = 0; i < fileTuples.Count; i++)
			{
				FileTuple fileTuple1 = fileTuples[i];

				if (fileTuple1.IsDuplicate)
				{
					// Already marked as duplicate somewhere in the process.
					ticks += fileTuples.Count / 2;
					continue;
				}

				for (int j = i + 1; j < fileTuples.Count; j++)
				{
					FileTuple fileTuple2 = fileTuples[j];

					if (FileTuplesAreEqual(fileTuple1, fileTuple2))
					{
						fileTuple2.IsDuplicate = true;
						fileTuple2.OriginalFileTuple = fileTuple1;
					}

					// Callbacks
					ticks++;
					bool mustDoCallbacks = ticks % ticksPerCallback == 0;

					if (mustDoCallbacks)
					{
						if (IsCancelled(cancelCallback))
						{
							progressCallback?.Invoke(CommonResourceFormatter.Cancelled);
							return new List<DuplicateFilePair>();
						}

						string formattedPercentage = GetFormattedPercentage(ticks, totalTicks, callbackCountEnum);
						string message = ResourceFormatter.ScanningForDuplicates_WithFormattedPercentage(formattedPercentage);
						progressCallback?.Invoke(message);
					}
				}
			}

			progressCallback?.Invoke(ResourceFormatter.ProcessingResult);

			// Convert to overviewable list of duplicates.
			List<DuplicateFilePair> duplicateFilePairs = fileTuples.Where(x => x.IsDuplicate)
			                                                       .Select(ConvertFileTupleToDuplicateFilePair)
			                                                       .OrderBy(x => x.OriginalFilePath)
			                                                       .ThenBy(x => x.DuplicateFilePath)
			                                                       .ToList();

			progressCallback?.Invoke(ResourceFormatter.DoneScanning_WithDuplicatesCount(duplicateFilePairs.Count));

			return duplicateFilePairs;
		}

		// Helpers

		private long GetAndAssertCallBackCount(FileDeduplicatorCallbackCountEnum callbackCountEnum)
		{
			switch (callbackCountEnum)
			{
				case FileDeduplicatorCallbackCountEnum.Hundred: return 100;
				case FileDeduplicatorCallbackCountEnum.Thousand: return 1000;
				case FileDeduplicatorCallbackCountEnum.TenThousand: return 10000;
				default: throw new ValueNotSupportedException(callbackCountEnum);
			}
		}

		private bool IsCancelled(Func<bool> cancelCallback) => cancelCallback?.Invoke() ?? false;

		private string GetFormattedPercentage(long ticks, long totalTicks, FileDeduplicatorCallbackCountEnum callbackCountEnum)
		{
			string formatString;
			switch (callbackCountEnum)
			{
				case FileDeduplicatorCallbackCountEnum.Hundred:
					formatString = "0%";
					break;

				case FileDeduplicatorCallbackCountEnum.Thousand:
					formatString = "0.0%";
					break;

				case FileDeduplicatorCallbackCountEnum.TenThousand: 
					formatString = "0.00%";
					break;

				default: 
					throw new ValueNotSupportedException(callbackCountEnum);
			}

			decimal fraction = (decimal)ticks / totalTicks;
			if (fraction > 1m) fraction = 1m;

			string formattedPercentage = fraction.ToString(formatString);
			return formattedPercentage;
		}

		/// <summary> Gets basic info with file path and file length, not yet the bytes nor whether it is a duplicate. </summary>
		private FileTuple GetBasicFileTuple(string filePath)
		{
			var fileInfo = new FileInfo(filePath);

			var info = new FileTuple
			{
				FilePath = filePath,
				FileSize = fileInfo.Length
			};

			return info;
		}

		private bool FileTuplesAreEqual(FileTuple fileTuple1, FileTuple fileTuple2)
		{
			if (fileTuple1.FileSize != fileTuple2.FileSize) return false;

			LoadBytesForFileTuple(fileTuple1);
			LoadBytesForFileTuple(fileTuple2);

			bool bytesAreEqual = fileTuple1.FileBytes.SequenceEqual(fileTuple2.FileBytes);
			return bytesAreEqual;
		}

		private static void LoadBytesForFileTuple(FileTuple fileTuple) => fileTuple.FileBytes ??= fileTuple.FilePath.ReadAllBytes();

		private static DuplicateFilePair ConvertFileTupleToDuplicateFilePair(FileTuple fileTuple)
			=> new DuplicateFilePair
			{
				DuplicateFilePath = fileTuple.FilePath,
				OriginalFilePath = fileTuple.OriginalFileTuple?.FilePath
			};
	}
}
