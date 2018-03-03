# JJ.Framework.Common

Some basic helpers, for instance:

* `ConfigurationHelper`: For using configuration settings when you cannot be dependent on System.Configuration.
* `CultureHelper`: For instance to set thread culture with a single code line.
* `EmbeddedResourceHelper`: Make it a little easier to get embedded resource Streams, bytes and strings.
* `EnumHelper`: Make it a little easier to check the validitiy of enum values.
* `EventArgs`<`T`>: A generic version of event args. If you use a C# 7 tuple for T you can basically use it for everything.

NOTE: Some of the parsing methods were moved to `JJ.Framework.Conversion`.