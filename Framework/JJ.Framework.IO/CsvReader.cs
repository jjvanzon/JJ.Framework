﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using JJ.Framework.Common;

namespace JJ.Framework.IO
{
    public class CsvReader : IDisposable
    {
        // TODO: Enforce number of columns.

        private Stream _stream;
        private StreamReader _reader;
        private string[] _values;

        public CsvReader(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");

            _stream = stream;
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
            return line.Split(",", quote: '"');
        }

        public string this[int i]
        {
            get { return _values[i]; }
        }
    }
}