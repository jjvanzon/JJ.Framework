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
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface IUnitOfWork : IContextChild
	{

		void RegisterCreated(object obj);

		void RegisterDirty(object obj);

		void RegisterDeleted(object obj);

		void RegisterClean(object obj);
//
//		ObjectStatus GetObjectStatus(object obj);

		void Commit(int exceptionLimit);

		void CommitObject(object obj, int exceptionLimit);

		ArrayList GetCreatedObjects();

		ArrayList GetDeletedObjects();

		ArrayList GetDirtyObjects();

        void Clear();

		IList Exceptions { get; }

        void TouchLockTables(object obj, int exceptionLimit, DeadlockStrategy deadlockStrategy, IList tables);
    }
}