// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using System.Reflection;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for IObjectCloner.
	/// </summary>
	public interface IObjectCloner : IContextChild
	{
		IObjectClone CloneObject(object obj);

		void EnsureIsClonedIfEditing(object obj);

		void EnsureIsCloned(object obj);

		void RestoreFromClone(object obj);

		void DiscardClone(object obj);

		void BeginEdit();

		void CancelEdit();

		void EndEdit();

		IList ClonedObjects { get; }
	}
}
