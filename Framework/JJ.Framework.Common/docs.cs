// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Common.Legacy.docs;

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
public struct _jjframeworkcommon;

/// <summary>
/// <b>String Extensions</b><br/>
/// Provides extension methods for working with strings, offering convenience utilities 
/// for formatting, trimming, and manipulating content such as casing and splitting.
/// </summary>
public struct _stringextensions;

/// <summary>
/// <b>Left / Right</b><br/>
/// Return the left or right part of a string.<br/>
/// (Throws if string shorter than requested length.)
/// <code>
/// &quot;12345&quot;.Left(2) = &quot;12&quot;
/// &quot;12345&quot;.Right(2) = &quot;45&quot;
/// </code>
/// </summary>
public struct _leftright;

/// <summary>
/// <b>FromTill</b><br/>
/// Take the middle of a string by start/end index (zero‑based, inclusive)<br/>
/// (Throws if indexes out of range.)
/// <code>&quot;12345&quot;.FromTill(2, 3) = &quot;34&quot;</code>
/// </summary>
public struct _fromtill;

/// <summary>
/// <b>CutLeft/CutRight</b><br/>
/// Trim at most one occurrence of a value from the given string:
/// <code>
/// &quot;BlaLala&quot;.CutLeft(&quot;Bla&quot;) = &quot;Lala&quot;
/// &quot;12345&quot;.CutRight(2) = &quot;123&quot;
/// </code>
/// </summary>
public struct _cutleftorright;

/// <summary>
/// <b>CutLeftUntil / CutRightUntil</b><br/>
/// Remove text until the delimiter, keeping the delimiter:
/// <code>
/// &quot;Path/to/file.txt&quot;.CutRightUntil(&quot;/&quot;) = &quot;Path/to/&quot;
/// &quot;Hello world!&quot;.CutLeftUntil(&quot;world&quot;) = &quot;world!&quot;
/// </code>
/// </summary>
public struct _cutleftorrightuntil;

/// <summary>
/// <b>StartWithCap / StartWithLowerCase</b><br/>
/// Changes the first character's case:
/// <code>
/// &quot;test&quot;.StartWithCap() = &quot;Test&quot;
/// &quot;TEST&quot;.StartWithLowerCase() = &quot;tEST&quot;
/// </code>
/// </summary>
public struct _startwithcaporlowercase;

/// <summary>
/// <b>Split</b><br/>
/// Overloads missing until .NET 5 plus a <c>params</c> variant for multiple delimiters:<br/>
/// <c>
/// &quot;apple-banana|cherry&quot;.Split(&quot;-&quot;, &quot;|&quot;) =><br/> [ &quot;apple&quot;, &quot;banana&quot;, &quot;cherry&quot; ]
/// </c>
/// </summary>
public struct _split;
    
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
public struct _splitwithquotationbase;

/// <remarks>
/// <b>SplitWithQuotation</b>
/// <para>Parse CSV-like lines honoring quotes to allow use of separator and quote characters within the values themselves:</para>
/// <code>
/// &quot;apple|~banana|split~|cherry&quot;.SplitWithQuotation(&quot;|&quot;, '~') =&gt;
/// [ &quot;apple&quot;, &quot;banana|split&quot;, &quot;cherry&quot; ]
/// </code>
/// </remarks>
/// <inheritdoc cref="_splitwithquotationbase" />
public struct _splitwithquotation;

/// <summary>
/// <b>RemoveExcessiveWhiteSpace</b><br/>
/// Trims and replaces sequences of two or more white space characters by a single space:<br/>
/// <c>
/// &quot;    This  is  a   test. &quot;.RemoveExcessiveWhiteSpace() = &quot;This is a test.&quot;
/// </c>
/// </summary>
public struct _removeexcessivewhitespace;

/// <summary>
/// <b>Replace</b> variant with optional case-insensitive match:<br/>
/// <c>
/// &quot;HelloWORLD&quot;.Replace(&quot;world&quot;, &quot;Universe&quot;, <b>ignoreCase: true</b>) = &quot;HelloUniverse&quot;
/// </c>
/// </summary>
public struct _replace;

/// <summary>
/// <b>Collection Extensions</b><br/>
/// Provide extension methods for working with collections, offering convenience utilities 
/// for common operations such as filtering, transformation, structural adjustments and tree traversal.
/// </summary>
public struct _collectionextensions;

/// <summary>
/// <b>Distinct</b>
/// <para>Variation that takes a key selector that determines what makes an item unique:</para>
/// <code>myItems.Distinct(x =&gt; x.LastName);</code>
/// <para>For multi-part as keys, use:</para>
/// <code>myItems.Distinct(x =&gt; new { x.FirstName, x.LastName });</code>
/// </summary>
public struct _distinct;

/// <summary>
/// <b>Except</b> variations with:<br/>
/// - A single item, e.g. <c>myCollection.Except(myItem);</c><br/>
/// - The choice to keep duplicates.<br/>
/// (<c>Except</c> from .NET automatically does a distinct, which is something you do not always want.)
/// </summary>
public struct _except;

/// <summary>
/// <b>Union</b> variations with:<br/>
/// - A single item, e.g. <c>myCollection.Union(myItem);</c><br/>
/// - Starts with a single item and then adds a collection to it e.g. <c>myItem.Union(myCollection);</c>
/// </summary>
public struct _union;

/// <summary>
/// <c>Add</c> multiple items to a collection by means of a comma separated argument list:<br/>
/// <c>myCollection.Add(1, 5, 12);</c>
/// </summary>
public struct _add;

/// <summary>
/// <c>AddRange</c> is a member of <c>List</c>&lt;<c>T</c>&gt;. Here is a variation for the interface type <c>IList</c>&lt;<c>T</c>&gt; to support more collection types.
/// </summary>
public struct _addrange;

/// <summary>
/// <b>ForEach</b><br/>
/// Not all collection types have the <c>ForEach</c> method. Here you have an overload for <c>IEnumerable</c>&lt;<c>T</c>&gt; so you can use it for more collection types.
/// </summary>
public struct _foreach;

/// <summary>
/// <b>AsEnumerable</b><br/>
/// Convert a single item to a enumerable, so you can for instance use it with <c>LINQ</c>:<br/>
/// <c>IEnumerable&lt;int&gt; myInts = 3.AsEnumerable();</c>
/// </summary>
public struct _asenumerable;

/// <summary>
/// Trims all the strings in the collection:<br/>
/// <c>string[] trimmedTexts = myTexts.TrimAll()</c>
/// </summary>
public struct _trimall;

/// <summary>
/// <b>Recursive Collection Extensions</b><br/>
/// <c>LINQ</c> methods already allow you to process a whole <b>collection</b> of items in one blow. Process a whole <b>tree</b> of items in one blow? For many cases these <b>Recursive Collection Extensions</b> offer a one-line solution.
/// </summary>
public struct _recursivecollectionextensions;

/// <summary>
/// <para><b>Recursive Collection Extensions</b></para>
/// <para>
/// <c>LINQ</c> methods already allow you to process a whole <b>collection</b> of items in one blow. Process a whole <b>tree</b> of items in one blow? For many cases these <b>Recursive Collection Extensions</b> offer a one-line solution.</para>
/// <para><b>UnionRecursive</b></para>
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
public struct _unionrecursive;

/// <summary>
/// <para><b>Recursive Collection Extensions</b></para>
/// <para><c>LINQ</c> methods already allow you to process a whole <b>collection</b> of items in one blow. Process a whole <b>tree</b> of items in one blow? For many cases these <b>Recursive Collection Extensions</b> offer a one-line solution.</para>
/// <para><b>SelectRecursive</b></para>
/// <para>The difference with <c>UnionRecursive</c> is that <c>SelectRecursive</c> does not include the roots in the result collection:</para>
/// <code>var allItemsExceptRoots = myRootItems.SelectRecursive(x =&gt; x.Children);</code>
/// </summary>
public struct _selectrecursive;

/// <summary>
/// <para><b>KeyValuePairHelper</b><br/>
/// Converts a single array to <c>KeyValuePair</c> or <c>Dictionary</c>, where the 1st item is a name, the 2nd a value, the 3rd a name, the 4th a value, etc. This can be useful to be able to specify name/value pairs as <c>params</c> (variable amount of arguments). For instance:</para>
/// <code>void MyMethod(params object[] namesAndValues)
/// {
///     var dictionary =
///       KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(namesAndValues);
/// }
/// </code>
/// <para>Calling <c>MyMethod</c> looks like this:</para>
/// <code>MyMethod(&quot;Name1&quot;, 3, &quot;Name2&quot;, 5, &quot;Name3&quot;, 6);</code>
/// </summary>
public struct _keyvaluepairhelper;

/// <summary>
/// <b>InvalidValueException</b> with messages like:<br/>
/// <c>Invalid CustomerType value: 'Undefined'.</c><br/>
/// when throwing:<br/>
/// <c>throw new InvalidValueException(CustomerType.Undefined)</c>
/// </summary>
public struct _invalidvalueexception;

/// <summary>
/// <b>ValueNotSupportedException</b> with messages like:<br/>
/// <c>CustomerType value: 'Subscriber' is not supported.</c><br/>
/// when throwing:<br/>
/// <c>throw new ValueNotSupportedException(CustomerType.Subscriber)</c>
/// </summary>
public struct _valuenotsupportedexception;

/// <summary>
/// <b>EmbeddedResourceHelper</b><br/>
/// Makes it a little easier to get embedded resource <c>Streams</c>, <c>bytes</c> and <c>strings</c>.
/// </summary>
public struct _embeddedresourcehelper;

/// <summary>
/// <b>CultureHelper</b><br/>
/// To set thread culture with a single code line.
/// </summary>
public struct _culturehelper;

/// <summary>
/// <b>ConfigurationHelper</b><br/>
/// Legacy helper for using configuration settings on platforms where <c>System.Configuration</c> was not available.
/// </summary>
public struct _configurationhelper;

/// <summary>
/// <b>KeyHelper</b><br/>
/// Utility to produce keys for use in <c>Dictionaries</c> by concatenating values with a <c>GUID</c> separator in between.
/// </summary>
public struct _keyhelper;
