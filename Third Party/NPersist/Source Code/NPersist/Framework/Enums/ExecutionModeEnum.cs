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
    /// Represents different modes that the SqlExecutor can work under.
    /// </summary>
	public enum ExecutionMode
	{
        /// <summary>
        /// All sql statements are passed to the database as soon as requested by the framework.
        /// </summary>
		DirectExecution = 0,
        /// <summary>
        /// All select statements are passed directly but insert, update and delete statements are put in a queue. 
        /// </summary>
        /// <remarks>
        /// As soon as a select statement is issued or the transaction commits, 
        /// all queued statements are sent in a batch, potentially reducing the number of messages over the network.
        /// </remarks>
		BatchExecution = 1,
        /// <summary>
        /// Sometimes useful in testing, this setting lets through all select statements but simply ignores all insert, update and delete stataments.
        /// </summary>
		NoWriteExecution = 2,
        /// <summary>
        /// No sql statements are sent to the database.
        /// </summary>
		NoExecution = 3
	}
}