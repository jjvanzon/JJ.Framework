// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.IO;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Mapping.Serialization
{
	public interface IMapSerializer
	{
		string Serialize(IDomainMap domainMap);

		IDomainMap Deserialize(string xml);

		void Save(IDomainMap domainMap, string fileName);

		IDomainMap Load(string fileName);

		IDomainMap LoadFromXml(string xml);

		bool BareBones { get; set; }
	}
}