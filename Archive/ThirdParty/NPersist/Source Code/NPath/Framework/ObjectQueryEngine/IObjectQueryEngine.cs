// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using System.Data;
using Puzzle.NPath.Framework.CodeDom;

namespace Puzzle.NPath.Framework
{
	/// <summary>
	/// Summary description for ObjectQueryEngine.
	/// </summary>
	public interface IObjectQueryEngine
	{
		IList GetObjectsByNPath(string npath, IList sourceList);
		DataTable GetDataTableByNPath(string npath, IList sourceList);

		IList GetObjectsByNPath(string npath, IList sourceList, IList parameters);
		DataTable GetDataTableByNPath(string npath, IList sourceList, IList parameters);

		IList GetObjects(NPathSelectQuery query, IList sourceList);
		DataTable GetDataTable(NPathSelectQuery query, IList sourceList);

		object EvalValue(object item, object expression);

		IObjectQueryEngineHelper ObjectQueryEngineHelper { get; set; }
	}
}