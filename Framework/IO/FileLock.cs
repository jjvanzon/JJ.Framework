using System;
using System.IO;
using JJ.Framework.Exceptions.InvalidValues;

namespace JJ.Framework.IO
{
	/// <summary>
	/// Allows you to lock a file.
	/// A write lock is the most common, allowing other processes to still read the file, but not write it.
	/// A read lock is used for transactional integrity:
	/// another process can only read a file, after you are done writing all files.
	/// However, do mind that the FileLock class cannot prevent a file getting locked by another process
	/// when switching between read and write locks.
	/// </summary>
	public class FileLock : IDisposable
	{
		// Initialization, Clean-Up

		// ReSharper disable once SuggestBaseTypeForParameter
		public FileLock(FileInfo fileInfo, LockEnum lockEnum)
			: this(fileInfo.FullName, lockEnum)
		{ }

		public FileLock(string path, LockEnum lockEnum)
		{
			FileHelper.AssertFileExists(path);
			Path = path;
			LockEnum = lockEnum;
		}

		~FileLock()
		{
			Dispose();
		}

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			if (IsDisposed) return;
			IsDisposed = true;

			DisposeReadLockStream();
			DisposeWriteLockStream();
		}

		// Path

		public string Path { get; }

		// Lock

		private LockEnum _lockEnum;

		public LockEnum LockEnum
		{
			get { return _lockEnum; }
			set
			{
				if (_lockEnum == value) return;

				// Transactional integrity is not guaranteed here.

				// You can only impose a write lock, if you first release the read lock.
				// Working completely transactional with files is not possible.

				// When this procedure switches from write lock to read lock, first the write lock is released,
				// creating a window of opportunity for some process to get full access to the file.
				// It could impose a write lock of its own and prevent ourselves from imposing the write lock again,
				// thus making our lock fail.

				// Locking integrity is guaranteed, however.
				// Process will fail if lock fails. Process will continue if lock succeeds.
				// However, it is not possible to keep the file locked, while switching from write lock to read lock.

				// Technical constraints: (cryptic, but it is the basis for the conclusions above)
				// FileStream.Lock() only creates a write lock, not a read lock.
				// FileStream.Lock() only works in case of FileShare.Read, not when FileShare.ReadWrite.
				// You can only impose a read lock by creating a FileStream with FileShare.None,
				// and you can only do that if there is no Stream open yet at all.

				long position = 0;

				switch (_lockEnum)
				{
					case LockEnum.Read:
						position = _readLockStream.Position;
						DisposeReadLockStream();
						break;

					case LockEnum.Write:
						position = _writeLockStream.Position;
						DisposeWriteLockStream();
						break;
				}

				switch (value)
				{
					case LockEnum.Write:
						CreateWriteLockStream();
						_writeLockStream.Position = position;
						break;

					case LockEnum.Read:
						CreateReadLockStream();
						_readLockStream.Position = position;
						break;

					case LockEnum.None:
						break;

					default:
						throw new InvalidValueException(_lockEnum);
				}

				_lockEnum = value;
			}
		}

		// ReadLockStream

		private FileStream _readLockStream;

		private void CreateReadLockStream()
		{
			try
			{
				_readLockStream = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			}
			catch (Exception ex)
			{
				throw new FileLockException(ex);
			}
		}

		private void DisposeReadLockStream()
		{
			_readLockStream?.Dispose();
			_readLockStream = null;
		}

		// WriteLockStream

		private FileStream _writeLockStream;

		private void CreateWriteLockStream()
		{
			try
			{
				_writeLockStream = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
			}
			catch (Exception ex)
			{
				throw new FileLockException(ex);
			}
		}

		private void DisposeWriteLockStream()
		{
			_writeLockStream?.Dispose();
			_writeLockStream = null;
		}

		// Stream

		public FileStream Stream
		{
			get
			{
				switch (_lockEnum)
				{
					case LockEnum.Read: return _readLockStream;
					case LockEnum.Write: return _writeLockStream;
					case LockEnum.None: return null;
					default: throw new InvalidValueException(LockEnum);
				}
			}
		}

		// DetermineLock

		public static LockEnum DetermineLock(string path)
		{
			FileHelper.AssertFileExists(path);

			try
			{
				using (new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{ }
			}
			catch (IOException)
			{
				return LockEnum.Read;
			}

			try
			{
				using (new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
				{ }
			}
			catch (IOException)
			{
				return LockEnum.Write;
			}

			return LockEnum.None;
		}
	}
}
