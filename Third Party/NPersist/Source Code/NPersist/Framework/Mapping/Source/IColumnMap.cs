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
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public interface IColumnMap : IMap
	{
		[XmlIgnore()]
		ITableMap TableMap { get; set; }

		void SetTableMap(ITableMap value);

		DbType DataType { get; set; }

		int Length { get; set; }

		bool IsAutoIncrease { get; set; }

		string Format { get; set; }

		bool AllowNulls { get; set; }

		bool IsForeignKey { get; set; }

		bool IsPrimaryKey { get; set; }

		int Increment { get; set; }

		int Seed { get; set; }

		string DefaultValue { get; set; }

		int Precision { get; set; }

		int Scale { get; set; }

		string ForeignKeyName { get; set; }

		string PrimaryKeyTable { get; set; }

		ITableMap MustGetPrimaryKeyTableMap();

		ITableMap GetPrimaryKeyTableMap();

		string PrimaryKeyColumn { get; set; }

		IColumnMap MustGetPrimaryKeyColumnMap();

		IColumnMap GetPrimaryKeyColumnMap();

		string Sequence { get; set; }

		bool IsFixedLength { get; set; }

		string SpecificDataType { get; set; }

		void UpdateName(string newName);

		Type GetSystemType();
	}
}