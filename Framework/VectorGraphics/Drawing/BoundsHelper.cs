using System;
using System.Runtime.CompilerServices;

namespace JJ.Framework.VectorGraphics.Drawing
{
	public static class BoundsHelper
	{
		private const float MAX_VALUE = 100_000f;
		private const float MIN_VALUE = -100_000f;
		private const float VERY_SMALL_VALUE = 0.00001f;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CorrectCoordinate(float value)
		{
			if (float.IsNaN(value))
			{
				return 0f;
			}

			if (float.IsInfinity(value))
			{
				return 0f;
			}

			if (value > MAX_VALUE)
			{
				return MAX_VALUE;
			}

			if (value < MIN_VALUE)
			{
				return MIN_VALUE;
			}

			if (value > 0f && value < VERY_SMALL_VALUE)
			{
				return VERY_SMALL_VALUE;
			}

			if (value < 0f && value > -VERY_SMALL_VALUE)
			{
				return -VERY_SMALL_VALUE;
			}

			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CorrectLength(float length)
		{
			length = CorrectCoordinate(length);

			if (Math.Abs(length) < VERY_SMALL_VALUE)
			{
				return VERY_SMALL_VALUE;
			}

			return length;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int CorrectToInt32(float correctedFloat)
		{
			if (correctedFloat > int.MaxValue) correctedFloat = int.MaxValue;
			if (correctedFloat < int.MinValue) correctedFloat = int.MinValue;

			return (int)correctedFloat;
		}
	}
}
