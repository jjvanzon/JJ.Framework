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
using System.Text;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
    public interface IRefreshConflict : IContextChild
	{

        object Obj { get; set; }
        string PropertyName { get; set; }
        object CachedOriginalValue { get; set; }
        object CachedValue { get; set; }
        object FreshValue { get; set; }

        void Resolve(ConflictResolution resolution);

	}
}
