using JJ.Framework.Presentation.Svg.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Styling
{
    public class BackStyle
    {
        public BackStyle()
        {
            Visible = true;
            Color = ColorHelper.White;
        }

        public bool Visible { get; set; }
        public int Color { get; set; }
    }
}
