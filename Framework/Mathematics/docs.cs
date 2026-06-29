#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE1006 // Naming rule
// ReSharper disable UnusedType.Global

namespace JJ.Framework.Mathematics.docs;

/// <summary>
/// <c>GetRandomItem</c>: Gets a random item out of a collection.<br/>
/// <c>GetInt32</c> / <c>GetSingle</c> / <c>GetDouble</c>: 
/// Return a random number out of a range.<br/><br/>
/// 
/// Extends the <see cref="Randomizer">Randomizer</see> variant
/// with additional methods.
/// </summary>
public struct _randomizer;

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