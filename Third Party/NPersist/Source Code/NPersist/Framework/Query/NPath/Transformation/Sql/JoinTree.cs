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
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.NPath.Sql
{
	/// <summary>
	/// Summary description for JoinTree.
	/// </summary>
	public class JoinTree
	{
		public JoinTree(PropertyPathTraverser propertyPathTraverser) => this.propertyPathTraverser = propertyPathTraverser;

	    private ArrayList tableJoins = new ArrayList();
		private ITableMap tableMap = null;
		private PropertyPathTraverser propertyPathTraverser = null;

		public PropertyPathTraverser PropertyPathTraverser => this.propertyPathTraverser;

	    public ArrayList TableJoins
		{
			get => this.tableJoins;
	        set => this.tableJoins = value;
	    }

		public ITableMap TableMap
		{
			get => this.tableMap;
		    set => this.tableMap = value;
		}

		public TableJoin GetTableJoinForPropertyPath(string propertyPath)
		{
			ArrayList propertyMaps = propertyPathTraverser.GetPathPropertyMaps(propertyPath);
			ArrayList joins = tableJoins;
			TableJoin theTableJoin = null;
			foreach (IPropertyMap propertyMap in propertyMaps)
			{
				theTableJoin = null;
				foreach (TableJoin tableJoin in joins)
				{
					if (tableJoin.PropertyMap == propertyMap)
					{
						theTableJoin = tableJoin;
						break;
					}
				}
				if (theTableJoin == null)
				{
					return null;
				}
				joins = theTableJoin.Children;
			}
			return theTableJoin;
		}


		public void SetupJoin(IPropertyMap propertyMap, IPropertyMap parentMap, string propertyPath) => SetupJoin(propertyMap, parentMap, propertyPath, JoinType.InnerJoin);

	    public void SetupJoin(IPropertyMap propertyMap, IPropertyMap parentMap, string propertyPath, JoinType joinType)
		{
			TableJoin tableJoin = GetTableJoinForPropertyPath(propertyPath);
			if (tableJoin == null)
			{
				tableJoin = new TableJoin();
				tableJoin.PropertyMap = propertyMap;
				tableJoin.JoinType = joinType;
				if (parentMap == null)
				{
					tableJoin.JoinTree = this;
					this.propertyPathTraverser.SqlEmitter.GetTableAlias(propertyMap.MustGetTableMap(), propertyMap);
				}
				else
				{
					//make sure the table has an alias
					tableJoin.Parent = GetTableJoinForPropertyPath(propertyPath.Substring(0, propertyPath.Length - propertyMap.Name.Length - 1));					
					this.propertyPathTraverser.SqlEmitter.GetTableAlias(propertyMap.MustGetTableMap(), tableJoin.Parent);
				}
			}
		}
	}
}