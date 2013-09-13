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
using System.IO;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class ClassListMap : IClassListMap
	{
		private ArrayList m_ClassMaps = new ArrayList();


		public static IClassListMap Load(string path)
		{
			ClassListMap classMap;
			try
			{
				XmlSerializer mySerializer = new XmlSerializer(typeof (ClassListMap));
				FileStream myFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				classMap = ((ClassListMap) (mySerializer.Deserialize(myFileStream)));
				myFileStream.Close();
			}
			catch (Exception ex)
			{
				throw new NPersistException("Could not load ClassMaps from path: '" + path + "': " + ex.Message, ex); // do not localize
			}
			return classMap;
		}

		public virtual void Save(string path)
		{
			try
			{
				XmlSerializer mySerializer = new XmlSerializer(this.GetType());
				StreamWriter myWriter = new StreamWriter(path);
				mySerializer.Serialize(myWriter, this);
				myWriter.Close();
			}
			catch (Exception ex)
			{
				throw new NPersistException("Could not serialize Class List Map! " + ex.Message, ex); // do not localize
			}
		}

		[XmlArrayItem(typeof (ClassMap))]
		public virtual ArrayList ClassMaps
		{
			get { return m_ClassMaps; }
			set { m_ClassMaps = value; }
		}

		public virtual IClassMap GetClassMap(string findName)
		{
			foreach (IClassMap classMap in m_ClassMaps)
			{
				if (classMap.Name == findName)
				{
					return classMap;
				}
			}
			return null;
		}
	}
}