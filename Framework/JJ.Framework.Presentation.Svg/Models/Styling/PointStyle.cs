using JJ.Framework.Presentation.Svg.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Styling
{
    public class PointStyle
    {
        public PointStyle()
        {
            Visible = true;
            Width = 2;
            Color = ColorHelper.Black;
        }

        public bool Visible { get; set; }
        public int Color { get; set; }
        public float Width { get; set; }
    }
}
