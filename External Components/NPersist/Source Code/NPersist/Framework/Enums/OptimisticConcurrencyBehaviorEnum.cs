// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

//Note: Perhaps we should add IncludeAlways for forcing the load of unloaded properties. On the other hand, they would be loaded just before
//the update takes place, probably within a transaction, and it wouldn't help much. Maybe even giving false sense of security.
//...Maybe a MustBeLoaded setting that throws an exception if an important property wasan't loaded during commit ?

namespace Puzzle.NPersist.Framework.Enumerations
{
    /// <summary>
    /// Represents the different strategies for determining if a property should be considered part of the optimistic concurrency check.
    /// </summary>
	public enum OptimisticConcurrencyBehaviorType
	{
        /// <summary>
        /// Inherits the value, finally resolves to IncludeWhenDirty for update operations and IncludeWhenLoaded for delete operations.
        /// </summary>
		DefaultBehavior = 0,
        /// <summary>
        /// The property is only part of the optimistic concurrency check if it is dirty (modified but not saved).
        /// </summary>
		IncludeWhenDirty = 1,
        /// <summary>
        /// The property is always part of the optimistic concurrency check as long as it has been loaded. 
        /// </summary>
		IncludeWhenLoaded = 2,
        /// <summary>
        /// The property is not part of the optimistic concurrency check.
        /// </summary>
		Disabled = 3
	}
}