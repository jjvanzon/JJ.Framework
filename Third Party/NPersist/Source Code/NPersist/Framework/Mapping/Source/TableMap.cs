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
using System.Globalization;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class TableMap : MapBase, ITableMap
	{
				
		public override void Accept(IMapVisitor visitor) => visitor.Visit(this);

	    public override IMap GetParent() => m_SourceMap;

	    private ArrayList m_ColumnMaps = new ArrayList();
		private ISourceMap m_SourceMap;
		private string m_name = "";
		private bool m_IsView = false;
        private int m_LockIndex = -1;

		public TableMap() : base()
		{
		}

		public TableMap(string name) : base() => m_name = name;

	    [XmlIgnore()]
		public virtual ISourceMap SourceMap
		{
			get => m_SourceMap;
	        set
			{
				if (m_SourceMap != null)
				{
					m_SourceMap.TableMaps.Remove(this);
				}
				m_SourceMap = value;
				if (m_SourceMap != null)
				{
					m_SourceMap.TableMaps.Add(this);
				}
			}
		}

		public virtual void SetSourceMap(ISourceMap value)
		{
			m_SourceMap = value;
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				columnMap.SetTableMap(this);
			}
		}

		[XmlArrayItem(typeof (ColumnMap))]
		public virtual ArrayList ColumnMaps
		{
			get => m_ColumnMaps;
		    set => m_ColumnMaps = value;
		}

		public virtual IColumnMap MustGetColumnMap(string findName)
		{
			IColumnMap columnMap = GetColumnMap(findName);

			if (columnMap == null)
				throw new MappingException("Could not find column " + findName + " in table " + m_name + " in map file!");

			return columnMap;
		}

		public virtual IColumnMap GetColumnMap(string findName)
		{
			if (findName == null) { return null; }
			if (findName == "") { return null; }
			findName = findName.ToLower(CultureInfo.InvariantCulture);
			if (IsFixed("GetColumnMap_" + findName))
			{
				return (IColumnMap) GetFixedValue("GetColumnMap_" + findName);
			}
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				if (columnMap.Name.ToLower(CultureInfo.InvariantCulture) == findName)
				{
					if (IsFixed())
					{
						SetFixedValue("GetColumnMap_" + findName, columnMap);
					}
					return columnMap;
				}
			}
			return null;
		}

		public override string Name
		{
			get => m_name;
		    set => m_name = value;
		}

		public virtual bool IsView
		{
			get => m_IsView;
		    set => m_IsView = value;
		}

		public virtual ArrayList GetPrimaryKeyColumnMaps()
		{
			ArrayList keyColumnMaps = new ArrayList();
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				if (columnMap.IsPrimaryKey)
				{
					keyColumnMaps.Add(columnMap);
				}
			}
			return keyColumnMaps;
		}

		public virtual ArrayList GetForeignKeyColumnMaps()
		{
			ArrayList keyColumnMaps = new ArrayList();
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				if (columnMap.IsForeignKey)
				{
					keyColumnMaps.Add(columnMap);
				}
			}
			return keyColumnMaps;
		}

		public virtual ArrayList GetForeignKeyColumnMaps(string foreignKeyName)
		{
			ArrayList keyColumnMaps = new ArrayList();
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				if (columnMap.IsForeignKey)
				{
					if (columnMap.ForeignKeyName == foreignKeyName)
					{
						keyColumnMaps.Add(columnMap);
					}
				}
			}
			return keyColumnMaps;
		}

		public virtual ArrayList GetDefaultValueColumnMaps()
		{
			ArrayList defColumnMaps = new ArrayList();
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				if (columnMap.DefaultValue.Length > 0)
				{
					defColumnMaps.Add(columnMap);
				}
			}
			return defColumnMaps;
		}

		public void UpdateName(string newName)
		{
			foreach (IClassMap classMap in SourceMap.DomainMap.ClassMaps)
			{
				if (classMap.Table.Length > 0)
				{
					if (classMap.GetTableMap() == this)
					{
						classMap.Table = newName;
					}
				}
				foreach (IPropertyMap propertyMap in classMap.GetNonInheritedPropertyMaps())
				{
					if (propertyMap.Table.Length > 0)
					{
						if (propertyMap.GetTableMap() == this)
						{
							propertyMap.Table = newName;
						}
					}
				}
			}
			foreach (ITableMap tableMap in SourceMap.TableMaps)
			{
				foreach (IColumnMap columnMap in tableMap.ColumnMaps)
				{
					if (columnMap.PrimaryKeyTable.Length > 0)
					{
						if (columnMap.GetPrimaryKeyTableMap() == this)
						{
							columnMap.PrimaryKeyTable = newName;
						}
					}
				}
			}
			m_name = newName;
		}

        public int LockIndex 
        {
            get => m_LockIndex;
            set => m_LockIndex = value;
        }

        public int GetLockIndex()
        {
            if (m_LockIndex < 0)
            {
                this.SourceMap.SetupLockIndexes();
            }
            return m_LockIndex;
        }


		public override IMap Clone()
		{
			ITableMap tableMap = new TableMap();
			Copy(tableMap);
			return tableMap;
		}

		public override IMap DeepClone()
		{
			ITableMap tableMap = new TableMap();
			DeepCopy(tableMap);
			return tableMap;
		}

		protected virtual void DoDeepCopy(ITableMap tableMap)
		{
			IColumnMap cloneColumnMap;
			foreach (IColumnMap columnMap in this.ColumnMaps)
			{
				cloneColumnMap = (IColumnMap) columnMap.DeepClone();
				cloneColumnMap.TableMap = tableMap;
			}
		}

		public override void DeepCopy(IMap mapObject)
		{
			ITableMap tableMap = (ITableMap) mapObject;
			tableMap.ColumnMaps.Clear();
			Copy(tableMap);
			DoDeepCopy(tableMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			ITableMap tableMap = (ITableMap) compareTo;
			IColumnMap checkColumnMap;
			if (!(this.ColumnMaps.Count == tableMap.ColumnMaps.Count))
			{
				return false;
			}
			foreach (IColumnMap columnMap in this.ColumnMaps)
			{
				checkColumnMap = tableMap.GetColumnMap(columnMap.Name);
				if (checkColumnMap == null)
				{
					return false;
				}
				else
				{
					if (!(columnMap.DeepCompare(checkColumnMap)))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override void DeepMerge(IMap mapObject)
		{
			Copy(mapObject);
			ITableMap tableMap = (ITableMap) mapObject;
			IColumnMap columnMap;
			IColumnMap checkColumnMap;
			ArrayList remove = new ArrayList();
			foreach (IColumnMap iColumnMap in this.ColumnMaps)
			{
				checkColumnMap = tableMap.GetColumnMap(iColumnMap.Name);
				if (checkColumnMap == null)
				{
					checkColumnMap = (IColumnMap) iColumnMap.DeepClone();
					checkColumnMap.TableMap = tableMap;
				}
				else
				{
					iColumnMap.DeepMerge(checkColumnMap);
				}
			}
			foreach (IColumnMap iColumnMap in tableMap.ColumnMaps)
			{
				columnMap = this.GetColumnMap(iColumnMap.Name);
				if (columnMap == null)
				{
					remove.Add(iColumnMap);
				}
			}
			foreach (IColumnMap iColumnMap in remove)
			{
				tableMap.ColumnMaps.Remove(iColumnMap);
			}
		}

		public override void Copy(IMap mapObject)
		{
			ITableMap tableMap = (ITableMap) mapObject;
			tableMap.Name = this.Name;
			tableMap.IsView = this.IsView;
            tableMap.LockIndex = this.LockIndex;
        }

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			ITableMap tableMap = (ITableMap) compareTo;
			if (!(tableMap.Name == this.Name))
			{
				return false;
			}
            if (!(tableMap.IsView == this.IsView))
            {
                return false;
            }
            if (!(tableMap.LockIndex == this.LockIndex))
            {
                return false;
            }
            return true;
		}



		public override string GetKey() => m_SourceMap.DomainMap.Name + "." + m_SourceMap.Name + "." + this.Name;

	    public override void Fixate()
		{
			base.Fixate();
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				columnMap.Fixate();
			}
		}

		public override void UnFixate()
		{
			base.UnFixate();
			foreach (IColumnMap columnMap in m_ColumnMaps)
			{
				columnMap.UnFixate();
			}
		}
	}
}