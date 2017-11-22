using System;
using System.IO;
using System.Linq;
using JJ.Framework.Common;

namespace JJ.Framework.IO
{
	/// <summary> Fully unit tested. </summary>
	public class PathParser
	{
		public string Volume { get; }
		public string FolderPath { get; }
		public string FileName { get; }
		public string[] SubFolders { get; } = new string[0];

		public PathParser(string path)
			: this(path, null)
		{ }

		public PathParser(string path, bool? isFile = null)
		{
			bool? isFile1 = isFile;
			if (string.IsNullOrEmpty(path)) return;

			isFile1 = isFile1 ?? FileHelper.IsFile(path);

			if (isFile1 == true)
			{
				FileName = Path.GetFileName(path); // Beware that Path.GetFileName() can return a sub folder name.
				FolderPath = Path.GetDirectoryName(path);
			}
			else
			{
				FolderPath = path;
			}

			string[] parts = FolderPath.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
			// ReSharper disable once InvertIf
			if (parts.Length > 0)
			{
				if (IsVolume(parts[0]))
				{
					Volume = parts[0];

					SubFolders = parts.Skip(1).ToArray();
				}
				else
				{
					SubFolders = parts;
				}
			}
		}

		private bool IsVolume(string path)
		{
			return path.Contains(Path.VolumeSeparatorChar);
		}
	}
}
