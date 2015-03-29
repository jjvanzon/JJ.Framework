using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Label : Element
    {
        private string DebuggerDisplay
        {
            get
            {
                return String.Format("{{{0}}} '{1}', X={2}, Y={3} (HashCode={4})", GetType().Name, Text, X, Y, GetHashCode());
            }
        }

        public Label()
        { }

        public string Text { get; set; }

        private TextStyle _textStyle = new TextStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public TextStyle TextStyle
        {
            get { return _textStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _textStyle = value;
            }
        }

        public override float X { get; set; }
        public override float Y { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }
    }
}
