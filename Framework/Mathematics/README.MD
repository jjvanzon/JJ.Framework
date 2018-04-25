# JJ.Framework.Mathematics

Helpers for calculations.

* Interpolation
* Base-n numbering systems
* Special rounding methods
* Use the `Random` class more easily
* Simple geometric calculations
* Other basic math helpers.

## Interpolator

For (sound) curves.

* `Hermite4pt3oX`:
	* Pretty good sound interpolation.
	* Derived from: http://stackoverflow.com/questions/1125666/how-do-you-do-bicubic-or-other-non-linear-interpolation-of-re-sampled-audio-da
* `CubicFromT`
	* Also know as Bezier curves.
* `CubicSmoothSlope`
	* Super nice interpolation.
	* Thanks to my brother for giving me some of the math long ago.

There are also separate methods for precalculating values once when you start interpolating between two numbers and then doing a faster calculation to derive the points in between.

## NumberBases

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

## Randomizer

* `GetRandomItem`
	* Gets a random item out of a collection.

Return a random number out of a range:

* `GetInt32`
* `GetDouble`
* `GetSingle`

## Geometry

* `IsInRectangle`
* `GetCenter`
* `AbsoluteDistance`

## MathHelper

Misc math helpers.

* `Pow` with integers
* `Log` with integers
	* It will only return integers, but will prevent rounding erros such as 1000 log 10 = 2.99999999996.
* `IsPowerOf2`
	* With help of: http://www.lomont.org/Software/Misc/FFT/LomontFFT.html
* `LogRatio`
	* Calculates where x is in between x0 and x1 on a logarithmic scale. 0 means it is on point x0. 1 means it is on pont x1. between 0 and 1 means it is somewhere in between. 0.5 means it is precisely half-way x0 and x1 logarithmically. Note that it can also be outside the bounds 0 and 1 if it is not in between those numbers.
* `RoundToSignificantDigits`
	* Source: https://stackoverflow.com/questions/374316/round-a-double-to-x-significant-figures
* `RoundWithStep`
	* Rounds to multiples of step, with an offset. It uses `Math.Round` as a helper, which supports a wide range of values.
* `RoundWithStepWithInt64Bounds`
	* Same as above, but uses a cast to `Int64` as a helper, which might be faster than `Math.Round`, but means you are stuck within the value bounds of `long`.
* `ScaleLinearly`
	* Converts one range of numbers to another, both making a number bigger or smaller and shifting it over.
* `SpeadItems`
	* Equally spreads out items over another set of items. For instance the numbers {1,2,3} could be spread over 10 items, the first ones getting 1, the middle ones getter 2 and the last ones getting 3.
* `SpreadIntegers`
	* Equally spreads out a number of indices over a different number of indices. For instance the numbers {1,2,3} could be spread over 10 items, the first ones getting 1, the middle ones getter 2 and the last ones getting 3.
* `SpreadDoubles`
	* Equally spreads out a number of points over a span.
	* It takes a `valueSpan` and `pointCount` and returns a `double[]`.