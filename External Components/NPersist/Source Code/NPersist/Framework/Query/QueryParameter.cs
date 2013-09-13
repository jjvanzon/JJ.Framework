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
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Puzzle.NPersist.Framework.Querying
{
	/// <summary>
	/// Summary description for DbParameter.
	/// </summary>
	public class QueryParameter : IQueryParameter
	{
		public QueryParameter()
		{
		}

		public QueryParameter(string name, DbType dbType)
		{
			this.name = name;
			this.dbType = dbType;
		}

		public QueryParameter(string name, DbType dbType, object value)
		{
			this.name = name;
			this.dbType = dbType;
			this.value = value;
		}

		public QueryParameter(DbType dbType, object value)
		{
			this.dbType = dbType;
			this.value = value;
		}

		public QueryParameter(object value)
		{
			this.value = value;
		}

		private string name = "";
		
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		private object value = null;
		
		public object Value
		{
			get { return this.value; }
			set { this.value = value; }
		}

		private DbType dbType;
		
		public DbType DbType
		{
			get { return this.dbType; }
			set { this.dbType = value; }
		}

		public void AddToDbCommand(IDbCommand dbCommand)
		{
			IDbDataParameter dbParam = dbCommand.CreateParameter();
			dbParam.ParameterName = this.name;
			dbParam.DbType = this.dbType;				
			if (this.dbType == DbType.Object)
			{
				if (dbParam is SqlParameter)
				{
					((System.Data.SqlClient.SqlParameter)dbParam).SqlDbType = SqlDbType.Image;					
				}
			}
			if (value != null)
			{
				dbParam.Value = this.value;				
			}
			else
			{
				dbParam.Value = System.DBNull.Value;
			}
			OleDbParameter oleDbParam = dbParam as OleDbParameter ;
			if (oleDbParam != null)
			{
				if (this.dbType == DbType.DateTime)
				{
					oleDbParam.OleDbType = OleDbType.Date ;
				}
			}
			//			if (this.dbType == DbType.AnsiString || 
			//				this.dbType == DbType.AnsiStringFixedLength || 
			//				this.dbType == DbType.String || 
			//				this.dbType == DbType.StringFixedLength)
			//			{
			//				if (this.value != null)
			//				{
			//					if (!(System.DBNull.Value.Equals(this.value)))
			//					{
			//						dbParam.Size = ((string)this.value).Length;
			//					}					
			//				}
			//			}
			dbCommand.Parameters.Add(dbParam);
		}

	}
}
