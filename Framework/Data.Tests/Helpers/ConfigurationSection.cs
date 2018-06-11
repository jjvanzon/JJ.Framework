using System.Xml.Serialization;

namespace JJ.Framework.Data.Tests.Helpers
{
	public class ConfigurationSection
	{
		[XmlAttribute]
		public string Location { get; set; }

		[XmlAttribute("nhibernateContextType")]
		public string NHibernateContextType { get; set; }

		[XmlAttribute("npersistContextType")]
		public string NPersistContextType { get; set; }

		[XmlAttribute]
		public string EntityFrameworkContextType { get; set; }

		[XmlAttribute]
		public string Dialect { get; set; }
	}
}
