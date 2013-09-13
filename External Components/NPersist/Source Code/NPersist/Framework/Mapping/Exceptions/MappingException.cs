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
using System.Runtime.Serialization;
using Puzzle.NPersist.Framework.Exceptions;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class MappingException : NPersistException
	{
		private IMap m_mapObject;
		private string m_Setting;

		public MappingException() : base()
		{
		}

		public MappingException(string message) : base(message)
		{
		}

		public MappingException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public MappingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public MappingException(string message, IMap mapObject, string setting) : base(message)
		{
			m_mapObject = mapObject;
			m_Setting = setting;
		}

		public MappingException(string message, IMap mapObject, string setting, Exception innerException) : base(message, innerException)
		{
			m_mapObject = mapObject;
			m_Setting = setting;
		}

		public IMap MapObject
		{
			get { return m_mapObject; }
			set { m_mapObject = value; }
		}

		public string Setting
		{
			get { return m_Setting; }
			set { m_Setting = value; }
		}
	}
}