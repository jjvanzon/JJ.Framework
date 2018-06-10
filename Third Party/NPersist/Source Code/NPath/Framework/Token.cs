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

namespace Puzzle.NPath.Framework
{
	public struct Token
	{
		public int Index;
		public string Text;
		public string[] Types;

		public static Token Empty
		{
			get
			{
				Token empty = new Token();
				return empty;
			}
		}

		public bool IsType(string type)
		{
			if (Types == null)
				return false;

			return Array.IndexOf(Types, type) >= 0;
		}

		public override string ToString() => string.Format("{0}\t\t{1}", Text, Types);
	}
}