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
using System.Data;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Sql.Dom;
using Puzzle.NPersist.Framework.Sql.Visitor;
using Puzzle.NPersist.Framework.Utility;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for SqlEngineOracle.
	/// </summary>
	public class SqlEngineOracle : SqlEngineBase
	{
		public SqlEngineOracle()
		{
		}

		#region Property  AutoIncreaserStrategy
		
		private AutoIncreaserStrategy autoIncreaserStrategy = AutoIncreaserStrategy.SelectNextSequence ;
		
		public override AutoIncreaserStrategy AutoIncreaserStrategy
		{
			get { return this.autoIncreaserStrategy; }
			set { this.autoIncreaserStrategy = value; }
		}
		
		#endregion

		protected override ISqlVisitor GetVisitor()
		{
			return new SqlOracleVisitor();
		}

		protected override string GetParameterName(IPropertyMap propertyMap)
		{
			return GetParameterName(propertyMap, "");			
		}

		protected override string GetParameterName(IPropertyMap propertyMap, string prefix)
		{
			string name = prefix;
			name = name + propertyMap.Name;
			name = ":" + name + GetNextParamNr().ToString() ;
			return name;
		}

		protected override string GetParameterName(IClassMap classMap)
		{
			return GetParameterName(classMap, "");			
		}

		protected override string GetParameterName(IClassMap classMap, string prefix)
		{
			string name = prefix;
			name = name + classMap.Name;
			name = ":" + name;
			return name;
		}

		protected override string GetParameterName(IPropertyMap propertyMap, IColumnMap columnMap)
		{
			return GetParameterName(propertyMap, columnMap, "");			
		}

		protected override string GetParameterName(IPropertyMap propertyMap, IColumnMap columnMap, string prefix)
		{
			string name = prefix;
			name = name + propertyMap.Name;
			name = name + "_" + columnMap.Name;
			name = ":" + name;
			return name;
		}

		protected override string GenerateSql(SqlStatement statement)
		{
			ISqlVisitor visitor = GetVisitor();
			statement.Accept(visitor);
			return visitor.Sql;
		}

	}
}
