// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
#pragma warning disable IDE1006

namespace JJ.Framework.Common
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive when used in inheritdoc tags.

        /// <summary>
        /// <para> <b>JJ.Framework.Common</b> <br/>
        /// A mixed bag of general-purpose utilities with minimal dependencies.
        /// Later versions of this library split functionality into focused packages like
        /// <c>JJ.Framework.Text</c>, <c>JJ.Framework.Collections</c>, and <c>JJ.Framework.Exceptions</c>.
        /// This &quot;prequel&quot; version contains a little bit of everything:
        /// a version released in aid of releasing older legacy apps, still holding value.  </para>
        /// 
        /// <para> <b>Contains:</b> <br/>
        /// - String Extensions <br/>
        /// - Collection Extensions <br/>
        /// - Recursive Collection Extensions <br/>
        /// - KeyValuePairHelper <br/>
        /// - Exception Types <br/>
        /// - Misc Helpers <br/> </para>
        /// </summary>
        public struct _jjframeworkcommon { }
        
        /// <summary>
        /// <b>String Extensions</b>
        /// </summary>
        public struct _stringextensions { }

        /// <summary>
        /// <b>Left / Right</b>
        /// <para>Return the left or right part of a string.</para>
        /// <code>
        /// &quot;12345&quot;.Left(2) = &quot;12&quot;
        /// &quot;12345&quot;.Right(2) = &quot;45&quot;
        /// </code>
        /// <para>(throws if string shorter than requested length)</para>
        /// </summary>
        public struct _leftright { }

        /// <summary>
        /// <b>FromTill</b>
        /// <para>Take the middle of a string by start/end index (zero‑based, inclusive)</para>
        /// <code>&quot;12345&quot;.FromTill(2, 3) = &quot;34&quot;</code>
        /// <para>(throws if indexes out of range)</para>
        /// </summary>
        public struct _fromtill { }

        /// <summary>
        /// <b>CutLeft/CutRight</b>
        /// <para> Trim at most one occurrence of a value from the given string: </para>
        /// <code>
        /// &quot;BlaLala&quot;.CutLeft(&quot;Bla&quot;) = &quot;Lala&quot;
        /// &quot;12345&quot;.CutRight(2) = &quot;123&quot;
        /// </code>
        /// </summary>
        public struct _cutleftorright { }
        
        /// <summary>
        /// <b>CutLeftUntil / CutRightUntil</b>
        /// <para>Remove text until the delimiter, keeping the delimiter:</para>
        /// <code>
        /// &quot;Path/to/file.txt&quot;.CutRightUntil(&quot;/&quot;) = &quot;Path/to/&quot;
        /// &quot;Hello world!&quot;.CutLeftUntil(&quot;world&quot;) = &quot;world!&quot;
        /// </code>
        /// </summary>
        public struct _cutleftorrightuntil { }

        /// <summary>
        /// <b>StartWithCap / StartWithLowerCase</b>
        /// <para>Change just the first character's case:</para>
        /// <code>
        /// &quot;test&quot;.StartWithCap() = &quot;Test&quot;
        /// &quot;TEST&quot;.StartWithLowerCase() = &quot;tEST&quot;
        /// </code>
        /// </summary>
        public struct _startwithcaporlowercase { }
        
        /// <summary>
        /// <b>Split</b>
        /// <para>Adds overloads missing until .NET 5 and a <c>params</c> variant for delimiters:</para>
        /// <code>
        /// &quot;apple-banana|cherry&quot;.Split(&quot;-&quot;, &quot;|&quot;) = [ &quot;apple&quot;, &quot;banana&quot;, &quot;cherry&quot; ]
        /// </code>
        /// </summary>
        public struct _split { }
            
        /// <summary>
        /// On top of the usual Split, this version allows you to use the separator character
        /// inside values if you surround the value by quotes.
        /// To embed quotes again, you repeat the quote character 2x.
        /// Multi-line values are not supported.
        /// </summary>
        /// <param name="input">The full string to be split into substrings.</param>
        /// <param name="separator">The substring delimiter used to divide the input.</param>
        /// <param name="options">Controls whether empty entries are included in the result.</param>
        /// <param name="quote">
        /// Quote character. If set, text enclosed in quotes will be treated as a single value,
        /// even if it contains the separator. To embed quotes in the value again, repeat the quote character twice.
        /// </param>
        public struct _splitwithquotationbase { }

        /// <remarks>
        /// <b>SplitWithQuotation</b>
        /// <para>Parse CSV-like lines honoring quotes to allow use of separator and quote characters within the values themselves:</para>
        /// <code>
        /// &quot;apple|~banana|split~|cherry&quot;.SplitWithQuotation(&quot;|&quot;, '~') =
        /// [ &quot;apple&quot;, &quot;banana|split&quot;, &quot;cherry&quot; ]
        /// </code>
        /// </remarks>
        /// <inheritdoc cref="_splitwithquotationbase" />
        public struct _splitwithquotation { }
        

        /// <summary>
        /// <b>RemoveExcessiveWhiteSpace</b>
        /// <para>Trim and replace sequences of two or more white space characters by a single space:</para>
        /// <code>
        /// &quot;    This  is  a   test. &quot;.RemoveExcessiveWhiteSpace() = &quot;This is a test.&quot;
        /// </code>
        /// </summary>
        public struct _removeexcessivewhitespace { }
        
        /// <summary>
        /// <b>Replace</b>
        /// <para><c>String.Replace</c> variant with optional case-insensitive match:</para>
        /// <code>
        /// &quot;HelloWORLD&quot;.Replace(&quot;world&quot;, &quot;Universe&quot;, <b>ignoreCase: true</b>) = &quot;HelloUniverse&quot;
        /// </code>
        /// </summary>
        public struct _replace { }
        
        /// <summary>
        /// <b>Collection Extensions</b>
        /// </summary>
        public struct _collectionextensions { }
        
        /// <summary>
        /// <b>Distinct</b>
        /// <para>Variation that takes a key selector that determines what makes an item unique, e.g.</para>
        /// <code>myItems.Distinct(x =&gt; x.LastName);</code>
        /// <para>For multi-part as keys, use:</para>
        /// <code>myItems.Distinct(x =&gt; new { x.FirstName, x.LastName });</code>
        /// </summary>
        public struct _distinct { }
        
        /// <summary>
        /// <b>Except</b>
        /// <para>Variations with:</para>
        /// - A single item, e.g. <c>myCollection.Except(myItem);</c><br/>
        /// - The choice to keep duplicates.
        /// <para>(The original <c>Except</c> method from .NET automatically does a distinct, which is something you do not always want.)</para>
        /// </summary>
        public struct _except { }
        
        /// <summary>
        /// <b>Union</b>
        /// <para>Variations with:</para>
        /// - A single item, e.g. <c>myCollection.Union(myItem);</c><br/>
        /// - Starts with a single item and then adds a collection to it e.g. <c>myItem.Union(myCollection);</c><br/>
        /// </summary>
        public struct _union { }
        
        /// <summary>
        /// <b>Add</b>
        /// <para>Add multiple items to a collection by means of a comma separated argument list:</para>
        /// <code>myCollection.Add(1, 5, 12);</code>
        /// </summary>
        public struct _add { }
        
        /// <summary>
        /// <b>AddRange</b>
        /// <para><c>AddRange</c> is a member of <c>List</c>&lt;<c>T</c>&gt;. Here is a variation for <c>IList</c>&lt;<c>T</c>&gt; to support more collection types.</para>
        /// </summary>
        public struct _addrange { }
        
        /// <summary>
        /// <b>ForEach</b>
        /// <para>Not all collection types have the <c>ForEach</c> method. Here you have an overload for <c>IEnumerable</c>&lt;<c>T</c>&gt; so you can use it for more collection types.</para>
        /// </summary>
        public struct _foreach { }
        
        /// <summary>
        /// <b>AsEnumerable</b>
        /// <para>Convert a single item to a enumerable, so you can for instance use it with <c>LINQ</c>:</para>
        /// <code>IEnumerable&lt;int&gt; myInts = 3.AsEnumerable();</code>
        /// </summary>
        public struct _asenumerable { }
        
        /// <summary>
        /// <b>TrimAll</b>
        /// <para>Trims all the strings in the collection:</para>
        /// <code>string[] trimmedTexts = myTexts.TrimAll()</code>
        /// </summary>
        public struct _trimall { }
        
        /// <summary>
        /// <para><b>Recursive Collection Extensions</b></para>
        /// <para>
        /// <c>LINQ</c> methods already allow you to process a whole <b>collection</b> of items in one blow. Process a whole <b>tree</b> of items in one blow? For many cases these <b>Recursive Collection Extensions</b> offer a one-line solution.</para>
        /// </summary>
        public struct _recursivecollectionextensions { }
        
        /// <summary>
        /// <para>This line of code:</para>
        /// <code>var allItems = myRootItems.UnionRecursive(x =&gt; x.Children);</code>
        /// <para>Gives you a list of all the nodes in a tree structure like the following:</para>
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
        /// </summary>
        public struct _unionrecursive { }
        
        /// <summary>
        /// <para>There is also a <c>SelectRecursive</c> method:</para>
        /// <code>var allItemsExceptRoots = myRootItems.SelectRecursive(x =&gt; x.Children);</code>
        /// <para>The difference with <c>UnionRecursive</c> is that <c>SelectRecursive</c> does not include the roots in the result collection.</para>
        /// </summary>
        public struct _selectrecursive { }
        
        /// <summary>
        /// <b>KeyValuePairHelper</b>
        /// <para>Converts a single array to <c>KeyValuePair</c> or <c>Dictionary</c>, where the 1st item is a name, the 2nd a value, the 3rd a name, the 4th a value, etc. This can be useful to be able to specify name/value pairs as <c>params</c> (variable amount of arguments). For instance:</para>
        /// <code>void MyMethod(params object[] namesAndValues)
        /// {
        ///     var dictionary = KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(namesAndValues);
        ///     ...
        /// }
        /// </code>
        /// <para>Calling <c>MyMethod</c> looks like this:</para>
        /// <code>MyMethod(&quot;Name1&quot;, 3, &quot;Name2&quot;, 5, &quot;Name3&quot;, 6);</code>
        /// </summary>
        public struct _keyvaluepairhelper { }
        
        /// <summary>
        /// <b>Exception Types</b>
        /// <para>2 exception types with subtle differences.</para>
        /// </summary>
        public struct _exceptiontypes { }
        
        /// <summary>
        /// <b>InvalidValueException</b>
        /// <para>With messages like:</para>
        /// <code>Invalid CustomerType value: 'Undefined'.</code>
        /// <para>when you throw:</para>
        /// <code>throw new InvalidValueException(CustomerType.Undefined)</code>
        /// </summary>
        public struct _invalidvalueexception { }
        
        /// <summary>
        /// <b>ValueNotSupportedException</b>
        /// <para>With messages like:</para>
        /// <code>CustomerType value: 'Subscriber' is not supported.</code>
        /// <para>when you throw:</para>
        /// <code>throw new ValueNotSupportedException(CustomerType.Subscriber)</code>
        /// </summary>
        public struct _valuenotsupportedexception { }
        
        /// <summary>
        /// <b>Misc Helpers</b>
        /// </summary>
        public struct _mischelpers { }
        
        /// <summary>
        /// <b>EmbeddedResourceHelper</b>
        /// <para>Makes it a little easier to get embedded resource <c>Streams</c>, <c>bytes</c> and <c>strings</c>.</para>
        /// </summary>
        public struct _embeddedresourcehelper { }
        
        /// <summary>
        /// <b>CultureHelper</b>
        /// <para>To set thread culture with a single code line.</para>
        /// </summary>
        public struct _culturehelper { }
        
        /// <summary>
        /// <b>ConfigurationHelper</b>
        /// <para>Legacy helper for using configuration settings on platforms where <c>System.Configuration</c> was not available.</para>
        /// </summary>
        public struct _configurationhelper { }
        
        /// <summary>
        /// <b>KeyHelper</b>
        /// <para>Utility to produce keys for use in <c>Dictionaries</c> by concatenating values with a <c>GUID</c> separator in between.</para>
        /// </summary>
        public struct _keyhelper { }
    }
}
