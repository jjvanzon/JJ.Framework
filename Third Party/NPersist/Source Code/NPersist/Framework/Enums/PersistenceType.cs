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
	/// Represents the different object persistence strategies supported by NPersist.
	/// </summary>
	public enum PersistenceType
	{
        /// <summary>
        /// Default resolves to ObjectRelational.
        /// </summary>
		Default = 0, 
        /// <summary>
        /// Object/Relational Mapping, persistence to relational database.
        /// </summary>
		ObjectRelational = 1,
        /// <summary>
        /// Object/Document Mapping, persistence to xml documents on disk.
        /// </summary>
		ObjectDocument = 2,
        /// <summary>
        /// Objectt/Service Mapping, persistence to Web Services.
        /// </summary>
		ObjectService = 3,
        /// <summary>
        /// Object/Object Mapping, persistence to object graph
        /// </summary>
		ObjectObject = 4, 
        /// <summary>
        /// Transient, no persistence
        /// </summary>
		Transient = 5,
		Other = 6
	}
}
