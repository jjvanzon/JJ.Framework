using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Exceptions;
using System.Diagnostics;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Styling
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
        /// <summary> not nullable, auto-instantiated </summary>
        public Font Font
        {
            [DebuggerHidden]
            get { return _font; }
            set
            {
                _font = value ?? throw new NullException(() => value);
            }
        }
    }
}
