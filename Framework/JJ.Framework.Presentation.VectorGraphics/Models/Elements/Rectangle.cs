using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Rectangle : Element
    {
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

                sb.Append(String.Format("{{{0}}} ", GetType().Name));

                string tag = Convert.ToString(Tag);
                if (!String.IsNullOrEmpty(tag))
                {
                    sb.Append(String.Format("Tag='{0}', ", Tag));
                }

                sb.Append(String.Format("X={0}, Y={1}, Width={2}, Height={3} ", X, Y, Width, Height));
                sb.Append(String.Format("(HashCode={0})", GetHashCode()));

                return sb.ToString();
            }
        }
    }
}
