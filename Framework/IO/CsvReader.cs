using System;
using System.Collections.Generic;
using System.IO;
using JJ.Framework.Common;

namespace JJ.Framework.IO
{
    public class CsvReader : IDisposable
    {
        // TODO: Enforce number of columns.

        private readonly StreamReader _reader;
        private IList<string> _values;

        public CsvReader(Stream stream) => _reader = new StreamReader(stream);

        ~CsvReader() => Dispose();

        public void Dispose() => _reader?.Dispose();

        public bool Read()
        {
            if (_reader.EndOfStream)
            {
                return false;
            }

            string line = _reader.ReadLine();

            _values = ParseLine(line);

            return true;
        }

        private IList<string> ParseLine(string line) => line.SplitWithQuotation(",", quote: '"');

        public string this[int i] => _values[i];
    }
}
