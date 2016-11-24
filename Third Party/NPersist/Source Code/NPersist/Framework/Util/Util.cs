// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;

namespace Puzzle.NPersist.Framework.Utility
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
		public Util()
		{
		}

		public static bool IsNumeric(string value)
		{
			foreach (char c in value)
			{
				if (!Char.IsNumber(c))
				{
					return false;
				}
			}

			return true;
		}

		public static bool IsDBNull(object Expression)
		{
			if ((Expression != null) && (Expression is DBNull))
			{
				return true;
			}
			return false;
		}

		public static bool IsArray(object VarName)
		{
			if (VarName == null)
			{
				return false;
			}
			return (VarName is Array);
		}

	}
}