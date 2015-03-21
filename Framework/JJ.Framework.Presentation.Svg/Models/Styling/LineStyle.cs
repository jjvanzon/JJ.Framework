using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Styling
{
    public class LineStyle
    {
        public LineStyle()
        {
            Visible = true;
            Width = 1;
            DashStyleEnum = DashStyleEnum.Solid;
            Color = ColorHelper.Black;
        }

        public bool Visible { get; set; }
        public float Width { get; set; }
        public int Color { get; set; }
        public DashStyleEnum DashStyleEnum { get; set; }
    }
}
