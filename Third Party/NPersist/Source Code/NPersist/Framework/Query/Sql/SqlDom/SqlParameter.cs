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
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlParameter.
	/// </summary>
	public class SqlParameter : SqlExpression 
	{
		public SqlParameter(SqlStatement sqlStatement, object value, DbType dbType, string name)
		{
			this.Parent = sqlStatement ;
			this.value = value;
			this.dbType = dbType;
			this.name = name;
		}

		public SqlParameter(SqlStatement sqlStatement, object value, DbType dbType) : this(sqlStatement, value, dbType, "")
		{
		}

		public SqlParameter(SqlStatement sqlStatement, string name) : this(sqlStatement, null, DbType.AnsiString, "")
		{

		}

		public SqlStatement SqlStatement => this.Parent as SqlStatement;

	    #region Property  DbType
		
		private DbType dbType;
		
		public DbType DbType
		{
			get => this.dbType;
		    set => this.dbType = value;
		}

		#endregion

		#region Property  Value
		
		private object value;
		
		public object Value
		{
			get => this.value;
		    set => this.value = value;
		}
		
		#endregion

		#region Property  Name
		
		private string name;
		
		public string Name
		{
			get => this.name;
		    set => this.name = value;
		}
		
		#endregion

		public string GetName()
		{
			if (this.name == "")
				this.name = "@param" + this.SqlStatement.GetNextParameterIndex().ToString();
            return this.name;
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	
	}
}
