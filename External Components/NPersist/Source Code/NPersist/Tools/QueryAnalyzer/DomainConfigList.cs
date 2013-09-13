using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace Puzzle.NPersist.Tools.QueryAnalyzer
{
	/// <summary>
	/// Summary description for DomainConfigList.
	/// </summary>
	public class DomainConfigList
	{
		public DomainConfigList()
		{
		}

		public static DomainConfigList Load(string path)
		{
			DomainConfigList domainConfigList;
			try
			{
				XmlSerializer mySerializer = new XmlSerializer(typeof (DomainConfigList));
				FileStream myFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				domainConfigList = ((DomainConfigList) (mySerializer.Deserialize(myFileStream)));
				myFileStream.Close();
			}
			catch (Exception)
			{
				domainConfigList = new DomainConfigList() ;
			}
			return domainConfigList;
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
			catch (Exception)
			{
			}
		}

		private ArrayList domainConfigs = new ArrayList() ;
		
		[XmlArrayItem(typeof(DomainConfig))] public ArrayList DomainConfigs
		{
			get { return this.domainConfigs; }
			set { this.domainConfigs = value; }
		}
	}
}
