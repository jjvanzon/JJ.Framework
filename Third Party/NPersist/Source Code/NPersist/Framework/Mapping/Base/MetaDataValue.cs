// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Mapping
{
	public class MetaDataValue : IMetaDataValue
	{
		private string m_Key;
		private object m_Value;

		public string Key
		{
			get { return m_Key; }
			set { m_Key = value; }
		}

		public object Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
	}
}