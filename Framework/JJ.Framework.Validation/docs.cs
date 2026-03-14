// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace
#pragma warning disable IDE1006 // Naming rule violation

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Validation.Legacy.docs;

// Types

/// <summary>
/// Provides access to validation results:
/// the collected messages, an overall pass/fail flag and a throw-on-failure helper.
/// </summary>
public struct _ivalidator;

/// <summary>
/// Base class for building validators.
/// Override <c>Execute</c> to define validation rules.
/// Collects <see cref="ValidationMessage" /> entries and supports composing with sub-validators.
/// </summary>
/// <inheritdoc cref="_postponeexecute" />
public struct _validatorbase;

/// <summary>
/// A validator with a fluent API.
/// Call <c>For</c> to select a property, then chain checks such as
/// <c>NotNull</c>, <c>Min</c>, <c>Max</c>, <c>In</c>, etc.
/// </summary>
/// <inheritdoc cref="_postponeexecute" />
public struct _fluentvalidator;

/// <summary>
/// A single validation message consisting of a property key (for UI binding)
/// and a human-readable message.
/// </summary>
public struct _validationmessage;

/// <summary>
/// The validation messages collected during execution of a validator.
/// </summary>
public struct _validationmessages;

// ValidatorBase / IValidator

/// <summary>
/// // TODO: This is filler that adds no meaning.
/// The object being validated.
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

/// <summary>
/// Runs a sub-validator and merges its messages into this validator's results.
/// </summary>
/// <param name="validatorType">
/// This overload requires the sub-validator to accept the same root object type
/// and have no additional constructor parameters.
/// // TODO: Repeat doc for TValidator type argument.
/// </param>
/// <param name="messagePrefix">
/// // TODO: Bit too technical + An example could help.
/// A prefix prepended to the sub-validator's messages,
/// identifying which part of the object structure they relate to.
/// </param>
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

// TODO: "Fails" it too vague here. Make it more clear what the effect is. You could use a 2nd-level inheritdoc to describe that and use the <remarks> tag in that.

/// <summary>
/// Fails when the value is <see langword="null" />.
/// </summary>
public struct _notnull;

/// <summary>
/// Fails when the value is <see langword="null" />, empty or contains only white-space characters.
/// </summary>
public struct _notnullorwhitespace;

/// <summary>
/// Fails when the value is not one of the specified allowed values.
/// </summary>
public struct _in;

/// <summary>
/// Fails when the value does not equal the specified value.
/// </summary>
public struct _is;

/// <summary>
/// Fails when the value equals the specified value.
/// // TODO: The functional effect of the string comparison should be described here, since it's relevant to the user. (Don't elaborate the implementation, talk about the effect.)
/// </summary>
public struct _isnot;

/// <summary>
/// Fails when the value is zero.
/// </summary>
public struct _notzero;

/// <summary>
/// Fails when the value is not strictly greater than the specified minimum.
/// </summary>
public struct _above;

/// <summary>
/// Fails when the value is less than the specified minimum (inclusive lower bound).
/// </summary>
public struct _min;

/// <summary>
/// Fails when the value exceeds the specified maximum (inclusive upper bound).
/// </summary>
public struct _max;

/// <summary>
/// Fails when the value can be parsed as an integer.
/// Use to reject whole-number input where a non-integer is expected.
/// </summary>
public struct _notinteger;

/// <summary>
/// Fails when the value does not correspond to a defined member of the specified enum type.
/// </summary>
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
/// // TODO: Write something for the ValidationMessages.GetEnumerator.
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
