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
    /// This enumeration is used in xml persistence and determines the document partitioning strategy when objects of a class are stored to disk.
    /// </summary>
	public enum DocClassMapMode
	{
        /// <summary>
        /// The strategy will be inherited, and finally PerDomain.
        /// </summary>
		Default = 0,
        /// <summary>
        /// Saves all objects from the domain into one big document.
        /// </summary>
		PerDomain = 1,
        /// <summary>
        /// Creates a separate document per class where all objects of the class are stored.
        /// </summary>
		PerClass = 2,
        /// <summary>
        /// Each object gets its own document.
        /// </summary>
		PerObject = 3,
        /// <summary>
        /// Xml persistence is turned off.
        /// </summary>
		None = 4
	}
}
