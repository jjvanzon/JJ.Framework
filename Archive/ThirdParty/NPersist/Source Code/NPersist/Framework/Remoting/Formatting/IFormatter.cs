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
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Remoting.Marshaling;

namespace Puzzle.NPersist.Framework.Remoting.Formatting
{
	/// <summary>
	/// Summary description for IFormatter.
	/// </summary>
	public interface IFormatter
	{
		object Serialize(object obj);
		object Deserialize(object serialized, Type type);
	}
}
