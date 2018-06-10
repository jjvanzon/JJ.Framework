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
using System.Globalization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Sql.Dom;

namespace Puzzle.NPersist.Framework.NPath.Sql
{
	public class PropertyPathTraverser
	{		
		public PropertyPathTraverser(SqlEmitter sqlEmitter)
		{
			this.sqlEmitter = sqlEmitter;

			joinTree = new JoinTree(this);

			joinTree.TableMap = sqlEmitter.RootClassMap.MustGetTableMap();

		}

		private SqlEmitter sqlEmitter;
		
		private JoinTree joinTree = null ;
		private Hashtable joinedNonPrimaries = new Hashtable() ;

		public JoinTree JoinTree
		{
			get => this.joinTree;
		    set => this.joinTree = value;
		}

		public SqlEmitter SqlEmitter
		{
			get => this.sqlEmitter;
		    set => this.sqlEmitter = value;
		}

		public virtual SqlTableAlias GetClassTable(string className)
		{
			IClassMap classMap = sqlEmitter.RootClassMap.DomainMap.MustGetClassMap(className);
			ITableMap tableMap = classMap.MustGetTableMap();

			return sqlEmitter.Select.GetSqlTableAlias(tableMap);						
		}

		
		public virtual SqlColumnAlias GetPropertyColumn(IPropertyMap propertyMap, object hash) 
		{	
			if (hash == null) { hash = propertyMap; }
			SqlTableAlias tbl = sqlEmitter.GetTableAlias(propertyMap.MustGetTableMap(), hash)  ;

            IColumnMap columnMap = propertyMap.GetColumnMap();

            return tbl.GetSqlColumnAlias(columnMap);
		}

		public virtual string GetPathParent(string path)
		{
			string[] pathNames = GetPathPropertyNames(path); 
			string pathParent = "";
			for (int i = 0; i < pathNames.Length -1; i++)
			{
				pathParent += pathNames[i];
				if (i < pathNames.Length - 2)
				{
					pathParent += ".";
				}
			}

			return pathParent;
		}

		public virtual void GetListPropertySubselectAndAlias(IPropertyMap propertyMap, object hash, Hashtable columns, ArrayList order, string propPath, string suggestion)
		{	
			if (hash == null) { hash = propertyMap; }
			ITableMap listTableMap = propertyMap.MustGetTableMap();
			ITableMap parentTableMap = propertyMap.ClassMap.MustGetTableMap();
			SqlTableAlias parentTable = sqlEmitter.GetTableAlias(parentTableMap, hash);

			SqlSelectStatement subSelect = new SqlSelectStatement(parentTableMap.SourceMap);

			//Hmmm....can an alias be redefined in a subselect?
			//SqlTableAlias listTable = subSelect.GetSqlTableAlias(listTableMap, "cnt" + subSelect.GetNextTableAliasIndex());
			SqlTableAlias listTable = subSelect.GetSqlTableAlias(listTableMap, "cnt" + sqlEmitter.Select.GetNextTableAliasIndex());

			SqlCountFunction count = new SqlCountFunction();

			subSelect.SqlSelectClause.AddSqlAliasSelectListItem(count);

			subSelect.SqlFromClause.AddSqlAliasTableSource(listTable);

			foreach (IColumnMap fkIdColumnMap in propertyMap.GetAllIdColumnMaps())
			{
				IColumnMap idColumnMap = fkIdColumnMap.MustGetPrimaryKeyColumnMap();

				SqlColumnAlias fkIdColumn = listTable.GetSqlColumnAlias(fkIdColumnMap);
				SqlColumnAlias idColumn = parentTable.GetSqlColumnAlias(idColumnMap);
				SqlSearchCondition search = subSelect.SqlWhereClause.GetNextSqlSearchCondition();

				search.GetSqlComparePredicate(fkIdColumn, SqlCompareOperatorType.Equals, idColumn);
			}

			if (suggestion == "")
				suggestion = propPath;

			SqlAliasSelectListItem countAlias = this.sqlEmitter.Select.SqlSelectClause.AddSqlAliasSelectListItem(subSelect, suggestion);
			this.sqlEmitter.PropertyColumnMap[propPath] = countAlias.SqlExpressionAlias.Alias;						
		}



		public virtual void GetPropertyColumnNamesAndAliases(IPropertyMap propertyMap, object hash, Hashtable columns, ArrayList order, string path, string propPath, string suggestion)
		{	
			if (hash == null) { hash = propertyMap; }
			SqlTableAlias tbl = sqlEmitter.GetTableAlias(propertyMap.MustGetTableMap(), hash)  ;
			IList columnAliases = new ArrayList();

			if (propertyMap.IsIdentity)
			{
				IClassMap classMap = propertyMap.ClassMap;
				IColumnMap typeColumnMap = classMap.GetTypeColumnMap();
				if (typeColumnMap != null)
				{
					string pathParent = GetPathParent(path);
					string suggestedPath = pathParent.Length == 0 ? "NPersistTypeColumn" : pathParent + ".NPersistTypeColumn";
					SqlColumnAlias column = GetPropertyColumnAlias(tbl, suggestedPath , typeColumnMap, suggestedPath);
					columnAliases.Add(column);
				}
			}

            if (suggestion == "")
                suggestion = propPath;
      //      bool hasTypeColumn = false;

            IPropertyMap inverse = propertyMap.GetInversePropertyMap();

			//Type column first
            if (inverse != null)
            {
				IColumnMap inverseTypeColumnMap = inverse.ClassMap.GetTypeColumnMap();
				foreach (IColumnMap columnMap in propertyMap.GetAllColumnMaps())
                {
                    if (inverseTypeColumnMap != null && inverseTypeColumnMap == columnMap.GetPrimaryKeyColumnMap())
                    {
                        string suggestionString;
                        suggestionString = propPath.Length == 0 ? "NPersistTypeColum" : propPath + ".NPersistTypeColumn";

                        SqlColumnAlias column = GetPropertyColumnAlias(tbl, path, columnMap, suggestionString);
                        columnAliases.Add(column);
                    }                
                }
            }

			foreach (IColumnMap columnMap in propertyMap.GetAllColumnMaps())
			{
                if (inverse != null) 
                {
                    IColumnMap inverseTypeColumnMap = inverse.ClassMap.GetTypeColumnMap();
                    if ( inverseTypeColumnMap != null && inverseTypeColumnMap == columnMap.GetPrimaryKeyColumnMap())
                    {
                        continue;
                    }
                }

                string suggestionString;

                suggestionString = suggestion;
                    
				SqlColumnAlias column = GetPropertyColumnAlias(tbl, path, columnMap, suggestionString);
				columnAliases.Add(column);
			}
 
			foreach (SqlColumnAlias column in columnAliases)
			{

				if (!(columns.ContainsKey(column)))
				{
					columns[column] = column;					
					order.Add(column);

					//Note: Important stuff, right here in nowhere-ville!!
					if (this.sqlEmitter.PropertyColumnMap.ContainsKey(propPath))
					{
						ArrayList arrAliases;
						if (this.sqlEmitter.PropertyColumnMap[propPath] is string)
						{
							arrAliases = new ArrayList() ;
							arrAliases.Add(this.sqlEmitter.PropertyColumnMap[propPath]);
							this.sqlEmitter.PropertyColumnMap[propPath] = arrAliases;
						}
						else
						{
							arrAliases = (ArrayList) this.sqlEmitter.PropertyColumnMap[propPath];
						}
						arrAliases.Add(column.Alias);
					}
					else
					{
						this.sqlEmitter.PropertyColumnMap[propPath] = column.Alias;						
					}				
				}
			}			
		}

		public virtual SqlTableAlias GetClassTableAlias(string className)
		{	
			IClassMap classMap = sqlEmitter.RootClassMap.DomainMap.MustGetClassMap(className);
			return sqlEmitter.GetTableAlias(classMap.MustGetTableMap(), classMap)  ;
		}

		public virtual SqlColumnAlias GetPropertyColumnAlias(SqlTableAlias tableAlias, string propertyPath, IColumnMap columnMap, string suggestion) => sqlEmitter.GetColumnAlias(tableAlias, columnMap, propertyPath, GetAliasSuggestionFromPropertyPath(propertyPath, suggestion));

	    public virtual SqlColumnAlias GetPropertyColumnAlias(SqlTableAlias tableAlias, IPropertyMap propertyMap, string propertyPath, string suggestion) => sqlEmitter.GetColumnAlias(tableAlias, propertyMap.GetColumnMap(), propertyPath, GetAliasSuggestionFromPropertyPath(propertyPath, suggestion));

	    public virtual string GetAliasSuggestionFromPropertyPath(string propertyPath, string suggestion)
		{
			if (suggestion.Length < 1)
				suggestion = propertyPath;
	
			return suggestion;
		}

		public ArrayList GetPathPropertyMaps(string propertyPath)
		{
			string special = "";
			return GetPathPropertyMaps(propertyPath, ref special);
		}

		public ArrayList GetPathPropertyMaps(string propertyPath, ref string special)
		{
			ArrayList propertyMaps = new ArrayList();
			IPropertyMap propertyMap = null;
			IClassMap classMap = sqlEmitter.RootClassMap;
			bool skip = false;
			bool first = true;
            int cnt = 1;
            IList pathPropertyNames = GetPathPropertyNames(propertyPath); 
			foreach (string name in pathPropertyNames)
			{
				if (name.Length > 0)
				{
					skip = false;
					if (first)
					{
						if (name.ToLower(CultureInfo.InvariantCulture) == sqlEmitter.RootClassMap.Name.ToLower())
						{
							skip = true;
						}					
					}
					first = false;
					if (!(skip))
					{
						if (!(name.Equals("*")))
						{
							propertyMap = classMap.MustGetPropertyMap(name);
							propertyMaps.Add(propertyMap);

                            if (cnt < pathPropertyNames.Count)
							    classMap = propertyMap.MustGetReferencedClassMap();					
						}
						else
						{
                            //HACK: hmmm * => ID ??
							special = name;
							//special - we trade for the first id property
							propertyMap = (IPropertyMap) classMap.GetIdentityPropertyMaps()[0];
							propertyMaps.Add(propertyMap);
						}
					}					
				}
                cnt++;
			}
			return propertyMaps;
		}


		public string[] GetPathPropertyNames(string propertyPath) => propertyPath.Split('.');

	    public virtual void TraverseSpan(string span, Hashtable selectedColumns, ArrayList columnOrder, string suggestion)
		{	
			string special = "";
			ArrayList propertyMaps = GetPathPropertyMaps(span, ref special);
			TraverseSingleSpan(propertyMaps, selectedColumns, columnOrder, special, suggestion);
		}

		private void TraverseSingleSpan(ArrayList propertyMaps, Hashtable selectedColumns, ArrayList columnOrder, string special, string suggestion)
		{
			IPropertyMap parentMap = null;
			string path = "";
			string prevPath = "";
			foreach (IPropertyMap pathMap in propertyMaps)
			{
				IPropertyMap propertyMap = pathMap;
				if (propertyMaps.IndexOf(propertyMap) < propertyMaps.Count - 1)
				{
					NPathQueryType queryType = this.sqlEmitter.npathQueryType;
					if (queryType == NPathQueryType.SelectObjects || queryType == NPathQueryType.SelectMixed)
					{
						if (path == "")
						{
							GetPropertyColumnNamesAndAliases(propertyMap, propertyMap, selectedColumns, columnOrder, propertyMap.Name, propertyMap.Name, "");
						}
						else
						{
							GetPropertyColumnNamesAndAliases(propertyMap, path, selectedColumns, columnOrder, path, path + "." + propertyMap.Name, "");
						}
					}
					prevPath = path;
					if (path.Length > 0) { path += "." ;}
					path += propertyMap.Name;
					JoinType joinType;
					if (HasNullableColumn(propertyMap) || propertyMap.IsCollection)
					{
						joinType = JoinType.OuterJoin;
					}
					else
					{
						joinType = JoinType.InnerJoin;						
					}
					joinTree.SetupJoin(propertyMap, parentMap, path, joinType);						
				}
				else
				{
					if (special == "*")
					{
						IClassMap classMap = null;
						if (propertyMaps.Count == 1)
						{
							classMap = this.sqlEmitter.RootClassMap;							
						}
						else
						{
							//Should actually take refClassMap from previous prop in path!!
							classMap = propertyMap.ClassMap;
						}

						foreach (IPropertyMap iPropertyMap in classMap.GetAllPropertyMaps() )
						{
							if (!(iPropertyMap.ReferenceType != ReferenceType.None && iPropertyMap.AdditionalColumns.Count > 0))
							{
								if (iPropertyMap.IsCollection)
								{
									if (this.SqlEmitter.NPathEngine.Context.PersistenceManager.GetListCountLoadBehavior(LoadBehavior.Default, iPropertyMap) == LoadBehavior.Eager)
									{
										if (iPropertyMap.GetIdColumnMap() != null)
										{
											if (path == "")
											{
												GetListPropertySubselectAndAlias(iPropertyMap, iPropertyMap.ClassMap, selectedColumns, columnOrder, iPropertyMap.Name, "");
											}
											else
											{
												if (prevPath != "")
													GetListPropertySubselectAndAlias(iPropertyMap, prevPath, selectedColumns, columnOrder, path + "." + iPropertyMap.Name, suggestion);                                                
												else
													GetListPropertySubselectAndAlias(iPropertyMap, path, selectedColumns, columnOrder, path + "." + iPropertyMap.Name, suggestion);                                                
											}
										}
									}
								}
								else
								{
                                    //This if should be removed some day when the "JoinNonPrimary()" call a bit further down
                                    //has been refined to handle nullable OneToOne slaves...
                                    if (!(iPropertyMap.ReferenceType == ReferenceType.OneToOne && iPropertyMap.IsSlave && HasNullableColumn(iPropertyMap)))
                                    {
									    if (iPropertyMap.Column.Length > 0)
									    {
										    //Exclude inverse property to property leading to this point in the path
										    bool isInverse = false;
										    if (parentMap != null)
										    {											
											    if (iPropertyMap.Inverse.Length > 0)
											    {
												    if (parentMap == iPropertyMap.GetInversePropertyMap())
												    {
													    isInverse = true;
												    }
											    }
										    }
										    if (!isInverse)
										    {
												if (path == "")
												{
												    GetPropertyColumnNamesAndAliases(iPropertyMap, iPropertyMap, selectedColumns, columnOrder, iPropertyMap.Name, iPropertyMap.Name, "");
											    }
											    else
											    {
													// here
													if (parentMap != null && parentMap.ReferenceType == ReferenceType.ManyToOne && prevPath != "")
														GetPropertyColumnNamesAndAliases(iPropertyMap, prevPath, selectedColumns, columnOrder, path + "." + iPropertyMap.Name, path + "." + iPropertyMap.Name, suggestion);                                                
													else
														GetPropertyColumnNamesAndAliases(iPropertyMap, path, selectedColumns, columnOrder, path + "." + iPropertyMap.Name, path + "." + iPropertyMap.Name, suggestion);                                                

													//GetPropertyColumnNamesAndAliases(iPropertyMap, path, selectedColumns, columnOrder, path + "." + iPropertyMap.Name, path + "." + iPropertyMap.Name, suggestion);                                                
												}
											    if (iPropertyMap.MustGetTableMap() != iPropertyMap.ClassMap.MustGetTableMap())
											    {
												    JoinNonPrimary(iPropertyMap);
											    }																							
										    }
									    }

                                    }
								}
							}
						}						
					}
					else
					{
						if (path == "")
						{
							GetPropertyColumnNamesAndAliases(propertyMap, propertyMap, selectedColumns, columnOrder, propertyMap.Name, propertyMap.Name, suggestion);
						}
						else
						{
							//GetPropertyColumnNamesAndAliases(propertyMap, path, selectedColumns, columnOrder, path, path + "." + propertyMap.Name, suggestion);
							GetPropertyColumnNamesAndAliases(propertyMap, path, selectedColumns, columnOrder, path + "." + propertyMap.Name, path + "." + propertyMap.Name, suggestion);
						}													
						if (propertyMap.MustGetTableMap() != propertyMap.ClassMap.MustGetTableMap())
						{
							JoinNonPrimary(propertyMap);
						}
						
					}
				}
				parentMap = propertyMap;
			}
		}

		private void JoinNonPrimary(IPropertyMap iPropertyMap)
		{
			foreach (IColumnMap idColumn in iPropertyMap.GetAllIdColumnMaps() )
			{				
				SqlTableAlias thisTableAlias =  this.sqlEmitter.Select.GetSqlTableAlias(idColumn.TableMap.Name);
				SqlColumnAlias thisColAlias =  thisTableAlias.GetSqlColumnAlias(idColumn.Name) ;

				SqlTableAlias parentTableAlias =  this.sqlEmitter.Select.GetSqlTableAlias(idColumn.PrimaryKeyTable);
				SqlColumnAlias parentColAlias =  parentTableAlias.GetSqlColumnAlias(idColumn.PrimaryKeyColumn) ;

				if (!joinedNonPrimaries.ContainsKey(thisColAlias))
				{
					if (!(joinedNonPrimaries[thisColAlias] == parentColAlias))
					{
						SqlSearchCondition search = this.sqlEmitter.Select.SqlWhereClause.GetNextSqlSearchCondition();
						search.GetSqlComparePredicate(parentColAlias, SqlCompareOperatorType.Equals, thisColAlias);												
						
						joinedNonPrimaries[thisColAlias] = parentColAlias;
					}					
				}
			}
		}


		public virtual SqlColumnAlias TraversePropertyPath(string propertyPath)
		{	
			IPropertyMap propertyMap = null;
			return TraversePropertyPath(propertyPath, ref propertyMap);
		}

		public virtual SqlColumnAlias TraversePropertyPath(string propertyPath, ref IPropertyMap propertyMap)
		{	
			SqlColumnAlias result = null;
			IPropertyMap parentMap = null;
			ArrayList propertyMaps = GetPathPropertyMaps(propertyPath);
			string path = "";
            bool outerJoin = false;
			foreach (IPropertyMap pathMap in propertyMaps)
			{
				propertyMap = pathMap;
				if (propertyMaps.IndexOf(propertyMap) < propertyMaps.Count - 1)
				{
					if (path.Length > 0) { path += "." ;}
					path += propertyMap.Name;
                    JoinType joinType = JoinType.InnerJoin;
                    if (pathMap.GetIsNullable() && sqlEmitter.HasOrExpression)
                        outerJoin = true;

                    if (outerJoin)
                        joinType = JoinType.OuterJoin;

					joinTree.SetupJoin(propertyMap, parentMap, path,joinType);
				}
				else
				{
					if (path == "")
					{
						result = GetPropertyColumn(propertyMap, propertyMap);											
					}
					else
					{
						result = GetPropertyColumn(propertyMap, path);											
					}
				}
				parentMap = propertyMap;
			}

			return result;
		}

		public virtual SqlColumnAlias TraverseSimplePropertySpan(string propertyPath)
		{	
			IPropertyMap propertyMap = null;
			return TraverseSimplePropertySpan(propertyPath, ref propertyMap);
		}

		public virtual SqlColumnAlias TraverseSimplePropertySpan(string propertyPath, ref IPropertyMap propertyMap)
		{	
			SqlColumnAlias result = null;
			IPropertyMap parentMap = null;
			ArrayList propertyMaps = GetPathPropertyMaps(propertyPath);
			string path = "";
			JoinType joinType;
			foreach (IPropertyMap pathMap in propertyMaps)
			{
				propertyMap = pathMap;
				if (propertyMaps.IndexOf(propertyMap) < propertyMaps.Count - 1)
				{
					if (path.Length > 0) { path += "." ;}
					path += propertyMap.Name;

					if (HasNullableColumn(propertyMap))
					{
						joinType = JoinType.OuterJoin;
					}
					else
					{
						joinType = JoinType.InnerJoin;						
					}

					joinTree.SetupJoin(propertyMap, parentMap, path,joinType);
				}
				else
				{
					if (path == "")
					{
						result = GetPropertyColumn(propertyMap, propertyMap);											
					}
					else
					{
						result = GetPropertyColumn(propertyMap, path);											
					}
				}
				parentMap = propertyMap;
			}

			return result;
		}

		protected virtual bool HasNullableColumn(IPropertyMap propertyMap) => propertyMap.GetIsNullable();
	}
}
