using System;
using System.Xml;

namespace Puzzle.NCore.Runtime.Serialization
{
    public abstract class ObjectBase
    {
        public int ID;
        public Type Type;

        public abstract void Serialize(XmlTextWriter xml);

        public abstract void SerializeReference(XmlTextWriter xml);

        public abstract object GetValue();
    }
}