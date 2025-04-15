JJ.Framework.Common
===================

A mixed bag of general-purpose utilities with minimal dependencies. Later versions of this library split functionality into focused packages like `JJ.Framework.Text`, `JJ.Framework.Collections`, and `JJ.Framework.Exceptions`. This "prequel" version, contains a little bit of everything: a version released in aid of releasing older legacy apps, still holding value.

Here are the larger parts:

String Extensions
-----------------

- `Left` / `Right`
	- Returns the left or right part of a string. Throws an exception if the string has less characters than the length provided.
- `FromTill`
	- Takes the middle of a string by specifying the zero-based start index and the end index. Throws an exception if the string has less characters than the length provided.
- `CutLeft` / `CutRight`
	- Trims off at most one occurrence of a value from the given string.
- `CutLeftUntil` / `CutRightUntil`
	- Cuts off part of a string until the specified delimiter and returns what remains including the delimiter itself.
- `RemoveExcessiveWhiteSpace`
	- Trims and replaces sequences of two or more white space characters by a single space.
- `Replace`
	- Variation on `String.Replace` with the ability to ignore case.
- `StartWithCap`
	- Turns the first character into a capital letter.
- `StartWithLowerCase`
	- Turns the first character into a lower-case letter.
- `Split`
    - Overloads mostly missing before .NET 5 + one that takes params for split characters.
- `SplitWithQuotation`
    - Allows you to parse CSV-like lines including quotation for the ability to include the separator character and quote characters in the values themselves.


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
