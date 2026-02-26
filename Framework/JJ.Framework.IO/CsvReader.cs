using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.Framework.IO.Legacy
{
    /// <inheritdoc cref="_csvreader" />
    public class CsvReader : IDisposable
    {
        // TODO: Enforce number of columns.

        private Stream _stream;
        private StreamReader _reader;
        private string[] _values;

        /// <inheritdoc cref="_csvreader" />
        public CsvReader(Stream stream)
        {
            if (stream == null) throw new NullException(() => stream);

            _stream = stream;
            _reader = new StreamReader(stream);
        }

        ~CsvReader()
        {
            Dispose();
        }

        /// <inheritdoc cref="_dispose" />
        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }
        }

        /// <inheritdoc cref="_csvread" />
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

        /// <inheritdoc cref="_csvindexer" />
        public string this[int i]
        {
            get { return _values[i]; }
        }
    }
}
