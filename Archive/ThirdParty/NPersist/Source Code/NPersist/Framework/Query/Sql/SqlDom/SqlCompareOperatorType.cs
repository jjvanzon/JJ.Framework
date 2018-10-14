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
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlCompareOperatorType.
	/// </summary>
	public enum SqlCompareOperatorType
	{
		Equals = 0,
		SmallerOrGreaterThan = 1,
		NotEquals = 2,
		GreaterThan = 3,
		GreaterThanOrEqual = 4,
		NotGreaterThan = 5,
		SmallerThan = 6,
		SmallerThanOrEqual = 7,
		NotSmallerThan = 8,
		Like = 9
	}
}

