JJ.Framework.Configuration
==========================

Allows you to work with complex configuration structures in your *app.config* or *web.config* files. Doing it the classic way with `System.Configuration` may be difficult and error prone. `JJ.Framework.Configuration` makes it super easy.

<h2>Contents</h2>

- [AppSettingsReader`<`T`>`](#appsettingsreadert)
- [CustomConfigurationManager](#customconfigurationmanager)
- [XML Mapping Details](#xml-mapping-details)
	- [Elements](#elements)
	- [Attributes](#attributes)
	- [Collections](#collections)
	- [Composite Types](#composite-types)
	- [Standard Naming](#standard-naming)
		- [Standard Naming for Collections](#standard-naming-for-collections)
	- [Custom Naming](#custom-naming)
		- [Custom Naming for Elements](#custom-naming-for-elements)
		- [Custom Naming for Attributes](#custom-naming-for-attributes)
		- [Custom Naming for Arrays](#custom-naming-for-arrays)
	- [Nullability](#nullability)
		- [Nullability for Reference Types](#nullability-for-reference-types)
		- [Nullability for Value Types](#nullability-for-value-types)
		- [Nullability for Collections](#nullability-for-collections)
	- [Value Types](#value-types)
	- [Error Messages](#error-messages)

AppSettingsReader`<`T`>`
------------------------

For reading out `<appSettings>` in a strongly-typed way, cleanly, without generated code.

Example config:

```xml
<appSettings>
	<add key="MySetting" value="20"/>
</appSettings>
```

Helper C# interface:

```cs
interface IMySettings
{
	int MySetting { get; }
}
```

Call:

```cs
int value = AppSettingsReader<IMySettings>.Get(x => x.MySetting);
```


CustomConfigurationManager
--------------------------

If your configuration requires more than a flat list of key value pairs, you might make a custom configuration section. In a configuration section you can add as much hierarchy as you like. 

Example config:

```xml
<configSections>
	<section name="jj.demos.configuration" type="JJ.Framework.Configuration.ConfigurationSectionHandler, JJ.Framework.Configuration"/>
</configSections>

<jj.demos.configuration>
	<items>
		<item value="1" />
		<item value="2" >
			<child value="3" />
		</item>
	</items>
</jj.demos.configuration>
```

Relace the name `jj.demos.configuration` with your assembly name converted to lower case.

Helper classes: (to program yourself)
	
```cs
class ConfigurationSection
{
	public Item[] Items { get; set; }
}

class Item
{
	[XmlAttribute]
	public int Value { get; set; }
	public Item Child { get; set; }
}
```

Read the config:

```cs
var config = CustomConfigurationManager.GetSection<ConfigurationSection>();
```

Access some data:

```cs
int value = config.Items[1].Child.Value;
```

XML Mapping Details
-------------------

Here is the documentation about how to map the XML. (Source: [https://www.nuget.org/packages/JJ.Framework.Xml/](https://www.nuget.org/packages/JJ.Framework.Xml/))

Note that C# will follow the convention that property names are pascal case, while this maps automatically to XML in camel case.

### Elements

By default properties are mapped to XML elements.

C#:

```cs
public int MyElement { get; set; }
```

XML:

```xml
<myElement>3</myElement>
```

### Attributes

To map to XML attributes, mark a property with the `XmlAttribute` attribute.

C#:

```cs
[XmlAttribute]
public int MyAttribute { get; set; }
```

XML:

```xml
myAttribute="3"
```

### Collections

If a property is a collection type, a parent XML element is expected, and a child element for each position in the array.

C#:

```cs
public int[] MyArray { get; set; }
```

XML:

```xml
<myArray>
	<int32>2</int32>
	<int32>3</int32>
	<int32>5</int32>
</myArray>
```

That single collection property maps to both this parent element and the child elements.

The supported collection types are `Array` types, `List<T>`, `IList<T>`, `ICollection<T>` and `IEnumerable<T>`.

### Composite Types

You can easily work with composite types.

XML:
	
```xml
<myRoot>
	<myObject1 value="3" />
	<myObject2>
	<myArray>
		<item name="Name1" value="1" />
		<item name="Name2" value="2" >
		<childItem name="Child" value="3" />
		</item>
	</myArray>
	</myObject2>
</myRoot>
```

C#:

```cs
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
	public int? Value { get; set; }

	[XmlArrayItem("item")]
	public MyClass[] MyArray { get; set; }

	public MyClass ChildItem { get; set; }
}
```

The composite types in the object structure must have parameterless constructors.

C#:

```cs
class MyClass
{
	// Having this constructor with a parameter causes an exception.
	public MyClass(int myConstructorParameter) { }
}
```

### Standard Naming

By default the names in the XML are the camel-case version of the property names.

C#:

```cs
public int MyElement { get; set; }
```

XML:

```xml
<myElement>3</myElement>
```

#### Standard Naming for Collections

For XML array items, however, it is not the property name, but the camel case version of collection property's item type.

C#:

```cs
public int[] MyArray { get; set; }
```

XML:

```xml
<myArray>
	<int32>2</int32>
	<int32>3</int32>
	<int32>5</int32>
</myArray>
```

### Custom Naming

To diverge from the standard naming , you can specify the node name explicitly by using the following .NET attributes on the properties: `XmlElement`, `XmlAttribute`, `XmlArray` and `XmlArrayItem`.

#### Custom Naming for Elements

C#:

```cs
[XmlElement("Elm")]
public int MyElement { get; set; }
```

XML:

```xml
<Elm>3</Elm>
```

#### Custom Naming for Attributes

C#:
	
```cs
[XmlAttribute("Attr")]
public int MyAttribute { get; set; }
```

XML:

```xml
Attr="3"
```

#### Custom Naming for Arrays

C#:

```cs
[XmlArray("Arr")]
[XmlArrayItem("Item")]
public int[] MyArray { get; set; }
```

XML:

```xml
<Arr>
	<Item>2</Item>
	<Item>3</Item>
	<Item>5</Item>
</Arr>
```

### Nullability

Effort was made to make nullability as intuitive as possible.

#### Nullability for Reference Types

Reference types are always optional.

C#:

```cs
class MyRoot
{
	// Can be null
	public MyClass MyObject { get; set; }
}
```

XML:

```xml
<myRoot>
	<!-- No myObject element here, so the MyObject property in C# will be null. -->
</myRoot>
```

#### Nullability for Value Types

Value types are optional, only if they are nullable.

C#:

```cs
class MyRoot
{
	// The '?' makes it OK to leave out the XML element.
	public int? MyElement { get; set; }
}
```

XML:

```xml
<myRoot>
	<!-- myElement van be left out. -->
	<!-- Then the MyElement property in the C# code will be null. -->
</myRoot>
```

C#:

```cs
class MyRoot
{
	// Without the '?' the XML element is required.
	public int MyElement { get; set; }
}
```

XML:

```cs
<myRoot>
	<!-- myElement is required, otherwise you will get an exception. -->
	<myElement>3</myElement>
</myRoot>
```

#### Nullability for Collections

Collection types are always optional.

C#:

```cs
class MyRoot
{
	public int[] MyArray { get; set; }
}
```

If the parent element is missing from the XML, the collection will be null.

XML:

```xml
<myRoot>
	<!-- myArray can be left out, -->
	<!-- but then MyArray in the C# code will be null. -->
</myRoot>
```

If only the parent element is present, an empty collection will be assigned.

XML:

```xml
<myRoot>
	<!-- MyArray in the C# code will not be null, but an empty collection. -->
	<myArray />
</myRoot>
```

### Value Types

Recognized values are the .NET primitive types: `Boolean`, `Char`, `Byte`, `IntPtr`, `UIntPtr`, the numeric types, their signed and unsigned variations and `String`, `Guid`, `DateTime`, `TimeSpan` and `Enum` types.

### Error Messages

Effort was put into making the exception messages clear and accurate if there are structure mismatches.