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
    /// <summary>
    /// Represents a curved line going from one point to the next,
    /// going into the direction of two other control points.
    /// </summary>
    public class Curve : Element
    {
        public Curve(params IGesture[] gestures)
            : this((IList<IGesture>)gestures.ToList())
        { }

        public Curve(IList<IGesture> gestures)
            : base(gestures)
        { }

        private int _lineCount = 20;
        /// <summary>
        /// Default is 20. Cannot be less than 1.
        /// The curve is drawn out as a sequence of straight lines.
        /// The line count controls the precision with which the curve is drawn.
        /// </summary>
        public int LineCount 
        { 
            get { return _lineCount; }
            set
            {
                if (value < 1) throw new LessThanException(() => value, 1);
                _lineCount = value;
            }
        }

        private Point _pointA = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the Point are related to the Point's parent.
        /// </summary>
        public Point PointA
        {
            [DebuggerHidden]
            get { return _pointA; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _pointA = value;
            }
        }

        private Point _controlPointA = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the Point are related to the Point's parent.
        /// </summary>
        public Point ControlPointA
        {
            [DebuggerHidden]
            get { return _controlPointA; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _controlPointA = value;
            }
        }

        private Point _pointB = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the Point are related to the Point's parent.
        /// </summary>
        public Point PointB
        {
            [DebuggerHidden]
            get { return _pointB; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _pointB = value;
            }
        }

        private Point _controlPointB = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the Point are related to the Point's parent.
        /// </summary>
        public Point ControlPointB
        {
            [DebuggerHidden]
            get { return _controlPointB; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _controlPointB = value;
            }
        }

        private LineStyle _lineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle LineStyle
        {
            [DebuggerHidden]
            get { return _lineStyle; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _lineStyle = value;
            }
        }

        public override float X
        {
            get { return Math.Min(_pointA.X, _pointB.X); }
            set
            {
                float dx = _pointB.X - _pointA.X;
                _pointA.X = value;
                _pointB.X = _pointA.X + dx;
            }
        }

        public override float Y
        {
            get { return Math.Min(_pointA.Y, _pointB.Y); }
            set
            {
                float dy = _pointB.Y - _pointA.Y;
                _pointA.Y = value;
                _pointB.Y = _pointA.Y + dy;
            }
        }

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

        private IList<Line> _calculatedLines = new List<Line>();
        /// <summary>
        /// Not nullable. Auto-instantiated.
        /// </summary>
        public IList<Line> CalculatedLines
        {
            [DebuggerHidden]
            get { return _calculatedLines; }
            internal set 
            {
                if (value == null) throw new NullException(() => value);
                _calculatedLines = value;
            }
        }
    }
}
