# JJ.Framework.Conversion

Makes it easier to convert simple types.

* `SimpleTypeConverter.ParseValue`: One method to parse numeric types, their signed and unsigned variations, DateTime, TimeSpan, Guid and Enum types, IntPtr, UIntPtr and their nullable variations. Those often require different types of conversions. This method just takes care of it.
* `SimpleTypeConverter.ConvertValue`: Makes it easier to convert nullables along with non-nullables.
* `DecimalParser`, `DoubleParser`, `Int16Parser`, `Int32Parser`, `Int64Parser`, `SingleParser`: If you want to be more specific in what it is you parse: these classes make it easier to parse nullables.
* `EnumParser`: Make it a little easier to use enum parsing.