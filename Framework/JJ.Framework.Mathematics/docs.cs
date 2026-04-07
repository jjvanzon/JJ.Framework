#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE1006 // Naming rule

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
/// <item><c>GetInt32</c>: Return a random number out of a range.</item>
/// </list>
/// </summary>
public struct _randomizer;


/// <summary>
/// Gets a random item out of a collection.
/// </summary>
public struct _getrandomitem;

/// <summary>
/// <list type="bullet">
///   <item><c>Pow</c> with integers</item>
///   <item><c>Log</c> with integers: It will only return integers, but will prevent rounding errors such as 1000 log 10 = 2.99999999996.</item>
/// </list>
/// </summary>
public struct _maths;