
```cs
Assert.IsTrue(list.Any(x => x.Key == "Name1" && x.Value.Equals(3)));
Assert.IsTrue(list.Any(x => x.Key == "Name2" && x.Value.Equals(5)));
Assert.IsTrue(list.Any(x => x.Key == "Name3" && x.Value.Equals(6)));
```

```cs
// Redundant. Should use char variant.
[TestMethod]
public void CutLeft_NoMatch_Test() 
    => AreEqual("Lalalaa", () => "Lalalaa".CutLeft("laa"));
```

```cs
Assert.AreEqual(expected.Length, actual.Length);
for (int i = 0; i < expected.Length; i++)
{
    Assert.AreEqual(expected[i], actual[i]);
}
```


```cs
        IsNotNull(() => split1);
        IsNotNull(() => split2);
        AreEqual(1, () => split1.Length);
        AreEqual(1, () => split2.Length);
        IsNotNull(() => split1[0]);
        IsNotNull(() => split2[0]);
        AreEqual("a, b, c", () => split1[0]);
        AreEqual("a, b, c", () => split2[0]);
    
    [TestMethod]
    public void Split_StringSepAndOptions_EmptySepException()
    {
    }
```

```cs
    if (string.IsNullOrEmpty(input)) return input; // Is lenient about indices.
    
    if (startIndex < 0) throw new Exception("startIndex is less than 0.");
    if (endIndex   < 0) throw new Exception("endIndex is less than 0.");
    if (startIndex >= input.Length) throw new Exception("startIndex lies after the input string.");
    if (endIndex   >= input.Length) throw new Exception("endIndex lies after the input string.");
```

```
    `"Lalalaa".CutRight('a')` = `"Lalala"`  
```

```cs
    AreEqual("abcGHI", "abcDEF".Replace("def", "GHI", ignoreCase: true));
```


```xml
  <ItemGroup Condition="$(MSBuildProjectName.StartsWith('JJ.'))
                   And '$(MSBuildProjectName)' != 'JJ.Framework.Build' 
                   And '$(MSBuildProjectName)' != 'JJ.Framework.Versioning.Core'">
    <ProjectReference Include="$(SolutionDir)\Framework\JJ.Framework.Build\JJ.Framework.Build.csproj" />
  </ItemGroup>
```

```cs
        
        /// <summary>
        /// JJ.Framework.Common
        /// ===================
        /// 
        /// A mixed bag of general-purpose utilities with minimal dependencies. Later versions of this library split functionality into focused packages like `JJ.Framework.Text`, `JJ.Framework.Collections`, and `JJ.Framework.Exceptions`. This "prequel" version contains a little bit of everything: a version released in aid of releasing older legacy apps, still holding value.
        /// 
        /// __Contents__
        /// 
        /// - [String Extensions](#string-extensions)
        /// - [Collection Extensions](#collection-extensions)
        /// - [Recursive Collection Extensions](#recursive-collection-extensions)
        /// - [KeyValuePairHelper](#keyvaluepairhelper)
        /// - [Exception Types](#exception-types)
        /// - [Misc Helpers](#misc-helpers)
        /// 
        /// 
        /// String Extensions
        /// -----------------
        /// 
        /// - `Left` / `Right`  
        /// 
        /// 	* Return the left or right part of a string:  
        /// 	* `"12345".Left(2)` = `"12"`  
        /// 	* `"12345".Right(2)` = `"45"`  
        ///     * (Throws exception if string shorter than requested length.)
        /// 
        /// -----
        /// 
        /// - `FromTill`
        /// 
        /// 	* Take the middle of a string by start/end index (zero‑based, inclusive)  
        ///     * `"12345".FromTill(2, 3)` = `"34"`  
        ///     * (Throws exception if indexes out of range.)
        /// 
        /// -----
        /// 
        /// - `CutLeft` / `CutRight`
        /// 
        /// 	* Trim at most one occurrence of a value from the given string:  
        /// 	* `"BlaLala".CutLeft("Bla")` = `"Lala"`  
        ///     * `"12345".CutRight(2)` = `"123"`
        /// 
        /// -----
        /// 
        /// - `CutLeftUntil` / `CutRightUntil`
        /// 
        ///     * Remove text until the delimiter, keeping the delimiter:  
        /// 	* `"Path/to/file.txt".CutRightUntil("/")` = `"Path/to/"`  
        /// 	* `"Hello world!".CutLeftUntil("world")` = `"world!"`
        /// 
        /// -----
        /// 
        /// - `StartWithCap` / `StartWithLowerCase`
        /// 
        /// 	* Change just the first character's case:   
        /// 	* `"test".StartWithCap()` = `"Test"`
        ///     * `"TEST".StartWithLowerCase()` = `"tEST"`
        /// 
        /// -----
        /// 
        /// - `Split`
        /// 
        ///     * Adds overloads missing until .NET 5 and a `params` variant for delimiters:  
        ///     * `"apple-banana|cherry".Split("-", "|")` = `[ "apple", "banana", "cherry" ]`
        /// 
        /// -----
        /// 
        /// - `SplitWithQuotation`
        /// 
        ///     * Parse CSV-like lines honoring quotes to allow use of separator and quote characters within the values themselves:  
        ///     * `"apple|~banana|split~|cherry".SplitWithQuotation("|", '~')` = `[ "apple", "banana|split", "cherry" ]`
        /// 
        /// -----
        /// 
        /// - `RemoveExcessiveWhiteSpace`
        /// 
        /// 	* Trim and replace sequences of two or more white space characters by a single space:  
        /// 	* `"    This  is  a   test. ".RemoveExcessiveWhiteSpace()` = `"This is a test."`
        /// 
        /// -----
        /// 
        /// - `Replace`
        /// 
        /// 	* `String.Replace` variant with optional case-insensitive match:  
        /// 	* `"HelloWORLD".Replace("world", "Universe",` __`ignoreCase: true`__ `)` = `"HelloUniverse"`
        /// 
        /// 
        /// Collection Extensions
        /// ---------------------
        /// 
        /// - `Distinct`
        /// 
        ///     * Variation that takes a key selector that determines what makes an item unique, e.g.
        ///     * `myItems.Distinct(x =&gt; x.LastName);`
        ///     * For multi-part as keys, use:
        ///     * `myItems.Distinct(x =&gt; new { x.FirstName, x.LastName });`
        /// 
        /// -----
        /// 
        /// - `Except` 
        /// 
        ///     * Variations with:
        ///     * A single item, e.g. `myCollection.Except(myItem);`
        ///     * The choice to keep duplicates. (The original `Except` method from .NET automatically does a distinct, which is something you do not always want.)
        /// 
        /// -----
        /// 
        /// - `Union`
        /// 
        ///     * Variations with:
        ///     * A single item, e.g. `myCollection.Union(myItem);`
        ///     * Starts with a single item and then adds a collection to it e.g. `myItem.Union(myCollection);`
        /// 
        /// -----
        /// 
        /// - `Add`
        /// 
        ///     * Add multiple items to a collection by means of a comma separated argument list, e.g.
        ///     `myCollection.Add(1, 5, 12);`
        /// 
        /// -----
        /// 
        /// - `AddRange`
        /// 
        ///     * `AddRange` is a member of `List`&lt;`T`&gt;. Here is a variation for `IList`&lt;`T`&gt; to support more collection types.
        /// 
        /// -----
        /// 
        /// - `ForEach`
        /// 
        ///     * Not all collection types have the `ForEach` method. Here you have an overload for `IEnumerable`&lt;`T`&gt; so you can use it for more collection types.
        /// 
        /// -----
        /// 
        /// - `AsEnumerable`
        ///     * Converts a single item to a enumerable, so you can for instance use it with `LINQ`:
        ///     * `IEnumerable&lt;int&gt; myInts = 3.AsEnumerable();`
        /// 
        /// -----
        /// 
        /// - `TrimAll`
        /// 
        ///     * Trims all the strings in the collection:
        ///     * `string[] trimmedTexts = myTexts.TrimAll()`
        /// 
        /// 
        /// Recursive Collection Extensions
        /// -------------------------------
        /// 
        /// `LINQ` methods already allow you to process a whole __collection__ of items in one blow. Process a whole __tree__ of items in one blow? For many cases these *Recursive Collection Extensions* offer a one-line solution.
        /// 
        /// This line of code:
        /// 
        /// ```cs
        /// var allItems = myRootItems.UnionRecursive(x =&gt; x.Children);
        /// ```
        /// 
        /// Gives you a list of all the nodes in a tree structure like the following:
        /// 
        /// ```cs
        /// var root = new Item
        /// {
        ///     Children = new[]
        ///     {
        ///         new Item()
        ///         new Item
        ///         {
        ///             Children = new[]
        ///             {
        ///                 new Item()
        ///             }
        ///         },
        ///         new Item
        ///         {
        ///             Children = new[]
        ///             {
        ///                 new Item(),
        ///                 new Item(),
        ///             }
        ///         },
        ///     }
        /// };
        /// ```
        /// 
        /// There is also a `SelectRecursive` method:
        /// 
        /// ```cs
        /// var allItemsExceptRoots = myRootItems.SelectRecursive(x =&gt; x.Children);
        /// ```
        /// 
        /// The difference with `UnionRecursive` is that `SelectRecursive` does not include the roots in the result collection.
        /// 
        /// 
        /// KeyValuePairHelper
        /// ------------------
        /// 
        /// Converts a single array to `KeyValuePair` or `Dictionary`, where the 1st item is a name, the 2nd a value, the 3rd a name, the 4th a value, etc. This can be useful to be able to specify name/value pairs as `params` (variable amount of arguments). For instance:
        /// 
        /// ```cs
        /// void MyMethod(params object[] namesAndValues)
        /// {
        ///     var dictionary = KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(namesAndValues);
        ///     ...
        /// }
        /// ```
        /// 
        /// Calling `MyMethod` looks like this:
        /// 
        /// ```cs
        /// MyMethod("Name1", 3, "Name2", 5, "Name3", 6);
        /// ```
        /// 
        /// Exception Types
        /// ---------------
        /// 
        /// 2 exception types with subtle differences:
        /// 
        /// - `InvalidValueException`
        /// 
        ///     - With messages like:  
        ///       `Invalid CustomerType value: 'Undefined'.`  
        ///       when you throw:  
        ///       `throw new InvalidValueException(CustomerType.Undefined)`
        /// 
        /// -----
        /// 
        /// - `ValueNotSupportedException`
        /// 
        ///     - With messages like:  
        ///       `CustomerType value: 'Subscriber' is not supported.`  
        ///       when you throw:  
        ///       `throw new ValueNotSupportedException(CustomerType.Subscriber)`
        /// 
        /// 
        /// Misc Helpers
        /// ------------
        /// 
        /// - `EmbeddedResourceHelper`
        /// 
        ///     - Make it a little easier to get embedded resource `Streams`, `bytes` and `strings`.
        /// 
        /// -----
        /// 
        /// - `CultureHelper`
        /// 
        ///     - To set thread culture with a single code line.
        /// 
        /// -----
        /// 
        /// - `ConfigurationHelper`
        /// 
        ///     - Legacy helper for using configuration settings on platforms where `System.Configuration` was not available.
        /// 
        /// -----
        /// 
        /// - `KeyHelper`
        /// 
        ///     - Utility to produce keys for use in `Dictionaries` by concatinating values with a `GUID` separator in between.
        /// 
        /// 💬 Feedback
        /// ============
        /// 
        /// Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)
        /// </summary>
        public struct _readme { }
        
        
        /// <summary>
        /// <strong>JJ.Framework.Common</strong>
        /// <p>A mixed bag of general-purpose utilities with minimal dependencies. Later versions of this library split functionality into focused packages like <c>JJ.Framework.Text</c>, <c>JJ.Framework.Collections</c>, and <c>JJ.Framework.Exceptions</c>. This &quot;prequel&quot; version contains a little bit of everything: a version released in aid of releasing older legacy apps, still holding value.</p>
        /// <p><strong>Contents</strong></p>
        /// <list type="bullet">
        /// <item>String Extensions</item>
        /// <item>Collection Extensions</item>
        /// <item>Recursive Collection Extensions</item>
        /// <item>KeyValuePairHelper</item>
        /// <item>Exception Types</item>
        /// <item>Misc Helpers</item>
        /// </list>
        /// <strong>String Extensions</strong>
        /// <list type="bullet">
        /// <item><p><c>Left</c> / <c>Right</c></p>
        /// <list type="bullet">
        /// <item>Return the left or right part of a string:</item>
        /// <item><c>&quot;12345&quot;.Left(2)</c> = <c>&quot;12&quot;</c></item>
        /// <item><c>&quot;12345&quot;.Right(2)</c> = <c>&quot;45&quot;</c></item>
        /// <item>(Throws exception if string shorter than requested length.)</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>FromTill</c></p>
        /// <list type="bullet">
        /// <item>Take the middle of a string by start/end index (zero‑based, inclusive)</item>
        /// <item><c>&quot;12345&quot;.FromTill(2, 3)</c> = <c>&quot;34&quot;</c></item>
        /// <item>(Throws exception if indexes out of range.)</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>CutLeft</c> / <c>CutRight</c></p>
        /// <list type="bullet">
        /// <item>Trim at most one occurrence of a value from the given string:</item>
        /// <item><c>&quot;BlaLala&quot;.CutLeft(&quot;Bla&quot;)</c> = <c>&quot;Lala&quot;</c></item>
        /// <item><c>&quot;12345&quot;.CutRight(2)</c> = <c>&quot;123&quot;</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>CutLeftUntil</c> / <c>CutRightUntil</c></p>
        /// <list type="bullet">
        /// <item>Remove text until the delimiter, keeping the delimiter:</item>
        /// <item><c>&quot;Path/to/file.txt&quot;.CutRightUntil(&quot;/&quot;)</c> = <c>&quot;Path/to/&quot;</c></item>
        /// <item><c>&quot;Hello world!&quot;.CutLeftUntil(&quot;world&quot;)</c> = <c>&quot;world!&quot;</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>StartWithCap</c> / <c>StartWithLowerCase</c></p>
        /// <list type="bullet">
        /// <item>Change just the first character's case:</item>
        /// <item><c>&quot;test&quot;.StartWithCap()</c> = <c>&quot;Test&quot;</c></item>
        /// <item><c>&quot;TEST&quot;.StartWithLowerCase()</c> = <c>&quot;tEST&quot;</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>Split</c></p>
        /// <list type="bullet">
        /// <item>Adds overloads missing until .NET 5 and a <c>params</c> variant for delimiters:</item>
        /// <item><c>&quot;apple-banana|cherry&quot;.Split(&quot;-&quot;, &quot;|&quot;)</c> = <c>[ &quot;apple&quot;, &quot;banana&quot;, &quot;cherry&quot; ]</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>SplitWithQuotation</c></p>
        /// <list type="bullet">
        /// <item>Parse CSV-like lines honoring quotes to allow use of separator and quote characters within the values themselves:</item>
        /// <item><c>&quot;apple|~banana|split~|cherry&quot;.SplitWithQuotation(&quot;|&quot;, '~')</c> = <c>[ &quot;apple&quot;, &quot;banana|split&quot;, &quot;cherry&quot; ]</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>RemoveExcessiveWhiteSpace</c></p>
        /// <list type="bullet">
        /// <item>Trim and replace sequences of two or more white space characters by a single space:</item>
        /// <item><c>&quot;    This  is  a   test. &quot;.RemoveExcessiveWhiteSpace()</c> = <c>&quot;This is a test.&quot;</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>Replace</c></p>
        /// <list type="bullet">
        /// <item><c>String.Replace</c> variant with optional case-insensitive match:</item>
        /// <item><c>&quot;HelloWORLD&quot;.Replace(&quot;world&quot;, &quot;Universe&quot;,</c> <strong><c>ignoreCase: true</c></strong> <c>)</c> = <c>&quot;HelloUniverse&quot;</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <strong>Collection Extensions</strong>
        /// <list type="bullet">
        /// <item><p><c>Distinct</c></p>
        /// <list type="bullet">
        /// <item>Variation that takes a key selector that determines what makes an item unique, e.g.</item>
        /// <item><c>myItems.Distinct(x =&gt; x.LastName);</c></item>
        /// <item>For multi-part as keys, use:</item>
        /// <item><c>myItems.Distinct(x =&gt; new { x.FirstName, x.LastName });</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>Except</c></p>
        /// <list type="bullet">
        /// <item>Variations with:</item>
        /// <item>A single item, e.g. <c>myCollection.Except(myItem);</c></item>
        /// <item>The choice to keep duplicates. (The original <c>Except</c> method from .NET automatically does a distinct, which is something you do not always want.)</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>Union</c></p>
        /// <list type="bullet">
        /// <item>Variations with:</item>
        /// <item>A single item, e.g. <c>myCollection.Union(myItem);</c></item>
        /// <item>Starts with a single item and then adds a collection to it e.g. <c>myItem.Union(myCollection);</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>Add</c></p>
        /// <list type="bullet">
        /// <item>Add multiple items to a collection by means of a comma separated argument list, e.g.
        /// <c>myCollection.Add(1, 5, 12);</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>AddRange</c></p>
        /// <list type="bullet">
        /// <item><c>AddRange</c> is a member of <c>List</c>&lt;<c>T</c>&gt;. Here is a variation for <c>IList</c>&lt;<c>T</c>&gt; to support more collection types.</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>ForEach</c></p>
        /// <list type="bullet">
        /// <item>Not all collection types have the <c>ForEach</c> method. Here you have an overload for <c>IEnumerable</c>&lt;<c>T</c>&gt; so you can use it for more collection types.</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><c>AsEnumerable</c>
        /// <list type="bullet">
        /// <item>Converts a single item to a enumerable, so you can for instance use it with <c>LINQ</c>:</item>
        /// <item><c>IEnumerable&lt;int&gt; myInts = 3.AsEnumerable();</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>TrimAll</c></p>
        /// <list type="bullet">
        /// <item>Trims all the strings in the collection:</item>
        /// <item><c>string[] trimmedTexts = myTexts.TrimAll()</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <strong>Recursive Collection Extensions</strong>
        /// <p><c>LINQ</c> methods already allow you to process a whole <strong>collection</strong> of items in one blow. Process a whole <strong>tree</strong> of items in one blow? For many cases these <em>Recursive Collection Extensions</em> offer a one-line solution.</p>
        /// <p>This line of code:</p>
        /// <code>var allItems = myRootItems.UnionRecursive(x =&gt; x.Children);
        /// </code>
        /// <p>Gives you a list of all the nodes in a tree structure like the following:</p>
        /// <code>var root = new Item
        /// {
        ///     Children = new[]
        ///     {
        ///         new Item()
        ///         new Item
        ///         {
        ///             Children = new[]
        ///             {
        ///                 new Item()
        ///             }
        ///         },
        ///         new Item
        ///         {
        ///             Children = new[]
        ///             {
        ///                 new Item(),
        ///                 new Item(),
        ///             }
        ///         },
        ///     }
        /// };
        /// </code>
        /// <p>There is also a <c>SelectRecursive</c> method:</p>
        /// <code>var allItemsExceptRoots = myRootItems.SelectRecursive(x =&gt; x.Children);
        /// </code>
        /// <p>The difference with <c>UnionRecursive</c> is that <c>SelectRecursive</c> does not include the roots in the result collection.</p>
        /// <strong>KeyValuePairHelper</strong>
        /// <p>Converts a single array to <c>KeyValuePair</c> or <c>Dictionary</c>, where the 1st item is a name, the 2nd a value, the 3rd a name, the 4th a value, etc. This can be useful to be able to specify name/value pairs as <c>params</c> (variable amount of arguments). For instance:</p>
        /// <code>void MyMethod(params object[] namesAndValues)
        /// {
        ///     var dictionary = KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(namesAndValues);
        ///     ...
        /// }
        /// </code>
        /// <p>Calling <c>MyMethod</c> looks like this:</p>
        /// <code>MyMethod(&quot;Name1&quot;, 3, &quot;Name2&quot;, 5, &quot;Name3&quot;, 6);
        /// </code>
        /// <strong>Exception Types</strong>
        /// <p>2 exception types with subtle differences:</p>
        /// <list type="bullet">
        /// <item><p><c>InvalidValueException</c></p>
        /// <list type="bullet">
        /// <item>With messages like:<br/>
        /// <c>Invalid CustomerType value: 'Undefined'.</c><br/>
        /// when you throw:<br/>
        /// <c>throw new InvalidValueException(CustomerType.Undefined)</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>ValueNotSupportedException</c></p>
        /// <list type="bullet">
        /// <item>With messages like:<br/>
        /// <c>CustomerType value: 'Subscriber' is not supported.</c><br/>
        /// when you throw:<br/>
        /// <c>throw new ValueNotSupportedException(CustomerType.Subscriber)</c></item>
        /// </list>
        /// </item>
        /// </list>
        /// <strong>Misc Helpers</strong>
        /// <list type="bullet">
        /// <item><p><c>EmbeddedResourceHelper</c></p>
        /// <list type="bullet">
        /// <item>Make it a little easier to get embedded resource <c>Streams</c>, <c>bytes</c> and <c>strings</c>.</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>CultureHelper</c></p>
        /// <list type="bullet">
        /// <item>To set thread culture with a single code line.</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>ConfigurationHelper</c></p>
        /// <list type="bullet">
        /// <item>Legacy helper for using configuration settings on platforms where <c>System.Configuration</c> was not available.</item>
        /// </list>
        /// </item>
        /// </list>
        /// <br/>
        /// <list type="bullet">
        /// <item><p><c>KeyHelper</c></p>
        /// <list type="bullet">
        /// <item>Utility to produce keys for use in <c>Dictionaries</c> by concatenating values with a <c>GUID</c> separator in between.</item>
        /// </list>
        /// </item>
        /// </list>
        /// </summary>
        public struct _readme2 { }

        
        /// <summary>
        /// <strong>Demo list</strong>
        /// <list type="bullet">
        ///   <item>Item1</item>
        ///   <item>Item2</item>
        /// </list>
        /// </summary>
        public struct _testdoccomment {}

```

```
        
        /// <summary>
        /// <b>String Extensions</b>
        /// </summary>
        public struct _stringextensions { }

        /// <summary>
        /// <b>Collection Extensions</b>
        /// </summary>
        public struct _collectionextensions { }

        /// <b>Add</b><br/>

        /// <b>AddRange</b><br/>

        /// <b>TrimAll</b>
        
        /// <summary>
        /// <b>Exception Types</b>
        /// <para>2 exception types with subtle differences.</para>
        /// </summary>
        public struct _exceptiontypes { }
        
        /// <summary>
        /// <b>Misc Helpers</b>
        /// </summary>
        public struct _mischelpers { }

```

```cs
public override int GetHashCode() => HashCode.Combine(Coalesced, Nully);
```