using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Svg.Models
{
    public class Line : ElementBase
    {
        private Point _pointA = new Point();
        /// <summary>
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
    }
}
