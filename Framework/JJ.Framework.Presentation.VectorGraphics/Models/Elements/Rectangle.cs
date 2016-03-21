using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Rectangle : Element
    {
        public Rectangle()
        {
            _position = new RectanglePosition(this);
        }

        private ElementPosition _position;
        public override ElementPosition Position
        {
            get { return _position; }
        }

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
            get { return DebugHelper.GetDebuggerDisplay(this); }
        }
    }
}
