using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using JJ.Framework.Collections;
// ReSharper disable InvokeAsExtensionMethod

namespace JJ.Framework.IO
{
	[PublicAPI]
	public class FileDeduplicator
	{
		[PublicAPI]
		public class FilePair
		{
			public string FirstOccurrenceFilePath { get; set; }
			public string DuplicateFilePath { get; set; }
		}

		private class FileTuple
		{
			public FileInfo FileInfo { get; set; }
			public string FilePath { get; set; }
			public long FileSize { get; set; }
			public byte[] FileBytes { get; set; }
			public FileTuple MainOccurrence { get; set; }
			public bool IsDuplicate => MainOccurrence != null;
			//public IList<FileTuple> Duplicates { get; } = new List<FileTuple>();
		}

		public IList<FilePair> Analyze(string folderPath, bool recursive, Action<string> progressCallback = null)
		{
			FileHelper.AssertFolderExists(folderPath);

			// List files
			SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			IList<string> filePaths = Directory.GetFiles(folderPath, "*.*", searchOption);

			// Get basic info
			var fileTuples = new List<FileTuple>();

			foreach (string filePath in filePaths)
			{
				FileTuple fileTuple = GetBasicInfo(filePath);

				// TODO: Fail gracefully?

				fileTuples.Add(fileTuple);
			}

			// Prevent loop from erroring when only one file.
			if (fileTuples.Count == 1)
			{
				return new List<FilePair>();
			}

			// Compare files
			for (var i = 0; i < fileTuples.Count; i++)
			{
				FileTuple fileTuple1 = fileTuples[i];

				if (fileTuple1.IsDuplicate)
				{
					continue;
				}

				for (int j = i + 1; j < fileTuples.Count; j++)
				{
					FileTuple fileTuple2 = fileTuples[j];

					if (AreEqual(fileTuple1, fileTuple2))
					{
						//fileTuple1.Duplicates.Add(fileTuple2);
						//fileTuple2.IsDuplicate = true;
						fileTuple2.MainOccurrence = fileTuple1;
					}
				}
			}

			// Only keep listings of duplicate files.
			fileTuples = fileTuples.Except(x => !x.IsDuplicate).ToList();

			// Return more overviewable format.
			List<FilePair> filePairs = fileTuples.Select(ConvertToFilePair)
			                                     .OrderBy(x => x.FirstOccurrenceFilePath)
			                                     .ThenBy(x => x.DuplicateFilePath)
			                                     .ToList();
			return filePairs;
		}

		public void DeleteDuplicates(IList<FilePair> filePairs, Action<string> progressCallback = null)
		{
			if (filePairs == null) throw new ArgumentNullException(nameof(filePairs));

			foreach (FilePair filePair in filePairs)
			{
				// TODO: Fail gracefully?
				File.Delete(filePair.DuplicateFilePath);
			}
		}

		/// <summary> Not yet the bytes nor whether it is a duplicate. </summary>
		private FileTuple GetBasicInfo(string filePath)
		{
			var fileInfo = new FileInfo(filePath);

			var info = new FileTuple
			{
				FileInfo = fileInfo,
				FilePath = filePath,
				FileSize = fileInfo.Length
			};

			return info;
		}

		private bool AreEqual(FileTuple fileTuple1, FileTuple fileTuple2)
		{
			if (fileTuple1.FileSize != fileTuple2.FileSize) return false;

			LoadBytes(fileTuple1);
			LoadBytes(fileTuple2);

			bool bytesAreEqual = CollectionExtensions.ItemsAreEqual(fileTuple1.FileBytes, fileTuple2.FileBytes);
			return bytesAreEqual;
		}

		private static void LoadBytes(FileTuple fileTuple) => fileTuple.FileBytes ??= fileTuple.FilePath.ReadAllBytes();

		private static FilePair ConvertToFilePair(FileTuple fileTuple)
			=> new FilePair
			{
				DuplicateFilePath = fileTuple.FilePath,
				FirstOccurrenceFilePath = fileTuple.MainOccurrence?.FilePath
			};
	}
}
