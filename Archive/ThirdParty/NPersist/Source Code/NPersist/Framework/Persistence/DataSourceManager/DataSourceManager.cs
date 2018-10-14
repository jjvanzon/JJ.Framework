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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class DataSourceManager : ContextChild, IDataSourceManager
	{
		private Hashtable m_hashDataSources = new Hashtable();

		public virtual IDataSource GetDataSource(ISourceMap sourceMap)
		{
			string name = sourceMap.Name;
			return (IDataSource) m_hashDataSources[name];
		}

		public virtual IDataSource GetDataSource(object obj)
		{
			string name = this.Context.DomainMap.MustGetClassMap(obj.GetType()).GetSourceMap().Name;
			return (IDataSource) m_hashDataSources[name];
		}

		public virtual IDataSource GetDataSource(Type type)
		{
			string name = this.Context.DomainMap.MustGetClassMap(type).GetSourceMap().Name;
			return (IDataSource) m_hashDataSources[name];
		}

		public virtual IDataSource GetDataSource(object obj, string propertyName)
		{
            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
            IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
            ISourceMap sourceMap = propertyMap.GetSourceMap ();
            string name = sourceMap.Name;

			return (IDataSource) m_hashDataSources[name];
		}

		public virtual void Setup() => InitDataSources();

	    protected virtual void InitDataSources()
		{
			IDataSource ds;
			foreach (ISourceMap sourceMap in this.Context.DomainMap.SourceMaps)
			{
				ds = new DataSource();
				ds.DataSourceManager = this;
				ds.Name = sourceMap.Name;
				ds.SourceMap = sourceMap;
				m_hashDataSources[sourceMap.Name] = ds;
			}
		}

		public virtual void Dispose()
		{
			foreach (IDataSource ds in m_hashDataSources.Values)
			{
				ds.Dispose();
			}
			GC.SuppressFinalize(this);
		}
	}
}