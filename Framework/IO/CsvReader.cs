using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using JJ.Framework.Text;

namespace JJ.Framework.IO
{
	/// <summary> A class for reading out CSV files. </summary>
	[PublicAPI]
	public class CsvReader : IDisposable
	{
		private readonly string _columnSeparator;
		private readonly int? _enforcedColumnCount;
		private readonly StreamReader _reader;
		private IList<string> _values;

		public CsvReader(Stream stream, string columnSeparator = ",", int? enforcedColumnCount = null)
		{
			_columnSeparator = columnSeparator;
			_enforcedColumnCount = enforcedColumnCount;
			_reader = new StreamReader(stream);
		}

		~CsvReader() => Dispose();

		public void Dispose() => _reader?.Dispose();

		public int ColumnCount => _values.Count;
		public int CurrentLine { get; private set; }

		public bool Read()
		{
			if (_reader.EndOfStream)
			{
				return false;
			}

			CurrentLine++;

			string line = _reader.ReadLine();

			_values = ParseLine(line);

			if (_enforcedColumnCount.HasValue)
			{
				if (_values.Count != _enforcedColumnCount)
				{
					throw new Exception($"CsvReader: line {CurrentLine}: {new { columnCount = _values.Count }} is not equal to {new { _enforcedColumnCount }}.");
				}
			}

			return true;
		}

		private IList<string> ParseLine(string line) => line.SplitWithQuotation(_columnSeparator, quote: '"');

		public string this[int i] => _values[i];
	}
}
