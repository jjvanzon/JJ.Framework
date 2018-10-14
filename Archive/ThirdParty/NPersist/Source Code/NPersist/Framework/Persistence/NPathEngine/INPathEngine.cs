//// *
//// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
//// *
//// * This library is free software; you can redistribute it and/or modify it
//// * under the terms of the GNU Lesser General Public License 2.1 or later, as
//// * published by the Free Software Foundation. See the included license.txt
//// * or http://www.gnu.org/copyleft/lesser.html for details.
//// *
//// *
//
//using System;
//using System.Collections;
//using Puzzle.NPersist.Framework.Mapping;
//using Puzzle.NPersist.Framework.Persistence.NPath;
//
//namespace Puzzle.NPersist.Framework.Persistence
//{
//	public interface INPathEngine : IContextChild
//	{
//		//INPathSelectClause GetNPathSelectClause(string NPath);
//
//		string ToSql(string npath, Type type, ref Hashtable propertyColumnMap);
//
//		string ToScalarSql(string npath, Type type);
//
//		IClassMap GetRootClassMap(string npath, IDomainMap domainMap);
//
//	}
//}