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
	/// Represents the available modes for optimistic concurrency to work in.
	/// </summary>
	public enum OptimisticConcurrencyMode
	{
        /// <summary>
        /// The value is inherited, finally resolves to Late
        /// </summary>
		Default = 0,
        /// <summary>
        /// Optimistic concurrency checks are performed as late as possible, meaning that they only take place during commit operations.
        /// </summary>
		Late = 1,
        /// <summary>
        /// Optimistic concurrency checks are performed as early as possible, meaning that when an object is refreshed any conflicts
        /// that are detected between a cached value and a fresh value from the database will result in an exception being thrown.
        /// Checks are also performed during commit, as with the Late setting.
        /// </summary>
		Early = 2,
        /// <summary>
        /// Optimistic concurrency checks are not performed. 
        /// </summary>
		Disabled = 3
	}
}
