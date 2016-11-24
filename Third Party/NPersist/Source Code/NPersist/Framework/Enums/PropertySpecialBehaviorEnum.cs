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
    /// Represents special behaviors applicable to properties and executed during inserts and/or updates.
    /// </summary>
	public enum PropertySpecialBehaviorType
	{
        /// <summary>
        /// No special behavior is applied.
        /// </summary>
		None = 0,
        /// <summary>
        /// The property value is increased by one (applies only to numeric properties).
        /// </summary>
		Increase = 1,
        /// <summary>
        /// The property value is set to the current date and time (applies only to DateTime properties).
        /// </summary>
		SetDateTime = 2
	}
}