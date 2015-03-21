using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public static class SvgHelper
    {
        static SvgHelper()
        {
            DefaultLineStyle = new LineStyle
            {
                Width = 2
            };

            DefaultTextStyle = new TextStyle
            {
                HorizontalAlignmentEnum = HorizontalAlignmentEnum.Center,
                VerticalAlignmentEnum = VerticalAlignmentEnum.Center
            };
            DefaultTextStyle.Font.Bold = true;
            DefaultTextStyle.Font.Name = "Verdana";
            DefaultTextStyle.Font.Size = 13;
        }

        public static LineStyle DefaultLineStyle { get; private set; }
        public static TextStyle DefaultTextStyle { get; private set; }
    }
}
