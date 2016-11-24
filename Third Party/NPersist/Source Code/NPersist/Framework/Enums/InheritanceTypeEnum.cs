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
    /// <summary>
    /// Represents the strategy used for mapping a class inheritance hierarchy to tables in the database.
    /// </summary>
	public enum InheritanceType
	{
        /// <summary>
        /// Inheritance is not in use
        /// </summary>
		None = 0,
        /// <summary>
        /// All classes in the hierarchy are mapped to the same table.
        /// </summary>
		SingleTableInheritance = 1,
        /// <summary>
        /// Each class in the hierarchy gets its own table.
        /// </summary>
		ClassTableInheritance = 2,
        /// <summary>
        /// Only the concrete classes (and the root class) in the hierarchy get tables.
        /// </summary>
		ConcreteTableInheritance = 3
	}
}