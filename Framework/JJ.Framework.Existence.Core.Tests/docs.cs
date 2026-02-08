#pragma warning disable IDE1006 // Naming Styles
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Existence.Core.Tests.docs;

/// <summary>
/// Permutation Tests of StringBuilder variants, with String as Last Arg.
/// </summary>
public struct _coalesce3argssbtotext;

/// <summary>
/// Tests of all StringBuilder/Text Combos.<br/>
/// Non-nullable inputs are omitted. Test combinations of:<br/>
/// NullyEmpty, Null, NullySpace, NullyFilled, NullSB, NullyEmptySB, NullySpaceSB, NullyFilledSB.
/// </summary>
public struct _coalesce3argssbtextcombos;

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

/// <summary>
/// Note: Even though some hit the overload with their parameters swapped unintentionally,
/// The simple nature of Booleans seems to output the correct result anyway.
/// </summary>
public struct _nullableflag;