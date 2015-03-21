using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Svg.Models
{
    public class Label : ElementBase
    {
        public HorizontalAlignmentEnum HorizontalAlignment { get; set; }
        public VerticalAlignmentEnum VerticalAlignment { get; set; }
        public string Text { get; set; }

        private Rectangle _rectangle = new Rectangle();
        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _rectangle = value;
            }
        }

        private Font _font = new Font();
        public Font Font
        {
            get { return _font; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _font = value;
            }
        }

        public override float X
        {
            get { return _rectangle.X; }
            set { _rectangle.X = value; }
        }

        public override float Y
        {
            get { return _rectangle.Y; }
            set { _rectangle.Y = value; }
        }
    }
}
