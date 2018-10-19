# JJ.Framework.Xml

Helpers for working with XML.

## XmlHelper

A class that gives access to XML. It does so in a null-safe and multiplicity-safe way. It uses XmlDocument as the underlying .NET API. 

## XmlToObjectConverter

Converts an XmlDocument or string to an object graph. The way to map to classes is easier than the classic ways in .NET.

(Also: At the time on certain platforms standard XML serialization was not available or not be the best option.)

### Elements

By default properties are mapped to XML elements.

C#:

	public int MyElement { get; set; }
	
XML:

	<myElement>3</myElement>

### Attributes

To map to XML attributes, mark a property with the `XmlAttribute` attribute.

C#:

	public class MyRoot
	{
		[XmlAttribute]
		public int MyAttribute { get; set; }
	}

XML:

	<myRoot myAttribute="3" />

### Standard Naming

By default the names in the XML are the camel-case version of the property names.

C#:

	MyElement

XML:

	<myElement>

For XML array items, however, it is not the property name, but the camel case version of collection property's item type.

C#:

	int[] MyArray { get; set; }

XML:

	<myArray>
		<int32>2</int32>
		<int32>3</int32>
		<int32>5</int32>
	</myArray>

### Custom Naming

To diverge from this naming standard, you can specify the node name explicitly by using the following .NET attributes on the properties: `XmlElement`, `XmlAttribute`, `XmlArray` and `XmlArrayItem`.

#### Custom Naming for Elements

C#:

	[XmlElement("Elm")]
	public int MyElement { get; set; }

XML:

	<Elm>3</Elm>

#### Custom Naming for Attributes

C#:
	
	public class MyRoot
	{
		[XmlAttribute("Attr")]
		public int MyAttribute { get; set; }
	}

XML:

	<myRoot Attr="3" />

#### Custom Naming for Arrays

C#:

	[XmlArray("Arr")]
	[XmlArrayItem("Item")]
	int[] MyArray { get; set; }

XML:

	<Arr>
		<Item>2</Item>
		<Item>3</Item>
		<Item>5/Item>
	</Arr>

### Nullability Details

Reference types are always optional. Value types are optional only if they are nullable. Collection types are always optional. If only the parent element is present, an empty collection will be assigned. If the parent element is missing from the XML, the collection will be null.

### Value Types

Recognized values are the .NET primitive types: `Boolean`, `Char`, `Byte`, `IntPtr`, `UIntPtr`, the numeric types, their signed and unsigned variations and `String`, `Guid`, `DateTime`, `TimeSpan` and `Enum` types.

### Collection Types

The supported collection types are `Array` types, `List`<`T`>, `IList`<`T`>, `ICollection`<`T`> and `IEnumerable`<`T`>.

If a property is a collection type, a parent XML element is expected, and a child element for each position in the array. That single collection property maps to both this parent element and the child elements.

### Composite Types

The composite types in the object structure must have parameterless constructors.

### Performance

In short: performance is untested. I know it is a thing that people want to prove they have the fastest serializer. I really just wanted to map XML more easily. Other components I made depend on it, that's why it is a prerequisite to have this in NuGet.
