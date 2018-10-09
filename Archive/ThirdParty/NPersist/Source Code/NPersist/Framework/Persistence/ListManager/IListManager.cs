// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for IListManager.
	/// </summary>
	public interface IListManager : IContextChild
	{	
		IList CreateList(object obj, IPropertyMap propertyMap);

		IList CreateList(object obj, string propertyName);

		IList CloneList(object obj, IPropertyMap propertyMap, IList orgList);

		void SetupListProperties(object obj);

		bool CompareLists(IList newList, IList oldList);

        bool CompareListsById(IList newList, IList oldList);
    }
}
