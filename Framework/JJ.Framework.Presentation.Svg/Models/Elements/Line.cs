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
    public class Line : Element
    {
        private string DebuggerDisplay
        {
            get
            {
                return String.Format("{{{0}}} ({1}, {2}) - ({3}, {4}) (HashCode={5})", GetType().Name, PointA.X, PointA.Y, PointB.X, PointB.Y, GetHashCode());
            }
        }

        public Line()
        { }

        private Point _pointA = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the point are related to the Label's parent.
        /// </summary>
        public Point PointA
        {
            get { return _pointA; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _pointA = value;
            }
        }

        private Point _pointB = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the point are related to the Label's parent.
        /// </summary>
        public Point PointB
        {
            get { return _pointB; }
            set
            {
                if (value == null) throw new NullException(() => value);
                _pointB = value;
            }
        }

        private LineStyle _lineStyle = new LineStyle();
        /// <summary> not nullable, auto-instantiated </summary>
        public LineStyle LineStyle
        {
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
    }
}
