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
    /// Represents the status of a property.
    /// </summary>
	public enum PropertyStatus
	{
        /// <summary>
        /// The property has not yet been loaded with a value from the data source.
        /// </summary>
		NotLoaded = 0,
        /// <summary>
        /// The property value has been modified but the changed value has not yet been saved to the data source.
        /// </summary>
		Dirty = 1,
        /// <summary>
        /// The property has been loaded with a value from the data source. If the value has been modified it has also been saved back to the data source.
        /// </summary>
		Clean = 2,
        /// <summary>
        /// The property belongs to a deleted object.
        /// </summary>
		Deleted = 3
	}
}