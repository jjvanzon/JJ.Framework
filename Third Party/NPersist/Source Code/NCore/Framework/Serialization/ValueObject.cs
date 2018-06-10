using System.ComponentModel;
using System.Xml;

namespace Puzzle.NCore.Runtime.Serialization
{
    public class ValueObject : ObjectBase
    {
        public string Value;

        public override string ToString() => string.Format("'{0}' : {1}", Value, Type.Name);

        public override void Serialize(XmlTextWriter xml)
        {
            //xml.WriteStartElement ("value");
            //xml.WriteAttributeString ("id",ID.ToString());
            //xml.WriteAttributeString ("value",Value);
            //xml.WriteAttributeString ("type",Type.FullName);
            //xml.WriteEndElement ();
        }

        public override void SerializeReference(XmlTextWriter xml)
        {
            xml.WriteAttributeString("value", Value);
            xml.WriteAttributeString("type", Type.FullName);
        }

        public override object GetValue()
        {
            TypeConverter tc = TypeDescriptor.GetConverter(Type);
            object res = tc.ConvertFromString(Value);
            return res;
        }
    }
}