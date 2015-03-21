using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Helpers
{
    internal static class ColorHelper
    {
        static ColorHelper()
        {
            Black = unchecked((int)0xFF000000);
            White = unchecked((int)0xFFFFFFFF);
        }

        public static int Black { get; private set; }
        public static int White { get; private set; }

        //public static int GetColor(int red, int green, int blue)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
