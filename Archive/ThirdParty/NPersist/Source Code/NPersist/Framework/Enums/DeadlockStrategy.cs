// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Enumerations
{
	public enum DeadlockStrategy
	{
        /// <summary>
        /// The default deadlock strategy. Translates to None.
        /// </summary>
        Default = 0,
        /// <summary>
        /// No deadlock strategy is used.
        /// </summary>
        None = 1,
        /// <summary>
        /// The tables are given an order so committing a unit of work begins by touching the relevant tables in this order.
        /// </summary>
        TouchTablesInOrder = 2,
        /// <summary>
        /// A table is choosen as the lock table so committing a unit of work begins by touching the lock table.
        /// </summary>
        TouchLockTable = 3
	}
}
