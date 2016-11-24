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
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Querying
{
	public interface IQuery : IContextChild
	{
		object Query { get; set; }

		Type PrimaryType { get; set; }

		IList Parameters { get; set; }

		RefreshBehaviorType RefreshBehavior { get; set; }

		string ToSql();

		string ToSql(Type primaryType, IContext ctx, ref IList idColumns, ref IList typeColumns, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters);

		string ToSqlScalar();

		string ToSqlScalar(Type primaryType);

		string ToSqlScalar(Type primaryType, IContext ctx);

		string ToSqlScalar(Type primaryType, IContext ctx, ref IList outParameters, IList inParameters);

	}
}