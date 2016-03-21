using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Line : Element
    {
        public Line()
        {
            _position = new LinePosition(this);
        }

        private ElementPosition _position;
        public override ElementPosition Position
        {
            get { return _position; }
        }

        private Point _pointA = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the point are related to the Point's parent.
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

        private Point _pointB = new Point();
        /// <summary>
        /// Not nullable, auto-instantiated.
        /// Coordinates of the point are related to the Point's parent.
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

        private string DebuggerDisplay
        {
            get { return DebugHelper.GetDebuggerDisplay(this); }
        }
    }
}
