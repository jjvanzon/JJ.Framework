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

namespace Puzzle.NPath.Framework.Utility
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
			for (int i = 0; i < this.keys.Length; i++)
			{
				hash ^= keys[i].GetHashCode();
			}
			return hash;
		}

		public override int GetHashCode() => hashCode;

	    public override bool Equals(object obj)
		{
			KeyStruct other = (KeyStruct) obj;

			for (int i = 0; i < this.keys.Length; i++)
			{
				if (this.keys[i] != other.keys[i])
					return false;
			}

			return true;
		}

	}

	public class MultiHashtable
	{
		private Hashtable baseLookup = new Hashtable();

		public bool ContainsKeys(params object[] keys) => false;

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
			get => GetValue(keys);
		    set => Add(value, keys);
		}
	}
}