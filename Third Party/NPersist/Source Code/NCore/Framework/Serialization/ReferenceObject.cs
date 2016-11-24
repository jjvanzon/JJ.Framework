using System;
using System.Collections;
using System.Xml;
using System.Reflection;

namespace Puzzle.NCore.Runtime.Serialization
{
    public class ReferenceObject : ObjectBase
    {
        public bool IsEnumerable = false;
        public readonly IList Fields = new ArrayList();

        public override string ToString()
        {
            return string.Format("{0}#{1}", Type.Name, ID);
        }

        public override void Serialize(XmlTextWriter xml)
        {
            xml.WriteStartElement("object");
            xml.WriteAttributeString("id", ID.ToString());
            xml.WriteAttributeString("type", Type.FullName);

            foreach (Field property in Fields)
            {
                property.Serialize(xml);
            }


            xml.WriteEndElement();
        }

        public override void SerializeReference(XmlTextWriter xml)
        {
            xml.WriteAttributeString("id-ref", ID.ToString());
        }

        private object result;
        public override object GetValue()
        {
            if (result != null)
                return result;
            
            result = Activator.CreateInstance(Type);
            foreach (Field field in Fields)
            {
                FieldInfo fieldInfo = Type.GetField(field.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                object fieldValue = field.Value.GetValue();
                fieldInfo.SetValue(result, fieldValue);                
            }
            
            return result;
        }
    }
}