using System;

namespace JJ.Framework.Presentation.Svg.Helpers
{
    public static class ColorHelper
    {
        static ColorHelper()
        {
            Black = GetColor(0, 0, 0);
            White = GetColor(255, 255, 255);
        }

        public static int Black { get; private set; }
        public static int White { get; private set; }

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

        public static int GetColor(int alpha, int red, int green, int blue)
        {
            if (alpha < 0) throw new Exception("alpha cannot be less than 0");
            if (alpha > 255) throw new Exception("alpha cannot be greater than 255");
            if (red < 0) throw new Exception("red cannot be less than 0");
            if (red > 255) throw new Exception("red cannot be greater than 255");
            if (green < 0) throw new Exception("green cannot be less than 0");
            if (green > 255) throw new Exception("green cannot be greater than 255");
            if (blue < 0) throw new Exception("blue cannot be less than 0");
            if (blue > 255) throw new Exception("blue cannot be greater than 255");

            int color = 0;
            color |= alpha;

            color = color << 8;
            color |= red;

            color = color << 8;
            color |= green;

            color = color << 8;
            color |= blue;

            return color;
        }
    }
}
