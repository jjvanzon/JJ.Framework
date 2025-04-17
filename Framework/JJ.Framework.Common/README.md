JJ.Framework.Common
===================

A mixed bag of general-purpose utilities with minimal dependencies. Later versions of this library split functionality into focused packages like `JJ.Framework.Text`, `JJ.Framework.Collections`, and `JJ.Framework.Exceptions`. This "prequel" version, contains a little bit of everything: a version released in aid of releasing older legacy apps, still holding value.

__Contents__

- [String Extensions](#string-extensions)
- [Collection Extensions](#collection-extensions)
- [Recursive Collection Extensions](#recursive-collection-extensions)
- [KeyValuePairHelper](#keyvaluepairhelper)
- [Exception Types](#exception-types)
- [Misc Helpers](#misc-helpers)


String Extensions
-----------------

- `Left` / `Right`
	* Return the left or right part of a string:  
	* `"12345".Left(2)` = `"12"`  
	* `"12345".Right(2)` = `"45"`  
    * (Throws an exception if the string is shorter than the requested length.)
- `FromTill`
	* Takes the middle of a string by specifying the zero-based start index and the end index:  
    * `"12345".FromTill(2, 3)` = `"34"`  
    * (Throws an exception if the indexes are out of range.)
- `CutLeft` / `CutRight`
	* Trim off at most one occurrence of a value from the given string:  
	* `"BlaLala".CutLeft("Bla")` = `"Lala"`  
    * `"12345".CutRight(2)` = `"123"`  
- `CutLeftUntil` / `CutRightUntil`
    * Cuts off part of a string until the specified delimiter and returns what remains including the delimiter itself:  
	* `"Path/to/file.txt".CutRightUntil("/")` = `"Path/to/"`  
	* `"Hello world!".CutLeftUntil("world")` = `"world!"`
- `RemoveExcessiveWhiteSpace`
	* Trims and replaces sequences of two or more white space characters by a single space:  
	* `"    This  is  a   test. ".RemoveExcessiveWhiteSpace()` = `"This is a test."`
- `Replace`
	* Variation on `String.Replace` with the ability to ignore case:  
	* `"abcDEF".Replace("def", "GHI", ignoreCase: true)` = `"abcGHI"`
- `StartWithCap`
	* Turns the first character into a capital letter:  
	* `"test".StartWithCap()` = `"Test"`
- `StartWithLowerCase`
	* Turns the first character into a lower-case letter.  
    * `"TEST".StartWithLowerCase()` = `"tEST"`
- `Split`
    * A variant one that takes `params` for split characters + overloads mostly missing before .NET 5:  
    * `"apple-banana|cherry".Split("-", "|")` =  
    `[ "apple", "banana", "cherry" ]`
- `SplitWithQuotation`
    * Allows you to parse CSV-like lines including quotation for the ability to include the separator character and quote characters in the values themselves:  
    * `"apple|~banana|split~|cherry".SplitWithQuotation("|", '~')` =  
    `[ "apple", "banana|split", "cherry" ]`


Collection Extensions
---------------------

- `TrimAll`
    * Trims all the strings in the collection.
- `Distinct`
    * Variation that takes a key selector that determines what makes an item unique, e.g.
    `myItems.Distinct(x => x.LastName);` For multi-part as keys, use:
    `myItems.Distinct(x => new { x.FirstName, x.LastName });`
- `Except` 
    * Variations with:
    * A single item, e.g. `myCollection.Except(myItem);`
    * The choice to keep duplicates. (The original `Except` method from .NET automatically does a distinct, which is something you do not always want.)
- `Union`
    * Variations with:
    * A single item, e.g. `myCollection.Union(myItem);`
    * Starts with a single item and then adds a collection to it e.g. `myItem.Union(myCollection);`
- `ForEach`
    * Not all collection types have the `ForEach` method. Here you have an overload for `IEnumerable`<`T`> so you can use it for more collection types.
- `Add`
    * Add multiple items to a collection by means of a comma separated argument list, e.g.
    `myCollection.Add(1, 5, 12);`
- `AddRange`
    * `AddRange` is a member of `List`<`T`>. Here is a variation for `IList`<`T`> to support more collection types.
- `AsEnumerable`
    * Converts a single item to a enumerable. Example: `IEnumerable<int> myInts = 3.AsEnumerable();`


Recursive Collection Extensions
-------------------------------

`LINQ` methods already allow you to process a whole __collection__ of items in one blow. Process a whole __tree__ of items in one blow? For many cases these *Recursive Collection Extensions* offer a one-line solution.

This line of code:

    var allItems = myRootItems.UnionRecursive(x => x.Children);

Gives you a list of all the nodes in a tree structure like the following:

    var root = new Item
    {
        Children = new[]
        {
            new Item()
            new Item
            {
                Children = new[]
                {
                    new Item()
                }
            },
            new Item
            {
                Children = new[]
                {
                    new Item(),
                    new Item(),
                }
            },
        }
    };

There is also a `SelectRecursive` method:

    var allItemsExceptRoots = myRootItems.SelectRecursive(x => x.Children);

The difference with `UnionRecursive` is that `SelectRecursive` does not include the roots in the result collection.


KeyValuePairHelper
------------------

Converts a single array to `KeyValuePair` or `Dictionary`, where the 1st item is a name, the 2nd a value, the 3rd a name, the 4th a value, etc. This can be useful to be able to specify name/value pairs as `params` (variable amount of arguments). For instance:

    void MyMethod(params object[] namesAndValues)
    {
        var dictionary = KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(namesAndValues);
        ...
    }

Calling MyMethod  looks like this:

    MyMethod("Name1", 3, "Name2", 5, "Name3", 6);


Exception Types
---------------

Offers a minimal amount of 2 exception types with subtle differences:

- `InvalidValueException`
    - With mesages like:
      `Invalid CustomerType value: 'Undefined'.`
- `ValueNotSupportedException`
    - With messages like:
      `CustomerType value 'Subscriber' is not supported.`


Misc Helpers
------------

- `ConfigurationHelper`
    - Legacy helper for using configuration settings on platforms where `System.Configuration` is not available.
- `CultureHelper`
    - To set thread culture with a single code line.
- `EmbeddedResourceHelper`
    - Make it a little easier to get embedded resource `Streams`, `bytes` and `strings`.
- `KeyHelper`
    - Utility to produce keys for use in `Dictionaries` by concatinating values with a `GUID` separator in between.
