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
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.NPath.Sql {
	public enum JoinType { 
		InnerJoin = 0,
		OuterJoin = 1
	}

	/// <summary>
	/// Summary description for TableJoin.
	/// </summary>
	public class TableJoin {
		public TableJoin() {
			//
			// TODO: Add constructor logic here
			//
		}

		private JoinTree joinTree = null;
		private TableJoin parent = null;
		private ArrayList children = new ArrayList();
		private IPropertyMap propertyMap = null;
		private ITableMap tableMap = null;
		private ITableMap baseTableMap = null;
		private ArrayList columnMaps = new ArrayList();
		private ArrayList baseColumnMaps = new ArrayList();
		private JoinType joinType = JoinType.InnerJoin;

		public JoinTree JoinTree {
			get => this.joinTree;
		    set {
				this.joinTree = value;
				value.TableJoins.Add(this);
			}
		}

		public TableJoin Parent {
			get => this.parent;
		    set {
				this.parent = value;
				value.children.Add(this);
			}
		}
		
		public ArrayList Children {
			get => this.children;
		    set => this.children = value;
		}

		public IPropertyMap PropertyMap {
			get => this.propertyMap;
		    set => this.propertyMap = value;
		}
	
		public ITableMap TableMap {
			get => this.tableMap;
		    set => this.tableMap = value;
		}

		public ITableMap BaseTableMap
		{
			get => this.baseTableMap;
		    set => this.baseTableMap = value;
		}
		
		public ArrayList ColumnMaps {
			get => this.columnMaps;
		    set => this.columnMaps = value;
		}

		public ArrayList BaseColumnMaps
		{
			get => this.baseColumnMaps;
		    set => this.baseColumnMaps = value;
		}

		public JoinType JoinType {
			get => this.joinType;
		    set => this.joinType = value;
		}


		public TableJoin GetTableJoinForPropertyMap(IPropertyMap propertyMap) {
			TableJoin result;
			foreach(TableJoin tableJoin in children) {
				if (tableJoin.PropertyMap == propertyMap) {
					return tableJoin;
				}
				result = tableJoin.GetTableJoinForPropertyMap(propertyMap);
				if (result != null) {
					return result;
				}
			}
			return null;
		}

		public string GetPropertyPath()
		{
			string path = this.propertyMap.Name; 
			TableJoin p = this.Parent ;
			while (p != null)
			{
				path = p.propertyMap.Name + "." + path;
				p = p.Parent; 
			}
			return path;
		}

	}
}
