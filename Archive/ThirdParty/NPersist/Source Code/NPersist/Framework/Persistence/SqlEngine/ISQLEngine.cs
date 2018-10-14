using System;
using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Mapping;
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
	public interface ISqlEngine
	{
		ISqlEngineManager SqlEngineManager { get; set; }

		void LoadObject(ref object obj);

		void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue);

		void InsertObject(object obj, IList stillDirty);

		void UpdateObject(object obj, IList stillDirty);

		void RemoveObject(object obj);

		void LoadProperty(object obj, string propertyName);

		IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj);

		IList LoadObjects(IQuery query, IList listToFill);

		DataTable LoadDataTable(IQuery query);

		IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill);

		string DateDelimiter { get; set; }

		AutoIncreaserStrategy AutoIncreaserStrategy { get; set; }

		string SelectNewIdentity { get; set; }

		string GetSelectNextSequence(string sequenceName);

		string StatementDelimiter { get; set; }

        void TouchTable(ITableMap tableMap, int exceptionLimit);
    }
}