using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Exceptions;
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
            Position = new CurvePosition(this);
        }

        private int _segmentCount = 20;

        /// <summary>
        /// Default is 20. Cannot be less than 1.
        /// The curve is drawn out as a sequence of straight lines.
        /// The segment count controls the precision with which the curve is drawn.
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

        /// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
        public Point PointA { get; set; }

        /// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
        public Point PointB { get; set; }

        /// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
        public Point ControlPointA { get; set; }

        /// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
        public Point ControlPointB { get; set; }

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

        public override ElementPosition Position { get; }

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
