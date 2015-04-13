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
    public class Rectangle : Element
    {
        public Rectangle(params IGesture[] gestures)
            : this((IList<IGesture>)gestures.ToList())
        { }

        public Rectangle(IList<IGesture> gestures)
            : base(gestures)
        { }

        public override float X { get; set; }
        public override float Y { get; set; }
        public override float Width { get; set; }
        public override float Height { get; set; }

        private BackStyle _backStyle = new BackStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public BackStyle BackStyle
        {
            [DebuggerHidden]
            get { return _backStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _backStyle = value;
            }
        }

        private LineStyle _topLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle TopLineStyle
        {
            [DebuggerHidden]
            get { return _topLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _topLineStyle = value;
            }
        }

        private LineStyle _rightLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle RightLineStyle
        {
            [DebuggerHidden]
            get { return _rightLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _rightLineStyle = value;
            }
        }

        private LineStyle _bottomLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle BottomLineStyle
        {
            [DebuggerHidden]
            get { return _bottomLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _bottomLineStyle = value;
            }
        }

        private LineStyle _leftLineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle LeftLineStyle
        {
            [DebuggerHidden]
            get { return _leftLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _leftLineStyle = value;
            }
        }

        /// <summary>
        /// Sets the style of all 4 lines at the same time.
        /// Returns a single LineStyle in case all border lines have the same style.
        /// Otherwise returns null.
        /// </summary>
        public LineStyle LineStyle
        {
            get
            {
                if (TopLineStyle == RightLineStyle &&
                    RightLineStyle == BottomLineStyle &&
                    BottomLineStyle == LeftLineStyle)
                {
                    return TopLineStyle;
                }

                return null;
            }
            set
            {
                TopLineStyle = value;
                RightLineStyle = value;
                BottomLineStyle = value;
                LeftLineStyle = value;
            }
        }

        private string DebuggerDisplay
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(String.Format("{{{0}}} X={1}, Y={2}, Width={3}, Height={4} ", GetType().Name, X, Y, Width, Height));

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
