// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace
#pragma warning disable IDE1006 // Naming rule violation

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Validation.Legacy.docs;

// Types

/// <summary>
/// Provides validation results: the collected messages: <see cref="IValidator.ValidationMessages" />, an overall pass/fail flag: <see cref="IValidator.IsValid" />
/// and a helper to throw an aggregated exception when validation fails: <see cref="IValidator.Verify" />.
/// 
/// <code>
/// IValidator validator = new OrderValidator(order);
/// if (!validator.IsValid)
/// {
///     foreach (var msg in validator.ValidationMessages)
///     {
///         Console.WriteLine(msg.Text);
///     }
/// }
/// validator.Verify();
/// </code>
/// 
/// </summary>
public struct _ivalidator;

/// <remarks>
/// Base class for building validators. 
/// Override <c>Execute</c> to define validation rules.
/// Collects <see cref="ValidationMessage" /> entries and supports composing with sub-validators.
/// <code>
/// class OrderValidator(Order order) : ValidatorBase&lt;Order&gt;(order)
/// {
///     protected override void Execute()
///     {
///         if (Object == null) { ValidationMessages.Add("Order", "Order is required."); return; }
///         if (Object.Amount &lt;= 0) ValidationMessages.Add("Amount", "Amount must be positive.");
///     }
/// }
/// new OrderValidator(order).Verify();
/// </code>
/// </remarks>
/// <param name="postponeExecute">
/// When <see langword="true" />, <c>Execute</c> is not called by the base constructor,
/// letting your subclass constructor initialize state first.
/// You must then call <c>Execute</c> from your own constructor.
/// </param>
public struct _validatorbase;

/// <summary>
/// Base class for validators with a fluent API.
/// Call <c>For</c> to select a property, then chain checks such as
/// <c>NotNull</c>, <c>Min</c>, <c>Max</c>, <c>In</c>, etc.
/// 
/// <code>
/// class OrderValidator(Order order) 
///     : FluentValidator&lt;Order&gt;(order)
/// {
///     protected override void Execute()
///     {
///         For(() =&gt; Object, "Order")
///             .NotNull();
/// 
///         For(() =&gt; Object.Amount, StringResources.Amount)
///             .Min(1).Max(10000);
/// 
///         For(Object.Name, "Name", "Full Name")
///             .NotNullOrWhiteSpace();
///     }
/// }
/// 
/// new OrderValidator(order).Verify();
/// </code>
/// 
/// </summary>
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
/// the <c>Object</c> property is meant to store the object being validated.
/// The base classes do nothing with it.
/// It's expected to be used in the Execute method as a root object to validate.
/// This to enforce the style of passing something for the validator to validate.
/// </summary>
public struct _rootobject;

/// <summary>
/// Override this method in a derived FluentValidator (or ValidatorBase)
/// to define the validation rules for this validator.
/// </summary>
public struct _execute;

/// <summary>
/// <see langword="true" /> when no validation messages were produced.
/// 
/// <code>
/// if (!validator.IsValid)
/// {
///     foreach (var msg in validator.ValidationMessages)
///     {
///         Console.WriteLine(msg.Text);
///     }
/// }
/// </code>
/// 
/// </summary>
public struct _isvalid;

/// <summary>
/// Throws an exception if IsValid is false,
/// listing all the validation messages.
/// 
/// <code>
/// new OrderValidator(order).Verify();
/// </code>
/// </summary>
public struct _verify;

/// <summary>
/// Runs a sub-validator and merges its messages into this validator's results.
/// </summary>
/// <typeparam name="TValidator">
/// Type for the generic <c>Execute</c> overloads. Must be a validator derived from
/// <c>ValidatorBase&lt;TRootObject&gt;</c> that accepts the same root object as the caller. Use the generic overload
/// when you want to run a specific sub-validator type.
/// </typeparam>
/// <param name="validatorType">
/// The <see cref="Type"/> of the sub-validator to execute (used by reflection-based overloads).
/// </param>
/// <param name="messagePrefix">
/// A prefix that is prepended to each message produced by the sub-validator to indicate context
/// (for example, <c>"Address: "</c> so messages become <c>"Address: Street is required."</c>).
/// </param>
public struct _executesub;

/// <remarks>
/// This overload runs a sub-validator by instance.
/// 
/// <code>
/// Execute(new AddressValidator(Object.Address));
/// </code>
/// 
/// </remarks>
/// <inheritdoc cref="_executesub" />
public struct _executeivalidator;

/// <remarks>
/// This overload runs a sub-validator by generic type.
/// 
/// <code>
/// Execute&lt;AddressValidator&gt;();
/// </code>
/// 
/// </remarks>
/// <inheritdoc cref="_executesub" />
public struct _executetvalidator;

/// <remarks>
/// This overload runs a sub-validator by generic type with a message prefix.
/// 
/// <code>
/// Execute&lt;AddressValidator&gt;("Address: ");
/// </code>
/// 
/// </remarks>
/// <inheritdoc cref="_executesub" />
public struct _executetvalidatorwithprefix;

/// <remarks>
/// This overload runs a sub-validator by <see cref="Type"/>.
/// 
/// <code>
/// Execute(typeof(AddressValidator));
/// </code>
/// 
/// </remarks>
/// <inheritdoc cref="_executesub" />
public struct _executevalidatortype;

/// <remarks>
/// This overload runs a sub-validator by <see cref="Type"/> with a message prefix.
/// 
/// <code>
/// Execute(typeof(AddressValidator), "Address: ");
/// </code>
/// 
/// </remarks>
/// <inheritdoc cref="_executesub" />
public struct _executevalidatortypewithprefix;

/// <remarks>
/// This overload runs a sub-validator by instance with a message prefix.
/// 
/// <code>
/// Execute(new AddressValidator(Object.Address), "Address: ");
/// </code>
/// 
/// </remarks>
/// <inheritdoc cref="_executesub" />
public struct _executeivalidatorwithprefix;

// FluentValidator

/// <remarks>
/// Selects the property to validate next.
/// Subsequent fluent calls (e.g. <c>NotNull</c>, <c>Min</c>) apply to this property.
/// 
/// <code>
/// 
/// For(() =&gt; Object.Price, "Price")
///     .Min(0).Max(9999);
/// 
/// For(Object, "Order", StringResources.Order)
///     .NotNullOrWhiteSpace();
/// 
/// For(Object.Name, "Name", "Full Name")
///     .NotNullOrWhiteSpace();
/// </code>
/// 
/// </remarks>
/// <param name="propertyExpression">
/// Expression from which both the value and a property key are extracted.
/// The root of the expression is excluded from the key,
/// e.g. <c>() =&gt; MyObject.MyProperty</c> produces key <c>"MyProperty"</c>.
/// </param>
/// <inheritdoc cref="_propertykeyparam" />
/// <param name="propertyDisplayName">
/// A human-readable name shown in validation messages. Best set to a localized resource.
/// </param>
public struct _for;

/// <remarks>
/// Adds a value to the ValidationMessages when the validation fails.
/// The IsValid will return False and the Verify method will throw an exception if there are any ValidationMessages.
/// </remarks>
public struct _validationmethod;

/// <summary>
/// Checks if the value is <see langword="null" />.
/// 
/// <code>
/// For(() =&gt; Object.Customer, "Customer")
///     .NotNull();
///
/// For(Object.BillingAddress, "BillingAddress", DisplayNames.BillingAddress)
///     .NotNull();
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _notnull;

/// <summary>
/// Checks if the value is <see langword="null" />, empty or contains only white-space characters.
/// 
/// <code>
/// For(() =&gt; Object.Name, DisplayNames.FullName)
///     .NotNullOrWhiteSpace();
///
/// For(Object.Name, nameof(Object.Name), "Full Name")
///     .NotNullOrWhiteSpace();
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _notnullorwhitespace;

/// <summary>
/// Checks if the value is not one of the specified allowed values.
/// Useful for checking that a value is one of an explicit set (for example, enum-like choices).
/// 
/// <code>
/// For(() =&gt; Object.OrderStatus, "Order Status")
///     .In("Active", "Inactive", "Pending");
/// For(Object.Status, nameof(Object.Status), DisplayNames.Status)
///     .In("Active", "Inactive", "Pending");
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _in;

/// <summary>
/// Requires that the property has a specific value.
/// 
/// <code>
/// For(() =&gt; Object.Status, "Order Status")
///     .Is("Active");
/// 
/// For(Object.OrderStatus, "OrderStatus", DisplayNames.OrderStatus)
///     .Is("Active");
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _is;

/// <summary>
/// Checks if the selected property's value equals the specified forbidden value.
/// Use this to forbid a particular literal (for example, <c>"Deleted"</c> in a status field).
/// 
/// <code>
/// For(() =&gt; Object.OrderStatus, DisplayNames.OrderStatus)
///     .IsNot("Deleted");
/// 
/// For(Object.OrderStatus, "OrderStatus", "Order Status")
///     .IsNot("InProgress");
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _isnot;

/// <summary>
/// Checks if the selected property's value equals zero.
/// Useful for numeric fields where zero is not an acceptable value.
/// 
/// <code>
/// For(() =&gt; Object.Quantity, StringResources.Quantity)
///     .NotZero();
/// 
/// For(Object.Amount, "Amount", "Total Amount")
///     .NotZero();
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _notzero;

/// <summary>
/// Checks if the selected property's value is not strictly greater than the specified minimum.
/// 
/// <code>
/// For(() =&gt; Object.CreditScore, DisplayNames.CreditScore)
///     .Above(0);
/// 
/// For(Object.CreditScore, nameof(Object.CreditScore), "Credit Score")
///     .Above(0);
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _above;

/// <summary>
/// Checks if the value is less than the specified minimum.
/// The minimum is an inclusive lower bound for valid values.
/// 
/// <code>
/// For(() =&gt; Object.CreditScore, "Credit Score")
///     .Min(1);
/// 
/// For(Object.CreditScore, "CreditScore", DisplayNames.CreditScore)
///     .Min(1);
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _min;

/// <summary>
/// Checks if the selected property's value exceeds the specified maximum.
/// The maximum is an inclusive upper bound for valid values.
/// 
/// <code>
/// For(() =&gt; Object.CreditScore, "Credit Score")
///     .Max(100);
/// 
/// For(Object.CreditScore, nameof(Object.CreditScore), "Credit Score")
///     .Max(100);
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _max;

/// <summary>
/// Checks if the value can be parsed as an integer.
/// Use to reject whole-number input where a non-integer is expected.
/// 
/// <code>
/// // Passes for "hello", fails for "42":
/// For(() =&gt; Object.SerialNumber, "Serial Number")
///     .NotInteger();
/// 
/// For(Object.SerialNumber, "SerialNumber", DisplayNames.SerialNumber)
///     .NotInteger();
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
public struct _notinteger;

/// <summary>
/// Checks if the selected property's value does not match any defined member
/// of the specified enum type.
/// 
/// <code>
/// For(() =&gt; Object.Color, "Color")
///     .IsEnumValue&lt;ColorEnum&gt;();
/// 
/// For(Object.PaymentMethod, "PaymentMethod", DisplayNames.PaymentMethod)
///     .IsEnumValue&lt;PaymentMethodEnum&gt;();
/// </code>
/// 
/// </summary>
/// <inheritdoc cref="_validationmethod" />
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
/// 
/// <code>
/// ValidationMessages.Add("Name", "Name is required.");
/// ValidationMessages.Add(() =&gt; Object.Name, "Name is required.");
/// </code>
/// 
/// Instead of above syntax, prefer fluent methods like <c>.NotNull()</c> where available..
/// See <see cref="FluentValidator{TRootObject}">FluentValidator</see>.
/// </summary>
/// <param name="propertyKeyExpression">
/// Expression from which the property key is extracted.
/// The root is excluded, e.g. <c>() =&gt; MyObject.MyProperty</c> produces key <c>"MyProperty"</c>.
/// </param>
/// <inheritdoc cref="_propertykeyparam" />
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

/// <param name="propertyKey">
/// Technical key identifying the property this message relates to (e.g. for MVC UI binding).
/// </param>
public struct _propertykeyparam;

