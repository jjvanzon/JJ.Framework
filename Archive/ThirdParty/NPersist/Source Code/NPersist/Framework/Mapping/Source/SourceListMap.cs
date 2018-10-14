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
	public class SourceListMap : ISourceListMap
	{
				

		private ArrayList m_SourceMaps = new ArrayList();

		public static ISourceListMap Load(string path)
		{
			SourceListMap sourceMap;
			try
			{
				XmlSerializer mySerializer = new XmlSerializer(typeof (SourceListMap));
				FileStream myFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				sourceMap = ((SourceListMap) (mySerializer.Deserialize(myFileStream)));
				myFileStream.Close();
			}
			catch (Exception ex)
			{
				throw new NPersistException("Could not load SourceMaps from path: '" + path + "': " + ex.Message, ex); // do not localize
			}
			return sourceMap;
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
				throw new NPersistException("Could not serialize Source List Map! " + ex.Message, ex); // do not localize
			}
		}

		[XmlArrayItem(typeof (SourceMap))]
		public virtual ArrayList SourceMaps
		{
			get => m_SourceMaps;
		    set => m_SourceMaps = value;
		}

		public virtual ISourceMap GetSourceMap(string findName)
		{
			foreach (ISourceMap sourceMap in m_SourceMaps)
			{
				if (sourceMap.Name == findName)
				{
					return sourceMap;
				}
			}
			return null;
		}
	}
}