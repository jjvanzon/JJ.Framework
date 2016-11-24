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
using Puzzle.NPersist.Framework.Sql.Visitor;
using Puzzle.NPersist.Framework.Utility;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class SqlEngineMsAccess : SqlEngineBase
	{
		private string m_DateDelimiter = "#";

		public override string DateDelimiter
		{
			get { return m_DateDelimiter; }
			set { m_DateDelimiter = value; }
		}

		public override void InsertObject(object obj, IList stillDirty)
		{
			IList parameters = new ArrayList() ;
			ArrayList propertyNames = new ArrayList();
			IPropertyMap propertyMap;

			ArrayList nonPrimaryPropertyMaps = new ArrayList();
			ArrayList collectionPropertyMaps = new ArrayList();
			ArrayList sqlStatements = new ArrayList();
			int rowsAffected;
			object autoID;
			IPropertyMap autoProp;
			IColumnMap autoPropCol;
			string autoPropName;
			string prevId;
			bool originalKeepOpen;
			IContext ctx = SqlEngineManager.Context;
			ObjectCancelEventArgs e = new ObjectCancelEventArgs(obj);
			ctx.EventManager.OnInsertingObject(this, e);
			if (e.Cancel)
			{
				return;
			}
			IObjectManager om = ctx.ObjectManager;
			IListManager lm = ctx.ListManager;
			IClassMap classMap = ctx.DomainMap.MustGetClassMap(obj.GetType());
			string sqlSelect = "";
			string sql;
			if (classMap.HasSingleIdAutoIncreaser())
			{
				sql = GetInsertStatement(obj, propertyNames, stillDirty, nonPrimaryPropertyMaps, collectionPropertyMaps, ref sqlSelect, parameters);
			}
			else
			{
				sql = GetInsertStatement(obj, propertyNames, stillDirty, nonPrimaryPropertyMaps, collectionPropertyMaps, parameters);
			}
			IDataSource ds = ctx.DataSourceManager.GetDataSource(obj);
			if (classMap.HasSingleIdAutoIncreaser())
			{
				originalKeepOpen = ds.KeepConnectionOpen;
				ds.KeepConnectionOpen = true;
				rowsAffected = ctx.SqlExecutor.ExecuteNonQuery(sql, ds, parameters);
				if (!(rowsAffected == 1))
				{
					ds.KeepConnectionOpen = originalKeepOpen;
					throw new NPersistException("An exception occurred when inserting the row for a new object into the data source. Exactly one row should have been affected by the insert operation. Instead " + rowsAffected + " rows were affected!"); // do not localize
				}
				object[,] result = (object[,]) ctx.SqlExecutor.ExecuteArray(sqlSelect, ds, parameters);
				if (Util.IsArray(result))
				{
					prevId = om.GetObjectIdentity(obj);
					autoProp = classMap.GetAutoIncreasingIdentityPropertyMap();
					autoPropName = autoProp.Name;
					autoPropCol = autoProp.GetColumnMap();
					if (autoPropCol.DataType == DbType.Int64)
					{
						autoID = Convert.ToInt64(result[0, 0]);						
					}
					else if (autoPropCol.DataType == DbType.Int16)
					{
						autoID = Convert.ToInt16(result[0, 0]);						
					}
					else
					{
						autoID = Convert.ToInt32(result[0, 0]);						
					}					
					om.SetPropertyValue(obj, autoPropName, autoID);
					//om.SetOriginalPropertyValue(obj, autoPropName, autoID);
					om.SetNullValueStatus(obj, autoPropName, false);
					ctx.IdentityMap.UpdateIdentity(obj, prevId);
				}
				else
				{
					ds.KeepConnectionOpen = originalKeepOpen;
					throw new FailedFetchingDbGeneratedValueException("Could not find auto-increasing ID for new object!"); // do not localize
				}
				ds.KeepConnectionOpen = originalKeepOpen;
			}
			else
			{
				rowsAffected = ctx.SqlExecutor.ExecuteNonQuery(sql, ds, parameters);
				if (!(rowsAffected == 1))
				{
					throw new RowNotInsertedException("A new row was not inserted in the data source for a new object."); // do not localize
				}
			}
//			foreach (string propName in propertyNames)
//			{
//				om.SetOriginalPropertyValue(obj, propName, om.GetPropertyValue(obj, propName));
//			}
			InsertNonPrimaryProperties(obj, nonPrimaryPropertyMaps, stillDirty);
			foreach (IPropertyMap iPpropertyMap in collectionPropertyMaps)
			{
				propertyMap = iPpropertyMap;
				sqlStatements.Clear();
				GetInsertCollectionPropertyStatements(obj, propertyMap, sqlStatements, stillDirty);
				ds = ctx.DataSourceManager.GetDataSource(obj, propertyMap.Name);
				foreach (SqlStatementAndDbParameters sqlStatementAndDbParameters in sqlStatements)
				{
					sql = sqlStatementAndDbParameters.SqlStatement;
					rowsAffected = ctx.SqlExecutor.ExecuteNonQuery(sql, ds, sqlStatementAndDbParameters.DbParameters);
					if (!(rowsAffected == 1))
					{
						throw new RowNotInsertedException("A new row was not inserted in the data source for a collection property of a new object."); // do not localize
					}
				}
			}
			ctx.InverseManager.NotifyCreate(obj);
			ObjectEventArgs e2 = new ObjectEventArgs(obj);
			ctx.EventManager.OnInsertedObject(this, e2);
		}

		protected string GetInsertStatement(object obj, ArrayList propertyNames, IList stillDirty, ArrayList nonPrimaryPropertyMaps, ArrayList collectionPropertyMaps, ref string sqlSelect, IList parameters)
		{
			return GetInsertStatementOnIdentity(obj, propertyNames, stillDirty, nonPrimaryPropertyMaps, collectionPropertyMaps, ref sqlSelect, parameters);
		}

		protected string GetInsertStatementOnIdentity(object obj, ArrayList propertyNames, IList stillDirty, ArrayList nonPrimaryPropertyMaps, ArrayList collectionPropertyMaps, ref string sqlSelect, IList parameters)
		{
			sqlSelect = "Select @@IDENTITY"; // do not localize
			return GetInsertStatement(obj, propertyNames, stillDirty, nonPrimaryPropertyMaps, collectionPropertyMaps, parameters);
		}

		protected string GetInsertStatementOnDataMatch(object obj, ArrayList propertyNames, IList stillDirty, ArrayList nonPrimaryPropertyMaps, ArrayList collectionPropertyMaps, ref string sqlSelect, IList parameters)
		{
			string sql;
			string sqlInsert = "";
			string sqlColumns = "";
			string sqlValues = "";
			string sqlWhere = "";
			IDomainMap domainMap;
			IClassMap classMap;
			IPropertyMap propertyMap;
			IColumnMap columnMap;
			ITableMap tableMap;
			string table;
			string schema;
			string wrSchema;
			object refObj;
			IObjectManager om;
			bool ignore;
			IColumnMap typeColMap;
			string wrappedValue;
			string compareOp = "";
			string idColName = "";
			stillDirty.Clear() ;
			domainMap = SqlEngineManager.Context.DomainMap;
			classMap = domainMap.MustGetClassMap(obj.GetType());
			om = SqlEngineManager.Context.ObjectManager;
			tableMap = classMap.MustGetTableMap();
			table = tableMap.Name;
			schema = tableMap.SourceMap.Schema;
			if (schema.Length < 1)
			{
				wrSchema = "";
			}
			else
			{
				wrSchema = "[" + schema + "].";
			}
			sqlInsert += wrSchema + "[" + table + "]";
			foreach (IPropertyMap iPropertyMap in classMap.GetAllPropertyMaps())
			{
				propertyMap = iPropertyMap;
				if (!propertyMap.IsReadOnly && !propertyMap.IsSlave)
				{
					if (propertyMap.IsCollection)
					{
						collectionPropertyMaps.Add(propertyMap);
					}
					else
					{
						ignore = false;
						if (propertyMap.GetColumnMap().IsAutoIncrease)
						{
							if (propertyMap.IsIdentity)
							{
								idColName += "[" + table + "].[" + propertyMap.Column + "]";
							}
							ignore = true;
						}
						else if (!(propertyMap.ReferenceType == ReferenceType.None))
						{
							refObj = om.GetPropertyValue(obj, propertyMap.Name);
							if (refObj != null)
							{
								if (om.GetObjectStatus(refObj) == ObjectStatus.UpForCreation)
								{
									ignore = true;
									stillDirty.Add(propertyMap);
								}
							}
						}
						if (!(ignore))
						{
							if (!(propertyMap.MustGetTableMap() == tableMap))
							{
								nonPrimaryPropertyMaps.Add(propertyMap);
							}
							else
							{
								if (!(om.GetNullValueStatus(obj, propertyMap.Name)))
								{
									columnMap = propertyMap.GetColumnMap();
									sqlColumns += wrSchema + "[" + columnMap.Name + "], ";
									wrappedValue = WrapValue(obj, propertyMap, om.GetPropertyValue(obj, propertyMap.Name), columnMap, ref compareOp);
									sqlValues += wrappedValue + ", ";
									sqlWhere += wrSchema + "[" + columnMap.Name + "] " + compareOp + " " + wrappedValue + " And "; // do not localize
									propertyNames.Add(propertyMap.Name);
									foreach (IColumnMap iColumnMap in propertyMap.GetAdditionalColumnMaps())
									{
										columnMap = iColumnMap;
										sqlColumns += wrSchema + "[" + columnMap.Name + "], ";
										wrappedValue = WrapValue(obj, propertyMap, om.GetPropertyValue(obj, propertyMap.Name), columnMap, ref compareOp);
										sqlValues += wrappedValue + ", ";
										sqlWhere += wrSchema + "[" + columnMap.Name + "] " + compareOp + " " + wrappedValue + " And "; // do not localize
									}
								}
							}
						}
					}
				}
			}
			typeColMap = classMap.GetTypeColumnMap();
			if (typeColMap != null)
			{
				sqlColumns += wrSchema + "[" + typeColMap.Name + "], ";
				wrappedValue = WrapValue(obj, null, classMap.TypeValue, typeColMap, ref compareOp, true);
				sqlValues += wrappedValue + ", ";
				sqlWhere += wrSchema + "[" + typeColMap.Name + "] " + compareOp + " " + wrappedValue + " And "; // do not localize
			}
			if (sqlColumns.Length > 0)
			{
				sqlColumns = sqlColumns.Substring(0, sqlColumns.Length - 2);
			}
			if (sqlValues.Length > 0)
			{
				sqlValues = sqlValues.Substring(0, sqlValues.Length - 2);
			}
			if (sqlWhere.Length > 0)
			{
				sqlWhere = sqlWhere.Substring(0, sqlWhere.Length - 5);
			}
			sql = "Insert Into " + sqlInsert + " (" + sqlColumns + ") Values (" + sqlValues + ")"; // do not localize
			sqlSelect = "Select Top 1 " + idColName + " From " + sqlInsert + " Where " + sqlWhere; // do not localize
			return sql;
		}

		protected override string WrapBoolean(bool value)
		{
			if (value)
			{
				return "True";
			}
			else
			{
				return "False";
			}
		}

		protected override string GetParameterName(IPropertyMap propertyMap)
		{
			return "?";			
		}

		protected override string GetParameterName(IPropertyMap propertyMap, string prefix)
		{
			return "?";			
		}

		protected override string GetParameterName(IClassMap classMap)
		{
			return "?";			
		}

		protected override string GetParameterName(IClassMap classMap, string prefix)
		{
			return "?";			
		}

		protected override string GetParameterName(IPropertyMap propertyMap, IColumnMap columnMap)
		{
			return "?";			
		}

		protected override string GetParameterName(IPropertyMap propertyMap, IColumnMap columnMap, string prefix)
		{
			return "?";			
		}

		protected override ISqlVisitor GetVisitor()
		{
			return new SqlAccessVisitor();
		}
	}
}