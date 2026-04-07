JJ.Framework.Mathematics.Legacy
===============================

Miscellaneous math helpers from a 2015 code freeze.

It's a legacy release for projects that still depend on it.

This legacy release supports newer and older .NET versions, has IntelliSense docs and will support code trimming and native compilation.

A newer extended version is [`JJ.Framework.Mathematics`](https://www.nuget.org/packages/JJ.Framework.Mathematics) but it officially only supports `.NET 4.6.1` though there's a good chance it still works for later versions too, as compatibility was a high priority during its development.

This legacy release contains the following features:

## Maths

Class extending the `Math` helpers from `.NET` with:

* `Pow` 
	* Integer variation of the `Math.Pow` function.
* `Log` with integers
	* It will only return integers, but will prevent rounding errors such as `1000 log 10` = `2.99999999996`.

## Randomizer

* `GetRandomItem`
	* Gets a random item out of a collection.
* `GetInt32`
	* Return a random number out of a range:

## NumberingSystems

* `ToBase`
	* Converts an `int` to an n-base number in usually string format.
* `FromBase`
	* Converts an n-based number to an `int`. The input is usually in string format.
* You could convert from one base to another by first calling `FromBase` and then `ToBase`.
* Several overloads to handle it differently.
* `FromHex` / `ToHex`
* `ToLetterSequence` / `FromLetterSequence`
	* Does spread-sheet-style letter sequences. This is not the same as a base-26 numbering system. After the range A-Z is depleted, the next value is 'AA',
	which is equivalent to 00, so you basically start counting at 0 again, but you get 26 for free.

💬 Feedback
============

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)