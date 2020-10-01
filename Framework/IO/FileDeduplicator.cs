using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using JJ.Framework.Resources;

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

		[PublicAPI]
		[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
		public class FilePair
		{
			public string OriginalFilePath { get; set; }
			public string DuplicateFilePath { get; set; }

			private string DebuggerDisplay => DiagnosticsFormatter.GetDebuggerDisplay(this);
		}

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

		public IList<FilePair> Scan(
			string folderPath, bool recursive,
			Action<string> progressCallback = null, Func<bool> cancelCallback = null)
		{
			FileHelper.AssertFolderExists(folderPath);

			progressCallback?.Invoke(ResourceFormatter.ListingFiles);

			// List files
			SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			IList<string> filePaths = Directory.GetFiles(folderPath, "*.*", searchOption);

			// Get basic info
			List<FileTuple> fileTuples = filePaths.Select(GetBasicFileTuple).ToList();

			// Prevent nested loop from failing when only one file.
			if (fileTuples.Count == 1)
			{
				return new List<FilePair>();
			}

			long ticks = 0;
			// Total iterations is determined like this:
			// First iteration loops through about all items.
			// Last iteration loops through about 0 items.
			// So averagely an iteration would loop through half of the items.
			long totalTicks = fileTuples.Count * fileTuples.Count / 2;
			long ticksPerCallback = totalTicks / 1000;
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
							return new List<FilePair>();
						}

						decimal percentage = 100m * ticks / totalTicks;
						if (percentage > 100m) percentage = 100m;
						progressCallback?.Invoke(ResourceFormatter.ScanningForDuplicates_WithPercentage(percentage));
					}
				}
			}

			progressCallback?.Invoke(ResourceFormatter.ProcessingResult);

			// Convert to overviewable list of duplicates.
			List<FilePair> duplicateFilePairs = fileTuples.Where(x => x.IsDuplicate)
			                                              .Select(ConvertFileTupleToFilePair)
			                                              .OrderBy(x => x.OriginalFilePath)
			                                              .ThenBy(x => x.DuplicateFilePath)
			                                              .ToList();

			progressCallback?.Invoke(ResourceFormatter.DoneScanning_WithDuplicatesFound(duplicateFilePairs.Count));

			return duplicateFilePairs;
		}

		// Helpers

		private static bool IsCancelled(Func<bool> cancelCallback) => cancelCallback?.Invoke() ?? false;

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

		private static FilePair ConvertFileTupleToFilePair(FileTuple fileTuple)
			=> new FilePair
			{
				DuplicateFilePath = fileTuple.FilePath,
				OriginalFilePath = fileTuple.OriginalFileTuple?.FilePath
			};
	}
}
