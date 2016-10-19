namespace JJ.Framework.Xml.Linq
{
    /// <summary>
    /// Identifies what casing is expected in the XML
    /// when no name is specified with the 
    /// XmlElement, XmlAttribute, XmlArray or XmlArrayItem attributes.
    /// </summary>
    public enum XmlCasingEnum
    {
        /// <summary>
        /// Keeping this default value will result in an exception.
        /// When casing is applied to property names.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The casing in the XML is expected to be the exactly the same as the property names.
        /// </summary>
        UnmodifiedCase = 1,

        /// <summary>
        /// The casing in the XML is expected to be the camel-case version of the property name.
        /// </summary>
        CamelCase = 2
    }
}
