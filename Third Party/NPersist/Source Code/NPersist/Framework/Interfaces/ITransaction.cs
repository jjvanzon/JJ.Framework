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
using System.Data;
using Puzzle.NPersist.Framework.Persistence;
using System.Collections;

namespace Puzzle.NPersist.Framework.Interfaces
{
	public interface ITransaction : IContextChild, IDbTransaction
	{
		IDbTransaction DbTransaction { get; set; }

		bool AutoPersistAllOnCommit { get; set; }

		IDataSource DataSource { get; set; }

        Hashtable InverseHelpers { get; }

		Guid Guid { get; } 
	}
}