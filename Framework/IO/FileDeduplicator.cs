using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using JJ.Framework.Collections;

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
		/// <inheritdoc cref="FileDeduplicator"/>
		[UsedImplicitly] public FileDeduplicator() { }

		[PublicAPI]
		public class FilePair
		{
			public string OriginalFilePath { get; set; }
			public string DuplicateFilePath { get; set; }
		}

		private class FileTuple
		{
			public string FilePath { get; set; }
			public long FileSize { get; set; }
			public byte[] FileBytes { get; set; }
			public bool IsDuplicate { get; set; }
			public FileTuple OriginalFileTuple { get; set; }
		}

		public IList<FilePair> Analyze(
			string folderPath, bool recursive,
			Action<string> progressCallback = null, Func<bool> cancelCallback = null)
		{
			FileHelper.AssertFolderExists(folderPath);

			progressCallback?.Invoke("Listing files.");

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

			long iterationCounter = 0;
			// Total iterations is detemined like this:
			// First iteration loops through about all items.
			// Last iteration loops through about 0 items.
			// So averagely an iteration would loop through half of the items.
			long totalIterations = fileTuples.Count * fileTuples.Count / 2;
			long iterationsPerProgressCallback = totalIterations / 1000;

			progressCallback?.Invoke("Analyzing duplicates.");

			// Compare files
			for (var i = 0; i < fileTuples.Count; i++)
			{
				FileTuple fileTuple1 = fileTuples[i];

				if (fileTuple1.IsDuplicate)
				{
					// Already marked as duplicate somewhere in the process.
					continue;
				}

				for (int j = i + 1; j < fileTuples.Count; j++)
				{
					if (IsCancelled(cancelCallback)) return new List<FilePair>();

					FileTuple fileTuple2 = fileTuples[j];

					if (!FileTuplesAreEqual(fileTuple1, fileTuple2))
					{
						fileTuple2.IsDuplicate = true;
						fileTuple2.OriginalFileTuple = fileTuple1;
					}

					// Progress counter
					iterationCounter++;
					bool mustShowPercentage = iterationCounter % iterationsPerProgressCallback == 0;

					if (mustShowPercentage)
					{
						decimal percentage = 100m * iterationCounter / totalIterations;
						progressCallback?.Invoke($"Analyzing duplicates {percentage:0.0}");
					}
				}
			}

			progressCallback?.Invoke("Processing result.");

			// Convert to overviewable list of duplicates.
			List<FilePair> duplicateFilePairs = fileTuples.Where(x => x.IsDuplicate)
														  .Select(ConvertFileTupleToFilePair)
														  .OrderBy(x => x.OriginalFilePath)
														  .ThenBy(x => x.DuplicateFilePath)
														  .ToList();

			progressCallback?.Invoke("Analysis complete.");

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

			bool bytesAreEqual = CollectionExtensions.ItemsAreEqual(fileTuple1.FileBytes, fileTuple2.FileBytes);
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
