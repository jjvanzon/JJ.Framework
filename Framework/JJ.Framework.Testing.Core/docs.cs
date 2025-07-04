// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InvalidXmlDocComment
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Testing.Core.docs;

/// <summary>
/// Can function as a single collection, but also as a collection of collections, <br/>
/// and a helper for using structured test Cases. <br/>
/// Provides integration with MSTest using DynamicData for parameterized data-driven testing. <br/><br/>
///
/// Helps define a store the test cases into memory,
/// retrieving them by key, conversion to DynamicData
/// and Case templating.
/// </summary>
public struct _casecollection { }

/// <summary>
/// Allow duplicates to pass by, for practical reasons when managing multiple CaseCollections as one.
/// </summary>
public struct _casecollectionallowduplicates { }
        
/// <summary>
/// Creates new cases based on the specified template, applying its properties to the provided cases.<br/>
/// NOTE: You can't replace a template value by a ZERO value! Try defining a separate case without a template,
/// or another template with the zero value in it.
/// </summary>
/// <param name="template">The template case to apply.</param>
/// <param name="cases">The cases to which the template is applied.</param>
/// <param name="destCases">The cases to which the template is applied.</param>
/// <returns>A collection of cases derived from the template.</returns>
public struct _casetemplate { }

/// <summary>
/// <strong>AssertHelperCore.AreEqual</strong> overloads that accept an optional
/// <see cref="DeltaDirectionEnum"> DeltaDirectionEnum </see> parameter. <br/><br/>
/// 
/// Specify the acceptable delta (tolerance) for comparisons, based on the direction: <br/><br/>
/// - <see cref="DeltaDirectionEnum.Down"> Down </see> or a <strong>negative</strong> delta:
///   Allows only downward tolerance. <br/>
/// - <see cref="DeltaDirectionEnum.Up"> Up </see>:
///   Allows only upward tolerance. <br/>
/// - <see cref="DeltaDirectionEnum.None"> None </see> / <see langword="default" />:
///   Allows tolerance in both directions. <br/><br/>
/// 
/// Designed for scenarios like double-to-int conversions, ensuring accurate comparisons
/// despite rounding (e.g., flooring).
/// </summary>
public struct _deltadirection { }

/// <summary>
/// <c>From</c>, <c>Init</c> and <c>Source</c> are synonyms.
/// </summary>
public struct _from { }

        
/// <summary>
/// Asserts not only that the value isn't null,
/// also that the return type is not nullable.
/// </summary>
/// <typeparam name="TRet">Do not specify explicitly! <c>ret</c> determines this type!</typeparam>
/// <param name="expected">The value ret is expected to have.</param>
/// <param name="ret">Expression whose return type should not be nullable.</param>
public struct _nonullret { }

/// <summary>
/// Asserts that even when a value is filled in,
/// the return type is still nullable.
/// </summary>
/// <typeparam name="TRet">Do not specify explicitly! <c>ret</c> determines this type!</typeparam>
/// <param name="expected">The value ret is expected to have.</param>
/// <param name="ret">Expression whose return type should be nullable.</param>
public struct _nullret { }

/// <summary>
/// Usage of the flag is up to the developer's discretion. <br/><br/>
/// 
/// Specifies whether strict validation is applied to ensure consistency between
/// mathematically related Props.<br/><br/>
/// 
/// - <c>true</c>: Validation ensures that specified values match values calculated from dependencies.
///   Inconsistencies can result in exceptions, such as: <br/>
///   "Attempt to initialize FrameCount to 11 is inconsistent with FrameCount 4803 
///    based on initial values for AudioLength (0.1), SamplingRate (default 48000), and CourtesyFrames (3)." <br/>
/// - <c>false</c>: Validation is relaxed, and mismatched values are allowed for scenarios 
///   where not all properties might be relevant to the test. <br/><br/>
/// 
/// Use this flag to test cases with or without strict mathematical relationships between properties.
/// </summary>
public struct _strict { }

/// <summary>
/// <c>To</c>, <c>Value</c>, <c>Val</c> and <c>Dest</c> are synonyms.
/// </summary>
public struct _to { }
