// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Business.Legacy.docs;

/// <summary>
/// Simple in-memory holder for small, useful pieces of state about objects
/// (for example: New, Dirty, Deleted).
///
/// The goal: let business code ask "does this object look new/dirty/deleted?"
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
/// Business code can use this to handle newly created objects differently.
/// </summary>
public struct _isnew;

/// <summary>
/// Mark an entity as "new". The manager records the state; creating/saving the
/// entity is still the job of other code.
/// </summary>
public struct _setisnew;

/// <summary>
/// Returns true when an entity was marked as "dirty" via <c>SetIsDirty</c>.
/// Business code can use this to detect changed objects.
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
/// Mark an entity as deleted. The manager records deletion intent; performing
/// the actual delete is the responsibility of caller code.
/// </summary>
public struct _setisdeleted;

/// <summary>
/// Check whether a specific property is marked dirty. Call like
/// <c>IsDirty(() =&gt; myEntity.SomeProperty)</c>; the expression identifies
/// the entity instance and the property name.
/// </summary>
public struct _isdirty_property;

/// <summary>
/// Mark a property as dirty using an expression like
/// <c>SetIsDirty(() =&gt; myEntity.SomeProperty)</c>. Records which property on
/// which instance is dirty so business code can act on that.
/// </summary>
public struct _setisdirty_property;

/// <summary>
/// Remove all recorded entity and property states from the manager.
/// </summary>
public struct _clear;
