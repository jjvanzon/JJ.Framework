#pragma warning disable IDE1006 // Naming Styles
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Existence.Core.Tests.docs;

/// <summary>
/// 4-arg bools have their own overloads for flag-free calls to Coalesce.
/// This is for overload resolution purposes specific to Booleans.
/// These tests check those overloads systematically.
/// </summary>
public struct _coalesce4argsbool;

/// <summary>
/// TODO:
/// Char (does not behave well yet), Byte, IntPtr, UIntPtr
/// the numeric types, their signed and unsigned variations and TimeSpan.
/// Newer .NETs probably have more.
/// But let's start with a basic spread:<br/>
/// - [x] Enum/Enum?<br/>
/// - [x] bool<br/>
/// - [x] double<br/>
/// - [x] Guid<br/>
/// - [x] DateTime<br/>
/// - [x] Char<br/>
/// - [ ] ~ Decimal
/// </summary>
public struct _basictypestodo;
