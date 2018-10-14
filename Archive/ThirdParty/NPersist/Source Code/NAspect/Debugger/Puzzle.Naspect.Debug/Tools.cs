using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Puzzle.NAspect.Debug
{
    class Tools
    {
        public static Color MixColors(Color c1, Color c2)
        {
            Color mix = Color.FromArgb((c2.R + c1.R) / 2, (c2.G + c1.G) / 2, (c2.B + c1.B) / 2);
            return mix;
        }
    }
}
