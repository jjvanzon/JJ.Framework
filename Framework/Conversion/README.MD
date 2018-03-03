# JJ.Framework.Conversion

Makes it easier to convert to simple types.

* `SimpleTypeConverter.ConvertValue`: Makes it easier to convert nullables along with non-nullables.
* `SimpleTypeConverter.ParseValue`: One method to parse enums, TimeSpan, IntPtr, UIntPtr any other simple type and their nullable variations. Those often require different types of conversions. This method just takes care of it.
* `DecimalParser`, `DoubleParser`, `Int16Parser`, `Int32Parser`, `Int64Parser`, `SingleParser`: For instance making it easier to parse nullables.
* `EnumParser`: Make it a little easier to use enum parsing.
