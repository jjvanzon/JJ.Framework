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
            : this((IList<IGesture>)gestures)
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
            get { return _leftLineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _leftLineStyle = value;
            }
        }

        // TODO: Syntactically the SetLineStyle is ugly now, because you can initialize most things with an object initializer,
        // except for the line style. So maybe you should make it a magic property.

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
                return String.Format("{{{0}}} X={1}, Y={2}, Width={3}, Height={4} (HashCode={5})", GetType().Name, X, Y, Width, Height, GetHashCode());
            }
        }
    }
}
