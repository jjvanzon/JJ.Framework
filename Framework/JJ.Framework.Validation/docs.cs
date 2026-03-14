// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace
#pragma warning disable IDE1006 // Naming rule violation

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Validation.Legacy.docs;

// Types

/// <summary>
/// Provides access to validation results: the collected messages, an overall pass/fail flag
/// and a helper to throw an aggregated exception when validation fails.
/// </summary>
public struct _ivalidator;

/// <remarks>
/// Base class for building validators. 
/// Override <c>Execute</c> to define validation rules.
/// Collects <see cref="ValidationMessage" /> entries and supports composing with sub-validators.
/// </remarks>
/// <inheritdoc cref="_postponeexecute" />
public struct _validatorbase;

/// <summary>
/// A validator with a fluent API.
/// Call <c>For</c> to select a property, then chain checks such as
/// <c>NotNull</c>, <c>Min</c>, <c>Max</c>, <c>In</c>, etc.
/// </summary>
/// <inheritdoc cref="_validatorbase" />
public struct _fluentvalidator;

/// <summary>
/// A single validation message consisting of a property key (for UI binding)
/// and a human-readable message.
/// </summary>
public struct _validationmessage;

/// <summary>
/// A collection of <see cref="ValidationMessage"/> objects produced by a validator.
/// </summary>
public struct _validationmessages;

// ValidatorBase / IValidator

/// <summary>
/// The object being validated.
/// Exposed via the <c>Object</c> property.
/// </summary>
public struct _rootobject;

/// <summary>
/// Override to define the validation rules for this validator.
/// </summary>
public struct _execute;

/// <summary>
/// <see langword="true" /> when no validation messages were produced.
/// </summary>
public struct _isvalid;

/// <summary>
/// Throws an exception listing all messages when validation has failed.
/// </summary>
public struct _verify;

/// // TODO: Repeat doc for TValidator type argument.
/// 
/// <summary>
/// Runs a sub-validator and merges its messages into this validator's results.
/// </summary>
/// <param name="validatorType">The <see cref="Type"/> of the sub-validator to execute (used by reflection-based overloads).</param>
/// <param name="messagePrefix">A prefix that is prepended to each message produced by the sub-validator to indicate context
/// (for example, <c>"Address: "</c> so messages become <c>"Address: Street is required."</c>).</param>
public struct _executesub;

// FluentValidator

/// <summary>
/// Selects the property to validate next.
/// Subsequent fluent calls (e.g. <c>NotNull</c>, <c>Min</c>) apply to this property.
/// </summary>
/// <inheritdoc cref="_propertyexpression" />
/// <inheritdoc cref="_propertykeyparam" />
/// <param name="propertyDisplayName">
/// A human-readable name shown in validation messages. Best set to a localized resource.
/// </param>
public struct _for;


/// <remarks>
/// Adds a value to the ValidationMessages when the validation fails.
/// The IsValid will return False and the Verify method will throw an exception if there are any ValidationMessages.
/// </remarks>
public struct _validatormethod;

/// <summary>
/// Fails when the value is <see langword="null" />.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _notnull;

/// <summary>
/// Fails when the value is <see langword="null" />, empty or contains only white-space characters.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _notnullorwhitespace;

/// <summary>
/// Fails when the value is not one of the specified allowed values.
/// Useful for checking that a value is one of an explicit set (for example, enum-like choices).
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _in;

/// <summary>
/// Fails when the selected property's value does not equal the specified expected value.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _is;

/// <summary>
/// Fails when the selected property's value equals the specified forbidden value.
/// Use this to forbid a particular literal (for example, <c>"Deleted"</c> in a status field).
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _isnot;

/// <summary>
/// Fails when the selected property's value equals zero.
/// Useful for numeric fields where zero is not an acceptable value.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _notzero;

/// <summary>
/// Fails when the selected property's value is not strictly greater than the specified minimum.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _above;

/// <summary>
/// Fails when the value is less than the specified minimum.
/// The minimum is an inclusive lower bound for valid values.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _min;

/// <summary>
/// Fails when the selected property's value exceeds the specified maximum.
/// The maximum is an inclusive upper bound for valid values.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _max;

/// <summary>
/// Fails when the value can be parsed as an integer.
/// Use to reject whole-number input where a non-integer is expected.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _notinteger;

/// <summary>
/// Fails when the selected property's value does not match any defined member
/// of the specified enum type.
/// </summary>
/// <inheritdoc cref="_validatormethod" />
public struct _isenumvalue;

// ValidationMessage members

/// <summary>
/// Technical key identifying the property this message relates to (e.g. for MVC UI binding).
/// </summary>
public struct _propertykey;

/// <summary>
/// The human-readable validation message text.
/// </summary>
public struct _messagetext;

// ValidationMessages

/// <summary>
/// Adds a validation message to the collection.
/// </summary>
/// <inheritdoc cref="_propertykeyparam" />
/// <inheritdoc cref="_propertykeyexpression" />
public struct _add;

/// <summary>
/// The number of validation messages in the collection.
/// </summary>
public struct _count;

/// <summary>
/// Gets the validation message at the specified index.
/// </summary>
public struct _indexer;

/// <summary>
/// Adds multiple validation messages to the collection at once.
/// </summary>
public struct _addrange;


/// <summary>
/// Returns an enumerator that iterates through the validation messages.
/// </summary>
public struct _getenumerator;

// Parameters

/// <param name="postponeExecute">
/// When <see langword="true" />, <c>Execute</c> is not called by the base constructor,
/// letting your subclass constructor initialize state first.
/// You must then call <c>Execute</c> from your own constructor.
/// </param>
public struct _postponeexecute;

/// <param name="propertyKey">
/// Technical key identifying the property this message relates to (e.g. for MVC UI binding).
/// </param>
public struct _propertykeyparam;

/// <param name="propertyExpression">
/// Expression from which both the value and a property key are extracted.
/// The root of the expression is excluded from the key,
/// e.g. <c>() =&gt; MyObject.MyProperty</c> produces key <c>"MyProperty"</c>.
/// </param>
public struct _propertyexpression;

/// <param name="propertyKeyExpression">
/// Expression from which the property key is extracted.
/// The root is excluded, e.g. <c>() =&gt; MyObject.MyProperty</c> produces key <c>"MyProperty"</c>.
/// </param>
public struct _propertykeyexpression;
