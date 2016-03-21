using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class CurvePosition : ElementPosition
    {
        private Curve _curve;

        internal CurvePosition(Curve curve)
            : base(curve)
        {
            _curve = curve;
        }

        public override float X
        {
            get { return Math.Min(_curve.PointA.Position.X, _curve.PointB.Position.X); }
            set
            {
                float dx = _curve.PointB.Position.X - _curve.PointA.Position.X;
                _curve.PointA.Position.X = value;
                _curve.PointB.Position.X = _curve.PointA.Position.X + dx;
            }
        }

        public override float Y
        {
            get { return Math.Min(_curve.PointA.Position.Y, _curve.PointB.Position.Y); }
            set
            {
                float dy = _curve.PointB.Position.Y - _curve.PointA.Position.Y;
                _curve.PointA.Position.Y = value;
                _curve.PointB.Position.Y = _curve.PointA.Position.Y + dy;
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
