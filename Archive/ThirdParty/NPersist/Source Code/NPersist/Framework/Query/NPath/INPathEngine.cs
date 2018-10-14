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
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.NPath
{
	public interface INPathEngine : IContextChild
	{
		string ToSql(string npath, Type type, ref Hashtable propertyColumnMap);

		string ToSql(string npath, Type type, ref Hashtable propertyColumnMap, ref IList outParameters);

		string ToSql(string npath, Type type, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters);

		string ToSql(string npath,NPathQueryType queryType, Type type, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters);

		string ToScalarSql(string npath, Type type);

		string ToScalarSql(string npath, Type type, ref IList outParameters);

		string ToScalarSql(string npath, Type type, ref IList outParameters, IList inParameters);

		IClassMap GetRootClassMap(string npath, IDomainMap domainMap);

		NPathQueryType GetNPathQueryType(string npath);

        IList ResultParameters { get; set; }

	}
}