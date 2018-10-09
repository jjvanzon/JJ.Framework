// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using System.Data;
using System.Globalization;
using Puzzle.NCore.Framework.Exceptions;

namespace Puzzle.NCore.Framework.Data
{
    public class OfflineDataReader : IDataReader
    {
        private IList records = new ArrayList();
        private DataTable schemaTable;

        private Hashtable columnLookup = new Hashtable();


        public OfflineDataReader Clone()
        {
            OfflineDataReader clone = new OfflineDataReader();
            clone.schemaTable = schemaTable;
            clone.columnLookup = columnLookup;
            clone.records = records;
            clone.MoveFirst();
            return clone;
        }


        public OfflineDataReader()
        {
        }

        public OfflineDataReader(IDataReader reader)
        {
            schemaTable = reader.GetSchemaTable();

            //build column index lookup
            int j = 0;
            foreach (DataRow dr in schemaTable.Rows)
            {
                columnLookup[dr["ColumnName"].ToString().ToLower(CultureInfo.InvariantCulture)] = j;
                j++;
            }


            //copy data
            while (reader.Read())
            {
                object[] fields = new object[schemaTable.Rows.Count];
                for (int i = 0; i < fields.Length; i++)
                {
                    fields[i] = reader.GetValue(i);
                }
                records.Add(fields);
            }
            reader.Close();
            reader.Dispose();

            MoveFirst();
        }

        public void MoveFirst() => Position = -1;

        #region Public Property Position

        private int position;

        public int Position
        {
            get => position;
            set => position = value;
        }

        #endregion

        #region Public Property RecordsAffected

        public int RecordsAffected => throw new IAmOpenSourcePleaseImplementMeException();

        #endregion

        #region Public Property IsClosed		

        public bool IsClosed => throw new IAmOpenSourcePleaseImplementMeException();

        #endregion

        #region Public Property Count

        public int Count => records.Count;

        #endregion

        public bool NextResult() => throw new IAmOpenSourcePleaseImplementMeException("NextResult is not implemented");

        public void Close()
        {
            // TODO:  Add ICacheDataReader.Close implementation
        }

        public bool Read()
        {
            Position ++;
            return Position < Count;
        }

        public int Depth => 0;

        public DataTable GetSchemaTable() => schemaTable;

        public void Dispose()
        {
        }

        public int GetInt32(int i)
        {
            object[] fields = (object[]) records[position];
            return (int) fields[i];
        }

        public object this[string name]
        {
            get
            {
                int colIndex = GetColumnIndex(name);
                return GetValue(colIndex);
            }
        }

        private int GetColumnIndex(string name)
        {
            object colIndex = columnLookup[name.ToLower(CultureInfo.InvariantCulture)];
            if (colIndex != null)
                return (int) colIndex;
            colIndex = columnLookup[name.ToUpper()];
            if (colIndex != null)
                return (int) colIndex;
            throw new ApplicationException("Column with name " + name + " not found");
        }

        object IDataRecord.this[int i] => GetValue(i);

        public object GetValue(int i)
        {
            object[] fields = (object[]) records[position];
            return fields[i];
        }

        public bool IsDBNull(int i)
        {
            object[] fields = (object[]) records[position];
            return fields[i] == DBNull.Value;
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => 0;

        public byte GetByte(int i)
        {
            object[] fields = (object[]) records[position];
            return (byte) fields[i];
        }

        public Type GetFieldType(int i) => (Type) schemaTable.Rows[i]["DataType"];

        public decimal GetDecimal(int i)
        {
            object[] fields = (object[]) records[position];
            return (decimal) fields[i];
        }

        public int GetValues(object[] values) => 0;

        public string GetName(int i) => (string) schemaTable.Rows[i]["ColumnName"];

        public int FieldCount => schemaTable.Rows.Count;

        public long GetInt64(int i)
        {
            object[] fields = (object[]) records[position];
            return (Int64) fields[i];
        }

        public double GetDouble(int i)
        {
            object[] fields = (object[]) records[position];
            return (double) fields[i];
        }

        public bool GetBoolean(int i)
        {
            object[] fields = (object[]) records[position];
            return (bool) fields[i];
        }

        public Guid GetGuid(int i)
        {
            object[] fields = (object[]) records[position];
            return (Guid) fields[i];
        }

        public DateTime GetDateTime(int i)
        {
            object[] fields = (object[]) records[position];
            return (DateTime) fields[i];
        }

        public int GetOrdinal(string name)
        {
			name = name.ToLower();
			if (columnLookup.ContainsKey(name))
				return (int) columnLookup[name];
			return -1; //schemaTable.Columns.IndexOf(name);
        }

        public string GetDataTypeName(int i) => null;

        public float GetFloat(int i)
        {
            object[] fields = (object[]) records[position];
            return (float) fields[i];
        }

        public IDataReader GetData(int i) => null;

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => 0;

        public string GetString(int i)
        {
            object[] fields = (object[]) records[position];
            return (string) fields[i];
        }

        public char GetChar(int i)
        {
            object[] fields = (object[]) records[position];
            return (char) fields[i];
        }

        public short GetInt16(int i)
        {
            object[] fields = (object[]) records[position];
            return (Int16) fields[i];
        }
    }
}