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
    /// The mode of validation.
    /// </summary>
	public enum ValidationMode
	{
        /// <summary>
        /// Inherits ValidationMode from the ValidationMode holder above. 
        /// </summary>
        /// <remarks>
        /// A propertyMap inherits from its classMap, that inherits from its DomainMap, which inherits from the Context. 
        /// If the Context has ValidationMode.Default, this translates to ValidationMode.ValidateLoaded.
        /// </remarks>
		Default = 0,
        /// <summary>
        /// Validates all Loaded properties (including all Dirty properties).
        /// </summary>
        ValidateLoaded = 1,
        /// <summary>
        /// Validates only Dirty properties.
        /// </summary>
		ValidateDirty = 2, 
        /// <summary>
        /// Validates all Loaded, Dirty and NotLoaded properties (forces loading of NotLoaded properties for validation)
        /// </summary>
		ValidateAll = 3, 
        /// <summary>
        /// No validation
        /// </summary>
		Off = 4 
	}
}
