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
    /// Represents the status of a persistent domain object.
    /// </summary>
	public enum ObjectStatus
	{
        /// <summary>
        /// The object has not been loaded with values from the data source yet.
        /// </summary>
		NotLoaded = 0,
        /// <summary>
        /// The object is newly created and has not been inserted into the data source yet. It will be inserted into the data source during the next call to the Commit() method on the context.
        /// </summary>
		UpForCreation = 1,
        /// <summary>
        /// The object has been marked as deleted but has not been removed from the data source yet. It will be removed from the data source during the next call to the Commit() method on the context.
        /// </summary>
		UpForDeletion = 2,
        /// <summary>
        /// The object has been modified but the changes have not been saved to the data source yet. The changes will be saved to the data source during the next call to the Commit() method on the context.
        /// </summary>
		Dirty = 3,
        /// <summary>
        /// The object has been loaded with values from the database, and if it has been changed, all changes have been saved to the database.
        /// </summary>
		Clean = 4,
        /// <summary>
        /// The object has been deleted from the data source.
        /// </summary>
		Deleted = 5,
        /// <summary>
        /// The object is not yet registered with any context and does not have any "real" object status.
        /// </summary>
		NotRegistered = 6
	}
}