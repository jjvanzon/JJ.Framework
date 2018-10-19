# JJ.Framework.Xml

Helpers for working with XML.

## XmlHelper

A class that gives access to XML. It does so in a null-safe and multiplicity-safe way. It uses XmlDocument as the underlying .NET API. 

## XmlToObjectConverter

Converts an XmlDocument or string to an object graph. The way to map to classes is easier than the classic ways in .NET. The idea was to make XML mapping intuitive and clean. (Also: At the time on certain platforms standard XML serialization was not available or not be the best option.)

### Elements

By default properties are mapped to XML elements.

C#:

	public int MyElement { get; set; }
	
XML:

	<myElement>3</myElement>

### Attributes

To map to XML attributes, mark a property with the `XmlAttribute` attribute.

C#:

	[XmlAttribute]
	public int MyAttribute { get; set; }

XML:

	myAttribute="3"

### Collections

If a property is a collection type, a parent XML element is expected, and a child element for each position in the array.

C#:

	public int[] MyArray { get; set; }

XML:

	<myArray>
	  <int32>2</int32>
	  <int32>3</int32>
	  <int32>5</int32>
	</myArray>

That single collection property maps to both this parent element and the child elements.

The supported collection types are `Array` types, `List`<`T`>, `IList`<`T`>, `ICollection`<`T`> and `IEnumerable`<`T`>.

### Composite Types

You can easily work with composite types.

XML:
	
	<myRoot>
	  <myObject1 value="3">
	  <myObject2>
		<myArray>
		  <item name="Name1" value="1" />
		  <item name="Name2" value="2" >
		    <childItem name="Child" value="3" />
		  </item>
		<myArray
	  </items>
	</myRoot>

C#:

	class MyRoot
	{
		public MyClass MyObject1 { get; set; }
		public MyClass MyObject2 { get; set; }
	}

	class MyClass
	{
		[XmlAttribute]
		public string Name { get; set; }

		[XmlAttribute]
		public int Value { get; set; }

		[XmlArrayItem("item")]
		public MyClass[] MyArray { get; set; }

		public MyClass ChildItem { get; set; }
	}

The composite types in the object structure must have parameterless constructors.

C#:

	class MyClass
	{
		// Having this constructor with a constructor parameter causes an exception.
		public MyClass(int myConstructorParameter)
		{
		}
	}

XML:

	<myClass>
	</myClass>

### Value Types

Recognized values are the .NET primitive types: `Boolean`, `Char`, `Byte`, `IntPtr`, `UIntPtr`, the numeric types, their signed and unsigned variations and `String`, `Guid`, `DateTime`, `TimeSpan` and `Enum` types.

### Standard Naming

By default the names in the XML are the camel-case version of the property names.

C#:

	MyElement { get; set; }

XML:

	<myElement>

For XML array items, however, it is not the property name, but the camel case version of collection property's item type.

C#:

	public int[] MyArray { get; set; }

XML:

	<myArray>
	  <int32>2</int32>
	  <int32>3</int32>
	  <int32>5</int32>
	</myArray>

### Custom Naming

To diverge from the standard naming , you can specify the node name explicitly by using the following .NET attributes on the properties: `XmlElement`, `XmlAttribute`, `XmlArray` and `XmlArrayItem`.

#### Custom Naming for Elements

C#:

	[XmlElement("Elm")]
	public int MyElement { get; set; }

XML:

	<Elm>3</Elm>

#### Custom Naming for Attributes

C#:
	
	[XmlAttribute("Attr")]
	public int MyAttribute { get; set; }

XML:

	Attr="3"

#### Custom Naming for Arrays

C#:

	[XmlArray("Arr")]
	[XmlArrayItem("Item")]
	public int[] MyArray { get; set; }

XML:

	<Arr>
	  <Item>2</Item>
	  <Item>3</Item>
	  <Item>5</Item>
	</Arr>

### Nullability

Effort was made to make nullability as intuitive as possible.

#### Nullability for Reference Types

Reference types are always optional.

C#:

	class MyRoot
	{
		// Can be null
		public MyClass MyObject { get; set; }
	}

XML:

	<myRoot>
	  <!-- No myObject element here, so the MyObject property in C# will be null. -->
	</myRoot>

#### Nullability for Value Types

Value types are optional only if they are nullable.

C#:

	class MyRoot
	{
		// The '?' makes it OK to leave out the XML element.
		public int? MyElement { get; set; }
	}

XML:

	<myRoot>
	  <!-- myElement van be left out. Then MyElement in the C# code will be null. -->
	</myRoot>

C#:

	class MyRoot
	{
		// Without the '?' the XML element is required.
		public int MyElement { get; set; }
	}

XML:

	<myRoot>
	  <!-- myElement is required, otherwise you will get an exception. -->
	  <myElement>3</myElement>
	</myRoot>

#### Nullability for Collections

Collection types are always optional.

C#:

	class MyRoot
	{
		public int[] MyArray { get; set; }
	}

If the parent element is missing from the XML, the collection will be null.

XML:

	<myRoot>
	  <!-- myArray can be left out, but then MyArray in the C# code will be null. -->
	</myRoot>

If only the parent element is present, an empty collection will be assigned.

XML:

	<myRoot>
	  <!-- MyArray in the C# code will not be null, but an empty collection. -->
	  <myArray />
	</myRoot>

### Performance

In short: performance is untested. I know it is a thing that people want to prove they have the fastest serializer. I really just wanted to map XML more easily. Other components I made depend on it.