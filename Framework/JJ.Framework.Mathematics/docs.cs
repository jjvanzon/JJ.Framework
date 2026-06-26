#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE1006 // Naming rule
#pragma warning disable IDE0130 // Namespace != folder
// ReSharper disable UnusedType.Global

namespace JJ.Framework.Mathematics.Legacy.docs;

/// <summary>
/// 
/// * <c>ToBase</c>
/// 	* Converts an <c>int</c> to an n-base number in usually string format.
/// * <c>FromBase</c>
/// 	* Converts an n-based number to an <c>int</c>. The input is usually in string format.
/// * You could convert from one base to another by first calling <c>FromBase</c> and then <c>ToBase</c>.
/// * Several overloads to handle it differently.
/// * <c>FromHex</c> / <c>ToHex</c>
/// * <c>ToLetterSequence</c> / <c>FromLetterSequence</c>
/// 	* Does spread-sheet-style letter sequences. This is not the same as a base-26 numbering system. After the range A-Z is depleted, the next value is 'AA',
/// 	which is equivalent to 00, so you basically start counting at 0 again, but you get 26 for free.
/// </summary>
public struct _numberingsystems;

/// <summary>
/// <list type="bullet">
/// <item><c>GetRandomItem</c>: Gets a random item out of a collection.</item>
/// <item><c>GetInt32</c> / <c>GetSingle</c> / <c>GetDouble</c>: Return a random number out of a range.</item>
/// </list>
/// <see cref="RandomizerLegacy">RandomizerLegacy</see> 
/// which may extend the <see cref="Randomizer">Randomizer</see> variant
/// with additional methods.
/// </summary>
public struct _randomizer;

/// <inheritdoc cref="_randomizer" />
public struct _randomizerlegacy;

/// <summary>
/// Gets a random item out of a collection.
/// </summary>
public struct _getrandomitem;

/// <inheritdoc cref="_getrandomitem" />
public struct _trygetrandomitem;

/// <summary>
/// <list type="bullet">
///   <item><c>Pow</c>: Integer variation of the <c>Math.Pow</c> function.</item>
///   <item><c>Log</c> with integers: It will only return integers, but will prevent rounding errors such as 1000 log 10 = 2.99999999996.</item>
/// </list>
/// </summary>
public struct _maths;

/// <summary> Returns a random number between 0.0 and 1.0. </summary>
public struct _getdouble;

/// <summary> Returns a random number between 0.0 and a maximum value (limit excluded). </summary>
public struct _getdoublemax;

/// <summary> Returns a random number between a minimum and maximum value (max excluded). </summary>
/// <param name="min">inclusive</param>
/// <param name="max">exclusive</param>
public struct _getdoubleminmax;

/// <inheritdoc cref="_getdouble" />
public struct _getsingle;

/// <inheritdoc cref="_getdoublemax" />
public struct _getsinglemax;

/// <inheritdoc cref="_getdoubleminmax" />
public struct _getsingleminmax;

/// <summary>
/// Gets a random Int32 between Int32.MinValue and Int32.MaxValue - 1.
/// </summary>
public struct _getint32;

/// <summary>
/// Gets a random Int32 between 0 and the specified value.
/// max must at most be Int32.MaxValue - 1 or an overflow exception could occur.
/// </summary>
public struct _getint32max;

/// <summary>
/// Gets a random Int32 between between a minimum and a maximum.
/// Both the minimum and the maximum are included.
/// max must at most be Int32.MaxValue - 1 or an overflow exception could occur.
/// </summary>
public struct _getint32minmax;