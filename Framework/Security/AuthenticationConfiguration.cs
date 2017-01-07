using System.Xml.Serialization;

namespace JJ.Framework.Security
{
    public class AuthenticationConfiguration
    {
        [XmlAttribute]
        public AuthenticationTypeEnum AuthenticationType { get; set; }
    }
}
