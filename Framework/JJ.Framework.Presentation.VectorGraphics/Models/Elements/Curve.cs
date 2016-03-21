using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary>
    /// Represents a curved line going from one point to the next,
    /// going into the direction of two other control points.
    /// </summary>
    public class Curve : Element
    {
        public Curve()
        {
            _position = new CurvePosition(this);
        }

        private int _segmentCount = 20;

        /// <summary>
        /// Default is 20. Cannot be less than 1.
        /// The curve is drawn out as a sequence of straight lines.
        /// The line count controls the precision with which the curve is drawn.
        /// </summary>
        public int SegmentCount 
        {
            [DebuggerHidden]
            get { return _segmentCount; }
            set
            {
                if (value < 1) throw new LessThanException(() => value, 1);
                _segmentCount = value;
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

        private ElementPosition _position;
        public override ElementPosition Position
        {
            [DebuggerHidden]
            get { return _position; }
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
