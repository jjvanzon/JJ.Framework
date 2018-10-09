using System;
using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Remoting.Formatting;
using Puzzle.NPersist.Framework.Remoting.Marshaling;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Remoting
{
	/// <summary>
	/// Summary description for DomainMapStripper.
	/// </summary>
	public class DomainMapStripper
	{
		public DomainMapStripper()
		{
		}

		public static IDomainMap StripDomainMap(IDomainMap domainMap)
		{
			IDomainMap cloneMap = (IDomainMap) domainMap.DeepClone();

			foreach (IClassMap classMap in cloneMap.ClassMaps)
			{
				classMap.Table = "";
				classMap.TypeColumn = "" ;
				classMap.TypeValue = "" ;
				classMap.DocClassMapMode =  DocClassMapMode.Default;
				classMap.DocElement  = "" ;
				classMap.DocParentProperty = "" ;
				classMap.DocRoot  = "" ;

				foreach (IPropertyMap propertyMap in classMap.PropertyMaps)
				{
					bool isNullable = propertyMap.GetIsNullable();
					bool isAssigned = propertyMap.GetIsAssignedBySource();
					int maxLength = propertyMap.GetMaxLength();

					propertyMap.Table = "";
					propertyMap.Column = "";
					propertyMap.AdditionalColumns.Clear() ;
					propertyMap.IdColumn = "";
					propertyMap.AdditionalIdColumns.Clear() ;

					propertyMap.DocAttribute  = "";
					propertyMap.DocElement  = "";
					propertyMap.DocPropertyMapMode  = DocPropertyMapMode.Default;

					propertyMap.InheritInverseMappings = false;

					propertyMap.IsNullable = isNullable;
					propertyMap.MaxLength = maxLength;
					propertyMap.IsAssignedBySource = isAssigned;
				}				
			}

			foreach (ISourceMap sourceMap in cloneMap.SourceMaps)
			{
				sourceMap.ConnectionString = "";
				sourceMap.Catalog = "";
				sourceMap.DocPath  = "";
				sourceMap.DocEncoding  = "";
				sourceMap.DocRoot   = "";
				sourceMap.ProviderAssemblyPath    = "";
				sourceMap.ProviderConnectionTypeName    = "";
				sourceMap.ProviderType  = ProviderType.SqlClient;
				sourceMap.Schema  = "";
				sourceMap.TableMaps.Clear() ;
			}

			return cloneMap;
		}
	}
}
