// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace
// ReSharper disable InvalidXmlDocComment

namespace JJ.Framework.Business.docs;

/// <summary>
/// Simple in-memory holder for small, useful pieces of state about objects
/// (for example: New, Dirty, Deleted).
///
/// The goal: let business logic ask "does this object look new/dirty/deleted?"
/// without depending on a database or a large persistence framework. You
/// can fill this object from wherever is convenient (service code, UI, or
/// persistence layer) and pass it around. Business rules can then react to
/// those flags (for example: update LastModified) without being tied to
/// how the data is stored. It's intentionally tiny and non-persistent:
/// just a transient bag of status flags.
/// </summary>
public struct _entitystatusmanager;

/// <summary>
/// Returns true when an entity was marked as "new" via <c>SetIsNew</c>.
/// Business logic can use this to handle newly created objects differently.
/// </summary>
public struct _isnew;

/// <summary>
/// Mark an entity as "new". The <c>EntityStatusManager</c> records the state;
/// creating/saving the entity is still the job of other code.
/// </summary>
public struct _setisnew;

/// <summary>
/// Returns true when an entity was marked as "dirty" via <c>SetIsDirty</c>.
/// Business logic can use this to detect changed objects.
/// </summary>
public struct _isdirty;

/// <summary>
/// Mark an entity as dirty. Records that the object changed; saving/validation
/// should be handled by other parts of the application.
/// </summary>
public struct _setisdirty;

/// <summary>
/// Returns true when an entity was marked as deleted via <c>SetIsDeleted</c>.
/// Use to record deletion intent so business logic can respond appropriately.
/// </summary>
public struct _isdeleted;

/// <summary>
/// Mark an entity as deleted. The <c>EntityStatusManager</c> records deletion intent;
/// performing the actual delete is the responsibility of caller code.
/// </summary>
public struct _setisdeleted;

/// <summary>
/// Check whether a specific property is marked dirty. Call like
/// <c>IsDirty(() =&gt; myEntity.SomeProperty)</c>; the expression identifies
/// the entity instance and the property name.
/// </summary>
public struct _isdirty_property;

/// <summary>
/// Remove all recorded entity and property states from the manager.
/// </summary>
public struct _clear;

/// <summary>
/// Mark a property as dirty using an expression like
/// <c>SetIsDirty(() =&gt; myEntity.SomeProperty)</c>. Records which property on
/// which instance is dirty so business logic can act on that.
/// </summary>
public struct _setisdirty_property;

/// <summary>
/// Determine whether two lists (view model and entity list) differ in items.
/// Compares by keys supplied by the <c>getKey</c> callbacks and optionally ignores order.
/// </summary>
public struct _entitystatushelper;



/// <inheritdoc cref="_resulttypes"/>
/// <remarks>Use <c>Result</c> when there's no return value, just success / failure info.</remarks>
public struct _result;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks><c>IResult</c> is the common interface for the result types.</remarks>
public struct _iresult;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks>
/// <c>ResultBase</c> is a base class with core properties: 
/// <c>Success</c> and <c>Messages</c>
/// and base constructors.
/// </remarks>
public struct _resultbase;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks><c>Result&lt;T&gt;</c> returns data along with the status metadata.</remarks>
public struct _resultoft;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks>
/// The <c>Success</c> flag indicating success or failure of the result.
/// </remarks>
public struct _success;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks>
/// <c>Messages</c> to accompany a failed or successful result. 
/// In case of <c>Success</c>, the messages are considered mere <b>warnings</b>.
/// Having messages does not imply failure.
/// </remarks>
public struct _messages;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks>
/// <c>Data</c> to accompany the result. 
/// This would have been the return value,
/// if it wasn't wrapped in a <c>Result</c> type, 
/// containing success and messages alongside it.
/// </remarks>
public struct _data;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks>Converts the result type to a human-readable text.</remarks>
public struct _tostring;

/// <summary>
/// An elegant way to return data, status and messages from your operations.
/// </summary>
/// <param name="success">
/// The <c>Success</c> flag indicating success or failure of the result.
/// </param>
/// <param name="messages">
/// <c>Messages</c> to accompany a failed or successful result. 
/// In case of <c>Success</c>, the messages are considered mere <b>warnings</b>.
/// Having messages does not imply failure.
/// </param>
public struct _resulttypes;

/// <inheritdoc cref="_resulttypes"/>
/// <remarks>
/// <c>Assert()</c> throws an exception with descriptive message in case
/// <c>result.Success</c> is false. Otherwise, continues running your code.
/// </remarks>
public struct _assert;
