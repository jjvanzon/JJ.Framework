using System.Xml;

namespace Puzzle.NCore.Runtime.Serialization
{
    public class Field
    {
        public string Name;
        public ObjectBase Value;

        public void Serialize(XmlTextWriter xml)
        {
            xml.WriteStartElement("field");
            xml.WriteAttributeString("name", Name);
            Value.SerializeReference(xml);
            xml.WriteEndElement();
        }
    }
}