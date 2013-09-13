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
    /// Represents the standard strategies that can be used in order to convert property names into the names of the fields holding the property's value.
    /// </summary>
	public enum FieldNameStrategyType
	{
        /// <summary>
        /// The name of the field is the same as the name of the property (but presumably prefixed)
        /// </summary>
		None = 0,
        /// <summary>
        /// The name of the field is the same as the name of the property converted to camelCase. 
        /// </summary>
		CamelCase = 1,
        /// <summary>
        /// The name of the field is the same as the name of the property converted to PascalCase. 
        /// </summary>
		PascalCase = 2,
        /// <summary>
        /// The name of the field is the same as the name of the property converted to lowercase. 
        /// </summary>
        LowerCase = 3,
        /// <summary>
        /// The name of the field is the same as the name of the property converted to UPPERCASE. 
        /// </summary>
        UpperCase = 4
	}
}