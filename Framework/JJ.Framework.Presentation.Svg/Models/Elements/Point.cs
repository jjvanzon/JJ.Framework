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
    public class Point : Element
    {
        public Point(params IGesture[] gestures)
            : this((IList<IGesture>)gestures.ToList())
        { }

        public Point(IList<IGesture> gestures)
            : base(gestures)
        { }

        public override float X { get; set; }
        public override float Y { get; set; }

        public override float Width
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        public override float Height
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        private PointStyle _pointStyle = new PointStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public PointStyle PointStyle
        {
            get { return _pointStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _pointStyle = value;
            }
        }

        private string DebuggerDisplay
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(String.Format("{{{0}}} ({1}, {2}) ", GetType().Name, X, Y));

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