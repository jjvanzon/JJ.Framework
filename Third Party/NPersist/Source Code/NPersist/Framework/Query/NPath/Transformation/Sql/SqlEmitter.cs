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
using System.Globalization;
using System.Text;
using System.Collections;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPath.Framework;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPath.Framework.CodeDom;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Sql.Dom;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.NPath.Sql 
{
	public class SqlEmitter 
	{
		#region Constructors

		public SqlEmitter(INPathEngine npathEngine, NPathSelectQuery query,NPathQueryType queryType)
		{
			this.npathEngine = npathEngine;
			this.query = query;
			propertyPathTraverser = new PropertyPathTraverser(this);
			this.propertyColumnMap = new Hashtable() ;
			this.npathQueryType = queryType;

		}

		public SqlEmitter(INPathEngine npathEngine, NPathSelectQuery query,NPathQueryType queryType, IClassMap rootClassMap)
		{
			this.npathEngine = npathEngine;
			this.query = query;
			this.rootClassMap = rootClassMap;
			propertyPathTraverser = new PropertyPathTraverser(this);
			this.propertyColumnMap = new Hashtable() ;
			this.npathQueryType = queryType;
		}

		public SqlEmitter(INPathEngine npathEngine, NPathSelectQuery query,NPathQueryType queryType, IClassMap rootClassMap, Hashtable propertyColumnMap)
		{
			this.npathEngine = npathEngine;
			this.query = query;
			this.rootClassMap = rootClassMap;
			propertyPathTraverser = new PropertyPathTraverser(this);
			this.propertyColumnMap = propertyColumnMap;
			this.npathQueryType = queryType;
		}

		public SqlEmitter(INPathEngine npathEngine, NPathSelectQuery query,NPathQueryType queryType, IClassMap rootClassMap,SqlSelectStatement parentQuery,IPropertyMap backReference,int subQueryLevel)
		{
			this.npathEngine = npathEngine;
			this.query = query;
			this.rootClassMap = rootClassMap;
			propertyPathTraverser = new PropertyPathTraverser(this);
			this.propertyColumnMap = new Hashtable() ;
			this.npathQueryType = queryType;
			this.parentQuery = parentQuery;
			this.backReference = backReference;
			this.subQueryLevel = subQueryLevel;
		}

		#endregion

		#region Private Member Variables

        private int orExpressionCount;
		private int subQueryLevel;
		private SqlSelectStatement parentQuery;
		private IPropertyMap backReference;
		private SqlSelectStatement select = new SqlSelectStatement("");
		private ISqlConditionChainPart conditionChainOwner;

		private INPathEngine npathEngine = null;
		private NPathSelectQuery query = null;
		private IClassMap rootClassMap = null;
		private IClassMap baseClassMap = null;
		private PropertyPathTraverser propertyPathTraverser = null;
		private Hashtable propertyColumnMap = null;

		private int tableAliasCounter = 0;
		private int columnAliasCounter = 0;

		private string tableAlias = "tbl";
		private string columnAlias = "col";

		public NPathQueryType npathQueryType = NPathQueryType.SelectObjects;

		private ArrayList includedTableAliases = new ArrayList();

		private Hashtable tableAliases = new Hashtable();
		private Hashtable columnAliases = new Hashtable();

		private ArrayList fromTables = new ArrayList() ;
		private ArrayList fromAliasTables = new ArrayList() ;
		private ArrayList fromJoinTables = new ArrayList() ;
		private Hashtable expressionAliases = new Hashtable() ;

		private string sql = "";

		#endregion

		#region Public Properties

        public bool HasOrExpression
        {
            get
            {
                return orExpressionCount > 0;
            }
        }
		
		public string Sql
		{
			get { return this.sql; }
		}

		public SqlSelectStatement Select
		{
			get { return this.select; }
			set { this.select = value; }
		}

		public INPathEngine NPathEngine
		{
			get { return this.npathEngine; }
			set { this.npathEngine = value; }
		}

		public IClassMap RootClassMap
		{
			get { return this.rootClassMap; }
			set { this.rootClassMap = value; }
		}

		public Hashtable PropertyColumnMap
		{
			get { return this.propertyColumnMap; }
			set { this.propertyColumnMap = value; }
		}
		public Hashtable TableAliases
		{
			get { return this.tableAliases; }
			set { this.tableAliases = value; }
		}

		public Hashtable ColumnAliases
		{
			get { return this.columnAliases; }
			set { this.columnAliases = value; }
		}

		//private IList resultParameters = new ArrayList() ;
		
		public IList ResultParameters
		{
			get { return this.NPathEngine.ResultParameters;  }
		}

		#endregion

		#region Public Methods
				
		#region EmitSql

		public string EmitSql()
		{
			
			BuildSqlDom();

			return AssembleQuery();
		}

		public SqlSelectStatement BuildSqlDom()
		{
			this.baseClassMap = this.rootClassMap.GetBaseClassMap(); 
			EmitSelect();
			EmitFrom();
			EmitWhere();
			EmitOrderBy();
			EmitJoins();
						
			return select;
		}

		#endregion

		#region DeduceQueryType

		public static NPathQueryType DeduceQueryType(NPathSelectQuery query)
		{
			if (query.Select != null)
			{
				return DeduceQueryType(query.Select);
			}
			return NPathQueryType.SelectObjects;
		}

		public static NPathQueryType DeduceQueryType(NPathSelectClause select)
		{
			int cntPropPath = 0;
			int cntFnc = 0;
			int cntParenthesis = 0;
			int cntAlias = 0;

			foreach (NPathSelectField field in select.SelectFields)
			{
				if (field.Expression is NPathIdentifier)
				{
					cntPropPath++;
				}
				if (field.Alias != null && field.Alias.Length > 0)
				{
					cntAlias++;
				}
				if (field.Expression is NPathFunction)
				{
					cntFnc++;
				}
				if (field.Expression is NPathParenthesisGroup)
				{
					cntParenthesis++;
				}
			}

			if (select.SelectFields.Count == 1 && cntFnc == 1 && cntPropPath == 0)
			{
				return NPathQueryType.SelectScalar;
			}
//			if (cntFnc > 0 && cntPropPath > 0)
//			{
//				return NPathQueryType.SelectMixed;				
//			}
			if (cntFnc > 1 || cntParenthesis > 0 || cntAlias > 0)
			{
				return NPathQueryType.SelectTable;				
			}
			if (cntFnc == 0 && cntPropPath > 0)
			{
				return NPathQueryType.SelectObjects;				
			}

			return NPathQueryType.SelectObjects;				
		}

		#endregion

		#region GetTableAlias

		public SqlTableAlias GetTableAlias(ITableMap tableMap, object hash)
		{
			string alias;
			if (hash is IPropertyMap)
			{
				IPropertyMap propertyMap = (IPropertyMap) hash;
				if (!propertyMap.IsCollection)
				{
					if (propertyMap.ClassMap == this.rootClassMap || propertyMap.ClassMap == this.baseClassMap)
					{
						hash = this.baseClassMap;						
						//					if (propertyMap.GetTableMap() == propertyMap.ClassMap.GetTableMap())
						//					{
						//						hash = this.baseClassMap;						
						//					}
						//					else
						//					{
						//						hash = propertyMap.Name;
						//					}
					}			
				}
				else
				{
					hash = propertyMap.Name;
				}	
			}
			else if (hash is IClassMap)
			{
				if (hash == this.rootClassMap)
					hash = this.baseClassMap;
			}
			else if (hash is TableJoin)
			{
				hash = ((TableJoin) hash).GetPropertyPath();
			}

			if (!tableAliases.Contains(tableMap))
			{
				tableAliases[tableMap] = new Hashtable();
			}				

			Hashtable propertyTableAliases = (Hashtable) tableAliases[tableMap];

			if (propertyTableAliases.Contains(hash))
			{
				alias = (string) propertyTableAliases[hash];
				return this.select.GetSqlTableAlias(tableMap, alias);
			}

			alias = CreateTableAlias();
			propertyTableAliases[hash] = alias;
			return this.select.GetSqlTableAlias(tableMap, alias);
		}

		#endregion

		#region GetColumnAlias

		public SqlColumnAlias GetColumnAlias(SqlTableAlias tableAlias, IColumnMap columnMap, object hash, string suggestion)
		{
			string alias;

			if (hash is IPropertyMap)
			{
				if (((IPropertyMap) hash).ClassMap == this.rootClassMap || ((IPropertyMap) hash).ClassMap == this.baseClassMap)
				{
					hash = this.baseClassMap;
				}				
			}
			else if (hash is TableJoin)
			{
				hash = ((TableJoin) hash).GetPropertyPath();
			}
			else if (hash is string)
			{
				if (((string)hash).Length < 1)
				{
					hash = this.baseClassMap;					
				}
			}

			if (!columnAliases.Contains(columnMap))
			{
				columnAliases[columnMap] = new Hashtable();
			}				

			Hashtable propertyColumnAliases = (Hashtable) columnAliases[columnMap];

			if (propertyColumnAliases.Contains(hash))
			{
				alias = (string) propertyColumnAliases[hash];
				return tableAlias.GetSqlColumnAlias(columnMap, alias);
			}

			if (suggestion.Length > 0)
				alias = suggestion;
			else
				alias = CreateColumnAlias();
			propertyColumnAliases[hash] = alias;
			return tableAlias.GetSqlColumnAlias(columnMap, alias);
		}

		#endregion

		#endregion

		#region Private Methods

		#region Statement Assembly

		

		#region AssembleQuery

		private string AssembleQuery()
		{
			ISqlVisitor visitor = GetSqlVisitor();
			select.Accept(visitor);
			sql = visitor.Sql;
			return sql;
		}

		private ISqlVisitor GetSqlVisitor()
		{
			ISqlVisitor visitor = null;

			if (this.RootClassMap != null)
			{
				ISourceMap sourceMap = this.RootClassMap.GetSourceMap();
				if (sourceMap != null)
				{
					if (sourceMap.SourceType == SourceType.MSSqlServer)
					{
						visitor = new SqlSqlServerVisitor() ;	
					}
					if (sourceMap.SourceType == SourceType.MSAccess)
					{
						visitor = new SqlAccessVisitor() ;	
					}
					if (sourceMap.SourceType == SourceType.Oracle)
					{
						visitor = new SqlOracleVisitor() ;	
					}
				}
			}

			if (visitor == null)		
				visitor = new SqlVisitorBase();
	
			return visitor;
		}

		#endregion

		#region Statement Assembly Helpers

		#region GetWhereClauseJoinTables

		private void GetWhereClauseJoinTables()
		{
			JoinTree joinTree = this.propertyPathTraverser.JoinTree;
			joinTree.TableMap = rootClassMap.MustGetTableMap();

			GetWhereClauseJoinTables(joinTree.TableJoins);
		}

		private void GetWhereClauseJoinTables(ArrayList tableJoins)
		{
			ReferenceType refType;

			foreach (TableJoin tableJoin in tableJoins)
			{
				refType = tableJoin.PropertyMap.ReferenceType;
				if (refType != ReferenceType.None)
				{
					CreateJoin(tableJoin);
					if (tableJoin.JoinType == JoinType.InnerJoin)
					{
						EmitOldStyleInnerJoin(tableJoin);					
					}
					else
					{					
						FromTable fromTable = new FromTable();
						EmitLeftOuterJoin(tableJoin, fromTable);
						fromJoinTables.Add(fromTable);			
					}
				}
				GetWhereClauseJoinTables(tableJoin.Children);					
			}
		}

		#endregion

		#region EmitOldStyleInnerJoin

		private void EmitOldStyleInnerJoin(TableJoin tableJoin) 
		{
			IPropertyMap propertyMap = tableJoin.PropertyMap;
			ITableMap tableMap = propertyMap.MustGetTableMap();
			ArrayList columnMaps = tableJoin.ColumnMaps;
			object hashObject = tableJoin.Parent;
			if (hashObject == null) { hashObject = propertyMap; }
			SqlTableAlias tbl = GetTableAlias(tableMap, hashObject);
			SqlColumnAlias col;
			SqlTableAlias idtbl = null;
			SqlColumnAlias idcol;
			foreach (IColumnMap columnMap in columnMaps) 
			{
				if (idtbl == null) 
				{
					idtbl = GetTableAlias(columnMap.MustGetPrimaryKeyTableMap(), tableJoin);					
				}
				col = tbl.GetSqlColumnAlias(columnMap);
				idcol = idtbl.GetSqlColumnAlias(columnMap.MustGetPrimaryKeyColumnMap());

				SqlSearchCondition search = select.SqlWhereClause.GetNextSqlSearchCondition();
				search.GetSqlComparePredicate(col, SqlCompareOperatorType.Equals, idcol);
			}
			if (tableJoin.BaseTableMap != null) 
			{
				columnMaps = tableJoin.BaseColumnMaps;
				tbl = GetTableAlias(tableMap, hashObject);
				idtbl = null;
				foreach (IColumnMap columnMap in columnMaps) 
				{
					if (idtbl == null) 
					{
                        //TODO: examine this line , this causes a bug with an extra table alias in some cases
                        //the from "classmap" already got an alias , and this line uses a new hash  key and thus creating an extra alias
                        //if (hashObject is IPropertyMap) { hashObject = tableJoin ; }


						//FIX: Roger, if the classmap is the root class then use the classmap as key
						if (hashObject is IPropertyMap) 
						{
							IClassMap classMap = ((IPropertyMap) hashObject).ClassMap ; 

							if (classMap == this.RootClassMap)
							{
								hashObject = classMap;
							}
							else
							{
								hashObject = tableJoin;	
							}
						}
                        idtbl = GetTableAlias(columnMap.MustGetPrimaryKeyTableMap(), hashObject);					
						
                       
						
					}
					col = tbl.GetSqlColumnAlias(columnMap);
					idcol = idtbl.GetSqlColumnAlias(columnMap.MustGetPrimaryKeyColumnMap());

					SqlSearchCondition search = select.SqlWhereClause.GetNextSqlSearchCondition();
					search.GetSqlComparePredicate(col, SqlCompareOperatorType.Equals, idcol);				
                }
				
			}
		}

		#endregion

		#region CreateJoin

		private void CreateJoin(TableJoin tableJoin) 
		{
			IPropertyMap propertyMap = tableJoin.PropertyMap;
			tableJoin.TableMap = propertyMap.MustGetTableMap();
			tableJoin.ColumnMaps = propertyMap.GetAllColumnMaps();
			//fails on self-join
			//if (tableJoin.TableMap != propertyMap.ClassMap.GetTableMap())
			ArrayList idColumns = propertyMap.GetAllIdColumnMaps();
			if (idColumns.Count > 0 )
			{
				tableJoin.BaseTableMap = propertyMap.ClassMap.MustGetTableMap();
				tableJoin.BaseColumnMaps = idColumns;
			}
		}

		#endregion

		#region GetFromClauseJoinTables

		private void GetFromClauseJoinTables() 
		{
			Hashtable tablePropertyAliases = null;
			foreach (ITableMap tableMap in this.tableAliases.Keys)
			{
				tablePropertyAliases = (Hashtable) this.tableAliases[tableMap];
				foreach (string s in tablePropertyAliases.Values)
				{
					SqlTableAlias table = select.GetSqlTableAlias(tableMap, s);
					if (!(includedTableAliases.Contains(table)))
					{
						FromTable fromTable = new FromTable() ;

						fromTable.Alias = table;
						
						fromAliasTables.Add(fromTable);

						includedTableAliases.Add(table);
					}
				}
			}
		}

		#endregion

		#region Emit FromTable

		private void EmitFromTable(FromTable fromTable)
		{
			if (fromTable.LinksToAlias != null)
			{
				SqlJoinTableSource join = select.SqlFromClause.AddSqlJoinTableSource(fromTable.Alias, fromTable.LinksToAlias, SqlJoinType.LeftOuter);
				int i = 0;

				foreach (SqlColumnAlias column in fromTable.Columns)
				{
					SqlColumnAlias linksToColumn = (SqlColumnAlias) fromTable.LinksToColumns[i];
					
					SqlSearchCondition search = join.GetNextSqlSearchCondition();
					search.GetSqlComparePredicate(column, SqlCompareOperatorType.Equals,  linksToColumn);

					i++;
				}

			}
			else
			{
				select.SqlFromClause.AddSqlAliasTableSource(fromTable.Alias);
			}

		}

		#endregion

		#region RenderLeftOuterJoinFrom

		private void RenderLeftOuterJoinFrom(FromTable tbl)
		{
			foreach ( FromTable fromTable in fromJoinTables )
			{
				if (fromTable.LinksToAlias == tbl.Alias )
				{
					EmitFromTable(fromTable);

					RenderLeftOuterJoinFrom(fromTable);
				}					
			}
		}

		#endregion

		#region EmitLeftOuterJoin

		private string EmitLeftOuterJoin(TableJoin tableJoin, FromTable fromTable) //, StringBuilder whereBuilder)
		{
			StringBuilder clause = new StringBuilder() ;
			IPropertyMap propertyMap = tableJoin.PropertyMap ;
			ITableMap tableMap = propertyMap.MustGetTableMap();
			ArrayList columnMaps = tableJoin.ColumnMaps;
			object hashObject = tableJoin.Parent;
			if (hashObject == null) { hashObject = propertyMap; }
			SqlTableAlias tbl = GetTableAlias(tableMap, hashObject);
			SqlColumnAlias col;
			SqlTableAlias idtbl = null;
			SqlColumnAlias idcol;
			ITableMap idTableMap;
			foreach (IColumnMap columnMap in columnMaps)
			{
				if (idtbl == null)
				{
					idTableMap = columnMap.MustGetPrimaryKeyTableMap();
					idtbl = GetTableAlias(idTableMap, tableJoin);
				}
				col = tbl.GetSqlColumnAlias(columnMap);
				idcol = idtbl.GetSqlColumnAlias(columnMap.MustGetPrimaryKeyColumnMap());
				fromTable.Alias = idtbl;
				fromTable.LinksToAlias = tbl;
				fromTable.Columns.Add(idcol); 
				fromTable.LinksToColumns.Add(col); 
				this.includedTableAliases.Add(idtbl);
			}
			if (tableJoin.BaseTableMap != null)
			{
				columnMaps = tableJoin.BaseColumnMaps;
				tbl = GetTableAlias(tableMap, hashObject);
				idtbl = null;
				foreach (IColumnMap columnMap in columnMaps)
				{
					if (idtbl == null)
					{
						if (hashObject is IPropertyMap) { hashObject = ((IPropertyMap) hashObject).ClassMap ; }
						idtbl = GetTableAlias(columnMap.MustGetPrimaryKeyTableMap(), hashObject);					
					}
					col = tbl.GetSqlColumnAlias(columnMap);
					idcol = idtbl.GetSqlColumnAlias(columnMap.MustGetPrimaryKeyColumnMap());

//					fromTable.Alias = idtbl;
//					fromTable.LinksToAlias = tbl;
//					fromTable.Columns.Add(idcol); 
//					fromTable.LinksToColumns.Add(col); 
//					this.includedTableAliases.Add(idtbl);

					fromTable.Alias = tbl;
					fromTable.LinksToAlias = idtbl;
					fromTable.Columns.Add(col); 
					fromTable.LinksToColumns.Add(idcol); 
					this.includedTableAliases.Add(tbl);

//					SqlSearchCondition search = select.SqlWhereClause.GetNextSqlSearchCondition();
//					search.GetSqlComparePredicate(col, SqlCompareOperatorType.Equals, idcol);
				}
				
			}
			return clause.ToString();			
		}

		#endregion

		#endregion

		#endregion

		#region Clause Emission

		#region EmitJoins

		private void EmitJoins()
		{
			ArrayList allFromTables = new ArrayList() ;

			GetWhereClauseJoinTables();


			if (this.rootClassMap.GetTypeColumnMap() != null)
			{
				IList subClassMaps = new ArrayList();

				foreach (IClassMap subClassMap in this.rootClassMap.GetSubClassMaps())
				{
					if (subClassMap.InheritanceType != InheritanceType.ConcreteTableInheritance)
					{
						subClassMaps.Add(subClassMap); 						
					}					
				}
				subClassMaps.Add(this.rootClassMap); 

				//Don't forget: We must add type column to where clause!
				SqlSearchCondition search = select.SqlWhereClause.GetNextSqlSearchCondition();
				SqlSearchCondition nextSearch = search.GetSubSqlSearchCondition();

				foreach (IClassMap subClassMap in subClassMaps)
				{
					AddTypeColumnToWhereClause(subClassMap, nextSearch);
					if (subClassMap != subClassMaps[subClassMaps.Count -1])
					{
						nextSearch = nextSearch.GetNextSqlSearchCondition();
					}
				}
				
			}


			//Not so clear from name: This method also
			//sets up left outer joins
			GetFromClauseJoinTables();

			foreach (FromTable tbl in fromTables )
			{
				allFromTables.Add(tbl);
			}

			foreach (FromTable tbl in fromAliasTables )
			{
				allFromTables.Add(tbl);
			}

			foreach (FromTable tbl in allFromTables )
			{
				EmitFromTable(tbl);
				RenderLeftOuterJoinFrom(tbl);
			}

			if (IsSubquery)
			{
				IColumnMap c = backReference.GetColumnMap() ;
				SqlTableAlias parentTableAlias =  parentQuery.GetSqlTableAlias(c.PrimaryKeyTable);
				SqlColumnAlias parentColAlias =  parentTableAlias.GetSqlColumnAlias(c.PrimaryKeyColumn) ;
				
				SqlTableAlias thisTableAlias =  this.Select.GetSqlTableAlias(c.TableMap.Name);
				SqlColumnAlias thisColAlias =  thisTableAlias.GetSqlColumnAlias(c.Name) ;
//
//				SqlColumnAlias parentColAlias =  parentQuery.GetSqlColumnAlias(c.PrimaryKeyColumn,c.PrimaryKeyTable) ;
//				SqlTableAlias parentTableAlias =  parentQuery.GetSqlTableAlias(c.PrimaryKeyTable);
//				
//				SqlColumnAlias thisColAlias =  this.Select.GetSqlColumnAlias(c.Name,c.TableMap.Name) ;
//				SqlTableAlias thisTableAlias =  this.Select.GetSqlTableAlias(c.TableMap.Name);

				SqlSearchCondition search = select.SqlWhereClause.GetNextSqlSearchCondition();
				search.GetSqlComparePredicate(parentColAlias, SqlCompareOperatorType.Equals, thisColAlias);
				
			}
		}



		private void AddTypeColumnToWhereClause(IClassMap classMap, SqlSearchCondition search) 
		{
			IColumnMap typeColumnMap = classMap.GetTypeColumnMap(); 
			if (typeColumnMap != null)
			{
				ITableMap tableMap = classMap.MustGetTableMap();
				SqlTableAlias tbl = null ;
				foreach (IPropertyMap idPropertyMap in classMap.GetIdentityPropertyMaps())
				{
					tbl = GetTableAlias(tableMap, idPropertyMap)  ;
					break;
				}

				SqlColumnAlias column = this.propertyPathTraverser.GetPropertyColumnAlias(tbl, ".NPersistTypeColumn" , typeColumnMap, ".NPersistTypeColumn");

				search.GetSqlComparePredicate(column, SqlCompareOperatorType.Equals, new SqlStringLiteral(classMap.TypeValue));				
				search.OrNext = true;
			}
		}



		#endregion

		#region Emit Select

		private void EmitSelect()
		{
			//IColumnMap typeColumnMap = null;
			Hashtable selectedColumns = new Hashtable() ;
			ArrayList columnOrder = new ArrayList() ;			
			NPathSelectClause sel = query.Select;
			select.Distinct = sel.Distinct; 
			if (sel.HasTop)
			{
				select.Top = sel.Top ;
				select.Percent = sel.Percent;
				select.WithTies = sel.WithTies ;
			}

			if (npathQueryType == NPathQueryType.SelectObjects || npathQueryType == NPathQueryType.SelectMixed)
			{
				foreach (string idPropertyName in GetNeglectedIdentityPropertyNames(sel))
				{
					propertyPathTraverser.TraverseSpan(idPropertyName, selectedColumns, columnOrder, "");					
				}					
			}
			int i = 0;

			foreach (NPathSelectField field in sel.SelectFields)
			{
				if (field.Expression is NPathIdentifier)
				{
					NPathIdentifier path = field.Expression as NPathIdentifier ;
					string alias = field.Alias;
					if (alias == null)
						alias = "";
					propertyPathTraverser.TraverseSpan(path.Path, selectedColumns, columnOrder, alias);						
				}
				else
				{
					SqlExpression expression = EvalExpression(field.Expression);
					string alias = field.Alias;
					expressionAliases[expression] = alias;
					columnOrder.Add(expression);
				}
				i++;
			}
			foreach (object alias in columnOrder)
			{
				SqlColumnAlias sqlColumnAlias = alias as SqlColumnAlias ;
				if (sqlColumnAlias != null)
				{
					SqlColumnAlias col = (SqlColumnAlias) selectedColumns[sqlColumnAlias];
					select.SqlSelectClause.AddSqlAliasSelectListItem(col);					
				}
				else
				{
					SqlExpression sqlExpression = alias as SqlExpression;
					if (sqlExpression != null)
					{
						string expAlias = (string) expressionAliases[sqlExpression];
						select.SqlSelectClause.AddSqlAliasSelectListItem(sqlExpression, expAlias);					
					}					
				}
			}
		}

		#endregion

		#region Emit From
 
		private void EmitFrom()
		{
			SqlTableAlias tbl;
			foreach (NPathClassName className in query.From.Classes) 
			{
				tbl = propertyPathTraverser.GetClassTableAlias(className.Name);
				if (!(includedTableAliases.Contains(tbl)))
				{
					FromTable fromTable = new FromTable();
					fromTable.Alias = tbl ;

					fromTables.Add(fromTable);
					includedTableAliases.Add(tbl);	
				
				}
			}
		}

		#endregion

		#region Emit where

		private void EmitWhere() 
		{
			conditionChainOwner = select.SqlWhereClause;

            if (query.Where != null)
			{
                //EvalExpression (query.Where.Expression);					
                NPathParenthesisGroup parens = new NPathParenthesisGroup();
                parens.Expression = query.Where.Expression;

                EvalParenthesisGroup ( parens );					
			}
		}

		#endregion

		#region Emit Order By

		private void EmitOrderBy()
		{
			if (query.OrderBy != null) 
			{
				foreach (SortProperty sortExpression in query.OrderBy.SortProperties) 
				{
					SqlExpression expression = EvalExpression(sortExpression.Expression);
					select.SqlOrderByClause.AddSqlOrderByItem(expression, sortExpression.Direction == SortDirection.Desc);
				}
			}
		}

		#endregion
		
		#region Clause Emission Helpers
		
		#region GetNeglectedIdentityPropertyNames

		private ArrayList GetNeglectedIdentityPropertyNames(NPathSelectClause select)
		{
			ArrayList idProperties = new ArrayList() ;

			foreach (IPropertyMap idProperty in this.rootClassMap.GetIdentityPropertyMaps())
			{
				idProperties.Add(idProperty.Name.ToLower(CultureInfo.InvariantCulture));				
			}
			foreach (NPathSelectField field in select.SelectFields)
			{
				if (field.Expression is NPathIdentifier)
				{
					NPathIdentifier path = field.Expression as NPathIdentifier ;
					if (path.Path == "*" || path.Path == "¤")
					{
						return new ArrayList() ;
					}
					else
					{
						if (idProperties.Contains(path.Path.ToLower(CultureInfo.InvariantCulture)))
						{
							idProperties.Remove(path.Path.ToLower(CultureInfo.InvariantCulture));
						}				
					}
				}
			}

			return idProperties;
		}

		#endregion

		#endregion

		#endregion

		#region Expression Evaluation

		private SqlExpression EvalExpression(IValue expression)
		{
			if (expression is NPathMethodCall)
			{
				NPathMethodCall methodCall = (NPathMethodCall)expression;
				return EvalMethodCall(methodCall);	
			}
			if (expression is NPathNotExpression) // SearchCondition with Negative
			{
				NPathNotExpression value = (NPathNotExpression)expression;
				return EvalNot(value);
			}
			if (expression is NPathParameter)
			{
				NPathParameter value = (NPathParameter)expression;
				return EvalParameter(value);
			}
			if (expression is NPathNullValue)
			{
				return EvalNullValue();
			}
			if (expression is NPathBooleanValue)
			{
				NPathBooleanValue value = (NPathBooleanValue)expression;
				return EvalBooleanValue(value);
			}
			if (expression is NPathDecimalValue)
			{
				NPathDecimalValue value = (NPathDecimalValue)expression;
				return EvalDecimalValue(value);
			}
			if (expression is NPathDateTimeValue)
			{
				NPathDateTimeValue value = (NPathDateTimeValue)expression;
				return EvalDateTimeValue(value);
			}
			if (expression is NPathGuidValue)
			{
				NPathGuidValue value = (NPathGuidValue)expression;
				return EvalGuidValue(value);
			}
			if (expression is NPathStringValue)
			{
				NPathStringValue value = (NPathStringValue)expression;
				return EvalStringValue(value);
			}
			if (expression is NPathIdentifier)
			{
				NPathIdentifier propertyPath = (NPathIdentifier) expression;
				return EvalIdentifier(propertyPath);
			}
			//			if (expression is PropertyFilter)
			//			{
			//				PropertyFilter propertyFilter = (PropertyFilter) expression;
			//				return EvalPropertyFilter(propertyFilter);
			//			}
			if (expression is NPathParenthesisGroup) // SearchCondition
			{
				NPathParenthesisGroup parenthesisGroup = (NPathParenthesisGroup) expression;
				return EvalParenthesisGroup(parenthesisGroup);
			}
			//			if (expression is MathExpression)
			//			{
			//				MathExpression mathExpression = (MathExpression) expression;
			//				return EvalMathExpression(mathExpression);
			//			}
			if (expression is NPathBooleanExpression)  // SearchCondition
			{
				NPathBooleanExpression boolExpression = (NPathBooleanExpression) expression;
				return EvalBooleanExpression(boolExpression);
			}

			if (expression is NPathFunction) // Function
			{
				NPathFunction value = (NPathFunction)expression;
				return EvalFunction(value);
			}
			if (expression is NPathCompareExpression) // ComparePredicate
			{
				NPathCompareExpression compareExpression = (NPathCompareExpression) expression;
				return EvalCompareExpression(compareExpression);
			}
			if (expression is NPathBetweenExpression) // BetweenPredicate
			{
				NPathBetweenExpression value = (NPathBetweenExpression)expression;
				return EvalBetween(value);
			}
			if (expression is NPathInExpression) // InPredicate
			{
				NPathInExpression value = (NPathInExpression)expression;
				return EvalIn(value);
			}
			if (expression is NPathMathExpression) // InPredicate
			{
				NPathMathExpression value = (NPathMathExpression)expression;
				return EvalMath(value);
			}
			if (expression is NPathSelectQuery)
			{
				NPathSelectQuery query = (NPathSelectQuery)expression;
				return EvalSubQuery(query);
			}

			//			if (expression is SearchFunction) //FreeTextPredicate
			//			{
			//				SearchFunction value = (SearchFunction)expression;
			//				return EvalSearchFunction(value);
			//			}
			throw new IAmOpenSourcePleaseImplementMeException(string.Format("Expressions of type '{0}' is not yet implemented",expression.GetType().Name) ) ;
		}

		private bool noNext = false;
		


		private SqlExpression EvalParenthesisGroup(NPathParenthesisGroup parenthesisGroup)
		{
			if (conditionChainOwner != null && !(parenthesisGroup.Expression is NPathSelectQuery) )
			{
				SqlSearchCondition prev;
				if (conditionChainOwner is SqlSearchCondition)
					prev = (SqlSearchCondition) conditionChainOwner;
				else
					prev = conditionChainOwner.GetCurrentSqlSearchCondition();
				SqlSearchCondition search = conditionChainOwner.GetNextSqlSearchCondition() ;
				SqlSearchCondition sub = search.GetSubSqlSearchCondition();
				conditionChainOwner = sub;
				noNext = true;
				EvalExpression(parenthesisGroup.Expression);
				conditionChainOwner = prev;
				return search;
			}
			else
			{
				//Roger
				SqlExpression sqlExpression = EvalExpression(parenthesisGroup.Expression);
				SqlParenthesisGroup sqlParenthesisGroup = new SqlParenthesisGroup(parenthesisGroup.IsNegative,sqlExpression) ;
				return sqlParenthesisGroup;
			}
		}
		
		private SqlSearchCondition EvalBooleanExpression(NPathBooleanExpression booleanExpression)
		{
            bool orNext = String.Compare(booleanExpression.Operator, "or", true, CultureInfo.InvariantCulture) == 0;

            if (orNext)
                orExpressionCount++;

			SqlExpression leftExpression = EvalExpression(booleanExpression.LeftOperand);
			SqlSearchCondition search; 

			if (leftExpression is SqlSearchCondition)
				search = (SqlSearchCondition) leftExpression;
			else
			{
				if (conditionChainOwner is SqlSearchCondition)
					search = (SqlSearchCondition) conditionChainOwner;
				else
					search = conditionChainOwner.GetCurrentSqlSearchCondition();
			}

			

			if (orNext)
				search.OrNext = orNext;

			EvalExpression(booleanExpression.RightOperand);

            SqlSearchCondition cond = conditionChainOwner.GetCurrentSqlSearchCondition();

            if (orNext)
                orExpressionCount--;

            return cond;
		}

		private SqlExpression EvalCompareExpression(NPathCompareExpression compareExpression)
		{
			SqlSearchCondition search ;
			
			if (noNext)
				search = conditionChainOwner as SqlSearchCondition ; 
			else
				search = conditionChainOwner.GetNextSqlSearchCondition() ; 
			noNext = false;

			SqlExpression leftExpression = null;
			SqlExpression rightExpression = null;
			
			if (compareExpression.RightOperand is NPathIdentifier && !IsEnum(compareExpression.RightOperand) && IsEnum(compareExpression.LeftOperand))
			{
				//left operand is enum
				rightExpression = EvalExpression(compareExpression.RightOperand);
				
				NPathIdentifier propertyPath = (NPathIdentifier)compareExpression.RightOperand;
				NPathIdentifier enumIdentifier = (NPathIdentifier)compareExpression.LeftOperand;
				Type enumType = GetTypFromPropertyPath(propertyPath);		
	
				if (!enumType.IsEnum)
					throw new Exception(string.Format("Property '{0}' is not an Enum type",propertyPath.Path));

				int enumValue = GetEnumValue(enumType,enumIdentifier.Path);

				leftExpression = new SqlNumericLiteral(enumValue);

			}
			if (compareExpression.LeftOperand is NPathIdentifier && !IsEnum(compareExpression.LeftOperand) && IsEnum(compareExpression.RightOperand))
			{
				leftExpression = EvalExpression(compareExpression.LeftOperand);
				
				NPathIdentifier propertyPath = (NPathIdentifier)compareExpression.LeftOperand;
				NPathIdentifier enumIdentifier = (NPathIdentifier)compareExpression.RightOperand;
				Type enumType = GetTypFromPropertyPath(propertyPath);	
		
				if (!enumType.IsEnum)
					throw new Exception(string.Format("Property '{0}' is not an Enum type",propertyPath.Path));

				int enumValue = GetEnumValue(enumType,enumIdentifier.Path);

				rightExpression = new SqlNumericLiteral(enumValue);

			}
			else
			{
				leftExpression = EvalExpression(compareExpression.LeftOperand);
				rightExpression = EvalExpression(compareExpression.RightOperand);
			}
			
			SqlPredicate predicate; 

			if (compareExpression.RightOperand is NPathNullValue)
			{
				if (compareExpression.Operator == "=")
					predicate = search.GetSqlIsNullPredicate(leftExpression);
				else if (compareExpression.Operator == "!=") // do not localize
					predicate = search.GetSqlIsNullPredicate(leftExpression, true);
				else
					throw new NPathException("Comparisment operand " + compareExpression.Operator + " can't be used for comparisment with Null value!"); // do not localize
			}
			else
			{
				predicate = search.GetSqlComparePredicate(leftExpression, EvalOperator(compareExpression.Operator) ,rightExpression) ;									
			}
			return predicate;
		}

		private int GetEnumValue(Type enumType, string enumValue)
		{
			if (enumType == null)
				throw new ArgumentNullException("enumType") ;

			if (!enumType.IsEnum)
				throw new Exception(string.Format("Type '{0}' is not an Enum type",enumType.FullName));

			return (int)Enum.Parse(enumType,enumValue) ;
		}

		private Type GetTypFromPropertyPath(NPathIdentifier identifier)
		{
			string path = identifier.Path;			
			ArrayList properties = propertyPathTraverser.GetPathPropertyMaps (path);
			IPropertyMap property = (IPropertyMap)properties[properties.Count-1];
			//Type type = Type.GetType(property.DataType);
			Type type = this.npathEngine.Context.AssemblyManager.GetTypeFromPropertyMap(property);
	
			if (type == null)
				throw new NullReferenceException(string.Format("Property type returned null for path {0}",path) );

			return type;
		}


		private SqlExpression EvalBetween(NPathBetweenExpression betweenExpression)
		{
			SqlSearchCondition search ;
			
			if (noNext)
				search = conditionChainOwner as SqlSearchCondition ; 
			else
				search = conditionChainOwner.GetNextSqlSearchCondition() ; 
			noNext = false;

			SqlExpression leftExpression = EvalExpression(betweenExpression.TestExpression );
			SqlExpression middleExpression = EvalExpression(betweenExpression.FromExpression);
			SqlExpression rightExpression = EvalExpression(betweenExpression.EndExpression);
			
			SqlPredicate predicate = search.GetSqlBetweenPredicate(leftExpression, middleExpression ,rightExpression) ;									
			return predicate;
		}

		private SqlExpression EvalIn(NPathInExpression inExpression)
		{
			SqlSearchCondition search ;
			
			if (noNext)
				search = conditionChainOwner as SqlSearchCondition ; 
			else
				search = conditionChainOwner.GetNextSqlSearchCondition() ; 
			noNext = false;

			SqlExpression leftExpression = EvalExpression(inExpression.TestExpression );
			
			SqlInPredicate predicate = search.GetSqlInPredicate(leftExpression) ;									
			
			foreach (IValue expression in inExpression.Values)
				predicate.AddSqlInPredicateItem(EvalExpression(expression));
			
			return predicate;
		}

		private SqlExpression EvalMethodCall (NPathMethodCall methodCall)
		{
			if (methodCall.MethodName == "Count" && methodCall.Parameters.Count == 0)
			{
				string npath = string.Format("select count(*) from {0}",methodCall.PropertyPath.Path);
				
				NPathParser parser = new NPathParser() ;
				NPathSelectQuery query = parser.ParseSelectQuery(npath) ;
				NPathParenthesisGroup pg = new NPathParenthesisGroup() ;
				pg.IsNegative = methodCall.PropertyPath.IsNegative;
				pg.Expression = query;
				return EvalExpression (pg);				
			}

			throw new IAmOpenSourcePleaseImplementMeException (string.Format("Method calls to '{0}' is not yet implemented",methodCall.MethodName));
		}

		private SqlExpression EvalSubQuery(NPathSelectQuery subQuery)
		{
			NPathClassName className = (NPathClassName) subQuery.From.Classes[0];
			string collectionProperty = className.Name;

            if (collectionProperty.StartsWith(RootClassMap.Name + "."))
                collectionProperty = collectionProperty.Substring(RootClassMap.Name.Length + 1);


			IPropertyMap rootPropertyMap = this.RootClassMap.MustGetPropertyMap(collectionProperty);

			if (!rootPropertyMap.IsCollection)
				throw new Exception(string.Format("Property '{0}' or type {1} is not a collection",rootPropertyMap.Name, className.Name) ) ;

			IPropertyMap inversePropertyMap = rootPropertyMap.GetInversePropertyMap();
			string dataType = rootPropertyMap.ItemType;
			className.Name = dataType;
			IClassMap classMap = RootClassMap.DomainMap.MustGetClassMap(dataType);
			SqlEmitter subEmitter = new SqlEmitter(this.NPathEngine,subQuery,NPathQueryType.SelectTable,classMap,this.Select,inversePropertyMap,this.subQueryLevel + 1) ;
			SqlSelectStatement subSelect = subEmitter.BuildSqlDom();
			
			return subSelect;
		}

		private SqlExpression EvalMath(NPathMathExpression mathExpression)
		{
			SqlExpression leftExpression = EvalExpression(mathExpression.LeftOperand);
			SqlExpression rightExpression = EvalExpression(mathExpression.RightOperand);

			SqlMathOperatorType mathOperator ;
			switch(mathExpression.Operator)
			{
				case "add":
					mathOperator = SqlMathOperatorType.Add;
					break;

				case "minus":
					mathOperator = SqlMathOperatorType.Subtract;
					break;

				case "div":
					mathOperator = SqlMathOperatorType.Divide;
					break;

				case "mul":
					mathOperator = SqlMathOperatorType.Multiply;
					break;
				default:
					throw new IAmOpenSourcePleaseImplementMeException("Operator not implemented");
			}

			

			SqlMathExpression predicate = new SqlMathExpression(leftExpression,mathOperator,rightExpression);
			
			return predicate;
		}


//		private SqlExpression EmitSearchFunction(SearchFunction searchFunction)
//		{
//			SqlSearchCondition search ;
//			
//			if (noNext)
//				search = conditionChainOwner as SqlSearchCondition ; 
//			else
//				search = conditionChainOwner.GetNextSqlSearchCondition() ; 
//			noNext = false;
//
//			SqlExpression leftExpression = EvalExpression(searchFunction.PropertyPath);
//			
//			SqlPredicate predicate;								
//
//			string lowFuncName = searchFunction.FunctionName.ToLower(CultureInfo.InvariantCulture);
//			if (lowFuncName == "contains")
//				predicate = search.GetSqlContainsPredicate(leftExpression, new SqlStringLiteral(searchFunction.SearchString.Value));
//			else if (lowFuncName == "freetext") // do not localize
//				predicate = search.GetSqlFreeTextPredicate(leftExpression, new SqlStringLiteral(searchFunction.SearchString.Value));
//			else
//				throw new NPathException("Unknown search function: " + searchFunction.FunctionName); // do not localize
//			
//			return predicate;
//		}

//		private void EmitMathExpression(MathExpression mathExpression)
//		{
//			EmitExpression(mathExpression.LeftOperand);
//			switch (mathExpression.Operator)
//			{
//				case "add":
//					currentClause.Append(" + ") ;
//					break;
//				case "minus":
//					currentClause.Append(" - ") ;
//					break;
//				case "mul":
//					currentClause.Append(" * ") ;
//					break;
//				case "div":
//					currentClause.Append(" / ") ;
//					break;
//				case "xor": // do not localize
//					currentClause.Append(" xor ") ; // do not localize
//					break;
//				case "mod": // do not localize
//					currentClause.Append(" mod ") ; // do not localize
//					break;
//				default:
//					currentClause.Append(" " + mathExpression.Operator + " ") ;
//					break;
//			}
//			EmitExpression(mathExpression.RightOperand);
//		}
//
//
//		private void EmitPropertyFilter(PropertyFilter propertyFilter)
//		{
//			currentClause.Append(propertyPathTraverser.TraversePropertyPath(propertyFilter.Path)) ;
//			//Note: We have to get some kind of value back
//			//from the evaluation of the property path
//			//to keep track of where we are, I think....
//			//Or perhaps the path will do?
//			currentClause.Append("[") ;
//			EmitExpression(propertyFilter.Filter.Expression);
//			currentClause.Append("]") ;
//		}
		

		private SqlFunction EvalFunction(NPathFunction function)
		{
            if (function is NPathSoundexStatement)
                return new SqlSoundexFunction(EvalExpression(function.Expression));
			if (function is NPathSumStatement)
				return new SqlSumFunction(EvalExpression(function.Expression), function.Distinct );
			if (function is NPathCountStatement)
				return new SqlCountFunction(EvalExpression(function.Expression), function.Distinct );
			if (function is NPathAvgStatement)
				return new SqlAvgFunction(EvalExpression(function.Expression), function.Distinct );
			if (function is NPathMinStatement)
				return new SqlMinFunction(EvalExpression(function.Expression), function.Distinct );
			if (function is NPathMaxStatement)
				return new SqlMaxFunction(EvalExpression(function.Expression), function.Distinct );
			if (function is NPathIsNullStatement)
				throw new IAmOpenSourcePleaseImplementMeException("IsNullStatement not commpatible with SqlDom structure") ;
			throw new IAmOpenSourcePleaseImplementMeException("Unknown function type: " + function.GetType().ToString() ) ;
		}

		private SqlExpression EvalNot(NPathNotExpression notExpression)
		{
			SqlExpression expression = (SqlSearchCondition) EvalExpression(notExpression.Expression) ;
			SqlSearchCondition search = expression as SqlSearchCondition ;
			if (search != null)
				search.Negative = true;
			return expression;
		}

		private SqlNullValue EvalNullValue()
		{
			return new SqlNullValue();
		}

		
		private SqlExpression EvalStringValue(NPathStringValue value)
		{
			SqlStringLiteral stringLiteral = new SqlStringLiteral(value.Value) ;
			return stringLiteral;

			//TODO: change back when parameters are fixed

//			string paramName = GetParameterName();
//			IQueryParameter param = new QueryParameter(paramName, DbType.String, value.Value ) ;
//			ResultParameters.Add(param);
//			SqlParameter sqlParam = select.AddSqlParameter(paramName, DbType.String, value.Value) ;
//			return sqlParam ;
		}

		private SqlExpression EvalGuidValue(NPathGuidValue value)
		{
			string paramName = GetParameterName();
			IQueryParameter param = new QueryParameter(paramName, DbType.Guid, value.Value ) ;
			ResultParameters.Add(param);
			SqlParameter sqlParam = select.AddSqlParameter(paramName, DbType.Guid, value.Value) ;
			return sqlParam ;
		}

		private SqlExpression EvalDateTimeValue(NPathDateTimeValue value)
		{
			SqlDateTimeLiteral dateTimeLiteral = new SqlDateTimeLiteral(value.Value) ;
			return dateTimeLiteral;
//			string paramName = GetParameterName();
//			IQueryParameter param = new QueryParameter(paramName, DbType.DateTime, value.Value ) ;
//			ResultParameters.Add(param);
//			SqlParameter sqlParam = select.AddSqlParameter(paramName, DbType.DateTime, value.Value) ;
//			return sqlParam ;
		}

		private SqlExpression EvalDecimalValue(NPathDecimalValue value)
		{
			SqlNumericLiteral numericLiteral = new SqlNumericLiteral((Decimal)value.Value) ;
			return numericLiteral;
//			string paramName = GetParameterName();
//			IQueryParameter param = new QueryParameter(paramName, DbType.Decimal, value.Value ) ;
//			ResultParameters.Add(param);
//			SqlParameter sqlParam = select.AddSqlParameter(paramName, DbType.Decimal, value.Value) ;
//			return sqlParam ;
		}

		private SqlExpression EvalBooleanValue(NPathBooleanValue value)
		{
			SqlBooleanLiteral booleanValue = new SqlBooleanLiteral(value.Value);
			return booleanValue;
//			string paramName = GetParameterName();
//			IQueryParameter param = new QueryParameter(paramName, DbType.Boolean, value.Value ) ;
//			ResultParameters.Add(param);
//			SqlParameter sqlParam = select.AddSqlParameter(paramName, DbType.Boolean, value.Value) ;
//			return sqlParam ;
		}


		private SqlExpression EvalParameter(NPathParameter parameter)
		{
			string paramName = GetParameterName();
			IQueryParameter inParam = (IQueryParameter)parameter.Value;
			IQueryParameter param = TransformParameter(inParam, paramName);
			ResultParameters.Add(param);
			SqlParameter sqlParam = select.AddSqlParameter(paramName, param.DbType, param.Value) ;
			return sqlParam ;
		}

		
		private SqlExpression EvalIdentifier(NPathIdentifier identifier)
		{
			
			if (IsEnum(identifier)  )
			{
				throw new NPersistException("Enums should be handled by EvalCompareExpression!");
			}
			else
			{
				if (identifier.ReferenceLocation == NPathPropertyPathReferenceLocation.SelectClause)
				{
					return new SqlColumnAliasReference(propertyPathTraverser.TraverseSimplePropertySpan(identifier.Path)) ;			
				}
				else
				{
					return new SqlColumnAliasReference(propertyPathTraverser.TraversePropertyPath(identifier.Path)) ;
				}
			}
		}

		private bool IsEnum(IValue expression)
		{
			if (!(expression is NPathIdentifier))
				return false;

			NPathIdentifier identifier = (NPathIdentifier) expression;

			

			return identifier.Path.IndexOfAny(".*".ToCharArray() )  == -1 && this.rootClassMap.GetPropertyMap(identifier.Path) == null;
		}


		private SqlCompareOperatorType EvalOperator(string compareOperator)
		{
			switch (compareOperator)
			{
				case "=":
					return SqlCompareOperatorType.Equals;
				case "!=":
					return SqlCompareOperatorType.NotEquals;
				case ">":
					return SqlCompareOperatorType.GreaterThan ;
				case ">=":
					return SqlCompareOperatorType.GreaterThanOrEqual;
				case "like":
					return SqlCompareOperatorType.Like ;
				case "!>":
					return SqlCompareOperatorType.NotGreaterThan ;
				case "!<":
					return SqlCompareOperatorType.NotSmallerThan ;
				case "<>":
					return SqlCompareOperatorType.SmallerOrGreaterThan ;
				case "<":
					return SqlCompareOperatorType.SmallerThan ;
				case "<=":
					return SqlCompareOperatorType.SmallerThanOrEqual ;
			}
			throw new NPathException("Unknown comparisment operator " + compareOperator);
		}

		#endregion

		#region Expression Evaluation Helpers


        //HACK: fix
		protected virtual string GetParameterName()
		{
			ISourceMap sourceMap = this.rootClassMap.GetSourceMap();
			string result = "";
			if (sourceMap.SourceType == SourceType.MSSqlServer)
			{
				result = "@Param" + this.NPathEngine.Context.GetNextParamNr().ToString() ;
			}			
			else if (sourceMap.SourceType == SourceType.MSAccess)
			{
				result = "?";
			}			
			else if (sourceMap.SourceType == SourceType.Oracle)
			{
                result = ":Param" + this.NPathEngine.Context.GetNextParamNr().ToString();
			}			
			else
			{
				result = "?";
			}			
			return result;			
		}

		private string CreateTableAlias()
		{			
			tableAliasCounter++;
			string alias = tableAlias + tableAliasCounter.ToString();
			if (IsSubquery)
				alias+="_" + subQueryLevel.ToString();

			return alias;
		}

		private string CreateColumnAlias()
		{			
			columnAliasCounter++;
			return columnAlias + columnAliasCounter.ToString();
		}

		protected virtual IQueryParameter TransformParameter(IQueryParameter inParam, string paramName)
		{
			IQueryParameter outParam = null;
			if (inParam.DbType == DbType.Object)
			{
				IClassMap classMap = this.rootClassMap.DomainMap.MustGetClassMap(inParam.Value.GetType() );
				foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps() )
				{
					object value = this.npathEngine.Context.ObjectManager.GetPropertyValue(inParam.Value, propertyMap.Name );
					DbType dbType =  propertyMap.GetColumnMap().DataType  ;
					outParam = new QueryParameter(paramName, dbType, value );
					break; // TODO: HOW??? To fix for composite identities??????
					// (possibly by traversing the propertypath as many times as the final property has columns ???)
					// (something like WrapColumn in sql engine does..)
				}				
			}
			if (outParam == null)
			{
				outParam = new QueryParameter(paramName, inParam.DbType,  inParam.Value);
			}
			return outParam;								
		}

		#endregion

		#endregion

		public bool IsSubquery
		{
			get
			{
				return this.parentQuery != null;
			}
		}
	}
}
