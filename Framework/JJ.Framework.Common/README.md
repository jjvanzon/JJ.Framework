JJ.Framework.Common
===================

A mixed bag of general-purpose utilities with minimal dependencies. Later versions of this library split functionality into focused packages like `JJ.Framework.Text`, `JJ.Framework.Collections`, and `JJ.Framework.Exceptions`. This "prequel" version, contains a little bit of everything: a version released in aid of releasing older legacy apps, that still hold value.

Here are the larger parts:

String Extensions
-----------------

- `Left`
- `Right`
- `CutLeft`
- `CutRight`
- `CutLeftUntil`
- `CutRightUntil`
- `FromTill`
- `RemoveExcessiveWhiteSpace`
- `Replace`
- `StartWithCap`
- `StartWithLowerCase`
- `Split` overloads
- `SplitWithQuotation` for text lines must like from CSV-files


Exception Types
---------------

- `InvalidValueException`
- `ValueNotSupportedException`


Collection Extensions
---------------------

- `TrimAll`
- `Recursive` collection extensions
- `ForEach`
- `Except`
- `Union`
- `Distinct`
- `AsEnumerable`
- `Add`
- `AddRange`
- `KeyValuePairHelper`


Misc Helpers
------------

- `ConfigurationHelper`: Legacy helper for using configuration settings on platforms where `System.Configuration` is not available.
- `CultureHelper`: To set thread culture with a single code line.
- `EmbeddedResourceHelper`: Make it a little easier to get embedded resource `Streams`, `bytes` and `strings`.
- `KeyHelper`: ...
