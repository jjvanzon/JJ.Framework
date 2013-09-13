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
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class ColumnMap : MapBase, IColumnMap
	{
				
		public override void Accept(IMapVisitor visitor)
		{
			visitor.Visit(this);
		}

		
		public override IMap GetParent()
		{
			return m_TableMap; 
		}

		private ITableMap m_TableMap;
		private string m_name = "";
		private DbType m_DataType = DbType.String;
		private int m_Length = 0;
		private bool m_IsAutoIncrease = false;
		private string m_Format = "";
		private bool m_AllowNulls = false;
		private bool m_IsKey = false;
		private bool m_IsForeignKey = false;
		private int m_Increment = 0;
		private int m_Seed = 0;
		private string m_DefaultValue = "";
		private int m_Precision = 0;
		private int m_Scale = 0;
		private string m_ForeignKeyName = "";
		private string m_PrimaryKeyColumn = "";
		private string m_PrimaryKeyTable = "";
		private string m_Sequence = "";
		private bool m_IsFixedLength = false;
		private string m_SpecificDataType = "";

		public ColumnMap() : base()
		{
		}

		public ColumnMap(string name) : base()
		{
			m_name = name;
		}


		[XmlIgnore()]
		public virtual ITableMap TableMap
		{
			get { return m_TableMap; }
			set
			{
				if (m_TableMap != null)
				{
					m_TableMap.ColumnMaps.Remove(this);
				}
				m_TableMap = value;
				if (m_TableMap != null)
				{
					m_TableMap.ColumnMaps.Add(this);
				}
			}
		}

		public virtual void SetTableMap(ITableMap value)
		{
			m_TableMap = value;
		}

		public override string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public virtual DbType DataType
		{
			get { return m_DataType; }
			set { m_DataType = value; }
		}

		public virtual int Length
		{
			get { return m_Length; }
			set { m_Length = value; }
		}

		public virtual bool IsAutoIncrease
		{
			get { return m_IsAutoIncrease; }
			set
			{
				m_IsAutoIncrease = value;
				if (m_IsAutoIncrease)
				{
					if (m_Seed == 0)
					{
						m_Seed = 1;
					}
					if (m_Increment == 0)
					{
						m_Increment = 1;
					}
				}
				else
				{
					m_Seed = 0;
					m_Increment = 0;
				}
			}
		}

		public virtual string Format
		{
			get { return m_Format; }
			set { m_Format = value; }
		}

		public virtual bool AllowNulls
		{
			get { return m_AllowNulls; }
			set { m_AllowNulls = value; }
		}

		public virtual bool IsPrimaryKey
		{
			get { return m_IsKey; }
			set { m_IsKey = value; }
		}

		public virtual bool IsForeignKey
		{
			get { return m_IsForeignKey; }
			set { m_IsForeignKey = value; }
		}

		public virtual int Increment
		{
			get { return m_Increment; }
			set { m_Increment = value; }
		}

		public virtual int Seed
		{
			get { return m_Seed; }
			set { m_Seed = value; }
		}

		public virtual string DefaultValue
		{
			get { return m_DefaultValue; }
			set { m_DefaultValue = value; }
		}

		public virtual int Precision
		{
			get { return m_Precision; }
			set { m_Precision = value; }
		}

		public virtual int Scale
		{
			get { return m_Scale; }
			set { m_Scale = value; }
		}

		public virtual string ForeignKeyName
		{
			get { return m_ForeignKeyName; }
			set { m_ForeignKeyName = value; }
		}

		public virtual string PrimaryKeyColumn
		{
			get { return m_PrimaryKeyColumn; }
			set { m_PrimaryKeyColumn = value; }
		}

		public virtual string PrimaryKeyTable
		{
			get { return m_PrimaryKeyTable; }
			set { m_PrimaryKeyTable = value; }
		}

		public virtual IColumnMap MustGetPrimaryKeyColumnMap()
		{
			IColumnMap columnMap = GetPrimaryKeyColumnMap();

			if (columnMap == null)
				throw new MappingException("Could not find column " + m_PrimaryKeyTable + "." + m_PrimaryKeyColumn + ", specified as primary column for foreign key column " + this.TableMap.Name + "." + this.Name + ", in map file!");

			return columnMap;
		}

		public virtual IColumnMap GetPrimaryKeyColumnMap()
		{
			if (m_PrimaryKeyTable.Length < 1)
			{
				return null;
			}
			if (m_PrimaryKeyColumn.Length < 1)
			{
				return null;
			}
			ITableMap tableMap = GetPrimaryKeyTableMap();
			if (tableMap != null)
			{
				return tableMap.GetColumnMap(m_PrimaryKeyColumn);
			}
			return null;
		}

		public virtual ITableMap MustGetPrimaryKeyTableMap()
		{
			ITableMap tableMap = GetPrimaryKeyTableMap();

			if (tableMap == null)
				throw new MappingException("Could not find table " + m_PrimaryKeyTable + ", specified as primary table for foreign key column " + this.TableMap.Name + "." + this.Name + ", in map file!");

			return tableMap;
		}

		public virtual ITableMap GetPrimaryKeyTableMap()
		{
			if (m_PrimaryKeyTable.Length < 1)
			{
				return null;
			}
			return m_TableMap.SourceMap.GetTableMap(m_PrimaryKeyTable);
		}

		public virtual string Sequence
		{
			get { return m_Sequence; }
			set { m_Sequence = value; }
		}

		public virtual bool IsFixedLength
		{
			get { return m_IsFixedLength; }
			set { m_IsFixedLength = value; }
		}

		public virtual string SpecificDataType
		{
			get { return m_SpecificDataType; }
			set { m_SpecificDataType = value; }
		}

		public virtual void UpdateName(string newName)
		{
			ArrayList columnMaps;
			int i;
			foreach (IClassMap classMap in TableMap.SourceMap.DomainMap.ClassMaps)
			{
				if (classMap.TypeColumn.Length > 0)
				{
					if (classMap.GetTypeColumnMap() == this)
					{
						classMap.TypeColumn = newName;
					}
				}
				foreach (IPropertyMap propertyMap in classMap.GetNonInheritedPropertyMaps())
				{
					if (propertyMap.Column.Length > 0)
					{
						if (propertyMap.GetColumnMap() == this)
						{
							propertyMap.Column = newName;
						}
					}
					if (propertyMap.IdColumn.Length > 0)
					{
						if (propertyMap.GetIdColumnMap() == this)
						{
							propertyMap.IdColumn = newName;
						}
					}
					columnMaps = propertyMap.GetAdditionalColumnMaps();
					if (columnMaps.Count == propertyMap.AdditionalColumns.Count)
					{
						i = 0;
						foreach (IColumnMap columnMap in columnMaps)
						{
							if (columnMap == this)
							{
								propertyMap.AdditionalColumns[i] = newName;
							}
							i += 1;
						}
					}
					columnMaps = propertyMap.GetAdditionalIdColumnMaps();
					if (columnMaps.Count == propertyMap.AdditionalIdColumns.Count)
					{
						i = 0;
						foreach (IColumnMap columnMap in columnMaps)
						{
							if (columnMap == this)
							{
								propertyMap.AdditionalIdColumns[i] = newName;
							}
							i += 1;
						}
					}
				}
			}
			foreach (ITableMap checkTableMap in TableMap.SourceMap.TableMaps)
			{
				foreach (IColumnMap columnMap in checkTableMap.ColumnMaps)
				{
					if (columnMap.PrimaryKeyColumn.Length > 0)
					{
						if (columnMap.GetPrimaryKeyColumnMap() == this)
						{
							columnMap.PrimaryKeyColumn = newName;
						}
					}
				}
			}
			m_name = newName;
		}

		public virtual Type GetSystemType()
		{
			Type result = typeof(string);
			switch (this.m_DataType)
			{
				case DbType.AnsiString :
					result = typeof(string);
					break;
				case DbType.AnsiStringFixedLength  :
					result = typeof(string);
					break;
				case DbType.Binary  :
					result = typeof(byte[]);
					break;
				case DbType.Boolean  :
					result = typeof(bool);
					break;
				case DbType.Byte  :
					result = typeof(byte);
					break;
				case DbType.Currency  :
					result = typeof(decimal);
					break;
				case DbType.Date  :
					result = typeof(DateTime);
					break;
				case DbType.DateTime :
					result = typeof(DateTime);
					break;
				case DbType.Decimal  :
					result = typeof(decimal);
					break;
				case DbType.Double  :
					result = typeof(double);
					break;
				case DbType.Guid :
					result = typeof(Guid);
					break;
				case DbType.Int16  :
					result = typeof(Int16);
					break;
				case DbType.Int32  :
					result = typeof(Int32);
					break;
				case DbType.Int64  :
					result = typeof(Int64);
					break;
				case DbType.Object :
					result = typeof(byte[]);
					break;
				case DbType.SByte  :
					result = typeof(byte);
					break;
				case DbType.Single  :
					result = typeof(Single);
					break;
				case DbType.String   :
					result = typeof(string);
					break;
				case DbType.StringFixedLength   :
					result = typeof(string);
					break;
				case DbType.Time   :
					result = typeof(DateTime);
					break;
				case DbType.UInt16 :
					result = typeof(UInt16);
					break;
				case DbType.UInt32 :
					result = typeof(UInt32);
					break;
				case DbType.UInt64  :
					result = typeof(Int64);
					break;
				case DbType.VarNumeric  :
					result = typeof(byte[]);
					break;
			}
			return result;
		}


		public override IMap Clone()
		{
			IColumnMap columnMap = new ColumnMap();
			Copy(columnMap);
			return columnMap;
		}

		public override IMap DeepClone()
		{
			IColumnMap columnMap = new ColumnMap();
			DeepCopy(columnMap);
			return columnMap;
		}

		protected virtual void DoDeepCopy(IColumnMap columnMap)
		{
		}

		public override void DeepCopy(IMap mapObject)
		{
			IColumnMap columnMap = (IColumnMap) mapObject;
			Copy(columnMap);
			DoDeepCopy(columnMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			return true;
		}

		public override void DeepMerge(IMap mapObject)
		{
			Copy(mapObject);
		}

		public override void Copy(IMap mapObject)
		{
			IColumnMap columnMap = (IColumnMap) mapObject;
			columnMap.AllowNulls = this.AllowNulls;
			columnMap.DataType = this.DataType;
			columnMap.Format = this.Format;
			columnMap.IsAutoIncrease = this.IsAutoIncrease;
			columnMap.IsForeignKey = this.IsForeignKey;
			columnMap.IsPrimaryKey = this.IsPrimaryKey;
			columnMap.Length = this.Length;
			columnMap.Name = this.Name;
			columnMap.Increment = this.Increment;
			columnMap.Seed = this.Seed;
			columnMap.DefaultValue = this.DefaultValue;
			columnMap.Precision = this.Precision;
			columnMap.Scale = this.Scale;
			columnMap.ForeignKeyName = this.ForeignKeyName;
			columnMap.PrimaryKeyColumn = this.PrimaryKeyColumn;
			columnMap.PrimaryKeyTable = this.PrimaryKeyTable;
			columnMap.Sequence = this.Sequence;
			columnMap.IsFixedLength = this.IsFixedLength;
			columnMap.SpecificDataType = this.SpecificDataType;
		}

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			IColumnMap columnMap = (IColumnMap) compareTo;
			if (!(columnMap.AllowNulls == this.AllowNulls))
			{
				return false;
			}
			if (!(columnMap.DataType == this.DataType))
			{
				return false;
			}
			if (!(columnMap.Format == this.Format))
			{
				return false;
			}
			if (!(columnMap.IsAutoIncrease == this.IsAutoIncrease))
			{
				return false;
			}
			if (!(columnMap.IsForeignKey == this.IsForeignKey))
			{
				return false;
			}
			if (!(columnMap.IsPrimaryKey == this.IsPrimaryKey))
			{
				return false;
			}
			if (!(columnMap.Length == this.Length))
			{
				return false;
			}
			if (!(columnMap.Name == this.Name))
			{
				return false;
			}
			if (!(columnMap.Increment == this.Increment))
			{
				return false;
			}
			if (!(columnMap.Seed == this.Seed))
			{
				return false;
			}
			if (!(columnMap.DefaultValue == this.DefaultValue))
			{
				return false;
			}
			if (!(columnMap.Precision == this.Precision))
			{
				return false;
			}
			if (!(columnMap.Scale == this.Scale))
			{
				return false;
			}
			if (!(columnMap.ForeignKeyName == this.ForeignKeyName))
			{
				return false;
			}
			if (!(columnMap.PrimaryKeyColumn == this.PrimaryKeyColumn))
			{
				return false;
			}
			if (!(columnMap.PrimaryKeyTable == this.PrimaryKeyTable))
			{
				return false;
			}
			if (!(columnMap.Sequence == this.Sequence))
			{
				return false;
			}
			if (!(columnMap.IsFixedLength == this.IsFixedLength))
			{
				return false;
			}
			if (!(columnMap.SpecificDataType == this.SpecificDataType))
			{
				return false;
			}
			return true;
		}

		public override string GetKey()
		{
			return m_TableMap.SourceMap.DomainMap.Name + "." + m_TableMap.SourceMap.Name + "." + m_TableMap.Name + "." + this.Name;
		}
	}
}