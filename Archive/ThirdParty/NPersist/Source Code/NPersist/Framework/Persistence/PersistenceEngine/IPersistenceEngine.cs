using System;
using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Querying;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for IPersistenceEngine.
	/// </summary>
	public interface IPersistenceEngine : IContextChild
	{
		void Begin();

		void Commit();

		void Abort();

		void InsertObject(object obj, IList stillDirty);

		void UpdateObject(object obj, IList stillDirty);

		void RemoveObject(object obj);

		IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj);

		void LoadObject(ref object obj);

		void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue);

		void LoadProperty(object obj, string propertyName);

		IList LoadObjects(IQuery query, IList listToFill);

        IList LoadObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill);

		//It is a bit ugly that these methods should have to be here, but it is so that these calls can be remoted...
		DataTable LoadDataTable(IQuery query);

		IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill);

        void TouchTable(Puzzle.NPersist.Framework.Mapping.ITableMap tableMap, int exceptionLimit);
    }
}
