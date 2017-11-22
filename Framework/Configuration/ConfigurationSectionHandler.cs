using System.Configuration;
using System.Xml;

namespace JJ.Framework.Configuration
{
	public class ConfigurationSectionHandler : IConfigurationSectionHandler
	{
		public object Create(object parent, object configContext, XmlNode section)
		{
			return section;
		}
	}
}
