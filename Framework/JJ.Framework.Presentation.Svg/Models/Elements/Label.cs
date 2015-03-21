using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class Label : ElementBase
    {
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

        private TextStyle _textStyle = new TextStyle();
        public TextStyle TextStyle
        {
            get { return _textStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _textStyle = value;
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
