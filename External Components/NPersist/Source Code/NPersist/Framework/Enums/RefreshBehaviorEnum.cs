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
    /// Represents the available strategies for dealing with fresh data from the data source that differs from a cached version of the data. 
    /// </summary>
    /// <remarks>
    /// Refresh situations occur whenever you query the data source for data that is already in the cache. For example, if you begin by issuing
    /// an NPath query that brings up some employees and then issue another NPath query (via the same context/cache) bringing up some of the 
    /// same employees again, you have a refresh situation. When the first query was issued, the employees were filled with the values from the
    /// database. During the second query, the data for the same employees is brought from the database once more, meaning we could update the 
    /// cached employees and fill them with the most recent values from the database. Sometimes this is desirable, at other times it isn't.
    /// Sometimes just part of the objects should be updated while other parts have been modifed but not saved (they are "dirty") and in that
    /// case we usually don't want to loose our unsaved changes by having them automatically overwritten with the fresh database values.
    /// <br></br><br></br>
    /// By specifying the refresh behavior you can specify exactly the refresh strategies that suit your situation. 
    /// </remarks>
	public enum RefreshBehaviorType
	{
        /// <summary>
        /// The value is inherited, finally resolves to OverwriteNotLoaded.
        /// </summary>
		DefaultBehavior = 0,
        /// <summary>
        /// Only properties that are not yet loaded may be updated with fresh values from the data source.
        /// </summary>
		OverwriteNotLoaded = 2,
        /// <summary>
        /// Unloaded properties and clean properties may be updated with fresh values from the data source.
        /// </summary>
		OverwriteLoaded = 3,
        /// <summary>
        /// All properties (not loaded, clean and dirty) may be updated with fresh values from the data source.
        /// </summary>
		OverwriteDirty = 4,
        /// <summary>
        /// Throw an exception whenever a fresh value from the database differs from a loaded value in the cache.
        /// </summary>
		ThrowConcurrencyException = 5,
        /// <summary>
        /// Logs a concurrency conflict whenever a fresh value from the database differs from a loaded value in the cache.
        /// </summary>
	        LogConcurrencyConflict = 6
	}
}