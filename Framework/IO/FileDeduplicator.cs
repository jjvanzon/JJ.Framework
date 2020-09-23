using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using JJ.Framework.Business;
using JJ.Framework.Collections;

namespace JJ.Framework.IO
{
	[PublicAPI]
	public class FileDeduplicator
	{
		//public class FilePair
		//{ 
		//	public string Du
		//}

		[PublicAPI]
		public class FileTuple
		{
			public FileInfo FileInfo { get; set; }
			public string FilePath { get; set; }
			public long FileSize { get; set; }
			public byte[] FileBytes { get; set; }
			public bool IsDuplicate { get; set; }
			public FileTuple FirstOccurrence { get; set; }
			public IList<FileTuple> Duplicates { get; } = new List<FileTuple>();
		}
		
		public IList<FileTuple> Analyze(string folderPath, bool recursive, Action<string> progressCallback = null)
		{
			FileHelper.AssertFolderExists(folderPath);

			// List files
			IList<string> filePaths = Directory.GetFiles(folderPath, "*.*", GetSearchOption(recursive));

			var fileTuples = new List<FileTuple>();

			// Get basic info
			foreach (string filePath in filePaths)
			{
				FileTuple fileTuple = GetBasicInfo(filePath);

				// TODO: Fail gracefully?

				fileTuples.Add(fileTuple);
			}

			// Prevent loop from erroring when only one file.
			if (fileTuples.Count == 1)
			{
				return fileTuples;
			}

			// Compare files
			for (var i = 0; i < fileTuples.Count; i++)
			{
				FileTuple fileTuple1 = fileTuples[i];

				if (fileTuple1.IsDuplicate)
				{
					continue;
				}

				for (var j = i + 1; j < fileTuples.Count; j++)
				{
					FileTuple fileTuple2 = fileTuples[j];

					bool areEqual = AreEqual(fileTuple1, fileTuple2);

					if (areEqual)
					{
						fileTuple1.Duplicates.Add(fileTuple2);
						fileTuple2.IsDuplicate = true;
						fileTuple2.FirstOccurrence = fileTuple1;
					}
				}
			}

			// Exclude unique files
			fileTuples = fileTuples.Except(x => !x.IsDuplicate).ToList();

			return fileTuples;
		}

		public void DeleteDuplicates(IList<FileTuple> fileTuples, Action<string> progressCallback = null)
		{
			if (fileTuples == null) throw new ArgumentNullException(nameof(fileTuples));

			foreach (FileTuple fileTuple in fileTuples)
			{
				if (!fileTuple.IsDuplicate)
				{
					continue;
				}

				// TODO: Fail gracefully?
				File.Delete(fileTuple.FilePath);
			}
		}

		private static SearchOption GetSearchOption(bool recursive) 
			=> recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

		/// <summary> Not yet the bytes nor the duplicates. </summary>
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

			bool bytesAreEqual = fileTuple1.FileBytes.ItemsAreEqual(fileTuple2.FileBytes);
			return bytesAreEqual;
		}

		private static void LoadBytes(FileTuple fileTuple) => fileTuple.FileBytes ??= fileTuple.FilePath.ReadAllBytes();


		//public IList<Info> Analyze(string folderPath, bool recursive, Action<string> progressCallback = null)
		//{
		//	FileHelper.AssertFolderExists(folderPath);

		//	//string[] filePaths = Directory.GetFiles(folderPath, "*.*", GetSearchOption(recursive));
		//}
	}
}
