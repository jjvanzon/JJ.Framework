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
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public interface ITableMap : IMap
	{
		[XmlIgnore()]
		ISourceMap SourceMap { get; set; }

		bool IsView { get; set; }

		void SetSourceMap(ISourceMap value);

		[XmlArrayItem(typeof (IColumnMap))]
		ArrayList ColumnMaps { get; set; }

		IColumnMap MustGetColumnMap(string findName);

		IColumnMap GetColumnMap(string findName);

		ArrayList GetPrimaryKeyColumnMaps();

		ArrayList GetForeignKeyColumnMaps();

		ArrayList GetForeignKeyColumnMaps(string foreignKeyName);

		ArrayList GetDefaultValueColumnMaps();

		void UpdateName(string newName);

        int LockIndex { get; set; }

        int GetLockIndex();
	}
}