using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
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
        public Label(params IGesture[] gestures)
            : this((IList<IGesture>)gestures.ToList())
        { }

        public Label(IList<IGesture> gestures)
            : base(gestures)
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

        public override float Width { get; set; }
        public override float Height { get; set; }

        private string DebuggerDisplay
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(String.Format("{{{0}}} '{1}', X={2}, Y={3} ", GetType().Name, Text, X, Y));

                string tag = Convert.ToString(Tag);
                if (!String.IsNullOrEmpty(tag))
                {
                    sb.Append("Tag='");
                    sb.Append(Tag);
                    sb.Append("' ");
                }

                sb.Append(String.Format("(HashCode={0})", GetHashCode()));
                return sb.ToString();
            }
        }
    }
}
