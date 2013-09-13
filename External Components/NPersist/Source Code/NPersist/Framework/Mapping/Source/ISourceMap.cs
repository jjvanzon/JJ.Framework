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
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public interface ISourceMap : IMap
	{
		PersistenceType PersistenceType { get; set; }


		[XmlIgnore()]
		IDomainMap DomainMap { get; set; }

		void SetDomainMap(IDomainMap value);

		bool Compute { get; set; }

		//O/R Mapping

		[XmlArrayItem(typeof (ITableMap))]
		ArrayList TableMaps { get; set; }

		ITableMap GetTableMap(string findName);

        ITableMap MustGetTableMap(string findName);

		SourceType SourceType { get; set; }

		ProviderType ProviderType { get; set; }

		string ProviderAssemblyPath { get; set; }

		string ProviderConnectionTypeName { get; set; }

		string ConnectionString { get; set; }

		string Schema { get; set; }

		string Catalog { get; set; }

		void UpdateName(string newName);

        string LockTable { get; set; }

        ITableMap MustGetLockTable();

        ITableMap GetLockTable();

        void SetupLockIndexes();

		//O/D Mapping

		string DocPath { get; set; }

		string DocRoot { get; set; }

		string GetDocRoot();

		string DocEncoding { get; set; }

		string GetDocEncoding();

		//O/S Mapping

		string Url { get; set; }

		string DomainKey { get; set; }

		//O/O Mapping
//
//		string ContextFactoryAssembly { get; set; }
//
//		string ContextFactoryClass { get; set; }


	}
}