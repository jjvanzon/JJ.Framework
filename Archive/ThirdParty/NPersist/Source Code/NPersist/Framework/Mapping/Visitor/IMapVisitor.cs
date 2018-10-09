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
using System.Data;
using System.Xml.Serialization;

namespace Puzzle.NPersist.Framework.Mapping.Visitor
{
	/// <summary>
	/// Summary description for IMapVisitor.
	/// </summary>
	public interface IMapVisitor
	{
		void Visit(IDomainMap domainMap);

		void Visit(ICodeMap codeMap);

		void Visit(IClassListMap classListMap);
	
		void Visit(IClassMap classMap);
	
		void Visit(IPropertyMap propertyMap);
	
		void Visit(ISourceListMap sourceListMap);
	
		void Visit(ISourceMap sourceMap);
	
		void Visit(ITableMap tableMap);
	
		void Visit(IColumnMap columnMap);

		void Visit(IEnumValueMap enumValueMap);

	}
}
