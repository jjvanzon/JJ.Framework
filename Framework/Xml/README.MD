JJ.Framework.Xml contains a class XmlHelper that gives access to XML, using XmlDocument as the underlying .NET API. But then it does it in a null-safe and multiplicity-safe way.

There is also the HtmlToXmlConverter class, which steals from SgmlReader (see external components and license files if applicable). It does what it says.

But most of all: JJ.Framework.Xml's main class is XmlToObjectConverter. It converts an XmlDocument or string to an object whose class you supply. The way to map XML to classes is easier than the classic ways in .NET. The class summary says it all, litterly:

Converts an XML structure to an object tree.

(Under certain platforms standard XML serialization may not be available or may not be the best option. That is why this class exists.)

By default properties are mapped to XML elements.

To map to XML attributes, mark a property with the XmlAttribute attribute.

If a property is an Array type or a supported collection type, a parent XML element is expected, and a child element for each position in the array. That single collection property maps to both this parent element and the child elements. The supported collection types are Array types, List<T>, IList<T>, ICollection<T> and IEnumerable<T>.

By default the names in the XML are the camel-case version of the property names. For XML array items, however, it is not the property name, but the collection property's item type name converted to camel case. To diverge from this standard, you can specify the node name explicitly by using the following .NET attributes on the properties: XmlElement, XmlAttribute, XmlArray and XmlArrayItem.

Reference types are always optional. Value types are optional only if they are nullable. Collection types are always optional. If only the parent element is present, an empty collection will be assigned. If the parent element is missing from the XML, the collection will be null.

Recognized values are the .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr, the numeric types, their signed and unsigned variations and String, Guid, DateTime, TimeSpan and Enum types.

The composite types in the object structure must have parameterless constructors.