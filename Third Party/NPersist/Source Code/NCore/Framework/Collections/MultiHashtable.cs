// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using System;
using System.Text;

namespace Puzzle.NCore.Framework.Collections
{
    public struct KeyStruct
    {
        private int hashCode;
        public readonly object[] keys;

        public KeyStruct(object[] keys)
        {
            this.keys = keys;
            hashCode = 0;
            hashCode = CreateHashCode();
        }

        private int CreateHashCode()
        {
            int hash = 0;
            for (int i = 0; i < keys.Length; i++)
            {
                hash ^= keys[i].GetHashCode();
            }
            return hash;
        }

        public override int GetHashCode()
        {
            return hashCode;
        }


        public override bool Equals(object obj)
        {
            KeyStruct other = (KeyStruct) obj;

			if (keys.Length != other.keys.Length)
				return false;

            for (int i = 0; i < keys.Length; i++)
            {
                object thisKey = keys[i];
                object thatKey = other.keys[i];

				if (!(thisKey.Equals(thatKey)))
					return false;
            }

            return true;
        }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (object key in keys)
				sb.Append(key.ToString() + ", ");
				
			if (sb.Length > 0)
				sb.Length -= 2;

			return sb.ToString();
		}

    }

    public class MultiHashtable
    {
        private Hashtable baseLookup = new Hashtable();

        public bool ContainsKeys(params object[] keys)
        {
            return false;
        }

        public void Add(object value, object[] keys)
        {
            KeyStruct key = new KeyStruct(keys);
            baseLookup[key] = value;
        }

        private Hashtable GetLastHashtable(object[] keys)
        {
            Hashtable current = baseLookup;
            return current;
        }

        private object GetValue(object[] keys)
        {
            KeyStruct key = new KeyStruct(keys);
            return baseLookup[key];
        }

        public object this[params object[] keys]
        {
            get { return GetValue(keys); }
            set { Add(value, keys); }
        }
    }
}