using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Helpers;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Styling
{
    public class TextStyle
    {
        public TextStyle()
        {
            Abbreviate = true;
            HorizontalAlignmentEnum = HorizontalAlignmentEnum.Left;
            VerticalAlignmentEnum = VerticalAlignmentEnum.Top;
            Color = ColorHelper.Black;
        }

        public int Color { get; set; }
        public bool Abbreviate { get; set; }
        public bool Wrap { get; set; }
        public HorizontalAlignmentEnum HorizontalAlignmentEnum { get; set; }
        public VerticalAlignmentEnum VerticalAlignmentEnum { get; set; }

        private Font _font = new Font();
        /// <summary>
        /// not nullable, auto-instantiated
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _font = value;
            }
        }
    }
}
