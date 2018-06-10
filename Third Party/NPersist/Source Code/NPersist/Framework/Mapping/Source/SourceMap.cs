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
using Puzzle.NPersist.Framework.Attributes;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class SourceMap : MapBase, ISourceMap
	{				
		public override void Accept(IMapVisitor visitor) => visitor.Visit(this);

	    public override IMap GetParent() => m_DomainMap;

	    #region Private Member Variables

		private PersistenceType m_PersistenceType = PersistenceType.Default;
		private bool m_Compute = false;

		//O/R Mapping
		private ArrayList m_TableMaps = new ArrayList();
		private IDomainMap m_DomainMap;
		private string m_name = "";
		private SourceType m_SourceType = SourceType.MSSqlServer;
		private ProviderType m_ProviderType = ProviderType.SqlClient;
		private string m_ConnectionString = "";
		private string m_Schema = "dbo";
		private string m_Catalog = "";
		private string m_ProviderAssemblyPath = "";
		private string m_ProviderConnectionTypeName = "";
        private string m_LockTable = "";

		//O/D Mapping
		private string m_DocPath = "";
		private string m_DocRoot = "";
		private string m_DocEncoding = "";

		//O/S Mapping
		private string m_Url = "";
		private string m_DomainKey = "";

		#endregion

		#region Constructors

		public SourceMap() : base()
		{
		}

		public SourceMap(string name) : base() => m_name = name;

	    #endregion

		#region General

		#region Property  PersistenceType
				
		public PersistenceType PersistenceType
		{
			get => this.m_PersistenceType;
		    set => this.m_PersistenceType = value;
		}
		
		#endregion

		#region Property  Compute
				
		public bool Compute
		{
			get => this.m_Compute;
		    set => this.m_Compute = value;
		}
		
		#endregion

		#endregion

		#region Object/Relational Mapping

		[XmlIgnore()]
		public virtual IDomainMap DomainMap
		{
			get => m_DomainMap;
		    set
			{
				if (m_DomainMap != null)
				{
					m_DomainMap.SourceMaps.Remove(this);
				}
				m_DomainMap = value;
				if (m_DomainMap != null)
				{
					m_DomainMap.SourceMaps.Add(this);
				}
			}
		}

		public virtual void SetDomainMap(IDomainMap value)
		{
			m_DomainMap = value;
			foreach (ITableMap tableMap in m_TableMaps)
			{
				tableMap.SetSourceMap(this);
			}
		}

		[XmlArrayItem(typeof (TableMap))]
		public virtual ArrayList TableMaps
		{
			get => m_TableMaps;
		    set => m_TableMaps = value;
		}

        public ITableMap MustGetTableMap(string findName)
        {
            ITableMap tableMap = GetTableMap(findName);
            if (tableMap == null)
                throw new MappingException("Could not find table " + findName + " in the source map " + this.Name + "!");
            return tableMap;
        }

		public virtual ITableMap GetTableMap(string findName)
		{
			if (findName == null) { return null; }
			if (findName == "") { return null; }
			findName = findName.ToLower(CultureInfo.InvariantCulture);
			if (IsFixed("GetTableMap_" + findName))
			{
				return (ITableMap) GetFixedValue("GetTableMap_" + findName);
			}
			foreach (ITableMap tableMap in m_TableMaps)
			{
				if (tableMap.Name.ToLower(CultureInfo.InvariantCulture) == findName)
				{
					if (IsFixed())
					{
						SetFixedValue("GetTableMap_" + findName, tableMap);
					}
					return tableMap;
				}
			}
			return null;
		}

		public override string Name
		{
			get => m_name;
		    set => m_name = value;
		}

		public virtual SourceType SourceType
		{
			get => m_SourceType;
		    set => m_SourceType = value;
		}

		public virtual ProviderType ProviderType
		{
			get => m_ProviderType;
		    set => m_ProviderType = value;
		}

		public virtual string ConnectionString
		{
			get => m_ConnectionString;
		    set => m_ConnectionString = value;
		}

		public virtual string Schema
		{
			get => m_Schema;
		    set => m_Schema = value;
		}

		public virtual string Catalog
		{
			get => m_Catalog;
		    set => m_Catalog = value;
		}

		public virtual string ProviderAssemblyPath
		{
			get => m_ProviderAssemblyPath;
		    set => m_ProviderAssemblyPath = value;
		}

		public virtual string ProviderConnectionTypeName
		{
			get => m_ProviderConnectionTypeName;
		    set => m_ProviderConnectionTypeName = value;
		}

		public virtual void UpdateName(string newName)
		{
			if (DomainMap.GetSourceMap() == this)
			{
				DomainMap.Source = newName;
			}
			else
			{
				foreach (IClassMap classMap in DomainMap.ClassMaps)
				{
					if (classMap.GetSourceMap() == this)
					{
						classMap.Source = newName;
					}
					if (classMap.GetDocSourceMap() == this)
					{
						classMap.DocSource = newName;
					}
					foreach (IPropertyMap propertyMap in classMap.GetNonInheritedPropertyMaps())
					{
						if (propertyMap.GetSourceMap() == this)
						{
							propertyMap.Source = newName;
						}
						if (propertyMap.GetDocSourceMap() == this)
						{
							propertyMap.DocSource = newName;
						}
					}
				}
			}
			m_name = newName;
		}

        public string LockTable 
        {
            get => m_LockTable;
            set => m_LockTable = value;
        }

        public ITableMap MustGetLockTable()
        {
            ITableMap tableMap = GetLockTable();
            if (tableMap == null)
                throw new MappingException("Could not find table " + m_LockTable + " in the source map " + this.Name + " in map file!");
            return tableMap;
        }

        public ITableMap GetLockTable()
        {
            if (m_LockTable == "")
            {
                //Assign a lock table
                foreach (ITableMap tableMap in this.TableMaps)
                {
                    m_LockTable = tableMap.Name;
                    break;
                }

            }
            return this.GetTableMap(m_LockTable);
        }


        public void SetupLockIndexes()
        {
            int highestIndex = -1;
            //find highest existing index
            foreach (ITableMap tableMap in this.TableMaps)
            {
                if (tableMap.LockIndex > highestIndex)
                    highestIndex = tableMap.LockIndex;
            }
            int index = highestIndex;
            if (index < 0)
                index = 0;
            //find highest existing index
            foreach (ITableMap tableMap in this.TableMaps)
            {
                if (tableMap.LockIndex < 0)
                {
                    tableMap.LockIndex = index;
                    index++;
                }
            }
        }


		#endregion

		#region Object/Object Mapping

		#endregion

		#region Object/Document Mapping
		
		public virtual string DocPath
		{
			get => m_DocPath;
		    set => m_DocPath = value;
		}
		
		public virtual string DocRoot
		{
			get => m_DocRoot;
		    set => m_DocRoot = value;
		}
				
		public virtual string GetDocRoot()
		{
			if (m_DocRoot.Length > 0)
				return m_DocRoot;

			return this.DomainMap.Name ;
		}

		public virtual string DocEncoding
		{
			get => m_DocEncoding;
		    set => m_DocEncoding = value;
		}
		
		public virtual string GetDocEncoding()
		{
			if (m_DocEncoding.Length > 0)
				return m_DocEncoding;

			return "utf-8";
		}

		#endregion

		#region Object/Service Mapping

		public string Url
		{
			get => this.m_Url;
		    set => this.m_Url = value;
		}

		public string DomainKey
		{
			get => this.m_DomainKey;
		    set => this.m_DomainKey = value;
		}

		#endregion

		#region Cloning

		public override IMap Clone()
		{
			ISourceMap sourceMap = new SourceMap();
			Copy(sourceMap);
			return sourceMap;
		}

		public override IMap DeepClone()
		{
			ISourceMap sourceMap = new SourceMap();
			DeepCopy(sourceMap);
			return sourceMap;
		}

		protected virtual void DoDeepCopy(ISourceMap sourceMap)
		{
			ITableMap cloneTableMap;
			foreach (ITableMap tableMap in this.TableMaps)
			{
				cloneTableMap = (ITableMap) tableMap.DeepClone();
				cloneTableMap.SourceMap = sourceMap;
			}
		}

		public override void DeepCopy(IMap mapObject)
		{
			ISourceMap sourceMap = (ISourceMap) mapObject;
			sourceMap.TableMaps.Clear();
			Copy(sourceMap);
			DoDeepCopy(sourceMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			ISourceMap sourceMap = (ISourceMap) compareTo;
			ITableMap checkTableMap;
			if (!(this.TableMaps.Count == sourceMap.TableMaps.Count))
			{
				return false;
			}
			foreach (ITableMap tableMap in this.TableMaps)
			{
				checkTableMap = sourceMap.GetTableMap(tableMap.Name);
				if (checkTableMap == null)
				{
					return false;
				}
				else
				{
					if (!(tableMap.DeepCompare(checkTableMap)))
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
			ISourceMap sourceMap = (ISourceMap) mapObject;
			ITableMap tableMap;
			ITableMap checkTableMap;
			ArrayList remove = new ArrayList();
			foreach (ITableMap iTableMap in this.TableMaps)
			{
				checkTableMap = sourceMap.GetTableMap(iTableMap.Name);
				if (checkTableMap == null)
				{
					checkTableMap = (ITableMap) iTableMap.DeepClone();
					checkTableMap.SourceMap = sourceMap;
				}
				else
				{
					iTableMap.DeepMerge(checkTableMap);
				}
			}
			foreach (ITableMap iTableMap in sourceMap.TableMaps)
			{
				tableMap = this.GetTableMap(iTableMap.Name);
				if (tableMap == null)
				{
					remove.Add(iTableMap);
				}
			}
			foreach (ITableMap iTableMap in remove)
			{
				sourceMap.TableMaps.Remove(iTableMap);
			}
		}

		public override void Copy(IMap mapObject)
		{
			ISourceMap sourceMap = (ISourceMap) mapObject;
			sourceMap.PersistenceType = this.PersistenceType;
			sourceMap.Compute = this.Compute;
			sourceMap.ConnectionString = this.ConnectionString;
			sourceMap.Name = this.Name;
			sourceMap.ProviderType = this.ProviderType;
			sourceMap.SourceType = this.SourceType;
			sourceMap.Schema = this.Schema;
			sourceMap.Catalog = this.Catalog;
			sourceMap.ProviderAssemblyPath = this.ProviderAssemblyPath;
			sourceMap.ProviderConnectionTypeName = this.ProviderConnectionTypeName;
			sourceMap.DocPath = this.DocPath;
			sourceMap.DocRoot = this.DocRoot;
			sourceMap.DocEncoding = this.DocEncoding;
			sourceMap.Url = this.Url;
			sourceMap.DomainKey = this.DomainKey;
            sourceMap.LockTable = this.LockTable;
        }

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			ISourceMap sourceMap = (ISourceMap) compareTo;
			if (!(sourceMap.PersistenceType == this.PersistenceType))
			{
				return false;
			}
			if (!(sourceMap.Compute == this.Compute))
			{
				return false;
			}
			if (!(sourceMap.ConnectionString == this.ConnectionString))
			{
				return false;
			}
			if (!(sourceMap.Name == this.Name))
			{
				return false;
			}
			if (!(sourceMap.ProviderType == this.ProviderType))
			{
				return false;
			}
			if (!(sourceMap.SourceType == this.SourceType))
			{
				return false;
			}
			if (!(sourceMap.Schema == this.Schema))
			{
				return false;
			}
			if (!(sourceMap.Catalog == this.Catalog))
			{
				return false;
			}
			if (!(sourceMap.ProviderAssemblyPath == this.ProviderAssemblyPath))
			{
				return false;
			}
			if (!(sourceMap.ProviderConnectionTypeName == this.ProviderConnectionTypeName))
			{
				return false;
			}
			if (!(sourceMap.DocPath == this.DocPath))
			{
				return false;
			}
			if (!(sourceMap.DocRoot == this.DocRoot))
			{
				return false;
			}
			if (!(sourceMap.DocEncoding == this.DocEncoding))
			{
				return false;
			}
			if (!(sourceMap.Url == this.Url))
			{
				return false;
			}
			if (!(sourceMap.DomainKey == this.DomainKey))
			{
				return false;
			}
            if (!(sourceMap.LockTable == this.LockTable))
            {
                return false;
            }
            return true;
		}

		#endregion

		#region IMap

		public override string GetKey() => m_DomainMap.Name + "." + this.Name;

	    #endregion

		#region IFixate

		public override void Fixate()
		{
			base.Fixate();
			foreach (ITableMap tableMap in m_TableMaps)
			{
				tableMap.Fixate();
			}
		}

		public override void UnFixate()
		{
			base.UnFixate();
			foreach (ITableMap tableMap in m_TableMaps)
			{
				tableMap.UnFixate();
			}
		}

		#endregion

		#region FromSourceMapAttribute

		public static void FromSourceMapAttribute(SourceMapAttribute attrib, ISourceMap sourceMap)
		{
			sourceMap.Name = attrib.Name;

			sourceMap.Catalog = attrib.Catalog ;
			sourceMap.Compute = attrib.Compute;
			sourceMap.ConnectionString = attrib.ConnectionString ;
			sourceMap.DocEncoding = attrib.DocEncoding ;
			sourceMap.DocPath = attrib.DocPath ;
			sourceMap.DocRoot = attrib.DocRoot ;
			sourceMap.DomainKey = attrib.DomainKey  ;
			sourceMap.PersistenceType = attrib.PersistenceType  ;
			sourceMap.ProviderAssemblyPath = attrib.ProviderAssemblyPath ;
			sourceMap.ProviderConnectionTypeName = attrib.ProviderConnectionTypeName ;
			sourceMap.ProviderType = attrib.ProviderType  ;
			sourceMap.Schema = attrib.Schema ;
			sourceMap.SourceType = attrib.SourceType ;
			sourceMap.Url = attrib.Url ;
			sourceMap.LockTable = attrib.LockTable;
		}

		#endregion
	
	}
}