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
using System.IO;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Mapping.Serialization
{
	public abstract class MapSerializerBase : IMapSerializer
	{
		public static void Convert(string sourceFileName, string targetFileName, IMapSerializer sourceMapSerializer, IMapSerializer targetMapSerializer)
		{
			IDomainMap domainMap = DomainMap.Load(sourceFileName, sourceMapSerializer);
			domainMap.Save(targetFileName, targetMapSerializer);
		}

		private bool m_BareBones;

		protected MapSerializerBase() : base()
		{
		}

		protected MapSerializerBase(bool bareBones) : base() => m_BareBones = bareBones;

	    public virtual IDomainMap Deserialize(string xml) => null;

	    public virtual string Serialize(IDomainMap domainMap) => "";

	    public virtual IDomainMap Load(string fileName)
		{
			StreamReader reader = null;
			string xml = "";
			try
			{
				reader = File.OpenText(fileName);
				xml = reader.ReadToEnd() ;
				reader.Close() ;
				reader = null;
			}
			catch (Exception ex)
			{
				if (reader != null)
				{
					try
					{
						reader.Close();
					}
					catch
					{
					}
					throw new IOException("Could not load npersist xml mapping file!", ex); // do not localize
				}
			}
			return LoadFromXml(xml);
		}

		
		public virtual IDomainMap LoadFromXml(string xml) => Deserialize(xml);

	    public virtual void Save(IDomainMap domainMap, string fileName)
		{
			string xml = Serialize(domainMap);
			StreamWriter str = null;
			try
			{
				str = File.CreateText(fileName);
				str.Write(xml);
				str.Close();
			}
			catch (Exception ex)
			{
				if (str != null)
				{
					try
					{
						str.Close();
					}
					catch
					{
					}
					throw new IOException("Could not load npersist xml mapping file!", ex); // do not localize
				}
			}
		}

		public bool BareBones
		{
			get => m_BareBones;
		    set => m_BareBones = value;
		}
	}
}