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
    /// This enumeration is used to represent accessibility of properties and fields in the domain map.
    /// </summary>
	public enum AccessibilityType
	{
		PublicAccess = 0,
		ProtectedAccess = 1,
		InternalAccess = 2,
		ProtectedInternalAccess = 3,
		PrivateAccess = 4
	}
}