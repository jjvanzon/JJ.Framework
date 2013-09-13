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
    /// Represents the basic relationship types.
    /// </summary>
    /// <remarks>
    /// The left side of the relationship name represents the property being described. This is the opposite of how NHibernate names relationships.
    /// For example, with a relationship between orders and orderlines, the Order.OrderLines list property would be considered in NPersist to be 
    /// marked as "ManyToOne" since the left part of the relationship name (the "Many" in "ManyToOne") refers to the property in question. Conversely,
    /// the OrderLine.Order reference property is considered "OneToMany". NHibernate uses the right part of the relationship name to describe the 
    /// property to which it is applied. 
    /// </remarks>
	public enum ReferenceType
	{
        /// <summary>
        /// No relationship.
        /// </summary>
		None = 0,
        /// <summary>
        /// One-to-one relationship.
        /// </summary>
		OneToOne = 1,
        /// <summary>
        /// One-to-many relationship. 
        /// </summary>
		OneToMany = 2,
        /// <summary>
        /// Many-to-one relationship.
        /// </summary>
		ManyToOne = 3,
        /// <summary>
        /// Many-to-many relationship.
        /// </summary>
		ManyToMany = 4
	}
}