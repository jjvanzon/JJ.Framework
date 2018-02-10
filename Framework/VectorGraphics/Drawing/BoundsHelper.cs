using System;
using System.Runtime.CompilerServices;

namespace JJ.Framework.VectorGraphics.Drawing
{
	public static class BoundsHelper
	{
		// TODO: If these values are at the scale of pixels, aren't these too 'big'?
		private const float MAX_VALUE = 1E9f;
		private const float MIN_VALUE = -1E9f;
		private const float VERY_SMALL_VALUE = 1E-9f;

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
		public static int CorrectCoordinateToInt32(float value)
		{
			float correctedFloat = CorrectCoordinate(value);
			int correctedToInt32 = CorrectToInt32(correctedFloat);
			return correctedToInt32;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int CorrectLengthToInt32(float value)
		{
			float correctedFloat = CorrectLength(value);
			int correctedToInt32 = CorrectToInt32(correctedFloat);
			return correctedToInt32;
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
