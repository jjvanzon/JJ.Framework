using JetBrains.Annotations;
// ReSharper disable UnusedTypeParameter

namespace JJ.Framework.Data.Xml
{
    [PublicAPI]
    public abstract class XmlMapping<TEntity> : IXmlMapping
    {
        public XmlMapping() => ElementName = "x";

        public IdentityType IdentityType { get; protected set; }
        public string IdentityPropertyName { get; protected set; }
        public string ElementName { get; protected set; }
    }
}