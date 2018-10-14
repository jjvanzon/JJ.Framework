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
	/// Represents the different available notification strategies.
	/// </summary>
    /// <remarks>
    /// Notification refers to the process in which the property getters and setters of domain objects send notification messages 
    /// to the Context object whenever the property is accessed. 
    /// </remarks>
	public enum Notification
	{
        /// <summary>
        /// Full notification. Messages are sent before and after properties are read and written to.
        /// </summary>
		Full = 0,
        /// <summary>
        /// Only the messages required for the NPersist object service features to work are sent.
        /// </summary>
		LightWeight = 1,
        /// <summary>
        /// No messages are sent and many of the NPersist object service features can not be supported.
        /// </summary>
		Disabled = 2
	}
}
