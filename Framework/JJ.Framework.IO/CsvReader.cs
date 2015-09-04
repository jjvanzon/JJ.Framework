using System;
using System.IO;
using JJ.Framework.Common;

namespace JJ.Framework.IO
{
    public class CsvReader : IDisposable
    {
        // TODO: Enforce number of columns.

        private StreamReader _reader;
        private string[] _values;

        public CsvReader(Stream stream)
        {
            _reader = new StreamReader(stream);
        }

        ~CsvReader()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }
        }

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

        private string[] ParseLine(string line)
        {
            return line.SplitWithQuotation(",", quote: '"');
        }

        public string this[int i]
        {
            get { return _values[i]; }
        }
    }
}
