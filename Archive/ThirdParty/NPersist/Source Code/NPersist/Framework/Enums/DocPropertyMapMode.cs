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
    /// This enumeration is used in xml persistence and determines the document partitioning strategy when reference properties of an object are stored to disk.
    /// </summary>
	public enum DocPropertyMapMode
	{
        /// <summary>
        /// The value is inherited. Finally ByReference.
        /// </summary>
		Default = 0,
        /// <summary>
        /// The referenced object is saved in the same document as the referring object, nested inside the referring object's xml.
        /// </summary>
		Inline = 1,
        /// <summary>
        /// The referenced object will not be stored as a nested part of the referring object's xml, only a reference will be. 
        /// </summary>
		ByReference = 2 /*,
		PerProperty = 3,
		PerValue = 4,
		None = 5*/
	}
}
