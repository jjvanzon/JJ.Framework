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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for IReadOnlyObjectCacheManager.
	/// </summary>
	public interface IReadOnlyObjectCacheManager : IContextChild
	{
		long MaxSize { get; set; }

		bool HasObject(object obj);

		bool LoadObject(object obj);
		
		void SaveObject(object obj);

		void Clear();

		void Clear(Type type);

	}
}
