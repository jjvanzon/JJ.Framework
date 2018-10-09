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
	/// Represents the behavior to be used when objects are loaded by identity.
	/// </summary>
	public enum LoadBehavior
	{
        /// <summary>
        /// the value is inherited. Finally resolves to Lazy.
        /// </summary>
		Default = 0,
        /// <summary>
        /// Objects that are not already in the cache will become lazy loaded (so called "ghost objects") 
        /// with only their identity properties filled. As soon as any other property is accessed, 
        /// the rest of the object is loaded from the database.
        /// </summary>
		Lazy = 1,
        /// <summary>
        /// Objects that are not already in the cache will become loaded right away with values from the database.
        /// </summary>
		Eager = 2
	}
}
