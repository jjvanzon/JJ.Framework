using JJ.Framework.Exceptions.Comparative;

namespace JJ.Framework.VectorGraphics.Helpers
{
	public static class ColorHelper
	{
		public static int Black { get; } = GetColor(0, 0, 0);
		public static int White { get; } = GetColor(255, 255, 255);

		public static int GetColor(uint unsignedInteger)
		{
			int color = unchecked((int)unsignedInteger);
			return color;
		}

		public static int GetColor(int red, int green, int blue)
		{
			int color = GetColor(255, red, green, blue);
			return color;
		}

		public static int GetColor(int opacity, int red, int green, int blue)
		{
			if (opacity < 0) throw new LessThanException(() => opacity, 0);
			if (opacity > 255) throw new GreaterThanException(() => opacity, 255);
			if (red < 0) throw new LessThanException(() => red, 0);
			if (red > 255) throw new GreaterThanException(() => red, 255);
			if (green < 0) throw new LessThanException(() => green, 0);
			if (green > 255) throw new GreaterThanException(() => green, 255);
			if (blue < 0) throw new LessThanException(() => blue, 0);
			if (blue > 255) throw new GreaterThanException(() => blue, 255);

			int color = 0;
			color |= opacity;

			color = color << 8;
			color |= red;

			color = color << 8;
			color |= green;

			color = color << 8;
			color |= blue;

			return color;
		}

		/// <summary>
		/// Red, green and blue components will be bound to a max of 255.
		/// Once one of the components maxes out brightness will not go any further up.
		/// </summary>
		/// <param name="grade">0 makes it black, 1 keeps it the same color.</param>
		public static int SetBrightness(int color, double grade)
		{
			int a = GetOpacity(color);
			int r = GetRed(color);
			int g = GetGreen(color);
			int b = GetBlue(color);

			r = (int)(r * grade);
			g = (int)(g * grade);
			b = (int)(b * grade);

			int max = r;
			if (max < g) max = g;
			if (max < b) max = b;

			if (max > 255)
			{
				// TODO: Low priority: This does not look like great performance anymore.
				float ratio = 255f / max;
				r = (int)(r * ratio);
				g = (int)(g * ratio);
				b = (int)(b * ratio);

				// Fix the odd rounding error.
				if (r > 255) r = 255;
				if (g > 255) g = 255;
				if (b > 255) b = 255;
			}

			return GetColor(a, r, g, b);
		}

		public static int GetOpacity(int color)
		{
			int value = color >> 24; // Move opacity to the right
			value = value & 0x000000FF; // NOTE: We use a mask, because a left shift with 1 in the left most bit (sign bit) makes the bit shift fill it up with 1's, not 0's.
			return value;
		}

		public static int GetRed(int color)
		{
			int value = color >> 16; // Move red to the right.
			value = value & 0x000000FF; // NOTE: We use a mask, because a left shift with 1 in the left most bit (sign bit) makes the bit shift fill it up with 1's, not 0's.
			return value;
		}

		public static int GetGreen(int color)
		{
			int value = color >> 8; // Move green to the right.
			value = value & 0x000000FF; // NOTE: We use a mask, because a left shift with 1 in the left most bit (sign bit) makes the bit shift fill it up with 1's, not 0's.
			return value;
		}

		public static int GetBlue(int color)
		{
			int value = color; // Blue is already at the right.
			value = value & 0x000000FF; // NOTE: We use a mask, because a left shift with 1 in the left most bit (sign bit) makes the bit shift fill it up with 1's, not 0's.
			return value;
		}

		public static int SetOpacity(int originalColor, int newOpacity)
		{
			if (newOpacity < 0) throw new LessThanException(() => newOpacity, 0);
			if (newOpacity > 255) throw new GreaterThanException(() => newOpacity, 255);

			int r = GetRed(originalColor);
			int g = GetGreen(originalColor);
			int b = GetBlue(originalColor);

			int newColor = GetColor(newOpacity, r, g, b);
			
			return newColor;
		}
	}
}
