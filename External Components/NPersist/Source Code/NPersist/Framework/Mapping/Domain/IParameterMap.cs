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
	/// <summary>
	/// Summary description for IParameterMap.
	/// </summary>
	public interface IParameterMap : IMap
	{
        [XmlIgnore()]
        IMethodMap MethodMap { get; set; }

        string Type { get; set; }

        bool IsParams { get; set; }
	}
}
