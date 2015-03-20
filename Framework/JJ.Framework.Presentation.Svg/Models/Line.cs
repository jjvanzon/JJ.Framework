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

        public override float CenterX
        {
            get { return (_pointA.X + _pointB.X) / 2; }
        }

        public override float CenterY
        {
            get { return (_pointA.Y + _pointB.Y) / 2; }
        }
    }
}
