using System;
using System.Runtime.CompilerServices;

namespace JJ.Framework.VectorGraphics.Drawing
{
	/// <summary>
	/// Helper for correcting coordinate values to 'reasonable' bounds for pixel coordinates.
	/// Coordinates minimally -100,000 and maximally 100,000. Sizes at least 0.0001.
	/// Admittedly these 'reasonable' bounds might be related to what System.Drawing and System.Windows.Forms 'want'.
	/// Coordinate values outside those ranges may have resulted in functional error in the past.
	/// Other presentation technology might not be need such corrections.
	/// But apparently it was thought it might not hurt to apply these corrections in the deeper layers,
	/// so higher framework layer might have to 'think' about it as much.
	/// In some cases JJ.Framework.VectorGraphics may correct the coordinate values
	/// put in the CalculatedValues of a vector graphics Element.
	/// But for line style widths a higher (framework) layer may have more opportunity to use an erroneous value.
	/// Therefor this class has some public parts for use there.
	/// </summary>
	public static class BoundsHelper
	{
		private const float MAX_VALUE = 100_000f;
		private const float MIN_VALUE = -100_000f;
		private const float VERY_SMALL_VALUE = 0.0001f;

		/// <inheritdoc cref="BoundsHelper" />
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float CorrectCoordinate(float value)
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

		/// <inheritdoc cref="BoundsHelper" />
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

		/// <inheritdoc cref="BoundsHelper" />
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int CorrectToInt32(float correctedFloat)
		{
			if (correctedFloat > int.MaxValue) correctedFloat = int.MaxValue;
			if (correctedFloat < int.MinValue) correctedFloat = int.MinValue;

			return (int)correctedFloat;
		}
	}
}
