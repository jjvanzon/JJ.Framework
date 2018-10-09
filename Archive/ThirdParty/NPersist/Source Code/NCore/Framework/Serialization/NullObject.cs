using System.Xml;

namespace Puzzle.NCore.Runtime.Serialization
{
    public class NullObject : ObjectBase
    {
        public static readonly NullObject Default = new NullObject();

        public override string ToString() => "{null}";

        public override void Serialize(XmlTextWriter xml)
        {
            //xml.WriteStartElement ("null");
            //xml.WriteEndElement ();
        }

        public override void SerializeReference(XmlTextWriter xml) => xml.WriteAttributeString("null", "true");

        public override object GetValue() => null;
    }
}